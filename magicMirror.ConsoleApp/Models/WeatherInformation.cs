using System;
using System.Collections.Generic;
using System.Text;

namespace magicMirror.ConsoleApp.Models
{
   public class WeatherInformation
    {
        public String Location { get; set; }

        public double Temperature { get; set; }

        public String TemperatureUOM { get; set; }

        public String WeatherType { get; set; }

        public String Sunrise { get; set; }

        public String Sunset { get; set; }


    }
}
