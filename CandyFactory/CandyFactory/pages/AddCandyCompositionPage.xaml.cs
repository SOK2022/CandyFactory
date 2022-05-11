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
    /// Логика взаимодействия для AddCandyComposition.xaml
    /// </summary>
    public partial class AddCandyComposition : Page
    {
        public AddCandyComposition()
        {
            InitializeComponent();
            NameCandy.ItemsSource = DB.Context.Candies.ToList();
            NameComponent.ItemsSource = DB.Context.Components.ToList();
            NameCandy.DisplayMemberPath = "CandyName";
            NameComponent.DisplayMemberPath = "ComponentName";
        }

        private void AddComposition(object sender, RoutedEventArgs e)
        {
            var selectedItem1 = NameCandy.SelectedItem as Candies;
            var selectedItem2 = NameComponent.SelectedItem as Components;
            try
            {
                var dataComposition = new CandyCompositionPerOneKg
                {
                    CandyId = selectedItem1.CandyId,
                    CandyName = selectedItem1.CandyName,
                    ComponentId = selectedItem2.ComponentId,
                    ComponentName = selectedItem2.ComponentName,
                    ComponentAmount = float.Parse(ComponentAmount.Text)
                };
                DB.Context.CandyCompositionPerOneKg.Add(dataComposition);
                DB.Context.SaveChanges();
                MessageBox.Show("Запись успешно добавлена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.Navigate(new CandyCompositionOnePerKg());
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при добавлении! Введены некоректные данные!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}