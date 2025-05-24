using Xunit;
using BasicMath;

namespace BasicMathTests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-1, -2, -3)]
        [InlineData(0, 0, 0)]
        [InlineData(1000000, 1, 1000001)] // Avoiding overflow test (handled separately if needed)
        public void Add_MultipleValues_ReturnsCorrectSum(double a, double b, double expected)
        {
            // Arrange
            var calculator = new BasicMaths();

            // Act
            double result = calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, result, 2); // 2 decimal places precision
        }

        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(-5, -3, -2)]
        [InlineData(0, 0, 0)]
        [InlineData(-2147483648, 1, -2147483649)] // Large numbers
        public void Subtract_MultipleValues_ReturnsCorrectDifference(double a, double b, double expected)
        {
            var calculator = new BasicMaths();
            double result = calculator.Subtract(a, b);
            Assert.Equal(expected, result, 2);
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(-2, -3, 6)]
        [InlineData(0, 5, 0)]
        [InlineData(1000000, 1, 1000000)]
        public void Multiply_MultipleValues_ReturnsCorrectProduct(double a, double b, double expected)
        {
            var calculator = new BasicMaths();
            double result = calculator.Multiply(a, b);
            Assert.Equal(expected, result, 2);
        }

        [Theory]
        [InlineData(6, 3, 2)]
        [InlineData(-6, -3, 2)]
        [InlineData(0, 1, 0)]
        [InlineData(1000000, 1, 1000000)]
        public void Divide_MultipleValues_ReturnsCorrectQuotient(double a, double b, double expected)
        {
            var calculator = new BasicMaths();
            double result = calculator.Divide(a, b);
            Assert.Equal(expected, result, 2);
        }

        [Fact]
        public void Divide_ByZero_ThrowsException()
        {
            var calculator = new BasicMaths();
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
        }
    }
}
