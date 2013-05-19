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

namespace WpfApplication1
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

        private LinearGradientBrush colorIni;
        int contador = 0;
        List<Image> resultado=new List<Image>(); 

		public MainWindow(Image img)
		{
			this.InitializeComponent();
            this.avatar.Source = img.Source;
            
			// A partir de este punto se requiere la inserción de código para la creación del objeto.
		}

        private void resaltar(object sender, MouseEventArgs e)
        {
            colorIni = btnSalir.ColorIniBoton;

            btnSalir.ColorBoton = Brushes.Red;
        }

        private void desresaltar(object sender, MouseEventArgs e)
        {
            btnSalir.ColorIniBoton = colorIni;
        }

        private void salir(object sender, MouseButtonEventArgs e)
        {
            Window1 VentanaInicial = new Window1();
            VentanaInicial.Show();
            this.Close();
        }

        private void inicioArrastrar(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void soltar(object sender, DragEventArgs e)
        {
            if (contador < 4)
            {
                Image aux = (Image)e.Data.GetData(typeof(Image));
                resultado.Add(aux);

                StackPanel st = new StackPanel();
                Image im = new Image();

                im.Source = aux.Source;
                im.Height = 80;
                st.Children.Add(im);

                listView1.Items.Add(st);
                contador++;
            }

        }

        private void comprobar(object sender, RoutedEventArgs e)
        {

            if (contador == 4)
            {
                StackPanel st = new StackPanel();
                st.Orientation = Orientation.Horizontal;
                for (int i = 0; i < 4; i++)
                {
                    Image im = new Image();
                    aniadir(st, im, i);

                }

                
                listView2.Items.Add(st);

                listView1.Items.Clear();
                contador = 0;
                resultado.Clear();
            }

            
        }

        private void aniadir(StackPanel st, Image img, int posicion)
        {
            img.Source = resultado[posicion].Source;
            img.Height = 80;
            st.Children.Add(img);
            
        }
	}
}