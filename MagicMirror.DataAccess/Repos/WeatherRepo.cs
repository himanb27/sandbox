using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MagicMirror.DataAccess.Configuration;
using MagicMirror.DataAccess.Entities.Weather;
using Newtonsoft.Json;

namespace MagicMirror.DataAccess.Repos
{
   public class WeatherRepo
    {
        private string _apiId;
        private string _apiUrl;
        private string _Url;

        private string _city;

        private async Task<WeatherEntity> GetWeatherEntityByCityAsync(string city)
        {
            FillInputData(city);
            HttpRequestMessage message = await GetHttpResponseMessageAsync();
            WeatherEntity entity = await GetEntityFromJsonAsync(message);
            return entity;
        }

        private Task<WeatherEntity> GetEntityFromJsonAsync(HttpRequestMessage message)
        {
            throw new NotImplementedException();
        }

        private Task<HttpRequestMessage> GetHttpResponseMessageAsync()
        {
            throw new NotImplementedException();
        }

        private void FillInputData(string city)
        {
            _apiId = DataAccessConfig.OpenWeatherMapApiID;
            _apiUrl = DataAccessConfig.OpenWeatherMapApiUrl;
            _city = city;

            ValidateInput();

            _Url = $"{_apiUrl}/weather?q={_city}&appId={_apiId}";
        }

        private void ValidateInput()
        {
            throw new NotImplementedException();
        }

        private void ValidateInput(string city)
        {
            if (string.IsNullOrWhiteSpace(_apiId)) { throw new ArgumentNullException("An apiKey has to be provided"); }
            if (string.IsNullOrWhiteSpace(_apiUrl)) { throw new ArgumentNullException("An apiUrl has to be provided"); }
            if (string.IsNullOrWhiteSpace(city)) { throw new ArgumentNullException("A home city has to be provided"); }
        }

        private async Task<HttpRsponseMessage> GetRsponseMessageAsync()
        {
            var client = new HttpClient();

            HttpRsponseMessage message = await client.GetAsync(_Url);

            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Cannot connect to api:{message.StatusCode}{message.ReasonPhrase}");
            }

            return message;
        
        }     
       
        private async Task<WeatherEntity> GetEntityFromJsonAsync(HttpResponseMessage message)
        {
            string json = await message.Content.ReadAsStringAsync();

            try
            {
                var result = JsonConvert.DeserializeObject<WeatherEntity>(json);
                return result;
            }
            catch(Exception e)
            {
                throw new JsonSerializationException("Cannot convert from entity", e);
            }

        }

    }
}
