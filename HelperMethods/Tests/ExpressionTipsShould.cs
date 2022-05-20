using HelperMethods;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Exceptions;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class ExpressionTipsShould
    {
        [Test]
        public void ReturnErrorWithWrongParameters()
        {
            var sut = new ExpressionTips();

            Assert.Throws<ParseException>(() => sut.AnyLibraryBookContains("Guide"));
        }
    }
}
