using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamlakezeles
{
    public class Szamla
    {
        public string szamla_sorszama;
        public string szamla_kelte;
        public string teljesites_datuma;
        public string szamla_penzneme;
        public string alkalmazott_arfolyam;
        public string elado_adoszama_torzsszam;
        public string elado_adoszama_afakod;
        public string elado_adoszama_megyekod;
        public string elado_neve;
        public string elado_cime;
        public string vevo_adoszama_torzsszam;
        public string vevo_adoszama_afakod;
        public string vevo_adoszama_megyekod;
        public string vevo_neve;
        public string vevo_cime;
        public string eredeti_szamla_szama;
        public string modosito_okirat_kelte;
        public string modosito_okirat_sorszama;
        public string szamla_netto_osszege_a_szamla_penznemeben;
        public double szamla_netto_osszege_forintban;
        public string szamla_afa_osszege_a_szamla_penznemeben;
        public double szamla_afa_osszege_forintban;
        public string szamla_brutto_osszege_a_szamla_penznemeben;
        public string szamla_brutto_osszege_forintban;

        /// <summary>
        /// 24 hosszú string tömböt kell megadni a konstruktornak
        /// </summary>
        /// <param name="values"></param>
        //TODO double parser format provider
        public Szamla(string[] values)
        {
            for (int i = 0; i < 24; i++)
            {
                switch (i)
                {
                    case 0:
                        szamla_sorszama = values[i];
                        break;
                    case 1:
                        szamla_kelte = values[i];
                        break;
                    case 2:
                        teljesites_datuma = values[i];
                        break;
                    case 3:
                        szamla_penzneme = values[i];
                        break;
                    case 4:
                        alkalmazott_arfolyam = values[i];
                        break;
                    case 5:
                        elado_adoszama_torzsszam = values[i];
                        break;
                    case 6:
                        elado_adoszama_afakod = values[i];
                        break;
                    case 7:
                        elado_adoszama_megyekod = values[i];
                        break;
                    case 8:
                        elado_neve = values[i];
                        break;
                    case 9:
                        elado_cime = values[i];
                        break;
                    case 10:
                        vevo_adoszama_torzsszam = values[i];
                        break;
                    case 11:
                        vevo_adoszama_afakod = values[i];
                        break;
                    case 12:
                        vevo_adoszama_megyekod = values[i];
                        break;
                    case 13:
                        vevo_neve = values[i];
                        break;
                    case 14:
                        vevo_cime = values[i];
                        break;
                    case 15:
                        eredeti_szamla_szama = values[i];
                        break;
                    case 16:
                        modosito_okirat_kelte = values[i];
                        break;
                    case 17:
                        modosito_okirat_sorszama = values[i];
                        break;
                    case 18:
                        szamla_netto_osszege_a_szamla_penznemeben = values[i];
                        break;
                    case 19:
                        if (values[i].Contains("-"))
                            values[i] = values[i].Replace("-", "0");
                        values[i] = values[i].Replace(",", ".");
                        szamla_netto_osszege_forintban = Double.Parse(values[i],CultureInfo.InvariantCulture);
                        break;
                    case 20:
                        szamla_afa_osszege_a_szamla_penznemeben = values[i];
                        break;
                    case 21:
                        if (values[i].Contains("-"))
                            values[i] =values[i].Replace("-", "0");
                        values[i] = values[i].Replace(",", ".");
                        szamla_afa_osszege_forintban = Double.Parse(values[i],CultureInfo.InvariantCulture);
                        break;
                    case 22:
                        szamla_brutto_osszege_a_szamla_penznemeben = values[i];
                        break;
                    case 23:
                        szamla_brutto_osszege_forintban = values[i];
                        break;
                    default:
                        break;
                }
            }
        }
    }
}