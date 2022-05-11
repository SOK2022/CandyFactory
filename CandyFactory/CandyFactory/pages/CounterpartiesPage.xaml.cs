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
    /// Логика взаимодействия для CounterpartiesPage.xaml
    /// </summary>
    public partial class CounterpartiesPage : Page
    {
        public void LoadList()
        {
            var test = DB.Context.Counterparties.ToList();
            CounterpartyList.ItemsSource = DB.Context.Counterparties.ToList();
        }
        public CounterpartiesPage()
        {
            InitializeComponent();
            LoadList();
        }
        private void ShowAddCounerpartyPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddCounterpartyPage());
        }
        private void DeleteCounterparty_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить запись?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                var SelectedItem = CounterpartyList.SelectedItem as Counterparties;
                if (DB.Context.CustomerOrders.ToList().Where(g => g.CounterpartyId == SelectedItem.CounterpartyId).Count() != 0)
                {
                    MessageBox.Show("Запись не может быть удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (DB.Context.Components.ToList().Where(g => g.CounterpartyId == SelectedItem.CounterpartyId).Count() != 0)
                {
                    MessageBox.Show("Запись не может быть удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (DB.Context.ComponentOrders.ToList().Where(g => g.CounterpartyId == SelectedItem.CounterpartyId).Count() != 0)
                {
                    MessageBox.Show("Запись не может быть удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    DB.Context.Counterparties.Remove(SelectedItem);
                    DB.Context.SaveChanges();
                    MessageBox.Show("Запись успешно удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadList();
                }
            }
        }
        private void FilterCounterparty(object sender, TextChangedEventArgs e)
        {
            string counterparty = CounterpartyFilter.Text;
            var dataFilter = DB.Context.Counterparties.Where(g => g.CounterpartyName.Contains(counterparty));
            CounterpartyList.ItemsSource = dataFilter.ToList();
        }
        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            LoadList();
            CounterpartyFilter.Clear();
        }
        private void ShowEditCounterpartyPage_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = CounterpartyList.SelectedItem as Counterparties;
            this.NavigationService.Navigate(new EditCounterpartyPage(selectedItem));
        }
    }
}