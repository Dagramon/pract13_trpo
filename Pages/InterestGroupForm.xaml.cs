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
    /// Логика взаимодействия для InterestGroupForm.xaml
    /// </summary>
    public partial class InterestGroupForm : Page
    {
        InterestGroup _interestGroup = new();
        InterestGroupService service = new();
        bool IsEdit = false;
        public InterestGroupForm(InterestGroup? interestGroup = null)
        {
            InitializeComponent();
            if (interestGroup != null)
            {
                _interestGroup = interestGroup;
                IsEdit = true;
            }
            DataContext = _interestGroup;
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (IsEdit)
                service.Commit();
            else
                service.Add(_interestGroup);

            go_back(sender, e);
        }

        private void go_back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
