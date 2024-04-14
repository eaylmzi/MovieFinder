
using MongoDB.Driver;
using MovieFinder.Application.Dtos;
using MovieFinder.Application.Interfaces.Repositories;
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
    public class PaginationRepository<T> : GenericRepository<T>, IPaginationRepository<T> where T : BaseEntity
    {
        public PaginationRepository(IMovieFinderDatabaseSettings settings, IMongoClient mongoClient)
            : base(settings, mongoClient)
        {
            // Burada gerekli constructor parametreleri ile GenericRepository<T>'nin constructor'ını çağırıyoruz.
        }

        public async Task<ListPaginationDto<T>> GetItemsWithPagination(Expression<Func<T, bool>> filter, int page, int pageSize)
        {
            // Filter ve pagination işlemleri burada yapılabilir.
            var filteredItems = await GetAsync(filter);

            int totalCount = filteredItems.Count;
            var pagedItems = filteredItems.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new ListPaginationDto<T>
            {
                Items = pagedItems,
                CurrentPage = page,
                PageCount = (int)Math.Ceiling((double)totalCount / pageSize),
                TotalItem = totalCount
            };
        }
    }
}
