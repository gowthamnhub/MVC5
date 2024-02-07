using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
  public class Minimum18YearsAge : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      //check if the membership selected is pay-as-you-go, if not then check age limit, if yes, just return success
      //so to check the other property here(MemberShipType), this valiationContext object helps.
      var customer = (Customer)validationContext.ObjectInstance;
      //if (customer.MembershipTypeId == MembershipType.Unknown ||
      //    customer.MembershipTypeId == MembershipType.PayAsYouGo) return ValidationResult.Success;

      if (customer.MembershipTypeId == (byte)MembershipType.Type.Unknown ||
          customer.MembershipTypeId == (byte)MembershipType.Type.PayAsYouGo) return ValidationResult.Success;

      if (customer.BirthDate == null)
        return new ValidationResult("Birth date is required");
      var age = GetAgeFromBirthDate(customer.BirthDate);

      if (age >= 18) return ValidationResult.Success;

      return new ValidationResult("Age should be at least 18 years to be on a member");

    }

    private static int GetAgeFromBirthDate(DateTime? customerBirthDate)
    {
      var age = DateTime.Today.Year - customerBirthDate.Value.Year;
      if (DateTime.Today.Month < customerBirthDate.Value.Month) return age - 1;
      if (DateTime.Today.Day < customerBirthDate.Value.Day) return age - 1;
      return age;

    }
  }
}