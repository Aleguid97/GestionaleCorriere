using System.ComponentModel.DataAnnotations;
//using static GestionaleCorriere.Nominativo;
//using static GestionaleCorriere.PartitaIva;


namespace GestionaleCorriere.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        [Nominativo]
        [Display(Name = "Nome e Cognome")]
        public string Nominativo { get; set; }

        [Display(Name = "Sei un'azienda?")]
        public bool IsAzienda { get; set; }
        
       
        [Display(Name = "Codice Fiscale")] 
        [CodiceFiscale]
        public string Codice_Fiscale { get; set; }

        [Display(Name = "Partita Iva")]
        [PartitaIva]
        public string Partita_Iva { get; set; }

        [Display(Name = "Ragione Sociale")]
        public string Ragione_Sociale { get; set; }

        [Required]
        [Display(Name = "Città")]
        public string Citta { get; set; }
    }
}