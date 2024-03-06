using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionaleCorriere.Controllers
{
    public class UserValid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string username = (string)value;

            if (username.Length < 5)
            {
                return new ValidationResult("Il nome utente deve contenere almeno 6 caratteri.");
            }

            if (!IsValidUsername(username))
            {
                return new ValidationResult("Il nome utente non può contenere caratteri speciali.");
            }

            return ValidationResult.Success;
        }

        private bool IsValidUsername(string username)
        {
            // Implement your logic to check if the username contains special characters
            // Return true if the username is valid, false otherwise
            // Example implementation:
            foreach (char c in username)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
