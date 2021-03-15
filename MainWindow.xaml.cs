using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace metodo_de_newton_raphson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private IList<Iteracion> iteraciones;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalcular_Click(object sender, RoutedEventArgs e)
        {
            int i;
            Iteracion iteracion, iteracionAnterior;

            if (int.TryParse(TxtValorX.Text, out int x) && !string.IsNullOrEmpty(TxtValorX.Text))
            {
                iteracionAnterior = new Iteracion();
                iteraciones = new List<Iteracion>();
                i = 0;

                do
                {
                    iteracion = new Iteracion();
                    iteracion.I = i;

                    if (iteracion.I == 0)
                    {
                        iteracion.Xi = x;
                    }
                    else
                    {
                        iteracion.Xi = iteracionAnterior.Xi1;
                    }

                    iteracion.Fx = Math.Pow(Math.E, -iteracion.Xi) - iteracion.Xi;
                    iteracion.Dx = -Math.Pow(Math.E, -iteracion.Xi) - 1;
                    iteracion.Xi1 = iteracion.Xi - (iteracion.Fx / iteracion.Dx);
                    iteracion.Error = Math.Abs((iteracion.Xi1 - iteracionAnterior.Xi1) / iteracion.Xi1) * 100;

                    iteraciones.Add(iteracion);
                    iteracionAnterior = iteracion;
                    i++;

                } while (iteracion.Error != 0 && iteracion.Error != 0.001);

                DgIteraciones.ItemsSource = iteraciones;
            }
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            TxtValorX.Clear();
            DgIteraciones.ItemsSource = null;
            TxtValorX.Focus();
        }
    }
}
