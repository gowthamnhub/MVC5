using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
  public class MovieFormViewModel
  {
    public MovieFormViewModel()
    {
      Id = 0;
    }

    public MovieFormViewModel(Movie movie)
    {
      Id = movie.Id;
      GenreId = movie.GenreId;
      Name = movie.Name;
      NumberInStock = movie.NumberInStock;
      ReleaseDate = movie.ReleaseDate;
    }
    public int? Id { get; set; }
    [Required]
    public string Name { get; set; }

    [DateShouldBeAtleast2MonthsOld]
    [Required]
    [Display(Name = "Release Date")]
    public DateTime? ReleaseDate { get; set; }

    [Required]
    [Display(Name = "Number in Stock")]
    [Range(1, 20)]
    public int? NumberInStock { get; set; }

    [Required]
    [Display(Name = "Genre")]
    public int GenreId { get; set; }
    public IEnumerable<Genre> Genres { get; set; }

    public string Title => Id == 0 ? "New Movie" : "Edit Movie";
  }
}