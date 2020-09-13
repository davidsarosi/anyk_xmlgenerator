using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamlakezeles
{
    public interface IMerge
    {
        /// <summary>
        /// A megadott elérési útvonalból felolvassa az XML dokumentumot és létrehoz egy nyomtatvány típust
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        nyomtatvanyok Beolvas(string path);
        /// <summary>
        /// A felolvasott excel sorokat hozzáfűzi a betöltött XML dokumentumhoz
        /// </summary>
        /// <param name="dokumentum"></param>
        /// <param name="szamla"></param>
        void Osszefuz(nyomtatvanyok dokumentum, List<Szamla> szamla);

        /// <summary>
        /// Az elkészített dokumentumot elmenti egy megadott helyre
        /// </summary>
        /// <param name="dokumentum"></param>
        /// <param name="path"></param>
        void Export(nyomtatvanyok dokumentum, string path);
    }
}
