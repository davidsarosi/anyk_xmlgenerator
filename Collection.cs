using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Szamlakezeles
{
    public class Collection
    {
        public ExcelLoader Excelloader
        {
            get; set;
        }
        //A kollekciónak meg lehet adni, hogy melyik excel táblából szedje ki az adatokat
        public Collection(string path)
        {
            Excelloader = new ExcelLoader(path);
        }

        public virtual void Close()
        {
            Excelloader.Close();
        }
        public virtual void AddToDataGrid(System.Windows.Forms.DataGridView dgw, Object o)
        {

        }
        public int GetRowCount()
        {
            return Excelloader.GetRowCount();
        }
    }
}
