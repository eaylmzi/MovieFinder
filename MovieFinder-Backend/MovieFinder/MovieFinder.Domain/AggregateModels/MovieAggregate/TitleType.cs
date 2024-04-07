using MovieFinder.Domain.Exceptions;
using MovieFinder.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Domain.AggregateModels.MovieAggregate
{
    public class TitleType : Enumeration
    {
        public static TitleType Director = new(1, nameof(Director).ToLowerInvariant());
        public static TitleType Writer = new(2, nameof(Writer).ToLowerInvariant());
        public static TitleType Star = new(3, nameof(Star).ToLowerInvariant());
        public TitleType(int id, string name) : base(id, name)
        {
        }
        public static IEnumerable<TitleType> List() =>
          new[] { Director, Writer, Star};

        public static TitleType FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            return state ?? throw new MovieTitleDomainException($"Possible values for Movie Title: {String.Join(",", List().Select(s => s.Name))}");
        }

        public static TitleType From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            return state ?? throw new MovieTitleDomainException($"Possible values for Movie Title: {String.Join(",", List().Select(s => s.Name))}");
        }
    }
}
