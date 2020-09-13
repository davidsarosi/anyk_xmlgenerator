using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Szamlakezeles
{
    public class Manager : IMerge
    {
        public nyomtatvanyok nyomtatvanyok;
        public string Tol { get; set; }
        public string Ig { get; set; }

        public nyomtatvanyok Beolvas(string path)
        {
            XmlSerializer ser = new XmlSerializer(typeof(nyomtatvanyok));
            using (XmlReader reader = XmlReader.Create(path))
            {
                nyomtatvanyok = (nyomtatvanyok) ser.Deserialize(reader);
            }

            return nyomtatvanyok;
        }

        private List<nyomtatvany> createNyomtatvanyList(List<Szamla> szamla)
        {
            List<nyomtatvany> nyomtatvanyList = new List<nyomtatvany>();

            Dictionary<string, List<Szamla>> groups = new Dictionary<string, List<Szamla>>();

            foreach (var sz in szamla)
            {
                if (groups.ContainsKey(sz.elado_adoszama_torzsszam))
                {
                    groups[sz.elado_adoszama_torzsszam].Add(sz);
                }
                else
                {
                    List<Szamla> temp = new List<Szamla>();
                    temp.Add(sz);
                    groups.Add(sz.elado_adoszama_torzsszam, temp);
                }
            }

            List<List<Szamla>> groupedszamlak = groups.Values.ToList();
            var eredetiny = nyomtatvanyok.nyomtatvany[0];
            foreach (var szamlalist in groupedszamlak)
            {
                Szamla sz = szamlalist[0];
                nyomtatvany dummy = null;

                foreach (var nyomtatvany in nyomtatvanyok.nyomtatvany)
                {
                    if(nyomtatvany.nyomtatvanyinformacio.nyomtatvanyazonosito.Equals("2065A"))
                        continue;
                    if (nyomtatvany.nyomtatvanyinformacio.albizonylatazonositas.azonosito.Equals(
                        sz.elado_adoszama_torzsszam))
                        dummy = nyomtatvany;
                }

                int dynamic_page_counter;
                int current_row;
                nyomtatvany ny=new nyomtatvany();
                int kezdes;
                if (dummy != null)
                {
                    int pages = ((dummy.mezok.Length - 7) / 4)/36;   //TODO rounding
                    dynamic_page_counter = pages;
                    kezdes = ((dummy.mezok.Length - 7) / 4);
                    int newSize = (dummy.mezok.Length + (szamlalist.Count * 4));
                   ny.mezok = new mezo[newSize];
                    for (int i = 0; i < dummy.mezok.Length; i++)
                    {
                        ny.mezok[i] = dummy.mezok[i];
                    }

                    for (int i = dummy.mezok.Length; i < ny.mezok.Length; i++)
                    {
                        ny.mezok[i]=new mezo();
                    }
                    
                    dummy.mezok = ny.mezok;
                    ny = dummy;
                }
                else
                {
                    dynamic_page_counter = 0;
                    kezdes = 0;


                    ny.nyomtatvanyinformacio = new nyomtatvanyinformacio();
                    ny.nyomtatvanyinformacio.adozo = new adozo();
                    ny.nyomtatvanyinformacio.albizonylatazonositas = new albizonylatazonositas();
                    ny.nyomtatvanyinformacio.idoszak = new idoszak();
                    ny.mezok = new mezo[7 + (szamlalist.Count * 4)];
                    for (int i = 0; i < (7 + szamlalist.Count * 4); i++)
                    {
                        ny.mezok[i] = new mezo();
                    }


                    ny.mezok[0].eazon = "0A0001C001A";
                    ny.mezok[0].Value = eredetiny.nyomtatvanyinformacio.adozo.adoszam;

                    ny.nyomtatvanyinformacio.adozo = eredetiny.nyomtatvanyinformacio.adozo;
                    ny.nyomtatvanyinformacio.nyomtatvanyazonosito = "2065M";
                    ny.nyomtatvanyinformacio.albizonylatazonositas.azonosito = sz.elado_adoszama_torzsszam;
                    ny.nyomtatvanyinformacio.albizonylatazonositas.megnevezes = sz.elado_neve;

                    ny.mezok[1].eazon = "0A0001C005A";
                    ny.mezok[1].Value = eredetiny.nyomtatvanyinformacio.adozo.nev;

                    ny.mezok[2].eazon = "0A0001C006A";
                    ny.mezok[2].Value = sz.elado_adoszama_torzsszam;

                    ny.mezok[3].eazon = "0A0001C007A";
                    ny.mezok[3].Value = "";

                    ny.mezok[4].eazon = "0A0001C008A";
                    ny.mezok[4].Value = sz.elado_neve;

                    DateTime d = DateTime.Parse(sz.szamla_kelte);
                    DateTime tol = Convert.ToDateTime(Tol);
                    DateTime ig = Convert.ToDateTime(Ig);

                    ny.mezok[5].eazon = "0A0001D001A";
                    ny.mezok[5].Value = tol.ToString("yyyyMMdd");
                    ny.nyomtatvanyinformacio.idoszak.tol = ny.mezok[5].Value;

                    ny.mezok[6].eazon = "0A0001D002A";
                    ny.mezok[6].Value = ig.ToString("yyyyMMdd");
                    ny.nyomtatvanyinformacio.idoszak.ig = ny.mezok[6].Value;
                }
                
                int current_szamla_index = 0;
                int offset;
                
                for (int i = 0; i < szamlalist.Count; i++)
                {
                    if (i % 37==0)
                    {
                        dynamic_page_counter++;
                    }

                    offset = (kezdes + kezdes * 3);
                    current_row = (kezdes % 36)+1;
                    ny.mezok[7 + offset].eazon = "0B" + dynamic_page_counter.ToString("D4") + "C" +
                                                 (current_row).ToString("D4") + "AA";
                    ny.mezok[7 + offset].Value = szamlalist[current_szamla_index].szamla_sorszama;

                    ny.mezok[8 + offset].eazon = "0B" + dynamic_page_counter.ToString("D4") + "C" +
                                                 (current_row).ToString("D4") + "BA";
                    ny.mezok[8 + offset].Value =
                        (Convert.ToDateTime(szamlalist[current_szamla_index].teljesites_datuma)).ToString("yyyyMMdd");

                    ny.mezok[9 + offset].eazon = "0B" + dynamic_page_counter.ToString("D4") + "C" +
                                                 (current_row).ToString("D4") + "CA";
                    ny.mezok[9 + offset].Value = Math.Round(szamlalist[current_szamla_index].szamla_netto_osszege_forintban/1000.0).ToString("F0");

                    ny.mezok[10 + offset].eazon = "0B" + dynamic_page_counter.ToString("D4") + "C" +
                                                  (current_row).ToString("D4") + "DA";
                    ny.mezok[10 + offset].Value = Math.Round(szamlalist[current_szamla_index].szamla_afa_osszege_forintban/1000.0).ToString("F0");

                    current_szamla_index++;
                    kezdes++;
                }

                // ny.mezok[7].eazon = "0B0001C0001AA";
                // ny.mezok[7].Value = sz.eredeti_szamla_szama;
                //
                // ny.mezok[8].eazon = "0B0001C0001BA";
                // ny.mezok[8].Value = (Convert.ToDateTime(sz.teljesites_datuma)).ToString("yyyyMMdd");
                //
                // ny.mezok[9].eazon = "0B0001C0001CA";
                // ny.mezok[9].Value = sz.szamla_netto_osszege_forintban;
                //
                // ny.mezok[10].eazon = "0B0001C0001DA";
                // ny.mezok[10].Value = sz.szamla_afa_osszege_forintban;

                nyomtatvanyList.Add(ny);
            }
            return nyomtatvanyList;
        }

        public void Osszefuz(nyomtatvanyok dokumentum, List<Szamla> szamla)
        {
            nyomtatvanyok tempnyomtatvanyok = new nyomtatvanyok();
            tempnyomtatvanyok.nyomtatvany = new nyomtatvany[1];


            var temp = createNyomtatvanyList(szamla);// összefűzés megfordítás
            var tempOriginal = dokumentum.nyomtatvany.ToList();
            foreach (var nyomtatvany in temp)
            {
                tempOriginal.Add(nyomtatvany);
            }

            nyomtatvanyok.nyomtatvany = tempOriginal.ToArray();
        }

        public void Export(nyomtatvanyok dokumentum,string path)
        {
            dokumentum.abev=new abev();
            dokumentum.abev.hibakszama = 0;
            dokumentum.abev.hash = dokumentum.GetHashCode().ToString();
          
            
            XmlSerializer xs = new XmlSerializer(typeof(nyomtatvanyok));

            TextWriter txtWriter = new StreamWriter(path);

            xs.Serialize(txtWriter, dokumentum);

            txtWriter.Close();
        }
    }
}