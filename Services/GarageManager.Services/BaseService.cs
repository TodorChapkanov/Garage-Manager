using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Services
{
    public abstract class BaseService
    {
        private const string EntityValidationErrorMsg = "Entity validation failed!";
        private const string InvalidStringInput = "Invalid string input";
        private const string StringIsOutOfRange = "String input out of range";
        protected void ValidateEntityState(object model)
        {
            var validationContext = new ValidationContext(model);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);

            if (!isValid)
            {
                throw new InvalidOperationException(EntityValidationErrorMsg);
            }
        }

        protected void ValidateNullOrEmptyString(params string[]  values)
        {
            foreach (var value in values)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidStringInput);
                }
            }
            
        }

        protected void ValidateStringLength(string value, int minLength, int maxLength)
        {
            if (value.Length < minLength || value.Length > maxLength)
            {
                throw new ArgumentException(StringIsOutOfRange);
            }
        }
    }
}
