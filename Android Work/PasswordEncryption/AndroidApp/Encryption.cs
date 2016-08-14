using System;
namespace AndroidApp
{
	public static class Encryption
	{
		
		public static string Encrypt(string input)
		{
			char[] values1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();
			char[] values2 = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

			string output = "";

			foreach (char c in input)
			{
				int i = 0;
				bool found = false;
				foreach (char ch in values1)
				{
					if (c == ch)
					{
						found = true;
					}
					else if (found == false)
						i++;
				}
				if (found == false)
					output = output + c;
				else
					output = output + values2[i];

			}
			return output;
		}

		public static string Decrypt(string input)
		{
			char[] values1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();
			char[] values2 = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

			string output = "";

			foreach (char c in input)
			{
				int i = 0;
				bool found = false;
				foreach (char ch in values2)
				{
					if (c == ch)
					{
						found = true;
					}
					else if (found == false)
						i++;
				}
				if (found == false)
					output = output + c;
				else
					output = output + values1[i];

			}

			return output;
		}
	}
}

