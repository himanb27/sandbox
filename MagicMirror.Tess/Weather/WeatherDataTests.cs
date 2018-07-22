using MagicMirror.DataAccess.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MagicMirror.Tess.Weather
{
    public class WeatherDataTests
    {
        private WeatherRepo _repo;

        public WeatherDataTests()
        {
            //test
            _repo = new WeatherRepo();
        }

        [Fact]
        public void Can_Retrive_Weather_Data();
        {
            // Arrange 
            WeatherEntity entity = null;
            string city = "London";
            
            //Act
            entity = await _repo

        }
    }
}
