using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Module_10.Models
{
    public class SwaggerModel
    {
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public Dictionary<string, string> Data { get; set; }
    }
}
