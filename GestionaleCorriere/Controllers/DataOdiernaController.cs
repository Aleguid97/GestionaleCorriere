using GestionaleCorriere.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace GestionaleCorriere.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DataOdiernaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDataOdierna1()
        {
            var model = new List<Spedizione>();
            return View(model);
        }

        public List<Spedizione> Consegna = new List<Spedizione>();
        public string ConnectionString = ConfigurationManager.ConnectionStrings["Gestionale"].ConnectionString;
        public string Query = "SELECT * FROM Spedizione";

        public JsonResult GetDataOdierna()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var spedizione = new Spedizione
                        {
                            idSpedizione = Convert.ToInt32(reader["idSpedizione"]),
                            FK_idCliente = Convert.ToInt32(reader["FK_idCliente"]),
                            codTracciamento = reader["codTracciamento"].ToString(),
                            dataSpedizione = Convert.ToDateTime(reader["dataSpedizione"]),
                            pesoSpedizione = Convert.ToDecimal(reader["pesoSpedizione"]),
                            cittaDestinazione = reader["cittaDestinazione"].ToString(),
                            nominativoDestinatario = reader["nominativoDestinatario"].ToString(),
                            costoSpedizione = Convert.ToDecimal(reader["costoSpedizione"]),
                            dataConsegna = Convert.ToDateTime(reader["dataConsegna"])
                        };

                        Consegna.Add(spedizione);
                    }
                    con.Close();
                }
            }
            return Json(Consegna, JsonRequestBehavior.AllowGet);
        }
    }
}
