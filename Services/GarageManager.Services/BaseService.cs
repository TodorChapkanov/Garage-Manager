using GarageManager.Domain;
using GarageManager.Extensions;
using GarageManager.Services.Enums;
using GarageManager.Services.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        
        protected IQueryable<TEntity> PaginateEntitiesAsync<TEntity>(
             IQueryable<TEntity> entities,
             int pageIndex,
             int itemsPerPage)
        {
            return entities
                .Skip(((pageIndex-1) * itemsPerPage))
                .Take(itemsPerPage);
        }
    }
}
