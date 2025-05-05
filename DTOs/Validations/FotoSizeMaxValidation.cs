using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Domain.Films.Resources;

namespace DTOs.Validations
{
    public class FotoSizeMaxValidation : ValidationAttribute
    {
        private readonly int _maxSizeMB;

        public FotoSizeMaxValidation(int maxSizeMB)
        {
            _maxSizeMB = maxSizeMB;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value is IFormFile file)
            {
                if (file.Length > _maxSizeMB * 1024 * 1024)
                {
                    var message = string.Format(ActorValidationMessages.MaxFotoMB, _maxSizeMB);
                    return new ValidationResult(message);
                }
            }
            return ValidationResult.Success;
        }
    }
}