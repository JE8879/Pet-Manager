using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Manager.Presenters.Common
{
    public class ModelDataValidation
    {
        public void Validate(object model)
        {
            string errorMessage = "";
            List<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model);
            bool isValid = Validator.TryValidateObject(model, context, validationResults, true);

            if (isValid == false)
            {
                foreach (ValidationResult validationResult in validationResults)
                {
                    errorMessage += "-" + validationResult.ErrorMessage + "\n";
                }
                throw new Exception(errorMessage);
            }
        }
    }
}
