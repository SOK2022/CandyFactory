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
    /// Логика взаимодействия для AddCandyPage.xaml
    /// </summary>
    public partial class AddCandyPage : Page
    {
        public AddCandyPage()
        {
            InitializeComponent();
        }
        private void AddCandy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataCandy = new Candies
                {
                    CandyName = CandyName.Text
                };
                DB.Context.Candies.Add(dataCandy);
                DB.Context.SaveChanges();
                MessageBox.Show("Запись успешно добавлена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.Navigate(new CandiesPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при добавлении! Введены некоректные данные!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}