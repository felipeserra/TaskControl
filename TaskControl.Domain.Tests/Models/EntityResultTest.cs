using Flunt.Validations;
using System.Linq;
using TaskControl.Domain.Core;
using Xunit;

namespace TaskControl.Domain.Tests.Models
{
    public class EntityResultTest
    {
        [Fact]
        public void Create_Successfull()
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
        public void Create_Fail()
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

            protected override bool EqualsCore(TestClass other)
            {
                return true;
            }

            protected override int GetHashCodeCore()
            {
                return 0;
            }

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