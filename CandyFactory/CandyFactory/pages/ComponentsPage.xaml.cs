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

namespace CandyFactory.pages
{
    /// <summary>
    /// Логика взаимодействия для ComponentsPage.xaml
    /// </summary>
    public partial class ComponentsPage : Page
    {
        public void LoadList()
        {
            var test = DB.Context.Components.ToList();
            ComponentList.ItemsSource = test;
        }
        public ComponentsPage()
        {
            InitializeComponent();
            LoadList();
        }

        private void ShowAddComponentPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddComponentPage());
        }

        private void DeleteComponent_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить запись?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                var SelectedItem = ComponentList.SelectedItem as Components;
                if (DB.Context.Compositions.ToList().Where(g => g.ComponentId == SelectedItem.ComponentId).Count() != 0)
                {
                    MessageBox.Show("Запись не может быть удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (DB.Context.ComponentOrders.ToList().Where(g => g.ComponentId == SelectedItem.ComponentId).Count() != 0)
                {
                    MessageBox.Show("Запись не может быть удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    DB.Context.Components.Remove(SelectedItem);
                    DB.Context.SaveChanges();
                    MessageBox.Show("Запись успешно удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadList();
                }
            }
        }

        private void FilterComponent(object sender, TextChangedEventArgs e)
        {
            string component = ComponentFilter.Text;
            var dataFilter = DB.Context.Components.Where(g => g.ComponentName.Contains(component));
            ComponentList.ItemsSource = dataFilter.ToList();
        }

        private void ClearFilter(object sender, RoutedEventArgs e)
        {
            LoadList();
            ComponentFilter.Clear();
        }

        private void ShowEditComponentPage_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ComponentList.SelectedItem as Components;
            this.NavigationService.Navigate(new EditComponentPage(selectedItem));
        }
    }
}