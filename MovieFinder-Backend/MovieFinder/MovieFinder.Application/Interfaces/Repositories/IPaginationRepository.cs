using MovieFinder.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Application.Interfaces.Repositories
{
    public interface IPaginationRepository<T> where T : class
    {
        public Task<ListPaginationDto<T>> GetItemsWithPagination(Expression<Func<T, bool>> filter, int page, int pageSize);
    }
}
