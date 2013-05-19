using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace WpfApplication1
{
	/// <summary>
	/// Lógica de interacción para Window1.xaml
	/// </summary>
    /// 
   

	public partial class Window1 : Window
	{
        
        Image imagen = new Image();
       
      
		public Window1()
		{
			this.InitializeComponent();
			
			// A partir de este punto se requiere la inserción de código para la creación del objeto.
		}


        private void cambiarVentana(object sender, RoutedEventArgs e)
        {
            //Evento entrar a la ventana de jugar.
            if (imagen.Source == null)
            {
                titulo.Content = "Tiene que seleccionar un avatar para jugar.";
            }

            else
            {
                MainWindow ventanaJuego = new MainWindow(imagen);
                ventanaJuego.Show();
                this.Close();
            }
        }

        private void aumentar(object sender, MouseEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 87;
            da.To = 100;
            da.Duration = new Duration(TimeSpan.FromSeconds(0.4));
            ((Button)sender).BeginAnimation(Button.HeightProperty, da);
           
            DoubleAnimation da2 = new DoubleAnimation();
            da2.From = 259;
            da2.To = 300;
            da2.Duration = new Duration(TimeSpan.FromSeconds(0.4));
            ((Button)sender).BeginAnimation(Button.WidthProperty, da2);
        }

        private void reducir(object sender, MouseEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 100;
            da.To = 87;
            da.Duration = new Duration(TimeSpan.FromSeconds(0.4));
            ((Button)sender).BeginAnimation(Button.HeightProperty, da);

            DoubleAnimation da2 = new DoubleAnimation();
            da2.From = 300;
            da2.To = 259;
            da2.Duration = new Duration(TimeSpan.FromSeconds(0.4));
            ((Button)sender).BeginAnimation(Button.WidthProperty, da2);

        }

        private void seleccionarImagen(object sender, MouseButtonEventArgs e)
        {
            imagen.Opacity= 0.5;
            imagen = ((Image)sender);
            
        }

        private void subeOpacidad(object sender, MouseEventArgs e)
        {
            ((Image)sender).Opacity = 1;
        }

        private void bajaOpacidad(object sender, MouseEventArgs e)
        {
            if (imagen.Source != ((Image)sender).Source)
            {
                ((Image)sender).Opacity = 0.5;
            }

        }

         

        
	}
}