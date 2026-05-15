using Xunit;

namespace Pat.Utils.Tests.Extensions
{
    public class TypeExtensionsTests
    {
        [Fact]
        public void GetNonNullableTypeTest()
        {
            // Arrange
            Type source = typeof(int?);

            // Act
            Type result = source.GetNonNullableType();

            // Assert
            Assert.Equal(typeof(int), result);
        }

        [Fact]
        public void IsNullableTest()
        {
            // Arrange
            int? value = null;

            // Act
            bool result = value.IsNullable();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsNullableTypeTest()
        {
            // Arrange
            Type source = typeof(int);

            // Act
            bool result = source.IsNullable();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsNumberTest()
        {
            // Arrange
            Type source = typeof(double);

            // Act
            bool result = source.IsNumber();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsEnumerableTest()
        {
            // Arrange
            Type source = typeof(List<int>);

            // Act
            bool result = source.IsEnumerable();

            // Assert
            Assert.True(result);
        }
    }
}
