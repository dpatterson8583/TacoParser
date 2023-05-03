using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...")]
        [InlineData("40.7127281,-74.0060152, Taco Bell New Jersey...")]
        [InlineData("40.0941323,-74.9048357, Taco Bell Bristol Township")]
        //[InlineData("")]
        public void ShouldDoSomething(string line)
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(line);

            //Assert
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("40.7127281,-74.0060152, Taco Bell New Jersey...", 40.7127281)]
        [InlineData("40.0941323,-74.9048357, Taco Bell Bristol Township", 40.0941323)]
        [InlineData("5, 65, Not a real TB", 5)]
        public void ShouldParseLatitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(line);

            //Assert
            //Assert.NotNull(actual);
            Assert.Equal(expected, Convert.ToDouble(actual.Location.Latitude));
        }


        //TODO: Create a test ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("40.7127281,-74.0060152, Taco Bell New Jersey...", -74.0060152)]
        [InlineData("40.0941323,-74.9048357, Taco Bell Bristol Township", -74.9048357)]
        [InlineData("5, 65, Not a real TB", 65)]
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(line);

            //Assert
            //Assert.NotNull(actual);
            Assert.Equal(expected, Convert.ToDouble(actual.Location.Longitude));
        }
    }
}
