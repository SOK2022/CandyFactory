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
    /// Логика взаимодействия для CustomerOrderPage.xaml
    /// </summary>
    public partial class CustomerOrderPage : Page
    {
        public CustomerOrderPage()
        {
            InitializeComponent();
        }

        private void EditCustomerOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddCustomerOrderPage_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new AddCustomerOrderPage());
        }
    }
}
