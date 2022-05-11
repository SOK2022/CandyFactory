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
    /// Логика взаимодействия для ComponentOrdersPage.xaml
    /// </summary>
    public partial class ComponentOrdersPage : Page
    {
        public void LoadList()
        {
            var test = DB.Context.ComponentOrders.ToList();
            ComponentOrderList.ItemsSource = test;
        }
        public ComponentOrdersPage()
        {
            InitializeComponent();
            LoadList();
        }

        private void FilterComponentOrder(object sender, TextChangedEventArgs e)
        {
            string componentOrder = ComponentOrderFilter.Text;
            var dataFilter = DB.Context.ComponentOrders.Where(g => g.Counterparties.CounterpartyName.Contains(componentOrder));
            ComponentOrderList.ItemsSource = dataFilter.ToList();
        }

        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            ComponentOrderFilter.Clear();
            LoadList();
        }
    }
}