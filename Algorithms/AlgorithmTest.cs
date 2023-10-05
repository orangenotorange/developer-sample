using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Fact]
        public void CanGetFactorial()
        {
            Assert.Equal(3628800, Algorithms.GetFactorial(10));
            Assert.Equal(24, Algorithms.GetFactorial(4));
            Assert.Equal(1, Algorithms.GetFactorial(1));
        }

        [Fact]
        public void CanFormatSeparators()
        {
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));
        }
    }
}