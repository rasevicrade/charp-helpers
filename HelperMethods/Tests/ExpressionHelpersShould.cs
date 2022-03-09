using HelperMethods;
using HelperMethods.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestClasses;

namespace Tests
{
    [TestFixture]
    public class ExpressionHelpersShould
    {
        [Test]
        [TestCase("Customer name", "x.FirstName")]
        public void ReturnCustomerNameForExpression(string firstName, string expression)
        {
            var sut = new ExpressionHelpers();

            var customer = new Customer
            {
                FirstName = firstName
            };
            Assert.AreEqual(firstName, sut.ExpressionToValue<string, Customer>(expression, customer));
        }

        [Test]
        [TestCase("Customer name", "x.BirthDate")]
        public void ReturnExpressionExceptionForBadExpression(string firstName, string expression)
        {
            var sut = new ExpressionHelpers();

            var customer = new Customer
            {
                FirstName = firstName
            };
            Assert.Throws<ExpressionException>(() => sut.ExpressionToValue<string, Customer>(expression, customer));
        }
    }
}
