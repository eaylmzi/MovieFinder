using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Domain.Exceptions
{
    public class MovieTitleDomainException : Exception
    {
        public MovieTitleDomainException()
        { }

        public MovieTitleDomainException(string message)
            : base(message)
        { }

        public MovieTitleDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }



}
