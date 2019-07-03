using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using db.Models;
using MySql.Data.MySqlClient;

namespace db.repos
{
    public class gamintojasRepository 
    {
        public List<Gamintojas> getKlientai()
        {
            List<Gamintojas> klientai = new List<Gamintojas>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from gamintojas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                klientai.Add(new Gamintojas
                {
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    id_Gamintojas = Convert.ToInt32(item["id_Gamintojas"]),

                });
            }
            return klientai;
        }

        public bool addKlientas(Gamintojas klientas)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"INSERT INTO gamintojas(pavadinimas, id_Gamintojas)VALUES(?pavadinimas,?id_Gamintojas);";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = klientas.pavadinimas;
                mySqlCommand.Parameters.Add("?id_Gamintojas", MySqlDbType.Int32).Value = klientas.id_Gamintojas;
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updateKlientas(Gamintojas klientas)
        {

            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"UPDATE gamintojas a SET a.pavadinimas=?pavadinimas WHERE a.id_Gamintojas=?id_Gamintojas";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = klientas.pavadinimas;
                mySqlCommand.Parameters.Add("?id_Gamintojas", MySqlDbType.Int32).Value = klientas.id_Gamintojas;
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Gamintojas getKlientas(int id_Gamintojas)
        {
            Gamintojas klientas = new Gamintojas();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from gamintojas where id_Gamintojas=?id_Gamintojas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id_Gamintojas", MySqlDbType.Int32).Value = id_Gamintojas;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                klientas.pavadinimas = Convert.ToString(item["pavadinimas"]);
                klientas.id_Gamintojas = Convert.ToInt32(item["id_Gamintojas"]);
            }
            return klientas;
        }


        public void deleteKlientas(int id_Gamintojas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM gamintojas where id_Gamintojas=?id_Gamintojas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id_Gamintojas", MySqlDbType.Int32).Value = id_Gamintojas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}