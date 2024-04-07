using MovieFinder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Application.Dtos
{
    public class MovieSearchDto
    {
        public string Name { get; set; } = null!;
        public string SearchType { get; set; } = null!;
    }
}
