using App3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
    public class NotaEstudiante : ContentPage
    {

        public NotaEstudiante(data datos)
        {
            Api api = new Api();


            var respuesta = api.Notas(1);


            List<Services.data2> listaNotas = respuesta.Result.data;
            Label header = new Label
            {
                Text = "Nota Estudiantes",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Label nameUser = new Label
            {
                Text = "Hello "
            };


            ListView listView = new ListView
            {
                //Origen de datos
                ItemsSource = listaNotas,
                RowHeight = 150,

                //Define template for displaying each item.
                //(Argument of dataTemplate contructor is called for)
                // each item; it must return a cell derivative.
                ItemTemplate = new DataTemplate(() =>
                {
                    //create  views with bindings for displaying each property.
                    Label Nombre = new Label();
                    Nombre.SetBinding(Label.TextProperty, "est_nombre");

                    Label Apellido = new Label();
                    Apellido.SetBinding(Label.TextProperty, "est_apellido");


                    Label Nota1 = new Label();
                    Nota1.SetBinding(Label.TextProperty, "ce_primera_nota");

                    Label Nota2 = new Label();
                    Nota2.SetBinding(Label.TextProperty, "ce_segunda_nota");

                    Label Nota3 = new Label();
                    Nota3.SetBinding(Label.TextProperty, "ce_tercera_nota");





                    //Return an assembled viewcell.
                    return new ViewCell
                    {

                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Vertical,

                            Children =
                              {
                                  Nombre,
                             
                                  Apellido,
                                  new StackLayout
                                  {
                                      VerticalOptions=LayoutOptions.Center,
                                      Orientation = StackOrientation.Vertical,
                                      Spacing=0,
                                      Children=
                                      {
                                          Nota1,
                                          Nota2,
                                          Nota3
                                      }
                                  }
                              }
                        }
                    };

                })

            };

            //Accomodate margin wich platform
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            //Build the page.


            this.Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Children = {
                    header,
                    nameUser,
                    listView
                    }
                }
            };




            listView.ItemTapped += ListView_ItemTapped;

        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var list=(Xamarin.Forms.ListView)sender;
            var item =(data2)list.SelectedItem;

            var test = Convert.ToDouble(item.ce_primera_nota);

            var calificacion = ((Convert.ToDouble(item.ce_primera_nota) * 0.3) + (Convert.ToDouble(item.ce_segunda_nota) * 0.3) + (Convert.ToDouble(item.ce_tercera_nota) * 0.4));

           

            DisplayAlert("Nota",(calificacion>=3)?"Gano":"Perdio", "cancel");

        }
    }
}