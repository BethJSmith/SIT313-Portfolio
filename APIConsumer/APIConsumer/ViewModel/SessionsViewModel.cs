using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

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
			SessionsList = new ObservableCollection<Session>();
			FetchDataAsync();
		}

		public async Task FetchDataAsync()
		{
			var list = await sessionsManager.FetchSesssionsAsync();
			foreach (Session s in list)
				SessionsList.Add(s);
		}
	}
}

