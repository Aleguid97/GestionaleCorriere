using GestionaleCorriere.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace GestionaleCorriere.Models
{
    public class Utenti
    {
        public int IdUtente { get; set; }

        [Required(ErrorMessage = "Inserisci Username")]
        [UserValid]
        public string Username { get; set; }

        [Required(ErrorMessage = "Inserisci Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}