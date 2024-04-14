using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieFinder.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieFinder.Application.Interfaces.Repositories;
using MovieFinder.Infrastructure.Repositories;
using MovieFinder.Application.Interfaces.StringHelper;
using MovieFinder.Infrastructure.StringHelper;

namespace MovieFinder.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistanceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            //Database configurations

            //   services.AddSingleton<IMovieFinderDatabaseSettings>(sp =>
            //   sp.GetRequiredService<IOptions<MovieFinderDatabaseSettings>>().Value);
            // Bir üsttekini yapmaya çalıştım aslında ama çalışmadı, ben de alttaki gibi yaptım
            services.AddSingleton<IMovieFinderDatabaseSettings, MovieFinderDatabaseSettings>();


            /*
            services.Configure<MovieFinderDatabaseSettings>(options =>
            {
                configuration.GetSection(nameof(MovieFinderDatabaseSettings)).Bind(options);
            });
            */
            // Bir üsttekini yapmaya çalıştım aslında ama çalışmadı, ben de alttaki gibi yaptım

            services.AddSingleton<IMovieFinderDatabaseSettings>(s => new MovieFinderDatabaseSettings()
            {
                DatabaseName = configuration.GetValue<string>("MovieFinderDatabaseSettings:DatabaseName"),
                ConnectionString = configuration.GetValue<string>("MovieFinderDatabaseSettings:ConnectionString"),
                
                MovieFinderCollectionName = configuration.GetSection("MovieFinderDatabaseSettings:MovieFinderCollectionNames").Get<List<string>>()
        });

            services.AddSingleton<IMongoClient>(s =>
                new MongoClient(configuration.GetValue<string>("MovieFinderDatabaseSettings:ConnectionString")));

            services.AddSingleton<IMovieRepository, MovieRepository>();
            services.AddSingleton<ICastRepository, CastRepository>();
            services.AddSingleton<IMovieGenreRepository, MovieGenreRepository>();

            services.AddScoped(typeof(IPaginationRepository<>), typeof(PaginationRepository<>));
            services.AddSingleton<ITextProcessing, TextProcessing>();

            //Other Dependencies

            return services;
        }
    }
}
