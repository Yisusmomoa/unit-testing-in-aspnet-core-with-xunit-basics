using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject2.Helpers
{
    public class AssertTests2
    {
        [Fact]
        [Trait("Assert", "Boolean")]
        public void Boolean_Assert_Returns_True()
        {
            bool condition = true;
            int a = 5;

            Assert.False(a==10, "no debe de ser 10");
        }

        [Fact]
        [Trait("Assert", "Equality")]
        public void Equality_Assert_Returns_True()
        {
            var actual = "Hello World";

            Assert.Equal("Hello World", actual);
            Assert.NotEqual("Hello World", actual);
        }
    }
}
