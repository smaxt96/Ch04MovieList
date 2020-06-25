using Ch04MovieList.Models;
using System;
using Xunit;


namespace FRWATesting
{
    public class UnitTest1
    {
        [Fact]
        public void CalculateCurrentAgeTest()
        {
            // Arrange
            BirthDateModel model = new BirthDateModel();
            model.BirthDate = "03/22/1996";

            int expected = 24;
            int actual;

            // Act
            actual = model.CalculateCurrentAge();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
