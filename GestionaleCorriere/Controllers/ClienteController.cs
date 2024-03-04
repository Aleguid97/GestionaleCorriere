using GestionaleCorriere.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace GestionaleCorriere.Controllers
{
    public class ClienteController : Controller
    {
        public object Partita_Iva { get; private set; }

        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InsertCliente()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertCliente(Cliente model)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Gestionale"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            try
            {

                string query = "INSERT INTO CLIENTE ( IDcliente, Nominativo , IsAzienda, Codice_Fiscale, Partita_Iva) VALUES ( @IDcliente, @Nominativo, @IsAzienda, @Codice_Fiscale, @Partita_Iva)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idcliente", model.IDcliente);
                cmd.Parameters.AddWithValue("@nominativo", model.Nominativo);
                cmd.Parameters.AddWithValue("@IsAzienda", model.IsAzienda);
                cmd.Parameters.AddWithValue("@codice_fiscale", model.Codice_Fiscale);
                cmd.Parameters.AddWithValue("@partita_iva", Partita_Iva);
                

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Errore nella richiesta SQL");
                return View(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return RedirectToAction("Create", "Cliente");

        }
    }
}