using pract12_trpo.Classes;
using pract12_trpo.Data.Service;
using pract12_trpo.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для SelectedGroupPage.xaml
    /// </summary>
    public partial class SelectedGroupPage : Page
    {
        public InterestGroup? group { get; set; } = new();
        public UserInterestGroup? userInterestGroup { get; set; } = null;
        public UserProfile? Profile;
        public SelectedGroupPage(InterestGroup group)
        {
            InitializeComponent();

            this.group = group;
            DataContext = this;
            profilePanel.DataContext = new UserProfile();
        }

        private void go_back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CheckProfile(object sender, SelectionChangedEventArgs e)
        {
            if (userInterestGroup.User == null)
                return;

            if (userInterestGroup.User.UserProfile != null)
            {
                Profile = userInterestGroup.User.UserProfile;
                profilePanel.DataContext = Profile;
            }
            else
            {
                profilePanel.DataContext = new UserProfile();
            }
        }
    }
}
