using System;
using System.Collections.Generic;
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
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public short NumberInStock { get; set; }
        [Required]    
        public Genre Genre { get; set; }
    }
}