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
    public class filialasRepository
    {
        public List<filialas> getFilialai()
        {
            List<filialas> aiksteles = new List<filialas>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "aiksteles";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                aiksteles.Add(new filialas
                {
                    id = Convert.ToInt32(item["id"]),
                    direktorius = Convert.ToString(item["direktorius"]),
                    adresas = Convert.ToString(item["adresas"]),
                    pastoKodas = Convert.ToInt32(item["pastoKodas"]),
                    fk_miestas = Convert.ToInt32(item["fk_miestas"])
                });
            }
            return aiksteles;
        }

        public List<filialas> getMiestoFilialai(int miestas)
        {
            List<filialas> aiksteles = new List<filialas>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "aiksteles where fk_miestas=" + miestas;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                aiksteles.Add(new filialas
                {
                    id = Convert.ToInt32(item["id"]),
                    direktorius = Convert.ToString(item["direktorius"]),
                    adresas = Convert.ToString(item["adresas"]),
                    pastoKodas = Convert.ToInt32(item["pastoKodas"]),
                    fk_miestas = Convert.ToInt32(item["fk_miestas"])
                });
            }
            return aiksteles;
        }
    }
}