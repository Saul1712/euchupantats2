using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace euchupantats2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Ok_Clicked(object sender, EventArgs e)
        {
            string Usuario = txtUsuario.Text;
            string Contraseña = txtContraseña.Text;

            if ((Usuario == "estudiante2023") && (Contraseña == "uisrael2023"))
            {
                Navigation.PushAsync(new Tarea2());
            }
            else
            {
                DisplayAlert("Alerta", "El usuario o contraseña son incorrectos", "OK");
            }
        }

        async void btnNo_Clicked_1(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Cerra", "Desea Cerrar la aplicación?", "Si", "No");
            if (answer)
            {
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            }
        }
    }
}