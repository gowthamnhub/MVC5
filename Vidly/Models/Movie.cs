using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Razor;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        
        [DateShouldBeAtleast2MonthsOld]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        [Required]
        [Display(Name = "Number in Stock")]
        public short NumberInStock { get; set; }    
        public Genre Genre { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}