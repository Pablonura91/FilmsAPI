using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Genero
{
    public class GeneroUpdateDTO
    {
        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }
    }
}
