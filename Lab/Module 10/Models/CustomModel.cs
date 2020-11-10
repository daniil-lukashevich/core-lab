using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Module_10.Models
{
    public class CustomModel
    {
        [StringLength(maximumLength: 4, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
