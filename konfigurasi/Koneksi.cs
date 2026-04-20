using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SIRaM.konfigurasi
{
    internal class Koneksi : Konfigurasi
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        string Link = "server=localhost;port=3306;database=db_siram;uid=root;pwd=";
        public Koneksi()
        {
            conn = new MySqlConnection(Link);
            cmd = new MySqlCommand();
            adapter = new MySqlDataAdapter();
        }

        private void bukaKoneksi()
        {
            try
            {
                if(conn.State==ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex) { }
        }

        public void tutupKoneksi()
        {
            conn.Close();
        }

        public override int eksekusiBukanQuery(string query)
        {
            int nilai = -1;

            try
            {
                bukaKoneksi();
                cmd.Connection=conn;
                cmd .CommandText=query;
                nilai=cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { tutupKoneksi(); }

            return nilai;
        }

        public override DataTable eksekusiQuery(string query)
        {
            DataTable nilai = new DataTable();

            try
            {
                bukaKoneksi();
                cmd.Connection = conn;
                cmd.CommandText = query;
                adapter.SelectCommand = cmd;
                adapter.Fill(nilai);
            }
            catch (Exception ex) { }
            finally { tutupKoneksi(); }

            return nilai;
        }
    }
}
