using System;
namespace Weather
{
	public class WeatherData
	{
		public string Location { get; set; }
		public string Postcode { get; set;}
		public string Temperature { get; set;}
		public string Humidity { get; set;}
		public string Weather { get; set; }
		public string Description { get; set; }

		public WeatherData()
		{
			Location = "";
			Postcode = "";
			Temperature = "";
			Humidity = "";
			Weather = "";
			Description = "";
		}

		public WeatherData(string location, string postcode, string temperature, 
		                   string humidity, string weather, string description)
		{
			Location = location;
			Postcode = postcode;
			Temperature = temperature;
			Humidity = humidity;
			Weather = weather;
			Description = description;
		}
	}
}