using System;
using System.Collections.Generic;
using System.Text;

namespace MagicMirror.DataAccess.Configuration
{
    public static class DataAccessConfig
    {
        public static String OpenWeatherMapApiID
        {
            get
            {
                return "08a36bec5ec1a6896e5804e539a1dc34";
            }
        }

        public static String OpenWeatherMapApiUrl
        {
            get
            {
                return "http://api.openweathermap.org/data/2.5";
            }
        }

    }
}
