using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace ConferenceSessionsAPIs.Controllers
{
	public class ConferenceSessionsController : ApiController
    {

		List<Session> sessions = new List<Session>(
			new Session[] {
				new Session { Title = "Microsoft", Description = "Azure!" },
				new Session { Title = "Google", Description = "Android!" },
				new Session { Title = "Facebook", Description = "What's App!" },
				new Session { Title = "IBM", Description = "Watson!" }
			}
		);

		public List<Session> GetAll()
		{
			return sessions;
		}

		public Session GetSession(string id)
		{
			var session = sessions.FirstOrDefault((p) => p.Title == id);
			return session;
		}
    }
}
