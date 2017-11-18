using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Aircompany.DataAccess.Entities;

namespace Aircompany.Web.Models.Person
{
    public class PerosonListViewModel
    {
        public int Id { get; set; }

        public Photo Photo { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Director of movies: ")]
        public List<string> DirectorOfMovies { get; set; }

        [Display(Name = "Actor in moveis: ")]
        public List<string> ActorInMovies { get; set; }
    }
}