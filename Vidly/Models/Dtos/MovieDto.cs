using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.Dtos
{
  public class MovieDto
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    [DateShouldBeAtleast2MonthsOld]
    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }

    [Required]
    [Display(Name = "Number in Stock")]
    [Range(1, 20)]
    public int NumberInStock { get; set; }

    [Required]
    public int GenreId { get; set; }
  }
}