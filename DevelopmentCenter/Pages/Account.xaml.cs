using DevelopmentCenter.Classes;
using DevelopmentCenter.Pages;
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

namespace DevelopmentCenter.Pages
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        public Account()
        {
            InitializeComponent();
            UserName.Text = CurrentUser.Fullname;
            AccountFrame.Navigate(new PageProgramms());
            NavManager.AccountFrane = AccountFrame;
        }

        private void BtnTests_Click(object sender, RoutedEventArgs e)
        {
            NavManager.AccountFrane.Navigate(new PageTests());
        }

        private void BtnStudents_Click(object sender, RoutedEventArgs e)
        {
            NavManager.AccountFrane.Navigate(new PageStudents());
        }

        private void BtnProgramm_Click(object sender, RoutedEventArgs e)
        {
            NavManager.AccountFrane.Navigate(new PageProgramms());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavManager.MainFrame.Navigate(new SignIn());
        }
    }
}
