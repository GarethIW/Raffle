using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Raffle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int maxNumber = 1000;
        int chosenNumber = 0;
        Random rand = new Random();

        DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public MainWindow()
        {
            Loaded += MainWindow_Loaded;
            InitializeComponent();
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtMax.Text = maxNumber.ToString();

            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(10);
            dispatcherTimer.Start();
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(delegate {
                MessageBox.Show("loL");
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            chosenNumber = rand.Next(maxNumber) + 1;

            lblNumber.Content = chosenNumber.ToString("0000");
        }

        private void txtMax_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(txtMax.Text, out maxNumber)) MessageBox.Show("Enter a maximum ticket number!");
        }
    }
}
