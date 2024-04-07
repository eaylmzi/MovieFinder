using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Application.Features.Queries.ViewModels
{
    public class MovieDetailViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Poster { get; set; }
        public int Duration { get; set; }
        public double Point { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string DirectorId { get; set; }
        public List<string> StarsId { get; set; }
        public List<string> WritersId { get; set; }
        public List<string> MovieTypesId { get; set; }
    }
}
