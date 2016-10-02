using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APIConsumer
{
	public class SessionManager
	{
		public SessionManager()
		{
		}

		// Declare HTTP Client
		HttpClient client = new HttpClient();

		// List of sessions
		List<Session> ConferenceSessions = null;

		// Using threading to avoid blocking in case of a lot of data
		public async Task<List<Session>> FetchSesssionsAsync()
		{
			// Link to API (my PC IP)
			string uri = "http://10.0.0.65:8080/api/conferencesessions";

			// Connect to the API
			var response = await client.GetAsync(uri);

			// If the request succeeded, response code is 200
			if (response.IsSuccessStatusCode)
			{
				// Get data
				var content = await response.Content.ReadAsStringAsync();

				// Deserialise data (convert from JSON to real objects)
				ConferenceSessions = JsonConvert.DeserializeObject<List<Session>>(content);
			}
			return ConferenceSessions;

		}

	}
}

