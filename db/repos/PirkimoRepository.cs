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
    public class PirkimoRepository
    {
        public List<PirkimoViewModel> getModeliai()
        {
            List<PirkimoViewModel> modelisViewModels = new List<PirkimoViewModel>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.PirkimoData, m.SutartiesNumeris, m.SaskaitosNumeris, m.PapildomosPaslaugos, m.PapildomuPaslauguKaina, m.id_Pirkimo_sutartis, mm.SerN AS televizorius
                                FROM pirkimo_sutartis m
                                LEFT JOIN televizorius mm ON mm.id_Televizorius=m.fk_Televizoriusid_Televizorius";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                modelisViewModels.Add(new PirkimoViewModel
                {
                    PirkimoData = Convert.ToDateTime(item["PirkimoData"]),
                    SutartiesNumeris = Convert.ToInt32(item["SutartiesNumeris"]),
                    SaskaitosNumeris = Convert.ToInt32(item["SaskaitosNumeris"]),
                    PapildomosPaslaugos = Convert.ToString(item["PapildomosPaslaugos"]),
                    PapildomuPaslauguKaina = Convert.ToDecimal(item["PapildomuPaslauguKaina"]),
                    televizorius = Convert.ToString(item["televizorius"]),
                    id_Pirkimo_sutartis = Convert.ToInt32(item["id_Pirkimo_sutartis"]),
                });
            }

            return modelisViewModels;
        }

        public PirkimoEditViewModel getModelis(int id)
        {
            PirkimoEditViewModel modelis = new PirkimoEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.* 
                                FROM pirkimo_sutartis m WHERE m.id_Pirkimo_sutartis=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                modelis.PirkimoData = Convert.ToDateTime(item["PirkimoData"]);
                modelis.SutartiesNumeris = Convert.ToInt32(item["SutartiesNumeris"]);
                modelis.SaskaitosNumeris = Convert.ToInt32(item["SaskaitosNumeris"]);
                modelis.PapildomosPaslaugos = Convert.ToString(item["PapildomosPaslaugos"]);
                modelis.PapildomuPaslauguKaina = Convert.ToDecimal(item["PapildomuPaslauguKaina"]);
                modelis.fk_televizorius = Convert.ToInt32(item["fk_Televizoriusid_Televizorius"]);
                modelis.id_Pirkimo_sutartis = Convert.ToInt32(item["id_Pirkimo_sutartis"]);
            }

            return modelis;
        }

        public bool updateModelis(PirkimoEditViewModel modelis)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE pirkimo_sutartis a SET a.PirkimoData=?PirkimoData, a.SutartiesNumeris=?SutartiesNumeris, a.SaskaitosNumeris=?SaskaitosNumeris, a.PapildomosPaslaugos=?PapildomosPaslaugos, a.PapildomuPaslauguKaina=?PapildomuPaslauguKaina, a.id_Pirkimo_sutartis=?id_Pirkimo_sutartis, a.fk_Televizoriusid_Televizorius=?fk_Televizoriusid_Televizorius WHERE a.id_Pirkimo_sutartis=?id_Pirkimo_sutartis";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?PirkimoData", MySqlDbType.DateTime).Value = modelis.PirkimoData;
            mySqlCommand.Parameters.Add("?SutartiesNumeris", MySqlDbType.Int32).Value = modelis.SutartiesNumeris;
            mySqlCommand.Parameters.Add("?SaskaitosNumeris", MySqlDbType.Int32).Value = modelis.SaskaitosNumeris;
            mySqlCommand.Parameters.Add("?PapildomosPaslaugos", MySqlDbType.VarChar).Value = modelis.PapildomosPaslaugos;
            mySqlCommand.Parameters.Add("?PapildomuPaslauguKaina", MySqlDbType.Decimal).Value = modelis.PapildomuPaslauguKaina;
            mySqlCommand.Parameters.Add("?fk_Televizoriusid_Televizorius", MySqlDbType.Int32).Value = modelis.fk_televizorius;
            mySqlCommand.Parameters.Add("?id_Pirkimo_sutartis", MySqlDbType.Int32).Value = modelis.id_Pirkimo_sutartis;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public bool addModelis(PirkimoEditViewModel modelis)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO pirkimo_sutartis(PirkimoData,SutartiesNumeris,SaskaitosNumeris,PapildomosPaslaugos,PapildomuPaslauguKaina,fk_Televizoriusid_Televizorius,id_Pirkimo_sutartis,fk_Pardavejasid_Pardavejas)VALUES(?PirkimoData,?SutartiesNumeris,?SaskaitosNumeris,?PapildomosPaslaugos,?PapildomuPaslauguKaina,?fk_Televizoriusid_Televizorius,?id_Pirkimo_sutartis,?fk_Pardavejasid_Pardavejas)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?PirkimoData", MySqlDbType.DateTime).Value = modelis.PirkimoData;
            mySqlCommand.Parameters.Add("?SutartiesNumeris", MySqlDbType.Int32).Value = modelis.SutartiesNumeris;
            mySqlCommand.Parameters.Add("?SaskaitosNumeris", MySqlDbType.Int32).Value = modelis.SaskaitosNumeris;
            mySqlCommand.Parameters.Add("?PapildomosPaslaugos", MySqlDbType.VarChar).Value = modelis.PapildomosPaslaugos;
            mySqlCommand.Parameters.Add("?PapildomuPaslauguKaina", MySqlDbType.Decimal).Value = modelis.PapildomuPaslauguKaina;
            mySqlCommand.Parameters.Add("?fk_Televizoriusid_Televizorius", MySqlDbType.Int32).Value = modelis.fk_televizorius;
            mySqlCommand.Parameters.Add("?id_Pirkimo_sutartis", MySqlDbType.Int32).Value = modelis.id_Pirkimo_sutartis;
            mySqlCommand.Parameters.Add("?fk_Pardavejasid_Pardavejas", MySqlDbType.Int32).Value = modelis.SutartiesNumeris;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public void deleteModelis(int id_Pirkimo_sutartis)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM pirkimo_sutartis where id_Pirkimo_sutartis=?id_Pirkimo_sutartis";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id_Pirkimo_sutartis", MySqlDbType.Int32).Value = id_Pirkimo_sutartis;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}