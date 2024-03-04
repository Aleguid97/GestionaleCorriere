using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static GestionaleCorriere.CodiceFiscale;

namespace GestionaleCorriere.Models
{
    public class Cliente
    {
        [Display(Name = "ID Cliente")]
        [Required(ErrorMessage = "Il campo ID Cliente è obbligatorio")]
        public int IDcliente { get; set; }
        [Required(ErrorMessage = "Il campo Nominativo è obbligatorio")]
        [Display(Name = "Nome e Cognome")]
        public string Nominativo { get; set; }

        [Required(ErrorMessage = "Dicci se sei un'azienda")]
        [Display(Name = "Sei un'azienda?")]
        public bool IsAzienda { get; set; }

        
        [Remote("IsValid", "Cliente", ErrorMessage = "Il Codice non è valido")]
        [Required(ErrorMessage = "Il Codice Fiscale è obbligatorio")]
        [Display(Name = "Codice Fiscale")]
        [CodiceFiscale]
        public string Codice_Fiscale { get; set; }

        [Required(ErrorMessage = "La Partita Iva è obbligatorio")]
        [Display(Name = "Partita Iva")]
        public string Partita_Iva { get; set; }
    }
}