using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TriangleFun.Models.Validators
{
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
  public class GridRowRangeAttribute : ValidationAttribute
  {
    public GridRowRangeAttribute() : base() {
      this.ErrorMessage = "{0} out of range.";
    }
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      string row = value as string;
      if (row == null)
      {
        return ValidationResult.Success; // this is not a required attribute...
      }
      char rowChar = row.ToUpper()[0];
      if ((rowChar < 'A') || (rowChar > ((char)('A' + GridBounds.GridRows - 1))))
      {
        if (validationContext != null)
        {
          return new ValidationResult("{0} out of range.", new[] { validationContext.DisplayName });
        }
        else
        {
          return new ValidationResult("{0} out of range.");
        }
      }
      return ValidationResult.Success;
    }
  }
}