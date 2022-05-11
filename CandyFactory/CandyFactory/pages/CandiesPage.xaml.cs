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
    /// Логика взаимодействия для CandiesPage.xaml
    /// </summary>
    public partial class CandiesPage : Page
    {
        public void LoadList()
        {
            var test = DB.Context.Candies.ToList();
            CandyList.ItemsSource = test;
        }
        public CandiesPage()
        {
            InitializeComponent();
            LoadList();
        }
        private void ShowAddCandyPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddCandyPage());
        }
        private void DeleteCandy_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить запись?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                var SelectedItem = CandyList.SelectedItem as Candies;
                if (DB.Context.Boxes.ToList().Where(g => g.CandyId == SelectedItem.CandyId).Count() != 0)
                {
                    MessageBox.Show("Запись не может быть удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (DB.Context.Compositions.ToList().Where(g => g.CandyId == SelectedItem.CandyId).Count() != 0)
                {
                    MessageBox.Show("Запись не может быть удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    DB.Context.Candies.Remove(SelectedItem);
                    DB.Context.SaveChanges();
                    MessageBox.Show("Запись успешно удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadList();
                }
            }
        }

        private void FilterCandy(object sender, TextChangedEventArgs e)
        {
            string candy = CandyFilter.Text;
            var dataFilter = DB.Context.Candies.Where(g => g.CandyName.Contains(candy));
            CandyList.ItemsSource = dataFilter.ToList();
        }

        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            LoadList();
            CandyFilter.Clear();
        }

        private void ShowEditCandyPage_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = CandyList.SelectedItem as Candies;
            this.NavigationService.Navigate(new EditCandyPage(selectedItem));
        }
    }
}