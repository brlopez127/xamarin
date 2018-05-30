using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
    public class CreateAccountDoc : ContentPage
    {
        Entry txtNombre = null;
        Entry txtApellido = null;
        Entry txtEmail = null;
        Entry txtPass = null;
        Entry txtSemestre = null;
        DatePicker dtpFecha_nacimiento = null;
        Switch esAdministrador = null;
        Label lblEsadmin = null;


        public CreateAccountDoc ()
		{

            StackLayout View_Page = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Aquamarine,
                Padding = new Thickness(20, 0, 20, 0),

            };

            TapGestureRecognizer tapForgot = new TapGestureRecognizer();
            Label titleCreateLabel = new Label
            {
                Text = "REGISTRA TU CUENTA",
                FontSize = 20,
                HorizontalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(0, 0, 0, 50)
            };



            txtNombre = new Entry()
            {                
                Placeholder = "Nombre"           
            };

            txtApellido = new Entry()
            {
                Placeholder = "Apellido"
                
            };

            txtEmail = new Entry()
            {
                Placeholder = "Email",
                Keyboard = Keyboard.Email
            };

            txtPass = new Entry()
            {
                
                Placeholder = "Password",
                IsPassword = true

            };

            txtSemestre = new Entry()
            {
                Placeholder = "Semestre"
                
            };

            dtpFecha_nacimiento = new DatePicker()
            {
                Date = DateTime.Now
            };

            lblEsadmin = new Label()
            {
                Text = "Administrador"
            };

            esAdministrador = new Switch()
            {
                IsToggled = false                
            };



            Button btnRegister = new Button()
            {
                Text = "Registrar",
                BackgroundColor = Color.FromHex("##9FF781")
            };

            //Button btnViewUsers = new Button()
            //{
            //    Text = "View Users",
            //    BackgroundColor = Color.FromHex("#B53F9F")
            //};

            View_Page.Children.Add(titleCreateLabel);
            View_Page.Children.Add(txtNombre);
            View_Page.Children.Add(txtApellido);
            View_Page.Children.Add(txtEmail);
            View_Page.Children.Add(txtPass);
            View_Page.Children.Add(txtSemestre);
            View_Page.Children.Add(dtpFecha_nacimiento);
            View_Page.Children.Add(lblEsadmin);
            View_Page.Children.Add(esAdministrador);
            View_Page.Children.Add(btnRegister);
            
            //View_Page.Children.Add(btnViewUsers);


            //buton event
            btnRegister.Clicked += BtnRegister_Clicked;
            //btnViewUsers.Clicked += BtnViewUsers_Clicked;

            Content = View_Page;
        }

       //// private async void BtnViewUsers_Clicked(object sender, EventArgs e)
       // {
       //     await Navigation.PushAsync(new ListUsers());
       // }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtNombre.Text)
                && !string.IsNullOrEmpty(txtNombre.Text)
                && !string.IsNullOrEmpty(txtApellido.Text)
                && !string.IsNullOrEmpty(txtEmail.Text)
                && !string.IsNullOrEmpty(txtPass.Text)
                && !string.IsNullOrEmpty(txtSemestre.Text))
            {
                Models.User user = new Models.User();

                user.Firstname = txtNombre.Text;
                user.Lastname = txtApellido.Text;
                user.Email = txtEmail.Text;
                user.Password = txtPass.Text;
                user.Semestre = int.Parse(txtSemestre.Text);
                user.Fecha_nacimiento = Convert.ToDateTime(dtpFecha_nacimiento.Date.ToString("yyyy-MM-dd"));
                if (esAdministrador.IsToggled)
                {
                    user.Rol =1;
                }
                else { user.Rol =0; }

                App.listUsers.Add(user);


                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtPass.Text = string.Empty;
                txtSemestre.Text = string.Empty;
                user.Fecha_nacimiento = Convert.ToDateTime(dtpFecha_nacimiento.Date.ToString("yyyy-MM-dd"));

                await DisplayAlert("Registro", "Completado", "Ok");

                await this.Navigation.PopAsync(true);

                


            }
            else
            {
                await DisplayAlert("Registrado", "Correcto", "Ok");
            }
          

        }
    }
}