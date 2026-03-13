using pract12_trpo.Classes;
using pract12_trpo.Data.Service;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public UsersService service { get; set; } = new();
        public User? user { get; set; } = null;

        public ObservableCollection<UserInterestGroup> currentUserGroups { get; set; } = new();
        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void AddNavigate(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddForm());
        }

        private void Edit(object sender, MouseButtonEventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Элемент не выбран");
                return;
            }
            NavigationService.Navigate(new AddForm(user));
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Элемент не выбран");
                return;
            }
            MessageBoxResult result = MessageBox.Show(
                "Вы действительно хотите удалить пользователя?",
                "Удалить",
                MessageBoxButton.YesNo
                );
            if (result == MessageBoxResult.Yes)
            {
                service.Remove(user);
            }
        }

        private void RolesNavigate(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RolesPage());
        }

        private void GoProfile_Click(object sender, RoutedEventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Элемент не выбран");
                return;
            }
            if (user.UserProfile == null)
            {
                MessageBox.Show("У пользователя нет профиля");
                return;
            }
            NavigationService.Navigate(new ProfilePage(user));
        }

        private void GoInterestGroup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InterestGroupsPage());
        }

        private void GoSignGroup_Click(object sender, RoutedEventArgs e)
        {
            if (user != null)
                NavigationService.Navigate(new SignGroupPage(user));
            else
                MessageBox.Show("Выберите пользователя");
        }

        private void ChangedUser(object sender, SelectionChangedEventArgs e)
        {
            if (user != null)
            {
                currentUserGroups.Clear();

                foreach (UserInterestGroup item in user.UserInterestGroups)
                {
                    currentUserGroups.Add(item);
                }
            }
        }
    }
}
