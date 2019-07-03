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
    public class TVRepository
    {
        public List<TVViewModel> getModeliai()
        {
            List<TVViewModel> modelisViewModels = new List<TVViewModel>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.SerN, m.ekranoDaznis, m.rezoliucija, m.imtuvas, m.id_Televizorius, mm.pavadimimas AS modelis
                                FROM televizorius m
                                LEFT JOIN modelis mm ON mm.id_Modelis=m.fk_Modelisid_Modelis";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                modelisViewModels.Add(new TVViewModel
                {
                    SerN = Convert.ToString(item["SerN"]),
                    ekranoDaznis = Convert.ToString(item["ekranoDaznis"]),
                    rezoliucija = Convert.ToString(item["rezoliucija"]),
                    imtuvas = Convert.ToString(item["imtuvas"]),
                    Modelis = Convert.ToString(item["modelis"]),
                    id_Televizorius = Convert.ToInt32(item["id_Televizorius"]),
                });
            }

            return modelisViewModels;
        }

        public TVEditViewModel getModelis(int id)
        {
            TVEditViewModel modelis = new TVEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.* 
                                FROM televizorius m WHERE m.id_Televizorius=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                modelis.SerN = Convert.ToString(item["SerN"]);
                modelis.ekranoDaznis = Convert.ToString(item["ekranoDaznis"]);
                modelis.rezoliucija = Convert.ToString(item["rezoliucija"]);
                modelis.imtuvas = Convert.ToString(item["imtuvas"]);
                modelis.fk_Modelis = Convert.ToInt32(item["fk_Modelisid_Modelis"]);
                modelis.id_Televizorius = Convert.ToInt32(item["id_Televizorius"]);
            }

            return modelis;
        }

        public bool updateModelis(TVEditViewModel modelis)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE televizorius a SET a.SerN=?SerN, a.ekranoDaznis=?ekranoDaznis, a.rezoliucija=?rezoliucija, a.imtuvas=?imtuvas, a.id_Televizorius=?id_Televizorius, a.fk_Modelisid_Modelis=?fk_Modelisid_Modelis WHERE a.id_Televizorius=?id_Televizorius";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?SerN", MySqlDbType.VarChar).Value = modelis.SerN;
            mySqlCommand.Parameters.Add("?ekranoDaznis", MySqlDbType.VarChar).Value = modelis.ekranoDaznis;
            mySqlCommand.Parameters.Add("?rezoliucija", MySqlDbType.VarChar).Value = modelis.rezoliucija;
            mySqlCommand.Parameters.Add("?imtuvas", MySqlDbType.VarChar).Value = modelis.imtuvas;
            mySqlCommand.Parameters.Add("?fk_Modelisid_Modelis", MySqlDbType.Int32).Value = modelis.fk_Modelis;
            mySqlCommand.Parameters.Add("?id_Televizorius", MySqlDbType.Int32).Value = modelis.id_Televizorius;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public bool addModelis(TVEditViewModel modelis)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO televizorius(SerN,ekranoDaznis,rezoliucija,imtuvas,fk_Modelisid_Modelis,id_Televizorius)VALUES(?SerN,?ekranoDaznis,?rezoliucija,?imtuvas,?fk_Modelisid_Modelis,?id_Televizorius)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?SerN", MySqlDbType.VarChar).Value = modelis.SerN;
            mySqlCommand.Parameters.Add("?ekranoDaznis", MySqlDbType.VarChar).Value = modelis.ekranoDaznis;
            mySqlCommand.Parameters.Add("?rezoliucija", MySqlDbType.VarChar).Value = modelis.rezoliucija;
            mySqlCommand.Parameters.Add("?imtuvas", MySqlDbType.VarChar).Value = modelis.imtuvas;
            mySqlCommand.Parameters.Add("?fk_Modelisid_Modelis", MySqlDbType.Int32).Value = modelis.fk_Modelis;
            mySqlCommand.Parameters.Add("?id_Televizorius", MySqlDbType.Int32).Value = modelis.id_Televizorius;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        //public int getModelisCount(int id)
        //{
        //    int naudota = 0;
        //    string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
        //    MySqlConnection mySqlConnection = new MySqlConnection(conn);
        //    string sqlquery = @"SELECT count(id_Modelis) as kiekis from tvparde where fk_Modelisid_Modelis=" + id;
        //    MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
        //    mySqlConnection.Open();
        //    MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
        //    DataTable dt = new DataTable();
        //    mda.Fill(dt);
        //    mySqlConnection.Close();

        //    foreach (DataRow item in dt.Rows)
        //    {
        //        naudota = Convert.ToInt32(item["kiekis"] == DBNull.Value ? 0 : item["kiekis"]);
        //    }
        //    return naudota;
        //}

        public void deleteModelis(int id_Televizorius)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM televizorius where id_Televizorius=?id_Televizorius";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id_Televizorius", MySqlDbType.Int32).Value = id_Televizorius;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}