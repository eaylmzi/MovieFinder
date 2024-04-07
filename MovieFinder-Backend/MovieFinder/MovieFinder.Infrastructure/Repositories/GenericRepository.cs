
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MovieFinder.Application.Features.Queries.ViewModels;
using MovieFinder.Application.Interfaces.Repositories;
using MovieFinder.Domain.AggregateModels.MovieAggregate;
using MovieFinder.Domain.SeedWork;
using MovieFinder.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace MovieFinder.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _collection;
        public GenericRepository(IMovieFinderDatabaseSettings settings, IMongoClient mongoClient)
        {       //dbden veri çekebiliyoz yeee başardık ama jsondan bu settingsi alamıyoz
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<T>(GetCollectionNameForType<T>(settings.MovieFinderCollectionName));
        }
        // MongoDb kullandığımız için UnitOfWork patternine gerek yok
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();
        private string GetCollectionNameForType<T>(List<string> collectionNames)
        {
            string typeName = typeof(T).Name.ToLowerInvariant();

            if (collectionNames.Contains(typeName))
            {
                return typeName;
            }
            else
            {
                throw new ArgumentException($"Collection name for type {typeName} not found in settings.");
            }
        }
        public async Task<T> AddAsync(T entity)
        {
           await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
        /*
        public async Task<List<T>> GetAsync(FilterDefinition<T> filter = null)
        {
            if (filter == null)
            {
                return await GetAllAsync();
            }

            return await _collection.Find(filter).ToListAsync();
        }
        */
        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
            {
                return await GetAllAsync();
            }

            return await _collection.Find(filter).ToListAsync();
        }
        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(entity => entity.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter = null)
        {
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(string id, T entity)
        {
            await _collection.ReplaceOneAsync(e => e.Id == id, entity);
            return entity;
        }
    }
}
