using Xunit;

namespace Pat.Utils.Tests.Extensions
{
    public class IEnumerableExtensionsTests
    {
        [Fact]
        public void CalculateHashCodeTest()
        {
            // Arrange
            var source = new List<int> { 1, 2, 3 };
            int start = 17;

            // Act
            int result = source.CalculateHashCode(start);

            // Assert
            Assert.Equal(409, result);
        }

        [Fact]
        public void CalculateHashCodeNullTest()
        {
            // Arrange
            IEnumerable<int> source = null;
            int start = 17;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => source.CalculateHashCode(start));
        }

        [Fact]
        public void SequenceEqualNullSafeTest()
        {
            // Arrange
            var source = new List<int> { 1, 2, 3 };
            var value = new List<int> { 1, 2, 3 };

            // Act
            bool result = source.SequenceEqualNullSafe(value);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void SequenceEqualNullSafeSourceNullTest()
        {
            // Arrange
            IEnumerable<int> source = null;
            var value = new List<int> { 1, 2, 3 };

            // Act & Assert
            Assert.False(source.SequenceEqualNullSafe(value));
        }

        [Fact]
        public void SequenceEqualNullSafeValueNullTest()
        {
            // Arrange
            var source = new List<int> { 1, 2, 3 };
            IEnumerable<int> value = null;

            // Act & Assert
            Assert.False(source.SequenceEqualNullSafe(value));
        }

        [Fact]
        public void ConcatenateTest()
        {
            // Arrange
            var source = new List<string> { "a", "b", "c" };
            string separator = ",";
            Expression<Func<string, string>> predicate = x => x;

            // Act
            string result = source.Concatenate(separator, predicate);

            // Assert
            Assert.Equal("a,b,c", result);
        }
    }
}
