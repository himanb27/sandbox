using magicMirror.ConsoleApp.Models;
using System;
    
namespace magicMirror.ConsoleApp
{
    public class Main
    {
        private UserInformation _userInfo;
        private WeatherInformation _weatherInformation;
        private TrafficInformation _trafficInformation;

        public object Private { get; private set; }

        public  void Run()
        {
            GetInformation();
            _weatherInformation = GetofflineWeatherDatat();
            _trafficInformation = GetOfflinetraccicData();

            GenerateOutput();
            Console.ReadLine();
        }

        private void GetInformation()
        {
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Please enter your street number and name:");
            string address = Console.ReadLine();

            Console.WriteLine("Please enter your zipcode:");
            string zipcode = Console.ReadLine();

            Console.WriteLine("Please enter your town:");
            string town = Console.ReadLine();

            Console.WriteLine("Please enter your work address:");
            string Workaddress = Console.ReadLine();

            _userInfo = new UserInformation
            {
                Address = address,
                Name = name,
                Town = town,
                WorkAddress = Workaddress,
                Zipcode = zipcode,
            };
        }

        private WeatherInformation GetofflineWeatherDatat()
        {
            return new WeatherInformation
            {
                Location = "USA",
                Sunrise = "5:58",
                Sunset = "18:36",
                Temperature = 76,
                WeatherType = "Sunny",
                TemperatureUOM = "Degree"
            };
        }

        private TrafficInformation GetOfflinetraccicData()
        {
            return new TrafficInformation
            {
                Minutes = 35,
                Distance = 27,
                DistanceUOM = "Kilometers",
                Destination = "2 St Margaret St, Virgina"
            };
        }

        private void GenerateOutput()
        {
            Console.WriteLine($"Good {GetTimeofDay()} { _userInfo.Name}");
            Console.WriteLine($"The current date is {DateTime.Now.ToShortDateString()} and the outside weather is {_weatherInformation.WeatherType}");
            Console.WriteLine($"Current topside temperature is {_weatherInformation.Temperature} {_weatherInformation.TemperatureUOM}.");
            Console.WriteLine($"The sun has risen at {_weatherInformation.Sunrise} and will set at approximately {_weatherInformation.Sunset}.");
            Console.WriteLine($"Your trip to work will take about {_trafficInformation.Minutes} minutes. " +
                $"If you leave now, you should arrive at approximately {_trafficInformation.TimeOfArrival.ToShortDateString()}.");
            Console.WriteLine("Thank you, and have a cery safe and productive day!");

        }

        private string GetTimeofDay()
        {
            var currentTime = DateTime.Now.TimeOfDay.Hours;

            if (currentTime >= 0 && currentTime <= 11)
                return "morning";
            else if (currentTime <= 13)
                return "day";
            else if (currentTime <= 18)
                return "afternoon";
            else if (currentTime <= 22)
                return "evening";
            else
                return "night";
        }
        }

  
    
    }


