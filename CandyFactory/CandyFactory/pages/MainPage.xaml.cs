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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ShowCandiesPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CandiesPage());
        }

        private void ShowBoxesPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BoxesPage());
        }

        private void ShowComponentsPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ComponentsPage());
        }

        private void ShowCounterpartiesPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CounterpartiesPage());
        }

        private void ShowCompositionsPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CompositionsPage());
        }

        private void ShowCustomerOrdersPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CustomerOrdersPage());
        }

        private void ShowComponentsOrdersPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ComponentOrdersPage());
        }
    }
}