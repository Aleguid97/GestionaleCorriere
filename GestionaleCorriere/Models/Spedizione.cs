using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace GestionaleCorriere.Models
{
    public class Spedizione
    {
        [Required(ErrorMessage = "Il campo ID Spedizione è obbligatorio")]
        [Display(Name = "ID Spedizione")]
        public int idSpedizione { get; set; }

        [Required(ErrorMessage = "Il campo ID Cliente è obbligatorio")]
        [Display(Name = "ID Cliente")]
        public int FK_idCliente { get; set; }

        [Required(ErrorMessage = "Il campo Codice Tracciamento è obbligatorio")]
        [StringLength(12, MinimumLength = 12)]
        [Display(Name = "Codice Tracciamento")]
        public string codTracciamento { get; set; }

       
        [Display(Name = "Data Spedizione")]
        [DataSpedizione]
        public DateTime dataSpedizione { get; set; }

        [Required(ErrorMessage = "Il campo Città Destinazione è obbligatorio")]
        [Display(Name = "Città Destinazione")]
        public string cittaDestinazione { get; set; }

        [Required(ErrorMessage = "Il campo Nominativo Destinatario è obbligatorio")]
        [Display(Name = "Destinatario")] 
        public string nominativoDestinatario { get; set; }

        [Required(ErrorMessage = "Il campo Costo Spedizione è obbligatorio")]
        [Display(Name = "Costo Spedizione")]
        public decimal costoSpedizione { get; set; }

        [Required(ErrorMessage = "Il campo Data Consegna è obbligatorio")]
        [Display(Name = "Data Consegna")]
        public DateTime dataConsegna { get; set; }


        [Required(ErrorMessage = "Il campo Peso Spedizione è obbligatorio")]
        [Display(Name = "Peso")]
        public decimal pesoSpedizione { get; set; }
    }
}