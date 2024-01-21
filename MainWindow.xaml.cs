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

        public MainWindow()
        {
            InitializeComponent();
            MainMenu.ToSoloButton.Click += OpenSoloMode;
            MainMenu.ToPvPButton.Click += OpenPvPMode;
            PvE.BacktoMenu.Click += BacktoMenuSolo;
            PvP.BacktoMenu.Click += BacktoMenuPvP;
        }

        private void OpenSoloMode(object sender, RoutedEventArgs e)
        {
            // Изменяем видимость контейнера с элементами основного функционала
            PvE.Visibility = Visibility.Visible;
            MainMenu.Visibility = Visibility.Collapsed;

            // Другие действия, если необходимо
        }

        private void OpenPvPMode(object sender, RoutedEventArgs e)
        {
            PvP.Visibility = Visibility.Visible;
            MainMenu.Visibility = Visibility.Collapsed;
        }

        private void BacktoMenuSolo(object sender, RoutedEventArgs e)
        {
            // Изменяем видимость контейнера с элементами основного функционала
            PvE.Visibility = Visibility.Collapsed;
            MainMenu.Visibility = Visibility.Visible;

            // Другие действия, если необходимо
        }

        private void BacktoMenuPvP(object sender, RoutedEventArgs e)
        {
            // Изменяем видимость контейнера с элементами основного функционала
            PvP.Visibility = Visibility.Collapsed;
            MainMenu.Visibility = Visibility.Visible;

            // Другие действия, если необходимо
        }
    }
}
