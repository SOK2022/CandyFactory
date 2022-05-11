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
    /// Логика взаимодействия для AddComponentPage.xaml
    /// </summary>
    public partial class AddComponentPage : Page
    {
        public AddComponentPage()
        {
            InitializeComponent();
            CounterpartyName.ItemsSource = DB.Context.Counterparties.ToList();
            CounterpartyName.DisplayMemberPath = "CounterpartyName";
        }

        private void AddComponent(object sender, RoutedEventArgs e)
        {
            var selectedItem = CounterpartyName.SelectedItem as Counterparties;
            try
            {
                var dataComponent = new Components
                {
                    ComponentName = ComponentName.Text,
                    CounterpartyId = selectedItem.CounterpartyId,
                    CounterpartyName = selectedItem.CounterpartyName,
                    Price = float.Parse(Price.Text)
                };
                DB.Context.Components.Add(dataComponent);
                DB.Context.SaveChanges();
                MessageBox.Show("Запись успешно добавлена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.Navigate(new ComponentsPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при добавлении! Введены некоректные данные!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}