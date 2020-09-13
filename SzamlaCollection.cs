using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamlakezeles
{
   public  class SzamlaCollection :Collection
    {
        public List<Szamla> SzamlaList { get; set; }

        public SzamlaCollection(string path) : base(path)
        {
            SzamlaList = new List<Szamla>();

            int i = 1;
            while (Excelloader.ReadCell(i, 0) != null)
            {
                int j = 0;
                string[] values = new string[24];
                string cellvalue;
                do
                {
                    cellvalue = Excelloader.ReadCell(i, j);
                    values[j] = cellvalue;
                    j++;
                } while (j != 24);
                SzamlaList.Add(new Szamla(values));
                i++;
            }
            Excelloader.Close();
        }
    }
}
