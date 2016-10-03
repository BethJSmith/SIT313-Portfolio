using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace APIConsumer
{
	public partial class SessionsListPage : ContentPage
	{
		SessionsViewModel svm = new SessionsViewModel();
		
		public SessionsListPage()
		{
			InitializeComponent();
			BindingContext = svm;

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}
	}
}

