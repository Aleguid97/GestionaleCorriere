using GestionaleCorriere.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GestionaleCorriere.Controllers
{
    public class DataOdiernaController : Controller
    {
        public List<Spedizione> Consegna = new List<Spedizione>();
        public string connectionString = ConfigurationManager.ConnectionStrings["Gestionale"].ConnectionString;
        public string query = "SELECT * FROM Spedizione";

        public async Task<JsonResult> GetDataOdierna()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Spedizione spedizione = new Spedizione
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

                        }
                    }
                }

                return Json(Consegna, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Gestisci gli errori, ad esempio, loggali o restituisci un messaggio di errore
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
