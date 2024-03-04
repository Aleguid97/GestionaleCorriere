using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GestionaleCorriere
{
    public class CodiceFiscale : ValidationAttribute




    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string codiceFiscale = value.ToString();
            if (codiceFiscale.Length != 16)
            {
                return new ValidationResult("Il codice fiscale deve essere lungo 16 caratteri");
            }
            return ValidationResult.Success;
        }


        //public class CodiceFiscaleValidator
        //{
        //    public static bool IsValidCodiceFiscale(string codiceFiscale)
        //    {
        //        // Espressione regolare per il codice fiscale italiano
        //        string pattern = @"^[a-zA-Z]{6}[0-9]{2}[a-zA-Z][0-9]{2}[a-zA-Z][0-9]{3}[a-zA-Z]$";

        //        // Regex per la convalida
        //        Regex regex = new Regex(pattern);

        //        // Verifica se il codice fiscale corrisponde al pattern
        //        return regex.IsMatch(codiceFiscale);
        //    }
        //}
    }
}




