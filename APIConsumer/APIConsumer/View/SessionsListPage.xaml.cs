using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace APIConsumer
{
	public partial class SessionsListPage : ContentPage
	{
		SessionsViewModel svm;

		public SessionsListPage()
		{
			InitializeComponent();
			svm = new SessionsViewModel();
			stackLayout.BindingContext = svm;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}
	}
}

