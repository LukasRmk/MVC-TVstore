using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using db.Models;
using db.ViewModels;
using MySql.Data.MySqlClient;

namespace db.repos
{
    public class AtaskaituRepository
    {
        public List<AtaskaitaViewModel> getUzsakytosPaslaugos(DateTime? nuo, DateTime? iki)
        {
            List<AtaskaitaViewModel> paslaugos = new List<AtaskaitaViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT pirkimo_sutartis.id_Pirkimo_sutartis, pardavejas.Vardas, pirkimo_sutartis.PirkimoData, pirkimo_sutartis.SutartiesNumeris, pirkimo_sutartis.PapildomuPaslauguKaina, COUNT(pirkimo_sutartis.id_Pirkimo_sutartis) as sutarciusk, SUM( pirkimo_sutartis.PapildomuPaslauguKaina ) AS bendraSuma
                                        FROM pirkimo_sutartis LEFT JOIN televizorius ON televizorius.id_Televizorius = pirkimo_sutartis.fk_Televizoriusid_Televizorius
                                        INNER JOIN pardavejas on pardavejas.id_Pardavejas = pirkimo_sutartis.fk_Pardavejasid_Pardavejas
                                        WHERE YEAR(pirkimo_sutartis.PirkimoData)>=IFNULL(?nuo, pirkimo_sutartis.PirkimoData)
                                        AND YEAR(pirkimo_sutartis.PirkimoData)<= IFNULL(?iki, pirkimo_sutartis.PirkimoData)
                                        AND pirkimo_sutartis.PapildomuPaslauguKaina > 0
                                        GROUP BY pirkimo_sutartis.SutartiesNumeris
                                        ORDER BY pirkimo_sutartis.id_Pirkimo_sutartis ASC";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?nuo", MySqlDbType.DateTime).Value = nuo;
            mySqlCommand.Parameters.Add("?iki", MySqlDbType.DateTime).Value = iki;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                paslaugos.Add(new AtaskaitaViewModel
                {
                    id = Convert.ToInt32(item["id_Pirkimo_sutartis"]),
                    sutartiesData = Convert.ToDateTime(item["PirkimoData"]),
                    SutartiesNumeris = Convert.ToInt32(item["SutartiesNumeris"]),
                    kaina = Convert.ToDecimal(item["PapildomuPaslauguKaina"]),
                    pardavejas = Convert.ToString(item["Vardas"]),
                });
            }
            return paslaugos;
        }

        public PirkimuAtaskaitaViewModel getBedraSumaUzsakytuPaslaugu(DateTime? nuo, DateTime? iki)
        {
            PirkimuAtaskaitaViewModel viso = new PirkimuAtaskaitaViewModel();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"select SUM( a.PapildomuPaslauguKaina ) as visoSumaSutartciu, COUNT(a.id_Pirkimo_sutartis) as sutarciusk 
                                from pirkimo_sutartis a
	                            where a.PirkimoData>=IFNULL(?nuo, a.PirkimoData) and a.PirkimoData<= IFNULL(?iki, a.PirkimoData)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?nuo", MySqlDbType.DateTime).Value = nuo;
            mySqlCommand.Parameters.Add("?iki", MySqlDbType.DateTime).Value = iki;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                viso.visoSumaSutartciu = Convert.ToInt32(item["visoSumaSutartciu"] == System.DBNull.Value ? 0 : item["visoSumaSutartciu"]);
                viso.sutarciusk = Convert.ToInt32(item["sutarciusk"] == System.DBNull.Value ? 0 : item["sutarciusk"]);
            }

            return viso;
        }

    }
}