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
using Tic_tac_toe_game.Model;

namespace Tic_tac_toe_game
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Board Game = new Board();


        public MainWindow()
        {
            InitializeComponent();
            
            A1.Click += Button_A1_Click;
            A2.Click += Button_A2_Click;
            A3.Click += Button_A3_Click;
            B1.Click += Button_B1_Click;
            B2.Click += Button_B2_Click;
            B3.Click += Button_B3_Click;
            C1.Click += Button_C1_Click;
            C2.Click += Button_C2_Click;
            C3.Click += Button_C3_Click;
        }


        private void Button_A1_Click(object sender, RoutedEventArgs e)
        {
            if (Game.A1 == 0) //если поле незанято, то занять его, вывести нужный png на первый план, если занято, то ничего не делать
            {
                if (Game.Playerturn)
                {
                    Game.A1 = 1;
                    A1.Background = new ImageBrush(new BitmapImage(new Uri("tic.png", UriKind.Relative)));
                }
                else 
                {
                    Game.A1 = 2;
                    A1.Background = new ImageBrush(new BitmapImage(new Uri("tac.png", UriKind.Relative)));
                }
                EndGame(Game.IsSomeoneWin());

            }
        }

        private void Button_A2_Click(object sender, RoutedEventArgs e)
        {
            if (Game.A2 == 0)
            {
                if (Game.Playerturn)
                {
                    Game.A2 = 1;
                    A2.Background = new ImageBrush(new BitmapImage(new Uri("tic.png", UriKind.Relative)));
                }
                else
                {
                    Game.A2 = 2;
                    A2.Background = new ImageBrush(new BitmapImage(new Uri("tac.png", UriKind.Relative)));
                }
                EndGame(Game.IsSomeoneWin());

            }
        }

        private void Button_A3_Click(object sender, RoutedEventArgs e)
        {
            if (this.Game.A3 == 0)
            {
                if (Game.Playerturn)
                {
                    Game.A3 = 1;
                    A3.Background = new ImageBrush(new BitmapImage(new Uri("tic.png", UriKind.Relative)));
                }
                else
                {
                    Game.A3 = 2;
                    A3.Background = new ImageBrush(new BitmapImage(new Uri("tac.png", UriKind.Relative)));
                }
                EndGame(Game.IsSomeoneWin());

            }
        }

        private void Button_B1_Click(object sender, RoutedEventArgs e)
        {
            if (this.Game.B1 == 0)
            {
                if (Game.Playerturn)
                {
                    Game.B1 = 1;
                    B1.Background = new ImageBrush(new BitmapImage(new Uri("tic.png", UriKind.Relative)));
                }
                else
                {
                    Game.B1 = 2;
                    B1.Background = new ImageBrush(new BitmapImage(new Uri("tac.png", UriKind.Relative)));
                }
                EndGame(Game.IsSomeoneWin());

            }
        }

        private void Button_B2_Click(object sender, RoutedEventArgs e)
        {
            if (this.Game.B2 == 0)
            {
                if (Game.Playerturn)
                {
                    Game.B2 = 1;
                    B2.Background = new ImageBrush(new BitmapImage(new Uri("tic.png", UriKind.Relative)));
                }
                else
                {
                    Game.B2 = 2;
                    B2.Background = new ImageBrush(new BitmapImage(new Uri("tac.png", UriKind.Relative)));
                }
                EndGame(Game.IsSomeoneWin());

            }
        }
        private void Button_B3_Click(object sender, RoutedEventArgs e)
        {
            if (this.Game.B3 == 0)
            {
                if (Game.Playerturn)
                {
                    Game.B3 = 1;
                    B3.Background = new ImageBrush(new BitmapImage(new Uri("tic.png", UriKind.Relative)));
                }
                else
                {
                    Game.B3 = 2;
                    B3.Background = new ImageBrush(new BitmapImage(new Uri("tac.png", UriKind.Relative)));
                }
                EndGame(Game.IsSomeoneWin());

            }
        }
        private void Button_C1_Click(object sender, RoutedEventArgs e)
        {
            if (this.Game.C1 == 0)
            {
                if (Game.Playerturn)
                {
                    Game.C1 = 1;
                    C1.Background = new ImageBrush(new BitmapImage(new Uri("tic.png", UriKind.Relative)));
                }
                else
                {
                    Game.C1 = 2;
                    C1.Background = new ImageBrush(new BitmapImage(new Uri("tac.png", UriKind.Relative)));
                }
                EndGame(Game.IsSomeoneWin());

            }
        }

        private void Button_C2_Click(object sender, RoutedEventArgs e)
        {
            if (this.Game.C2 == 0)
            {
                if (Game.Playerturn)
                {
                    Game.C2 = 1;
                    C2.Background = new ImageBrush(new BitmapImage(new Uri("tic.png", UriKind.Relative)));
                }
                else
                {
                    Game.C2 = 2;
                    C2.Background = new ImageBrush(new BitmapImage(new Uri("tac.png", UriKind.Relative)));
                }
                EndGame(Game.IsSomeoneWin());

            }
        }
        private void Button_C3_Click(object sender, RoutedEventArgs e)
        {
            if (this.Game.C3 == 0)
            {
                if (Game.Playerturn)
                {
                    Game.C3 = 1;
                    C3.Background = new ImageBrush(new BitmapImage(new Uri("tic.png", UriKind.Relative)));
                }
                else
                {
                    Game.C3 = 2;
                    C3.Background = new ImageBrush(new BitmapImage(new Uri("tac.png", UriKind.Relative)));
                }
                EndGame(Game.IsSomeoneWin());

            }
        }

        private void EndGame(int Winner)
        {
            if (Winner == 0)
            {

            }
            else if (Winner == 1)
            {
                MessageBox.Show("Победа Крестиков!");
                RestartWindow();
            }
            else if (Winner == 2)
            {
                MessageBox.Show("Победа Ноликов!");
                RestartWindow();
            }
        }



        private void RestartWindow() 
        {
            A1.Background = null;
            A2.Background = null;
            A3.Background = null;
            B1.Background = null;
            B2.Background = null;
            B3.Background = null;
            C1.Background = null;
            C2.Background = null;
            C3.Background = null;
        }
    }
}
