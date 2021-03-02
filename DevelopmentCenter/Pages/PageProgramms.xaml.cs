using DevelopmentCenter.Classes;
using DevelopmentCenter.Models;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DevelopmentCenter.Pages
{

    public partial class PageProgramms : Page
    {
        public PageProgramms()
        {
            InitializeComponent();
            Update();
        }

        private void BtnEditProgramms_Click(object sender, RoutedEventArgs e)
        {
            NavManager.AccountFrane.Navigate(new AddEditProgramms((sender as Button).DataContext as Programms));
        }

        private void BtnAddProgramms_Click(object sender, RoutedEventArgs e)
        {
            NavManager.AccountFrane.Navigate(new AddEditProgramms(null));
        }

        private void BtndelProgramms_Click(object sender, RoutedEventArgs e)
        {
            var serviceForDelete = DGridProgramms.SelectedItems.Cast<Programms>().ToList();
            if (MessageBox.Show($"Вы действительно хотите удалить {serviceForDelete.Count} элементов?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DevelopmentCenterEntities.GetContext().Programms.RemoveRange(serviceForDelete);
                    DevelopmentCenterEntities.GetContext().SaveChanges();
                    DGridProgramms.ItemsSource = DevelopmentCenterEntities.GetContext().Programms.ToList();
                    MessageBox.Show("Удаление выделенных элементов прошло успешно");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility.Visible == Visibility)
            {
                DevelopmentCenterEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridProgramms.ItemsSource = DevelopmentCenterEntities.GetContext().Programms.ToList();

            }
        }

        public void Update()
        {
            var programms = DevelopmentCenterEntities.GetContext().Programms.ToList();
            var CountAllProgramms = programms.Count;

            switch (HoursSort.SelectedIndex)
            {
                case 0:
                    programms = programms.ToList();
                    break;
                case 1:
                    programms = programms.OrderBy(p => p.CountHours).ToList();
                    break;
                case 2:
                    programms = programms.OrderByDescending(p => p.CountHours).ToList();
                    break;
            }

            programms = programms.Where(p => p.Name.ToLower().Contains(Search.Text.ToLower())).ToList();
            DGridProgramms.ItemsSource = programms;
            CountProgramms.Text = "Отображено " + programms.Count + " из " + CountAllProgramms;
        }

        private void HoursSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
