using MagicMirror.DataAccess.Entities.Weather;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MagicMirror.Tests.Weather
{
   public class WeatherDataTests
    {
        private IWeatherRepo _repo;

        public WeatherDataTests()
        {
            _repo = new IWeatherRepo();
        }

        [Fact]
        public async Task Can_Retrieve_Weather_Data()
        {
            //Arrange
            WeatherEntity entity = null;
            string city = "Leesburg";

            //Act
            entity = await _repo.GetWeatherEntityByCityAsync(city);

            //Assert
            Assert.NotNull(entity);
            Assert.Equal(city, entity.Name);
        }

        [Fact]
        public async Task Return_Type_Should_Be_WeatherEntity()
        {
            // Arrange 
            string city = "Leesburg";

            //Act 
            var entity = await _repo.GetWeatherEntityByCityAsync(city);

            // Assert
            Assert.IsType<WeatherEntity>(entity);
        }
        [Fact]
        public async Task No_Input_Shoulb_Throw_ArgumentNull()
        {
            //Arrange
            string city = "";

            // Act 
            var method = _repo.GetWeatherEntityByCityAsync(city);

            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await method);
        }

    }
}
