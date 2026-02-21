using pract12_trpo.Classes;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace pract12_trpo.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage(User user)
        {
            InitializeComponent();
            DataContext = user;

            BitmapImage avatarImg = new BitmapImage();
            if (File.Exists(user.UserProfile.AvatarUrl))
            {
                avatarImg.BeginInit();
                avatarImg.UriSource = new Uri(user.UserProfile.AvatarUrl);
                avatarImg.EndInit();
            }
            else
            {
                avatarImg.BeginInit();
                avatarImg.UriSource = new Uri("C:\\Users\\st310-10\\Documents\\Карамов\\Images\\Error.png");
                avatarImg.EndInit();
            }

            Avatar.Source = avatarImg;
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
