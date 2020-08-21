using DataAccessLayer.Models;
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
using System.Windows.Shapes;

namespace DesktopUI.ServiceItemsWindows
{
    /// <summary>
    /// Interaction logic for ShowServiceItemWindow.xaml
    /// </summary>
    public partial class ShowServiceItemWindow : Window
    {
        public ShowServiceItemWindow(ServiceItem serviceItem)
        {
            InitializeComponent();

            LoadServiceItemValues(serviceItem);
        }

        private void LoadServiceItemValues(ServiceItem serviceItem)
        {
            LblId.Text = serviceItem.Id.ToString();
            LblName.Text = serviceItem.Name;
            LblPrice.Text = serviceItem.Price.ToString();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
