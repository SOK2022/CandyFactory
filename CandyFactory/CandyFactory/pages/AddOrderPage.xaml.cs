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
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        public AddOrderPage()
        {
            InitializeComponent();
            NameCounterparty.ItemsSource = DB.Context.Counterparties.ToList();
            OrderType.ItemsSource = DB.Context.OrderTypes.ToList();
            NameCounterparty.DisplayMemberPath = "CounterpartyName";
            OrderType.DisplayMemberPath = "OrderType";
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            var selectedItem1 = NameCounterparty.SelectedItem as Counterparties;
            var selectedItem2 = OrderType.SelectedItem as OrderTypes;
            try
            {
                var dataOrder = new Orders
                {
                    CounterpartyId = selectedItem1.CounterpartyId,
                    CounterpartyName = selectedItem1.CounterpartyName,
                    OrderTypeId = selectedItem2.OrderTypeId,
                    OrderType = selectedItem2.OrderType
                };
                DB.Context.Orders.Add(dataOrder);
                DB.Context.SaveChanges();
                MessageBox.Show("Запись успешно добавлена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                if (selectedItem2.OrderTypeId == 1)
                {
                    this.NavigationService.Navigate(new AddCustomerOrderPage());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при добавлении! Введены некоректные данные!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}