using MongoDB.Bson.Serialization.Attributes;
using MovieFinder.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Domain.AggregateModels.MovieAggregate
{
    public class Cast : BaseEntity
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("title")]
        public List<string> Title { get; set; }

        public Cast(string name, List<string> title)
        {
            Name = name;
            Title = title;
        }
    }
}
