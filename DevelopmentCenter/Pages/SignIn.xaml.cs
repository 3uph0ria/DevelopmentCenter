using DevelopmentCenter.Classes;
using DevelopmentCenter.Models;
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
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Login.Text))
                errors.AppendLine("Введите логин");
            else if (string.IsNullOrWhiteSpace(Password.Password))
                errors.AppendLine("Введите пароль");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            var students = DevelopmentCenterEntities.GetContext().Students.ToList();
            students = students.Where(p => p.Login.Contains(Login.Text)).ToList();
            students = students.Where(p => p.Password.Contains(Password.Password)).ToList();
            Students student = students.FirstOrDefault();

            if (student == null)
            {
                MessageBox.Show("Неверный логин или праоль");
                return;
            }

            CurrentUser.Id = student.Id;
            CurrentUser.Type = 1;
            CurrentUser.Fullname = student.FullName.Trim();

            NavManager.MainFrame.Navigate(new Account());
        }

        private void BtnSignInTeacher_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Login.Text))
                errors.AppendLine("Введите логин");
            else if (string.IsNullOrWhiteSpace(Password.Password))
                errors.AppendLine("Введите пароль");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            var teachers = DevelopmentCenterEntities.GetContext().Teachers.ToList();
            teachers = teachers.Where(p => p.Login.Contains(Login.Text)).ToList();
            teachers = teachers.Where(p => p.Password.Contains(Password.Password)).ToList();
            Teachers teecher = teachers.FirstOrDefault();

            if (teecher == null)
            {
                MessageBox.Show("Неверный логин или праоль");
                return;
            }

            CurrentUser.Id = teecher.Id;
            CurrentUser.Type = 2;
            CurrentUser.Fullname = teecher.FullName.Trim();

            NavManager.MainFrame.Navigate(new Account());
        }

    }
}
