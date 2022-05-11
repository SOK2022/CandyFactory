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
    /// Логика взаимодействия для AddCustomerOrderPage.xaml
    /// </summary>
    public partial class AddCustomerOrderPage : Page
    {
        public AddCustomerOrderPage()
        {
            InitializeComponent();
            BoxName.ItemsSource = DB.Context.Boxes.ToList();
            BoxName.DisplayMemberPath = "BoxName";
            CounterpartyName.ItemsSource = DB.Context.Counterparties.ToList();
            CounterpartyName.DisplayMemberPath = "CounterpartyName";
        }
        
        private void AddcustomerOrder_Click(object sender, RoutedEventArgs e)
        {
            float price = 0;
            float sum = 0;
            var selectedItem1 = BoxName.SelectedItem as Boxes;
            var selectedItem2 = CounterpartyName.SelectedItem as Counterparties;
            var candyId = selectedItem1.CandyId;
            var compositions = DB.Context.Compositions.Where(c => c.CandyId == candyId).ToList();
            var components = DB.Context.Components.ToList();
            foreach (var composition in compositions)
            {
                var componentId = composition.ComponentId;
                foreach (var component in components)
                {
                    if (component.ComponentId == componentId)
                    {
                        price = (float)component.Price;
                        break;
                    }
                }
                sum += (float)(price * composition.ComponentAmount);
            }
            try
            {
                var dataCustomerOrder = new CustomerOrders
                {
                    BoxId = selectedItem1.BoxId,
                    BoxName = selectedItem1.BoxName,
                    BoxWeight = selectedItem1.BoxWeight,
                    BoxAmount = int.Parse(BoxAmount.Text),
                    CounterpartyId = selectedItem2.CounterpartyId,
                    CounterpartyName = selectedItem2.CounterpartyName,
                    OrderSum = (float)(sum * selectedItem1.BoxWeight * int.Parse(BoxAmount.Text)),
                    OrderDate = DateTime.Now
                };
                DB.Context.CustomerOrders.Add(dataCustomerOrder);
                DB.Context.SaveChanges();
                MessageBox.Show("Запись успешно добавлена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                foreach (var composition in compositions)
                {
                    var dataComponentOrder = new ComponentOrders
                    {
                        CustomerOrderId = dataCustomerOrder.CustomerOrderId,
                        ComponentId = composition.ComponentId,
                        ComponentAmount = composition.ComponentAmount * dataCustomerOrder.Boxes.BoxWeight * dataCustomerOrder.BoxAmount,
                        CounterpartyId = composition.Components.CounterpartyId,
                        CounterpartyName = composition.Components.CounterpartyName,
                        OrderSum = (float)(composition.ComponentAmount * composition.Components.Price * selectedItem1.BoxWeight * dataCustomerOrder.BoxAmount),
                        OrderDate = DateTime.Now
                    };
                    DB.Context.ComponentOrders.Add(dataComponentOrder);
                    DB.Context.SaveChanges();
                }
                this.NavigationService.Navigate(new ComponentOrdersPage());
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при добавлении! Введены некоректные данные!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}