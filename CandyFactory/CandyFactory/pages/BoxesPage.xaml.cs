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
    /// Логика взаимодействия для BoxesPage.xaml
    /// </summary>
    public partial class BoxesPage : Page
    {
        public void LoadList()
        {
            var test = DB.Context.Boxes.ToList();
            BoxList.ItemsSource = DB.Context.Boxes.ToList();
        }
        public BoxesPage()
        {
            InitializeComponent();
            LoadList();
        }
        private void ShowAddBoxPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddBoxPage());
        }
        private void DeleteBox_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить запись?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                var SelectedItem = BoxList.SelectedItem as Boxes;
                if (DB.Context.CustomerOrders.ToList().Where(g => g.BoxId == SelectedItem.BoxId).Count() != 0)
                {
                    MessageBox.Show("Запись не может быть удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    DB.Context.Boxes.Remove(SelectedItem);
                    DB.Context.SaveChanges();
                    MessageBox.Show("Запись успешно удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadList();
                }
            }
        }
        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            BoxFilter.Clear();
            LoadList();
        }
        private void FilterBox(object sender, TextChangedEventArgs e)
        {
            string box = BoxFilter.Text;
            var dataFilter = DB.Context.Boxes.Where(g => g.BoxName.Contains(box));
            BoxList.ItemsSource = dataFilter.ToList();
        }
        private void ShowEditBoxPage_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = BoxList.SelectedItem as Boxes;
            this.NavigationService.Navigate(new EditBoxPage(selectedItem));
        }
    }
}