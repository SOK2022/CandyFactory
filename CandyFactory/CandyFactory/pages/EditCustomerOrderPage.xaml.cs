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
    /// Логика взаимодействия для EditCustomerOrderPage.xaml
    /// </summary>
    public partial class EditCustomerOrderPage : Page
    {
        public CustomerOrders TempData { get; set; }
        public EditCustomerOrderPage(CustomerOrders customerOrders)
        {
            TempData = customerOrders;
            InitializeComponent();
            this.DataContext = this;
        }

        private void EditCustomerOrder_Click(object sender, RoutedEventArgs e)
        {
            float sum = 0;
            float price = 0;
            var componentOrders = DB.Context.ComponentOrders.Where(c => c.CustomerOrderId == TempData.CustomerOrderId);
            var compositions = DB.Context.Compositions.Where(c => c.CandyId == TempData.Boxes.CandyId).ToList();
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
            TempData.OrderSum = (float)(sum * TempData.BoxWeight * TempData.BoxAmount);
            foreach (var componentOrder in componentOrders)
            {
                foreach (var composition in compositions)
                {
                    if (componentOrder.ComponentId == composition.ComponentId)
                    {
                        componentOrder.ComponentAmount = composition.ComponentAmount * TempData.BoxWeight * TempData.BoxAmount;
                        componentOrder.OrderSum = (float)(composition.Components.Price * componentOrder.ComponentAmount);
                    }
                }
            }
            try
            {
                DB.Context.SaveChanges();
                if (MessageBox.Show("Запись успешно изменена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                {
                    this.NavigationService.Navigate(new ComponentOrdersPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при сохранении", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}