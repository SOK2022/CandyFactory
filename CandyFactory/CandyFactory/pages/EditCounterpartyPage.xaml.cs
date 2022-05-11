﻿using System;
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
    /// Логика взаимодействия для EditCounterpartyPage.xaml
    /// </summary>
    public partial class EditCounterpartyPage : Page
    {
        public Counterparties TempData { get; set; }

        public EditCounterpartyPage(Counterparties counterparties)
        {
            TempData = counterparties;
            InitializeComponent();
            this.DataContext = this;
        }

        private void EditCounterparty_Click(object sender, RoutedEventArgs e)
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