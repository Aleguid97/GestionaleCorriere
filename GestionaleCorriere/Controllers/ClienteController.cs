using GestionaleCorriere.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace GestionaleCorriere.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["Gestionale"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO Cliente (Nominativo, IsAzienda, Codice_Fiscale, Partita_Iva, Ragione_Sociale, Citta) VALUES (@Nominativo, @IsAzienda, @Codice_Fiscale, @Partita_Iva, @Ragione_Sociale, @Citta)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Output di debug per verificare i dati inseriti
                            System.Diagnostics.Debug.WriteLine($"Nominativo: {cliente.Nominativo}, IsAzienda: {cliente.IsAzienda}, ...");

                            command.Parameters.AddWithValue("@Nominativo", cliente.Nominativo ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@IsAzienda", cliente.IsAzienda);
                            command.Parameters.AddWithValue("@Codice_Fiscale", cliente.Codice_Fiscale ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@Partita_Iva", cliente.Partita_Iva ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@Ragione_Sociale", cliente.Ragione_Sociale ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@Citta", cliente.Citta);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    return RedirectToAction("Create", "Cliente");
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
                return View("Create", cliente);
            }
        }
    }
}
