using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionaleCorriere
{
    public class DataSpedizione : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dataSpedizione = (DateTime)value;
            DateTime dataConsegna = (DateTime)validationContext.ObjectInstance.GetType().GetProperty("dataConsegna").GetValue(validationContext.ObjectInstance);

            if (dataSpedizione.Date < DateTime.Now.Date)
            {
                return new ValidationResult("La data di spedizione non può essere antecedente alla data odierna");
            }
            else if (dataSpedizione.Date > dataConsegna.Date)
            {
                return new ValidationResult("La data di spedizione non può essere successiva alla data di consegna");
            }
            else if (dataSpedizione.Date == dataConsegna.Date)
            {
                return new ValidationResult("La data di spedizione non può essere uguale alla data di consegna");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
  }