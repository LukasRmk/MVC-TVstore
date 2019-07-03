using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using db.ViewModels;
using MySql.Data.MySqlClient;
namespace db.repos
{
    public class ModelisRepository
    {
        public List<ModeliaiViewModel> getModeliai()
        {
            List<ModeliaiViewModel> modelisViewModels = new List<ModeliaiViewModel>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.dydis, m.ekranoTipas, m.pavadimimas, m.id_Modelis, mm.pavadinimas AS gamintojas 
                                FROM modelis m
                                LEFT JOIN gamintojas mm ON mm.id_Gamintojas=m.fk_Gamintojasid_Gamintojas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                modelisViewModels.Add(new ModeliaiViewModel
                {
                    dydis = Convert.ToInt32(item["dydis"]),
                    ekranoTipas = Convert.ToString(item["ekranoTipas"]),
                    pavadinimas = Convert.ToString(item["pavadimimas"]),
                    gamintojas = Convert.ToString(item["gamintojas"]),
                    id_Modelis = Convert.ToInt32(item["id_Modelis"]),
                });
            }

            return modelisViewModels;
        }

        public ModelisEditViewModel getModelis(int id)
        {
            ModelisEditViewModel modelis = new ModelisEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.* 
                                FROM modelis m WHERE m.id_Modelis=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                modelis.dydis = Convert.ToInt32(item["dydis"]);
                modelis.ekranoTipas = Convert.ToString(item["ekranoTipas"]);
                modelis.pavadinimas = Convert.ToString(item["pavadimimas"]);
                modelis.fk_gamintojas = Convert.ToInt32(item["fk_Gamintojasid_Gamintojas"]);
                modelis.id_Modelis = Convert.ToInt32(item["id_Modelis"]);
            }

            return modelis;
        }

        public bool updateModelis(ModelisEditViewModel modelis)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE modelis a SET a.dydis=?dydis, a.ekranoTipas=?ekranoTipas, a.pavadimimas=?pavadimimas, a.id_Modelis=?id_Modelis, a.fk_Gamintojasid_Gamintojas=?fk_Gamintojasid_Gamintojas WHERE a.id_Modelis=?id_Modelis";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?dydis", MySqlDbType.Int32).Value = modelis.dydis;
            mySqlCommand.Parameters.Add("?ekranoTipas", MySqlDbType.VarChar).Value = modelis.ekranoTipas;
            mySqlCommand.Parameters.Add("?pavadimimas", MySqlDbType.VarChar).Value = modelis.pavadinimas;
            mySqlCommand.Parameters.Add("?fk_Gamintojasid_Gamintojas", MySqlDbType.Int32).Value = modelis.fk_gamintojas;
            mySqlCommand.Parameters.Add("?id_Modelis", MySqlDbType.Int32).Value = modelis.id_Modelis;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public bool addModelis(ModelisEditViewModel modelis)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO modelis(dydis,ekranoTipas,pavadimimas,fk_Gamintojasid_Gamintojas,id_Modelis)VALUES(?dydis,?ekranoTipas,?pavadimimas,?fk_Gamintojasid_Gamintojas,?id_Modelis)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?dydis", MySqlDbType.Int32).Value = modelis.dydis;
            mySqlCommand.Parameters.Add("?ekranoTipas", MySqlDbType.VarChar).Value = modelis.ekranoTipas;
            mySqlCommand.Parameters.Add("?pavadimimas", MySqlDbType.VarChar).Value = modelis.pavadinimas;
            mySqlCommand.Parameters.Add("?fk_Gamintojasid_Gamintojas", MySqlDbType.Int32).Value = modelis.fk_gamintojas;
            mySqlCommand.Parameters.Add("?id_Modelis", MySqlDbType.Int32).Value = modelis.id_Modelis;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public int getModelisCount(int id)
        {
            int naudota = 0;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT count(id_Modelis) as kiekis from tvparde where fk_Modelisid_Modelis=" + id;
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

        public void deleteModelis(int id_Modelis)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM modelis where id_Modelis=?id_Modelis";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id_Modelis", MySqlDbType.Int32).Value = id_Modelis;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}