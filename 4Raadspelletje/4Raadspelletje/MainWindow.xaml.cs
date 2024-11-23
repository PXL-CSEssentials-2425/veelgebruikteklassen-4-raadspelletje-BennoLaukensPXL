using Microsoft.VisualBasic;
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

namespace _4Raadspelletje

{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        int attempts = 0;
        int number = 1;
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            number = rnd.Next(1, 101);
            attempts = 0;
            int guess = 0;
            do
            {
                string input = Interaction.InputBox($"Geef een getal tussen 1 en 100", "Raadspel");
                int.TryParse(input, out guess);
                attempts++;
                if (string.IsNullOrEmpty(input))
                {
                    guess = -1;
                }
                else if (guess == 0)
                {
                    MessageBox.Show("Geef getal!", "Foutieve invoer");
                    attempts--;
                }
                else if (guess == number)
                {
                    MessageBox.Show($"U heeft het getal geraden in {attempts} beurten!", "Gefeliciteert!");
                }
                else if (number < guess)
                {
                    MessageBox.Show($"Raad lager!", "Raadspel");
                }
                else if (number > guess)
                {
                    MessageBox.Show($"Raad hoger!", "Raadspel");
                }
            }
            while (guess != number && guess != -1);
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
