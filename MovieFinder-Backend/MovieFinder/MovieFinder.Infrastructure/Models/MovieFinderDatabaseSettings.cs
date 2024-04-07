using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Infrastructure.Models
{
    public class MovieFinderDatabaseSettings : IMovieFinderDatabaseSettings
    {
        public List<string> MovieFinderCollectionName { get; set; } = new List<string>();
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
