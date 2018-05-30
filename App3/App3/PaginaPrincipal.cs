using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
	public class PaginaPrincipal : ContentPage
	{
		public PaginaPrincipal (Models.User user)
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "Bienvenido "+user.Email+"!" }
                   
                }
			};
		}
	}
}