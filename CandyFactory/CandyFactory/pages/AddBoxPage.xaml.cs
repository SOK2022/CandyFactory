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
    /// Логика взаимодействия для AddBoxPage.xaml
    /// </summary>
    public partial class AddBoxPage : Page
    {
        public AddBoxPage()
        {
            InitializeComponent();
            CandyName.ItemsSource = DB.Context.Candies.ToList();
            CandyName.DisplayMemberPath = "CandyName";
        }

        private void AddBox_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = CandyName.SelectedItem as Candies;
            try
            {
                var dataBox = new Boxes
                {
                    CandyId = selectedItem.CandyId,
                    BoxName = BoxName.Text,
                    BoxWeight = float.Parse(BoxWeight.Text)
                };

                DB.Context.Boxes.Add(dataBox);
                DB.Context.SaveChanges();
                MessageBox.Show("Запись успешно добавлена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.Navigate(new BoxesPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при добавлении! Введены некоректные данные!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}