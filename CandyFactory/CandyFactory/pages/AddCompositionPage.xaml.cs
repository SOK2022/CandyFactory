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
    /// Логика взаимодействия для AddCompositionPage.xaml
    /// </summary>
    public partial class AddCompositionPage : Page
    {
        public AddCompositionPage()
        {
            InitializeComponent();
            CandyName.ItemsSource = DB.Context.Candies.ToList();
            CandyName.DisplayMemberPath = "CandyName";
            ComponentName.ItemsSource = DB.Context.Components.ToList();
            ComponentName.DisplayMemberPath = "ComponentName";
        }

        private void AddComposition_Click(object sender, RoutedEventArgs e)
        {
            var selecteditem1 = CandyName.SelectedItem as Candies;
            var selectedItem2 = ComponentName.SelectedItem as Components;
            try
            {
                var dataComposition = new Compositions
                {
                    CandyId = selecteditem1.CandyId,
                    CandyName = selecteditem1.CandyName,
                    ComponentId = selectedItem2.ComponentId,
                    ComponentName = selectedItem2.ComponentName,
                    ComponentAmount = double.Parse(ComponentAmount.Text)
                };

                DB.Context.Compositions.Add(dataComposition);
                DB.Context.SaveChanges();
                MessageBox.Show("Запись успешно добавлена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.Navigate(new CompositionsPage());
            }

            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при добавлении! Введены некоректные данные!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}