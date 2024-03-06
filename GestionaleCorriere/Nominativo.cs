using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionaleCorriere
{
    public class Nominativo : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string Nominativo = value?.ToString();
            bool IsAzienda = (bool)validationContext.ObjectInstance.GetType().GetProperty("IsAzienda").GetValue(validationContext.ObjectInstance);

            if (Nominativo == null && IsAzienda == true)
            {
                return ValidationResult.Success;

            }

            if (Nominativo == null || Nominativo.Length < 5)
            {
                return new ValidationResult("Il Nominativo deve contenere almeno 5 caratteri");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}