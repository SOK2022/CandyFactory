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
    /// Логика взаимодействия для CandyCompositionOnePerKg.xaml
    /// </summary>
    public partial class CandyCompositionOnePerKg : Page
    {
        public CandyCompositionOnePerKg()
        {
            InitializeComponent();
        }

        private void AddCandyCompositionPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddCandyComposition());
        }

        private void FilterCandyComposition(object sender, TextChangedEventArgs e)
        {

        }

        private void ClearFilter(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteCandyComposition_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}