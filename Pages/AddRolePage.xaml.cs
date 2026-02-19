using pract12_trpo.Classes;
using pract12_trpo.Data.Service;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для AddRolePage.xaml
    /// </summary>
    public partial class AddRolePage : Page
    {
        private RolesService service = new();
        public Role _role = new();
        bool isEdit = false;
        public AddRolePage(Role? role = null)
        {
            InitializeComponent();
            if (role != null)
            {
                service.LoadRelation(role, "Users");
                _role = role;
                isEdit = true;
            }
            DataContext = _role;
        }
        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                service.Commit();
            }
            else
            {
                service.Add(_role);
            }
            NavigationService.GoBack();
        }
    }
}
