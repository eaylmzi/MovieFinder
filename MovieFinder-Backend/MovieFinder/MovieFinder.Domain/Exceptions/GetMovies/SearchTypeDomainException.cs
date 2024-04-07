using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Domain.Exceptions.GetMovie
{
    public class SearchTypeDomainException : Exception
    {
        public SearchTypeDomainException()
        { }

        public SearchTypeDomainException(string message)
            : base(message)
        { }

        public SearchTypeDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
