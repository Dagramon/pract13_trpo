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
    /// Логика взаимодействия для SignGroupPage.xaml
    /// </summary>
    public partial class SignGroupPage : Page
    {
        public InterestGroupService service { get; set; } = new();
        public UserInterestGroupService userInterestGroupService { get; set; } = new();
        public UserInterestGroup? userInterestGroup { get; set; } = new();
        public SignGroupPage(User user)
        {
            InitializeComponent();
            userInterestGroup.User = user;
            DataContext = this;
        }

        private void go_back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void sign(object sender, RoutedEventArgs e)
        {
            if (userInterestGroup.InterestGroup == null)
            {
                MessageBox.Show("Выберите группу интересов");
                return;
            }
            try
            {
                if (joinedPicker.Text == userInterestGroup.JoinedAt.ToString())
                {
                    userInterestGroupService.Add(userInterestGroup);
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
