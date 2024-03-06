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
    public class UtenteController : Controller
    {
        // GET: Utente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Utenti utente)

        {
            if (ModelState.IsValid)
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["Gestionale"].ConnectionString;
                    SqlConnection connection = new SqlConnection(connectionString);
                    {
                        string query = "(SELECT * FROM Utenti WHERE Username = @Username and Password = @Password)";
                             SqlCommand command = new SqlCommand(query, connection);
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@Username", utente.Username);
                            command.Parameters.AddWithValue("@Password", utente.Password);
                           
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
                return View("Create", utente);
            }
        }
    }
}