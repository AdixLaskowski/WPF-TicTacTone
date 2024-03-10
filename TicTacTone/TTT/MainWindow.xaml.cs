using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace TTT
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public bool isPlayerTurn { get; set; } = true;
        public int counter { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        public void NewGame()
        {
            isPlayerTurn = false;
            counter = 0;

            Button00.Content = string.Empty;
            Button10.Content = string.Empty;
            Button20.Content = string.Empty;

            Button01.Content = string.Empty;
            Button11.Content = string.Empty;
            Button21.Content = string.Empty;

            Button02.Content = string.Empty;
            Button12.Content = string.Empty;
            Button22.Content = string.Empty;



            Button00.Background = Brushes.White;
            Button10.Background = Brushes.White;
            Button20.Background = Brushes.White;

            Button01.Background = Brushes.White;
            Button11.Background = Brushes.White;
            Button21.Background = Brushes.White;

            Button02.Background = Brushes.White;
            Button12.Background = Brushes.White;
            Button22.Background = Brushes.White;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;

            if (button.Content.ToString() != string.Empty)
            {
                if (counter >= 9) { NewGame(); }

                return;
            }

            counter++;
            isPlayerTurn ^= true;

            if (counter > 9)
            {
                NewGame();
                return;
            }


            button.Content = isPlayerTurn ? "X" : "O";


            CheckIfPlayerWon();

            if (CheckIfPlayerWon()) { counter = 9; }


        }


        private bool CheckIfPlayerWon()
        {
            //Horzontal

            if (Button00.Content.ToString() != string.Empty && Button00.Content == Button01.Content && Button01.Content ==  Button02.Content)
            {
                Button00.Background = Brushes.Orange;
                Button01.Background = Brushes.Orange;
                Button02.Background = Brushes.Orange;
                return true;
            
            }

            if (Button10.Content.ToString() != string.Empty && Button10.Content == Button11.Content && Button11.Content == Button12.Content)
            {
                Button10.Background = Brushes.Orange;
                Button11.Background = Brushes.Orange;
                Button12.Background = Brushes.Orange;
                return true;

            }

            if (Button20.Content.ToString() != string.Empty && Button20.Content == Button21.Content && Button21.Content == Button22.Content)
            {
                Button20.Background = Brushes.Orange;
                Button21.Background = Brushes.Orange;
                Button22.Background = Brushes.Orange;
                return true;

            }

            //Veridcal

            if (Button00.Content.ToString() != string.Empty && Button00.Content == Button10.Content && Button20.Content == Button10.Content)
            {
                Button00.Background = Brushes.Orange;
                Button10.Background = Brushes.Orange;
                Button20.Background = Brushes.Orange;
                return true;

            }

            if (Button01.Content.ToString() != string.Empty && Button01.Content == Button11.Content && Button21.Content == Button11.Content)
            {
                Button01.Background = Brushes.Orange;
                Button11.Background = Brushes.Orange;
                Button21.Background = Brushes.Orange;
                return true;

            }

            if (Button02.Content.ToString() != string.Empty && Button02.Content == Button12.Content && Button22.Content == Button12.Content)
            {
                Button02.Background = Brushes.Orange;
                Button12.Background = Brushes.Orange;
                Button22.Background = Brushes.Orange;
                return true;

            } 

            //Diagonal
            if (Button00.Content.ToString() != string.Empty && Button00.Content == Button11.Content && Button11.Content == Button22.Content)
            {
                Button00.Background = Brushes.Orange;
                Button11.Background = Brushes.Orange;
                Button22.Background = Brushes.Orange;
                return true;

            } 
            
            if (Button02.Content.ToString() != string.Empty && Button02.Content == Button11.Content && Button11.Content == Button20.Content)
            {
                Button02.Background = Brushes.Orange;
                Button11.Background = Brushes.Orange;
                Button20.Background = Brushes.Orange;
                return true;

            }


            return false;
        }
    }
}
