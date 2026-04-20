using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SIRaM.konfigurasi
{
    abstract class Konfigurasi
    {
        //untuk menangani instruksi INSERT, UPDATE ,dan DELETE
        //function
        public abstract int eksekusiBukanQuery(string query);

        //untuk menangani proses SELECT
        public abstract DataTable eksekusiQuery(string query);
    }
}
