using MovieFinder.Application.Interfaces.StringHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Infrastructure.StringHelper
{
    public class TextProcessing : ITextProcessing
    {
        public string FirstLetterTurnUpper(string name)
        {
            if (name == null)
            {
                return null;
            }

            string formattedName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
            string[] nameParts = formattedName.Split(' ');
            formattedName = string.Join(" ", nameParts.Select(part => char.ToUpper(part[0]) + part.Substring(1)));

            return formattedName;
        }
        public string AllLowercase(string name)
        {
            if (name == null)
            {
                return null;
            }

            // Tüm harfleri küçük harfe çevir
            string lowercasedName = name.ToLower();

            return lowercasedName;
        }
    }
}
