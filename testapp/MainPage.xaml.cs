using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace testapp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MuestraMensaje(false);
            
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if(string.IsNullOrEmpty(city.Text) || string.IsNullOrEmpty(country.Text))
            {
                
                await App.Current.MainPage.DisplayAlert("Datos Erroneos", "Debes llenar toda la infomación", "Ok");
                //await App.Current.MainPage.DisplayAlert("Test Title", "Test", "OK");
            }
            else
            {
                WebServicesManager ws = new WebServicesManager();
                var resultado = await ws.Get(city.Text, country.Text);
                if (resultado != null)
                {
                    var temp = resultado.Temp - 273.15;
                    var tempmax = resultado.Temp_Max - 273.15;
                    var tempmin = resultado.Temp_Min - 273.15;

                    msg1.Text = $"Temperatura en {city.Text} es:";
                    msg2.Text = $"{temp.ToString()}°c";
                    MuestraMensaje(true);


                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Datos Erroneos", "La ciudad no existe", "Ok");
                }

            }

        }

        private void MuestraMensaje(bool senal)
        {
            msg1.IsVisible = senal;
            msg2.IsVisible = senal;
        }

    }
}
