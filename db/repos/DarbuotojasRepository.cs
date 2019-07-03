using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using db.Models;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace db.repos
{
    public class DarbuotojasRepository
    {
        public List<pardavejas> getDarbuotojai()
        {
            List<pardavejas> darbuotojai = new List<pardavejas>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "darbuotojai";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                darbuotojai.Add(new pardavejas
                {
                    tabelioNumeris = Convert.ToInt32(item["TabelioNumeris"]),
                    darboSutartiesNr = Convert.ToInt32(item["DarboSutartiesNr"]),
                    vardas = Convert.ToString(item["Vardas"]),
                    pavarde = Convert.ToString(item["Pavarde"])
                });
            }

            return darbuotojai;
        }

        public pardavejas getDarbuotojas(int filialas)
        {
            pardavejas darbuotojas = new pardavejas();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "darbuotojai where tabelio_nr=?tab";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?tab", MySqlDbType.VarChar).Value = filialas;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                darbuotojas.tabelioNumeris = Convert.ToInt32(item["TabelioNumeris"]);
                darbuotojas.darboSutartiesNr = Convert.ToInt32(item["DarboSutartiesNr"]);
                darbuotojas.vardas = Convert.ToString(item["Vardas"]);
                darbuotojas.pavarde = Convert.ToString(item["Pavarde"]);
            }

            return darbuotojas;
        }

        public bool updateDarbuotojas(pardavejas darbuotojas)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"UPDATE " + Globals.dbPrefix + "darbuotojai a SET a.vardas=?vardas, a.pavarde=?pavarde, a.darboSutartiesNr=?darbSut WHERE a.tabelioNumeris=?tab";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = darbuotojas.vardas;
                mySqlCommand.Parameters.Add("?pavarde", MySqlDbType.VarChar).Value = darbuotojas.pavarde;
                mySqlCommand.Parameters.Add("?tab", MySqlDbType.VarChar).Value = darbuotojas.tabelioNumeris;
                mySqlCommand.Parameters.Add("?darbSut", MySqlDbType.VarChar).Value = darbuotojas.darboSutartiesNr;
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

        public bool addDarbuotojas(pardavejas darbuotojas)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"INSERT INTO " + Globals.dbPrefix + "darbuotojai(tabelioNumeris,vardas,pavarde,darboSutartiesNr)VALUES(?tabelioNumeris,?vardas,?pavarde,?darbSut);";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = darbuotojas.vardas;
                mySqlCommand.Parameters.Add("?pavarde", MySqlDbType.VarChar).Value = darbuotojas.pavarde;
                mySqlCommand.Parameters.Add("?tabelioNumeris", MySqlDbType.VarChar).Value = darbuotojas.tabelioNumeris;
                mySqlCommand.Parameters.Add("?darbSut", MySqlDbType.VarChar).Value = darbuotojas.darboSutartiesNr;
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

        public int getDarbuotojasSutarciuCount(int id)
        {
            int naudota = 0;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT count(nr) as kiekis from " + Globals.dbPrefix + "sutartys where fk_pardavejas= '" + id + "'";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                naudota = Convert.ToInt32(item["kiekis"] == DBNull.Value ? 0 : item["kiekis"]);
            }
            return naudota;
        }

        public void deleteDarbuotojas(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM " + Globals.dbPrefix + "darbuotojai where tabelioNumeris=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}