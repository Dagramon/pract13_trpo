using pract12_trpo.Classes;
using pract12_trpo.Data.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RolesPage.xaml
    /// </summary>
    public partial class RolesPage : Page
    {
        public RolesService service { get; set; } = new();
        public UsersService usersService { get; set; } = new();
        public Role? current { get; set; } = null;

        public Role? Role { get; set; }
        public ObservableCollection<User> users { get; set; } = new();
        public RolesPage()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddRole(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddRolePage());
        }
        private void edit(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                NavigationService.Navigate(new AddRolePage(current));
            }
            else
            {
                MessageBox.Show("Выберите роль");
            }
        }
        private void remove(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить роль?",
                "Удалить роль?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    service.Remove(current);
                }
            }
            else
            {
                MessageBox.Show("Выберите роль для удаления", "Выберите роль",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ComboBoxRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            users.Clear();
            usersService.GetAll();
            foreach (var user in UsersService.Users)
            {
                if (user.Role == Role)
                    users.Add(user);
            }
        }
    }
}
