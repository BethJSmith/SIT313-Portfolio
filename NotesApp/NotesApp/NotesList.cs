using System;
using System.Collections.Generic:

namespace NotesApp
{
	public class NotesList
	{
		List<Note> List;

		private string _Filename;

		// Constructor requires filename for location of stored messages, will be different in different OSs
		public NotesList(string filename)
		{
			List = new List<Note>();

			_Filename = filename;

			LoadList();

		}

		// Add a new note to the list and save the file
		public void AddNote(string message)
		{
			// Code here...


			SaveList();
		}

		// Edit an existing note and save the file
		public void EditNote()
		{
			// Code here...


			SaveList();
		}

		// Save the list to the file, overwriting all previous data
		private void SaveList()
		{
			// Code here...
		}

		// Load the list from the file
		private void LoadList()
		{
			// Code here...
		}
	}
}

