using MovieFinder.Domain.Exceptions;
using MovieFinder.Domain.Exceptions.GetMovie;
using MovieFinder.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Domain.Enums
{
    public class SearchType : Enumeration
    {
        public static SearchType FilmName = new(1, nameof(FilmName).ToLowerInvariant());
        public static SearchType Director = new(2, nameof(Director).ToLowerInvariant());
        public static SearchType Star = new(3, nameof(Star).ToLowerInvariant());
        public static SearchType Year = new(4, nameof(Year).ToLowerInvariant());
        public SearchType(int id, string name) : base(id, name)
        {
        }
        public static IEnumerable<SearchType> List() =>
          new[] { FilmName, Director, Star, Year };

        public static SearchType FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            return state ?? throw new SearchTypeDomainException($"Possible values for Search Type: {String.Join(",", List().Select(s => s.Name))}");
        }

        public static SearchType From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            return state ?? throw new SearchTypeDomainException($"Possible values for Search Type: {String.Join(",", List().Select(s => s.Name))}");
        }
    }
}
