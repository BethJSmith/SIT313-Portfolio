using System;
namespace NotesApp
{
	public class Note
	{
		private string _Message;
		private bool _Completed;

		public string Message
		{
			get
			{
				return _Message;
			}
		}

		public bool Completed
		{
			get
			{
				return _Completed;
			}
		}

		// Constructor that takes a single string, all notes will be incomplete by default
		public Note(string message)
		{
			_Message = message;
			_Completed = false;
		}

		// Updates the message for the note
		public void Update(string newMessage)
		{
			_Message = newMessage;
		}

		// Changes the state of the note between completed and not completed
		public void Check()
		{
			if (_Completed)
				_Completed = false;
			else
				_Completed = true;
		}
	}
}