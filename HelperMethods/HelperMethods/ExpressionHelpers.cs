using HelperMethods.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelperMethods
{
    public class ExpressionHelpers
    {
        /// <summary>
        /// Given an expression string (eg. x.FirstName), returns the value
        /// of that field on Target object, if it doesn't exist
        /// throws ExpressionException
        /// </summary>
        /// <typeparam name="ReturnType">Type of the field to be returned</typeparam>
        /// <typeparam name="Target">Type of object on which to evaluate the expression</typeparam>
        /// <param name="expression"></param>
        /// <param name="targetObject"></param>
        /// <returns></returns>
        public ReturnType ExpressionToValue<ReturnType, Target>(string expressionString, Target targetObject)
        {
            var expressionParam = Expression.Parameter(typeof(Target), "x");
            try
            {
                var expression = DynamicExpressionParser.ParseLambda(new[] { expressionParam }, null, expressionString);
                return (ReturnType)expression.Compile().DynamicInvoke(targetObject);
            }
            catch (Exception e)
            {
                throw new ExpressionException(e.Message);
            }
        }
    }
}
