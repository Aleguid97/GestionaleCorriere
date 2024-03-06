using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GestionaleCorriere
{
    public class CodiceFiscale : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string codiceFiscale = value?.ToString();
            bool IsAzienda = (bool)validationContext.ObjectInstance.GetType().GetProperty("IsAzienda").GetValue(validationContext.ObjectInstance);

            if (!IsAzienda && (codiceFiscale == null || codiceFiscale.Length != 16 || !Regex.IsMatch(codiceFiscale, @"^[A-Z]{6}\d{2}[A-Z]\d{2}[A-Z]\d{3}[A-Z]$")))
                return new ValidationResult("Il codice fiscale non è valido");

            return ValidationResult.Success;
        }
    }
}



