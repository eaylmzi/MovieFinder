using MongoDB.Bson.Serialization.Attributes;
using MovieFinder.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Domain.AggregateModels.MovieAggregate
{
    public class MovieGenre : BaseEntity
    {
        [BsonElement("name")]
        public string Name { get; set; }

        public MovieGenre(string name)
        {
            Name = name;
        }

    }
}
