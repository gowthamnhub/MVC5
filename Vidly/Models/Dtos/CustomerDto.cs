using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.Dtos
{
  public class CustomerDto
  { 
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Display(Name = "Subscribed to Newsletter")]
    public bool IsSubscribedToNewsletter { get; set; }

    //public MembershipType MembershipType { get; set; }
    public MembershipTypeDto MembershipType { get; set; }

    [Display(Name = "Membership Type")]
    public byte MembershipTypeId { get; set; }

    //[Minimum18YearsAge]
    [Display(Name = "Date of Birth")]
    public DateTime? BirthDate { get; set; }
  }
}