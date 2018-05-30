using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
	public class ForgotAccount : ContentPage
	{
        #region Variables
        TapGestureRecognizer tap = new TapGestureRecognizer();
        Entry txtEmail = null;
        #endregion}



        #region Constructor
        public ForgotAccount()
        {
            StackLayout stack = new StackLayout()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.AliceBlue,
            };

            txtEmail = new Entry
            {
                Keyboard = Keyboard.Email,
                Placeholder = "Digite Email"
            };

            Button btnSend = new Button
            {
                Text = "Enviar",
                TextColor = Color.White,
                BackgroundColor = Color.LightBlue
            };

            //Agrega los controles al StackLayout
            stack.Children.Add(txtEmail);
            stack.Children.Add(btnSend);


            //Crea el evento Clicked del boton
            btnSend.Clicked += BtnSend_Clicked;

            //Agrega el stack al content principal
            Content = stack;
        }
        #endregion



        #region Events
        private async void BtnSend_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                await DisplayAlert("Alert", "El campo Email Esta Vacio", "Cancel");
            }
            else
            {
                await DisplayAlert("Alert", "Enviado Correctamente", "Cancel");
                txtEmail.Text = string.Empty;
            }
        }
        #endregion

    }
}