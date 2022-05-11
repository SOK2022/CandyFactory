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
    /// Логика взаимодействия для CompositionsPage.xaml
    /// </summary>
    public partial class CompositionsPage : Page
    {
        public void LoadList()
        {
            var test = DB.Context.Compositions.ToList();
            CompositionList.ItemsSource = test;
        }
        public CompositionsPage()
        {
            InitializeComponent();
            LoadList();
        }

        private void ShowAddCompositionPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddCompositionPage());
        }

        private void FilterComposition(object sender, TextChangedEventArgs e)
        {
            string candy = CompositionFilter.Text;
            var dataFilter = DB.Context.Compositions.Where(g => g.Candies.CandyName.Contains(candy));
            CompositionList.ItemsSource = dataFilter.ToList();
        }

        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            LoadList();
            CompositionFilter.Clear();
        }

        private void DeleteComposition_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить запись?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                var SelectedItem = CompositionList.SelectedItem as Compositions;
                try
                {

                    DB.Context.Compositions.Remove(SelectedItem);
                    DB.Context.SaveChanges();
                    MessageBox.Show("Запись успешно удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadList();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Запись не может быть удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void ShowEditCompositionPage_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = CompositionList.SelectedItem as Compositions;
            this.NavigationService.Navigate(new EditCompositionPage(selectedItem));
        }
    }
}