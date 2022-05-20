using HelperMethods.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelperMethods
{
    public class ExpressionTips
    {

        /// <summary>
        /// Example of a ParseLambda which fails because lambda parameter has a name which
        /// conflicts with main lambda parameter.
        /// An example of a hard to catch mistake which requires some head banging against the wall.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool AnyLibraryBookContains(string search)
        {
            var library = new Library();
            var books = new List<Book>()
            {
                new Book("The Hitchhiker's Guide to the Galaxy"),
                new Book("A Dance with Dragons")
            };
            library.Books = books;

            var expression = $"x.Books.Any(x => x.Title.Contains(\"{search}\"))"; // Problem is in this line, the "x" inside should be renamed to something else, eg. $"x.Books.Any(b => b.Title.Contains(\"{search}\"))"

            var param = Expression.Parameter(typeof(Library), "x");

            var lambdaExpression = DynamicExpressionParser.ParseLambda(new[] { param }, null, expression);
            return (bool)lambdaExpression.Compile().DynamicInvoke(library);
        }
    }
}
