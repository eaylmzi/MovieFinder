using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MovieFinder.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Domain.AggregateModels.MovieAggregate
{
    public class Movie :BaseEntity, IAggregareRoot
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("poster")]
        public string Poster { get; set; }
        [BsonElement("point")]
        public double Point { get; set; }
        [BsonElement("duration")]
        public int Duration { get; set; }
        [BsonElement("year")]
        public int Year { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("director_id")]
        public string DirectorId { get; set; }
        [BsonElement("stars_id")]
        public List<string> StarsId { get; set; }
        [BsonElement("writers_id")]
        public List<string> WritersId { get; set; }
        [BsonElement("movie_types_id")]
        public List<string> MovieTypesId { get; set; }

        public Movie(string name, string poster, int duration, int year, string description, string directorId, List<string> starsId, List<string> writersId, List<string> movieTypesId)
        {
            Name = name;
            Poster = poster;
            Duration = duration;
            Year = year;
            Description = description;
            DirectorId = directorId;
            StarsId = starsId;
            WritersId = writersId;
            MovieTypesId = movieTypesId;
            //AddDomainStart
        }
    }
}
