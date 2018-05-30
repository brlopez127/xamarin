using App3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
    public class Login : ContentPage

    {
        #region Variables
        Entry User = null;
        Entry Pass = null;
        #endregion
        

        #region UI
        public Login()
        {
            StackLayout View_Page = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.SteelBlue,
                Padding = new Thickness(20, 0, 20, 0),
                
            };

            TapGestureRecognizer tapForgot = new TapGestureRecognizer();


            Label titleBienvenidoUtap = new Label
            {
                Text = "BIENVENIDO A LA UTAP",
                FontSize = 20,
                HorizontalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(0, 0, 0, 50)
            };

            User = new Entry()
            {
                
                Placeholder = "User",
                Keyboard = Keyboard.Email,
            };

            Pass = new Entry()
            {
                
                Placeholder = "Password",
                IsPassword = true

            };

            Button ButtonLogin = new Button
            {
                BackgroundColor = Color.Silver,
                //TextColor = Color.White,
                Text = "Iniciar"
            };

            Label label = new Label
            {
                Margin = new Thickness(10),
                TextColor = Color.Azure,
                Text = "Conseguir Password"
            };

            Button btnRegister = new Button()
            {
                Text = "Registrar",
                BackgroundColor = Color.Silver,
            };

            //generar evento de tap gesture
            tapForgot.Tapped += TapForgot_Tapped;

            View_Page.Children.Add(titleBienvenidoUtap);
            View_Page.Children.Add(User);
            View_Page.Children.Add(Pass);
            View_Page.Children.Add(ButtonLogin);
            View_Page.Children.Add(btnRegister);
            View_Page.Children.Add(label);

            //asignar evento a un control
            label.GestureRecognizers.Add(tapForgot);

            ButtonLogin.Clicked += ButtonLogin_Clicked;
            btnRegister.Clicked += BtnRegister_Clicked;


            Content = View_Page;
        }
        #endregion

        #region Events
        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAccountDoc());
        }

        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(User.Text) &&
                    !string.IsNullOrEmpty(Pass.Text) && 
                    User.Text.Contains("@"))
                {
                    //var user = (from i in App.listUsers
                    //         where i.Email == User.Text && i.Password == Pass.Text
                    //         select i).FirstOrDefault();

                    Services.Api api = new Api();
                    RespuestaDocente respuesta = await api.EstudiantesApi(User.Text, Pass.Text);

                    if (respuesta.responseCode ==202)
                    {


                       await Navigation.PushAsync(new NotaEstudiante(respuesta.data));

                    }
                    else
                    {
                        await DisplayAlert("Alert", "Error de credenciales", "Cancel");
                    }
                }
                else
                {
                    await DisplayAlert("Alert", "Por favor llene los campos", "Cancel");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
       
           
        }

        private async void TapForgot_Tapped(object sender, EventArgs e)
        {
          

            await Navigation.PushAsync(new ForgotAccount());

            

        }
        #endregion


    }
}