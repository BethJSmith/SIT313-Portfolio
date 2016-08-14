using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace AndroidApp
{
	[Activity(Label = "Android App", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get all resources on screen
			EditText plainText = FindViewById<EditText>(Resource.Id.PlainText);
			EditText codeText = FindViewById<EditText>(Resource.Id.CodeText);
			TextView encryptedText = FindViewById<TextView>(Resource.Id.EncryptedText);
			TextView decryptedText = FindViewById<TextView>(Resource.Id.DecryptedText);
			Button encryptButton = FindViewById<Button>(Resource.Id.EncryptButton);
			Button decryptButton = FindViewById<Button>(Resource.Id.DecryptButton);

			// Encrypt text
			encryptButton.Click += (object sender, EventArgs e) =>
			{
				encryptedText.Text = Encryption.Encrypt(plainText.Text);
			};

			// Decrypt text
			decryptButton.Click += (object sender, EventArgs e) =>
			{
				decryptedText.Text = Encryption.Decrypt(codeText.Text);
			};
		}
	}
}


