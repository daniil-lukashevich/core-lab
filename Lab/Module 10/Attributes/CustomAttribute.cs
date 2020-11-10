using Module_10.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Module_10.Attributes
{
    public class CustomAttribute : ValidationAttribute
    {
        public CustomAttribute(string val)
        {
            Val = val;
        }

        public string Val { get; }

        public string GetErrorMessage() =>
            $"String are not equeal";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var model = (ValidateModel)validationContext.ObjectInstance;

            if (model.Custom != Val)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
