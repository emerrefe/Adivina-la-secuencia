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
        List<Image> secuenciaCorrecta = new List<Image>();
        int contCheck = 0;
                
        Image imaCheck = new Image();
        BitmapImage BitmapCheck = new BitmapImage();

        Image imaCross = new Image();
        BitmapImage BitmapCross = new BitmapImage();

        Image imaOtro = new Image();
        BitmapImage BitmapOtro = new BitmapImage();


		public MainWindow(Image img)
		{
			this.InitializeComponent();
            this.avatar.Source = img.Source;

            //para la imagen del check
            imaCheck.Width = 80;
            BitmapCheck.BeginInit();
            BitmapCheck.UriSource = new Uri(@"check.png", UriKind.Relative);
            BitmapCheck.EndInit();
            BitmapCheck.DecodePixelWidth = 80;
            imaCheck.Source = BitmapCheck;

            //para la imagen de la cruz
            imaCross.Width = 80;
            BitmapCross.BeginInit();
            BitmapCross.UriSource = new Uri(@"cross.png", UriKind.Relative);
            BitmapCross.EndInit();
            BitmapCross.DecodePixelWidth = 80;
            imaCross.Source = BitmapCross;

            //para la imagen de la cruz
            imaOtro.Width = 80;
            BitmapOtro.BeginInit();
            BitmapOtro.UriSource = new Uri(@"check2.png", UriKind.Relative);
            BitmapOtro.EndInit();
            BitmapOtro.DecodePixelWidth = 80;
            imaOtro.Source = BitmapOtro;

            generarSecuencia();
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

                for (int i = 0; i < 4; i++)
                {
                    Image im = new Image();
                    aniadirComprobacion(st, im, i);
                }

                if (contCheck == 4)
                {
                    listView1.AllowDrop = false;
                }
                else contCheck = 0;

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


        private void aniadirComprobacion(StackPanel st, Image img, int posicion)
        {
                         
            Image aux = new Image();
            aux = obtenerCheck(comprobar(posicion));
            img.Source = aux.Source;
            img.Height = 80;
            st.Children.Add(img);            
        }

        private void generarSecuencia()
        {
            Random random = new Random();
            for(int i=0; i<4;i++)
            {
                secuenciaCorrecta.Add(obtenerImagen(random.Next(1, 4)));
            }

        }

        private Image obtenerImagen(int numero)
        {
            Image fruta = null;

            switch(numero){
                case 1: fruta = imgUvas;                    
                    break;
                case 2: fruta = imgFresa;
                    break;
                case 3: fruta = imgNaranja;
                    break;
                case 4: fruta = imgLimon;
                    break;
            }
            return fruta;
        }

        private Image obtenerCheck(int numero)
        {
            Image check = null;

            switch (numero)
            {
                case 1: check = imaCheck;
                    break;
                case 2: check = imaOtro;
                    break;
                case 0: check = imaCross;
                    break; 
            }
            return check;
        }


        private int comprobar(int pResult)
        {
            int valor = 0;
                                    
            if (resultado[pResult].Source.Equals(secuenciaCorrecta[0].Source)
                || resultado[pResult].Source.Equals(secuenciaCorrecta[1].Source)
                || resultado[pResult].Source.Equals(secuenciaCorrecta[2].Source)
                || resultado[pResult].Source.Equals(secuenciaCorrecta[3].Source))                
            {
                if (resultado[pResult].Equals(secuenciaCorrecta[pResult]))
                {
                    valor = 1;
                    contCheck++;
                }
                else valor = 2;                         
            }            
            return valor;
        }
        
	}

}