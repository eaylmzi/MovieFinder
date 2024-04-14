using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Application.Interfaces.StringHelper
{
    public interface ITextProcessing
    {
        public string FirstLetterTurnUpper(string name);
        public string AllLowercase(string name);
    }
}
