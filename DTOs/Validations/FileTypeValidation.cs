using Domain.Films.Resources;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Validations
{
    public class FileTypeValidation : ValidationAttribute
    {
        private readonly string[] _validTypes;

        public FileTypeValidation(string[] validTypes)
        {
            this._validTypes = validTypes;
        }

        public FileTypeValidation(GroupFileType groupFileType)
        {
            if (groupFileType == GroupFileType.Image)
            {
                _validTypes = new string[] { "image/jpeg", "image/png", "image/gif" };
            }
            else if (groupFileType == GroupFileType.Video)
            {
                _validTypes = new string[] { "video/mp4", "video/x-ms-wmv", "video/x-msvideo" };
            }
            else if (groupFileType == GroupFileType.Audio)
            {
                _validTypes = new string[] { "audio/mpeg", "audio/wav" };
            }
            else if (groupFileType == GroupFileType.Document)
            {
                _validTypes = new string[] { "application/pdf", "application/msword" };
            }
            else
            {
                _validTypes = new string[] { };
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if (!_validTypes.Contains(file.ContentType))
                {
                    var message = string.Format(ActorValidationMessages.GroupFileType, string.Join(", ", _validTypes));
                    return new ValidationResult(message);
                }
            }
            return ValidationResult.Success;
        }
    }
}
