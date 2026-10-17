using LibraryApi.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject2.Helpers
{
    public class MathHelperTests
    {
        private readonly MathHelper _mathHelper = new();

        [Fact]
        //[Trait("name","value")]
        [Trait("category","addition2")]
        public void Add_WithTwoPositiveNumbers_ReturnsCorrectSum()
        {
            // Arrange
            int a = 5;
            int b = 10;

            // Act
            var result = _mathHelper.Add(a, b);

            // Assert
            Assert.True(result > 0);
            Assert.Equal(15, result);
        }

        [Fact]
        [Trait("category", "addition2")]
        public void Add_WithNegativeNumbers_ReturnsCorrectSum()
        {
            // Arrange
            int a = -5;
            int b = -10;

            // Act
            var result = _mathHelper.Add(a, b);

            // Assert
            Assert.Equal(-15, result);
        }

        [Fact]
        [Trait("category", "addition2")]
        public void Add_WithZeroValues_ReturnsCorrectSum()
        {
            // Arrange
            int a = 0;
            int b = 0;

            // Act
            var result = _mathHelper.Add(a, b);

            // Assert
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(5, 5, 10)]
        [InlineData(-5, 5, 0)]
        [InlineData(100, 200, 300)]
        [InlineData(-100, -200, -300)]
        public void Add_WithVariousInputs_ReturnsCorrectSum(int a, int b, int expected)
        {
            // Act
            var result = _mathHelper.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(10, 7, 3)]
        [InlineData(0, 5, -5)]
        [InlineData(-5, -3, -2)]
        [InlineData(100, 50, 50)]
        [Trait("category", "subtraction2")]
        public void Subtract_WithVariousInputs_ReturnsCorrectDifference(int a, int b, int expected)
        {
            // Act
            var result = _mathHelper.Subtract(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

    }
}
