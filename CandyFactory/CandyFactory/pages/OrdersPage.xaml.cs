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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public void LoadList()
        {
            var test = DB.Context.Orders.ToList();
            OrderList.ItemsSource = DB.Context.Orders.ToList();
        }
        public OrdersPage()
        {
            InitializeComponent();
            LoadList();
        }

        private void AddOrderPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddOrderPage());
        }

        private void EditOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить запись?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                var SelectedItem = OrderList.SelectedItem as Orders;
                DB.Context.Orders.Remove(SelectedItem);
                DB.Context.SaveChanges();
                MessageBox.Show("Запись успешно удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadList();
            }
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CustomerOrderPage());
        }
    }
}
