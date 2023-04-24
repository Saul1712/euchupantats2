using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace euchupantats2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tarea2 : ContentPage
    {
        public Tarea2()
        {
            InitializeComponent();
        }
        private void btnCalcularP2_Clicked(object sender, EventArgs e)
        {
            double nota, examen, nota2, examen2, promf;
            if (double.TryParse(txtNota1.Text, out nota) && double.TryParse(txtExamen1.Text, out examen) && double.TryParse(txtNota2.Text, out nota2) && double.TryParse(txtExamen2.Text, out examen2))
            {
                // Validar que la nota se encuentre dentro del rango permitido
                if (nota >= 0 && nota <= 10 && examen >= 0 && examen <= 10 && nota2 >= 0 && nota2 <= 10 && examen2 >= 0 && examen2 <= 10)
                {
                    // Realizar la multiplicación correspondiente
                    nota *= 0.3;
                    examen *= 0.2;
                    nota2 *= 0.3;
                    examen2 *= 0.2;

                    // Realizar la suma correspondiente
                    double suma1 = nota + examen;
                    txtPromedio1.Text = suma1.ToString();
                    double suma2 = nota2 + examen2;
                    txtPromedio2.Text = suma2.ToString();


                    double sumat = Convert.ToDouble(txtPromedio1.Text) + Convert.ToDouble(txtPromedio2.Text);
                    txtPromedioF.Text = sumat.ToString();

                    if (double.TryParse(txtPromedioF.Text, out promf))
                    {
                        if (promf >= 7)
                        {
                            //txtPromedio2.Text = "Alumno Aprobado";
                            DisplayAlert(txtPromedioF.Text, "¡Felicidades! Has aprobado la asignatura", "OK");
                        }
                        else if (promf >= 5 && promf < 6)
                        {
                            DisplayAlert(txtPromedioF.Text, "Tienes la oportunidad de rendir el examen complementario XD", "OK");
                        }
                        else
                        {
                            DisplayAlert(txtPromedioF.Text, "Lo siento, has reprobado la asignatura :(", "OK");
                        }

                        // Guardar la nota en la base de datos o realizar la acción correspondiente
                        DisplayAlert("Nota guardada", "La nota ingresada es válida", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Error", "Las notas debe de ingresar entre 0 y 10", "OK");
                }
            }

        }
        private void btnLimpiar_Clicked(object sender, EventArgs e)
        {
            txtNota2.Text = "";
            txtExamen2.Text = "";
            txtPromedio2.Text = "";
            txtPromedioF.Text = "";
            txtNota1.Text = "";
            txtExamen1.Text = "";
            txtPromedio1.Text = "";
          
        }

        async void btnSalir_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Cerra", "Desea cerrar la aplicación?", "Si", "No");
            if (answer)
            {
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            }
        }
        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
          await DisplayAlert("Informacion", "Usted ha regresado a la ventana principal", "OK");
          await Navigation.PushAsync (new Login());
        }
    }
 }


  


       
    
