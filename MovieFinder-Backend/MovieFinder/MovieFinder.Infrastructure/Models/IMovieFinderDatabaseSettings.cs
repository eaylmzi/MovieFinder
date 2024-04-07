using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Infrastructure.Models
{
    public interface IMovieFinderDatabaseSettings
    {
        List<string> MovieFinderCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
