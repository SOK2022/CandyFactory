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
    /// Логика взаимодействия для CustomerOrdersPage.xaml
    /// </summary>
    public partial class CustomerOrdersPage : Page
    {
        public void LoadList()
        {
            var test = DB.Context.CustomerOrders.ToList();
            CustomerOrderList.ItemsSource = test;
        }

        public CustomerOrdersPage()
        {
            InitializeComponent();
            LoadList();
        }

        private void ShowAddCustomerOrderPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddCustomerOrderPage());
        }

        private void FilterCustomerOrder(object sender, TextChangedEventArgs e)
        {
            string customerOrder = CustomerOrderFilter.Text;
            var dataFilter = DB.Context.CustomerOrders.Where(g => g.CounterpartyName.Contains(customerOrder));
            CustomerOrderList.ItemsSource = dataFilter.ToList();
        }

        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            LoadList();
            CustomerOrderFilter.Clear();
        }

        private void ShowEditCustomerOrderPage_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = CustomerOrderList.SelectedItem as CustomerOrders;
            this.NavigationService.Navigate(new EditCustomerOrderPage(selectedItem));
        }

        private void DeleteCustomerOrder_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить запись?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                var componentOrders = DB.Context.ComponentOrders.ToList();
                var SelectedItem = CustomerOrderList.SelectedItem as CustomerOrders;
                foreach (var componentOrder in componentOrders)
                {
                    if (componentOrder.CustomerOrderId == SelectedItem.CustomerOrderId)
                    {
                        DB.Context.ComponentOrders.Remove(componentOrder);
                        DB.Context.SaveChanges();
                    }
                }
                DB.Context.CustomerOrders.Remove(SelectedItem);
                DB.Context.SaveChanges();
                MessageBox.Show("Запись успешно удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadList();
            }
        }
    }
}