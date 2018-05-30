using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
	public class App : Application
	{
        public static List<Models.User> listUsers;

		public App ()
		{
            listUsers = new List<Models.User>();
            MainPage=new NavigationPage(new Login());
            
		}
	}
}