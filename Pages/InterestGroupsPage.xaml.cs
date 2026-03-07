using pract12_trpo.Classes;
using pract12_trpo.Data.Service;

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

namespace pract12_trpo.Pages
{
    /// <summary>
    /// Логика взаимодействия для InterestGroupsPage.xaml
    /// </summary>
    public partial class InterestGroupsPage : Page
    {
        public InterestGroupService service { get; set; } = new();
        public InterestGroup? current { get; set; } = null;
        public InterestGroupsPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void go_edit(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new InterestGroupForm(current));
        }

        private void go_add(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InterestGroupForm());
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                if (
                    MessageBox.Show(
                    "Удалить группу интересов?",
                    "Удалить?",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes
                    )
                {
                    service.Remove(current);
                }
            }
            else
            {
                MessageBox.Show("Выберите группу для удаления", "Выберите группу",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void go_back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
