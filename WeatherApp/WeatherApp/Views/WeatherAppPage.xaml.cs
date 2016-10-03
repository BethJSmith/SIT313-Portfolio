using Xamarin.Forms;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Xml;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WeatherApp
{
	public partial class WeatherAppPage : ContentPage
	{
		public WeatherAppPage()
		{
			InitializeComponent();
		}

		async void GetWeather(object sender, System.EventArgs e)
		{
			// Loading screen
			lblLocation.Text = "Loading...";
			lblTemperature.Text = "";
			lblWeather.Text = "";
			imgWeather.Source = "";
			imgWeather.IsVisible = false;

			// Get data
			string postcode = entryText.Text;
			WeatherData data = new WeatherData();
			data = await CallAPI(postcode);

			// Show data
			lblLocation.Text = data.City;
			lblTemperature.Text = data.Temperature + " degrees celsius";
			lblWeather.Text = data.Weather;
			imgWeather.Source = data.Icon;
			imgWeather.IsVisible = true;
		}

		public async static Task<WeatherData> FetchDataAsync(string url)
		{
			var client = new HttpClient();
			var result = await client.GetStringAsync(url);

			string location = "";
			string temperature = "";
			string weather = "";
			string image = "";

			WeatherData data;

			using (XmlReader reader = XmlReader.Create(new StringReader(result)))
			{
				// Get location name
				reader.ReadToFollowing("city");
				reader.MoveToAttribute("name");
				location = reader.Value;

				// Get temperature
				reader.ReadToFollowing("temperature");
				reader.MoveToAttribute("value");
				temperature = reader.Value;

				// Get weather
				reader.ReadToFollowing("weather");
				reader.MoveToAttribute("value");
				weather = reader.Value;

				// Get image
				reader.MoveToAttribute("icon");
				image = string.Format("http://openweathermap.org/img/w/{0}.png", reader.Value);

				// Save to object
				data = new WeatherData { City = location, Temperature = temperature, Weather = weather, Icon = image };
			}

			return data;
		}

		static async Task<WeatherData> CallAPI(string postcode)
		{
			string APIkey = "f22891da461f219e0ffca5eddbafc0a8";
			string url = string.Format("http://api.openweathermap.org/data/2.5/weather?zip={0},aus&units=metric&mode=xml&appid={1}", postcode, APIkey);

			WeatherData data = await FetchDataAsync(url);

			return data;
		}
	}
}

