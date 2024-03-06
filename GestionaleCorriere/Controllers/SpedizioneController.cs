using GestionaleCorriere.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionaleCorriere.Controllers
{ 
    [Authorize(Roles = "Admin")]
    public class SpedizioneController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Spedizione()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Spedizione(Spedizione spedizione)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["Gestionale"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO SPEDIZIONE (idSpedizione, FK_idCliente, codTracciamento, dataSpedizione, pesoSpedizione, cittaDestinazione, nominativoDestinatario, costoSpedizione, dataConsegna) VALUES (@idSpedizione, @FK_idCliente, @CodTracciamento, @DataSpedizione, @PesoSpedizione, @CittaDestinazione, @NominativoDestinatario, @CostoSpedizione, @DataConsegna)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            

                            command.Parameters.AddWithValue("@idSpedizione", spedizione.idSpedizione);
                            command.Parameters.AddWithValue("@FK_idCliente", spedizione.FK_idCliente);
                            command.Parameters.AddWithValue("@CodTracciamento", spedizione.codTracciamento);
                            command.Parameters.AddWithValue("@DataSpedizione", spedizione.dataSpedizione);
                            command.Parameters.AddWithValue("@PesoSpedizione", spedizione.pesoSpedizione);
                            command.Parameters.AddWithValue("@CittaDestinazione", spedizione.cittaDestinazione);
                            command.Parameters.AddWithValue("@NominativoDestinatario", spedizione.nominativoDestinatario);
                            command.Parameters.AddWithValue("@CostoSpedizione", spedizione.costoSpedizione);
                            command.Parameters.AddWithValue("@DataConsegna", spedizione.dataConsegna);


                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    return RedirectToAction("Spedizione", "Spedizione");
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Errore SQL: {ex.Message}");
                    return View(ex.Message); // Puoi creare una vista specifica per gli errori
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Errore generale: {ex.Message}");
                    return View("Error");
                }
            }
            else
            {
                return View("Spedizione", "Spedizione");
            }
        }
    }
}
