using GestionaleCorriere.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Security;

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
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM Utenti WHERE Username = @Username AND Password = @Password";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@Username", utente.Username);
                            command.Parameters.AddWithValue("@Password", utente.Password);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    FormsAuthentication.SetAuthCookie(utente.Username, false);
                                    return RedirectToAction("Index", "Home");
                                }
                                else
                                {
                                    ViewBag.AuthError = "Autenticazione non riuscita";
                                    return View();
                                }
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Errore SQL: {ex.Message}");
                    return View("Error"); // You can create a specific view for SQL errors
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

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
