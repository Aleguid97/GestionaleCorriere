using System;
using System.Collections.Generic;
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
        public ActionResult Login(GestionaleCorriere.Models.Utenti utente)
        {
            if (ModelState.IsValid)
            {
                if (utente.Username == "admin" && utente.Password == "admin")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username o Password errati");
                }
            }
            return View(utente);
        }
    }
}