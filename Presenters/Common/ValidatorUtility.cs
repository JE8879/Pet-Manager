using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Manager.Presenters.Common
{
    public class ValidationException : Exception
    {
        public List<ValidationResult> ValidationResults { get; private set; }

        public ValidationException(List<ValidationResult> validationResults)
        {
            ValidationResults = validationResults;
        }

        public override string Message
        {
            get
            {
                string errorMessage = "Validation failed:\n";
                foreach (var result in ValidationResults)
                {
                    errorMessage += "-" + result.ErrorMessage + "\n";
                }
                return errorMessage;
            }
        }
    }

    public class ValidatorUtility
    {
        public static void Validate(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);

            if (!Validator.TryValidateObject(model, context, validationResults, true))
            {
                throw new ValidationException(validationResults);
            }
        }
       
    }
}
