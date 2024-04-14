using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieFinder.Application.Features.Queries.ViewModels
{
    public class MovieDetailViewModel
    {
        public string Name { get; set; }
        public string Poster { get; set; }
        public int Duration { get; set; }
        public double Point { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string DirectorName { get; set; }
        public List<string> StarsName { get; set; }
        public List<string> WritersName { get; set; }
        public List<string> MovieTypesName { get; set; }
    }
}
