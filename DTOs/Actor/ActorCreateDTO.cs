using DTOs.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Actor
{
    public class ActorCreateDTO
    {
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }

        [FotoSizeMaxValidation(1)]
        [FileTypeValidation(GroupFileType.Image)]
        public IFormFile foto { get; set; }
    }
}
