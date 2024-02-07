using System;
using System.ComponentModel.DataAnnotations;


namespace Vidly.Models
{
  public class DateShouldBeAtleast2MonthsOld : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      if (value == null) return new ValidationResult("Release Date field is required");
      var diff = DateTime.Today - (DateTime)value;
      return diff.Days > 60
        ? ValidationResult.Success
        : new ValidationResult("Movie release date should be at least before 2 months");
    }
  }
}