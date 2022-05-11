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
    /// Логика взаимодействия для EditComponentPage.xaml
    /// </summary>
    public partial class EditComponentPage : Page
    {
        public Components TempData { get; set; }
        public EditComponentPage(Components components)
        {
            TempData = components;
            InitializeComponent();
            this.DataContext = this;
        }

        private void EditComponent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.Context.SaveChanges();
                if (MessageBox.Show("Запись успешно изменена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                {
                    this.NavigationService.GoBack();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при сохранении", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}