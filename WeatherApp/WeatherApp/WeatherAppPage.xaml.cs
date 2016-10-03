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
			client = new HttpClient();
			sXML = "";
		}

		void GetWeather(object sender, System.EventArgs e)
		{
			throw new NotImplementedException();
		}

		// Declare HTTP Client
		HttpClient client;

		string sXML;

		// Using threading to avoid blocking in case of a lot of data
		public async Task<string> FetchSesssionsAsync(string url)
		{
			
			// Connect to the API
			var response = await client.GetAsync(url);

			string xmlString = "";

			// If the request succeeded, response code is 200
			if (response.IsSuccessStatusCode)
			{
				// Get data
				var content = await response.Content.ReadAsStringAsync();
				xmlString = content;

			}
			return xmlString;

		}

		public async static Task FetchDataAsync(string url)
		{
			var xmlString = await FetchSesssionsAsync(url);
			sXML = xmlString;
		}

		static void CallAPI(string postcode)
		{
			string location = "";
			string temperature = "";
			string weather = "";
			string image = "";

			string APIkey = "f22891da461f219e0ffca5eddbafc0a8";
			string url = string.Format("http://api.openweathermap.org/data/2.5/weather?zip={0},aus&units=metric&mode=xml&appid={1}", postcode, APIkey);

			FetchDataAsync(url);

			/*
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			WebResponse response = request.GetResponse();
			Stream dataStream = response.GetResponseStream();
			StreamReader sreader = new StreamReader(dataStream);
			string responsereader = sreader.ReadToEnd();
			response.Close();
			*/

			//Console.WriteLine(responsereader);

			using (XmlReader reader = XmlReader.Create(new StringReader(sXML)))
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
			}

		}
	}
}

