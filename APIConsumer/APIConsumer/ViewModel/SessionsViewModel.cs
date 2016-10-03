using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Net.Http;

namespace APIConsumer
{
	public class SessionsViewModel
	{
		SessionManager sessionsManager = new SessionManager();

		public event PropertyChangedEventHandler PropertyChanged;

		ObservableCollection<Session> _SessionsList;
		public ObservableCollection<Session> SessionsList
		{
			get { return _SessionsList; }
			set
			{
				_SessionsList = value;
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("SessionsList"));
				}
			}
		}

		public SessionsViewModel()
		{
			FetchDataAsync();
		}

		public async Task FetchDataAsync()
		{
			var list = await sessionsManager.FetchSesssionsAsync();
			SessionsList = new ObservableCollection<Session>(list);
		}
	}
}

