using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
	public class ListUsers : ContentPage
	{

        //Label nombre = null;
        //Label apellido = null;

		public ListUsers ()
		{
            Label header = new Label
            {
                Text = "List of Courses",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };


            StackLayout stackPrincipal = new StackLayout();
            


            for (int i = 0; i < App.listUsers.Count; i++)
            {
                StackLayout layout = new StackLayout()
                {
                    Children = {

                        new Label(){
                           Text=App.listUsers[i].Email
                        },

                        new Label()
                        {
                            Text=App.listUsers[i].Firstname
                        },

                        new Label()
                        {
                            Text=App.listUsers[i].Semestre.ToString()
                        }

                    }

                };

               
                stackPrincipal.Children.Add(layout);
            }


           
        
            this.Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Children = {
                    header,
                    stackPrincipal
                    }
                }
            };
		}
	}
}