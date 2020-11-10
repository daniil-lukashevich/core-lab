using Microsoft.AspNetCore.Mvc;
using Module_10.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Module_10.Models
{
    public class ValidateModel
    {
        [EmailAddress]
        public string Prop1 { get; set; }

        [Required(ErrorMessage = "Some error")]
        [DisplayName("Some property")]
        public string Prop2 { get; set; }

        [Remote(action: "Validate", controller: "WeatherForecast", AdditionalFields = nameof(LastName))]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Remote(action: "Validate", controller: "WeatherForecast", AdditionalFields = nameof(FirstName))]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Custom("test")]
        public string Custom { get; set; }

    }
}
