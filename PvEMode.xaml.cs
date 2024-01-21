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
    /// Логика взаимодействия для PvEMode.xaml
    /// </summary>
    public partial class PvEMode : UserControl
    {
        public AI_Player Bot = new AI_Player(true);

        public PvEMode()
        {
            InitializeComponent();
            A1.Click += Button_Click;
            A2.Click += Button_Click;
            A3.Click += Button_Click;
            B1.Click += Button_Click;
            B2.Click += Button_Click;
            B3.Click += Button_Click;
            C1.Click += Button_Click;
            C2.Click += Button_Click;
            C3.Click += Button_Click;
            A1.Tag = 0;
            A2.Tag = 1;
            A3.Tag = 2;
            B1.Tag = 3;
            B2.Tag = 4;
            B3.Tag = 5;
            C1.Tag = 6;
            C2.Tag = 7;
            C3.Tag = 8;
        }

        private string _X_count;

        public string X_count
        {
            get { return _X_count; }
            set
            {
                if (_X_count != value)
                {
                    _X_count = value;
                }
            }
        }

        private string _O_count;

        public string O_count
        {
            get { return _O_count; }
            set
            {
                if (_O_count != value)
                {
                    _O_count = value;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int int_index = Convert.ToInt32(button.Tag);
            int[] index = new int[] { int_index / 3, int_index % 3 };
            if (Bot.Game.Cells[index[0], index[1]] == 0)
            {
                if (Bot.Game.Playerturn)
                {
                    Bot.Game.Cells[index[0], index[1]] = 1;
                    button.Background = new ImageBrush(new BitmapImage(new Uri("tic.png", UriKind.Relative)));
                }
                else
                {
                    Bot.Game.Cells[index[0], index[1]] = 2;
                    button.Background = new ImageBrush(new BitmapImage(new Uri("tac.png", UriKind.Relative)));
                }
                EndGame(Bot.Game.IsSomeoneWin());
            }
        }

        private void EndGame(int Winner)
        {
            if (Winner == 0)
            {

            }
            else if (Winner == 1)
            {
                textBlock1.Text = Bot.Game.X_count.ToString();
                MessageBox.Show("Победа Крестиков!");
                RestartWindow();
            }
            else if (Winner == 2)
            {
                textBlock2.Text = Bot.Game.O_count.ToString();
                MessageBox.Show("Победа Ноликов!");
                RestartWindow();
            }
            else if (Winner == -1)
            {
                MessageBox.Show("Ничья! Играйте заново");
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
