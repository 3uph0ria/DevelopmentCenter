﻿using DevelopmentCenter.Models;
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
    /// Логика взаимодействия для PageStudents.xaml
    /// </summary>
    public partial class PageStudents : Page
    {
        public PageStudents()
        {
            InitializeComponent();
            DGridStudents.ItemsSource = DevelopmentCenterEntities.GetContext().Students.ToList();
        }

        private void BtnEditProgramms_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
