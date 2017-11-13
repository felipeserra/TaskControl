using Flunt.Validations;
using System.Linq;
using Task.Domain.Core;
using Xunit;

namespace Task.Domain.Tests.Models
{
    public class EntityResultTest
    {
        [Fact]
        public void ValidateAndReturn_Successfull()
        {
            // Arrange
            var testClass = new TestClass
            {
                PropertyOne = "Some value.",
                PropertyTwo = "Some value."
            };

            // Act
            var result = EntityResult<TestClass>.ValidateAndReturn(testClass);

            // Assert
            Assert.True(result.Valid);
            Assert.False(result.Errors.Any());
            Assert.NotNull(result.Entity);
            Assert.IsType<TestClass>(result.Entity);
        }

        [Fact]
        public void ValidateAndReturn_Fail()
        {
            // Arrange
            var testClass = new TestClass
            {
                PropertyOne = string.Empty,
                PropertyTwo = null
            };

            // Act
            var result = EntityResult<TestClass>.ValidateAndReturn(testClass);

            // Assert
            Assert.False(result.Valid);
            Assert.True(result.Errors.Any());
            Assert.Null(result.Entity);
        }

        public class TestClass : Entity<TestClass>, IValidatable
        {
            public string PropertyOne { get; set; }
            public string PropertyTwo { get; set; }
            
            public void Validate()
            {
                AddNotifications(new Contract()
                    .IsNotNullOrEmpty(PropertyOne, nameof(PropertyOne), "Property one is not empty or null.")
                    .IsNotNullOrEmpty(PropertyTwo, nameof(PropertyTwo), "Property two is not empty or null.")
                    );
            }
        }
    }
}