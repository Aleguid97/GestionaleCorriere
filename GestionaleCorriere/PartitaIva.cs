using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GestionaleCorriere
{
    public class PartitaIva : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string Partita_Iva = value != null ? value.ToString() : null;
            bool IsAzienda = (bool)validationContext.ObjectInstance.GetType().GetProperty("IsAzienda").GetValue(validationContext.ObjectInstance);

            if (Partita_Iva == null && IsAzienda == false)
            {
                return ValidationResult.Success;
            }

            if (Partita_Iva == null || Partita_Iva.Length < 11)
            {
                return new ValidationResult("La Partita Iva deve contenere almeno 11 caratteri");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}