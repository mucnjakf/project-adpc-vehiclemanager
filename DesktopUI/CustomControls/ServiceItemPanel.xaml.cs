using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DesktopUI.ServiceItemsWindows;
using DesktopUI.VehiclesWindows;
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

namespace DesktopUI.CustomControls
{
    /// <summary>
    /// Interaction logic for ServiceItemPanel.xaml
    /// </summary>
    public partial class ServiceItemPanel : UserControl
    {
        readonly ServiceItemsSqlRepository serviceItemsSqlRepository;

        readonly ServiceItem serviceItem;

        public ServiceItemPanel(ServiceItem serviceItem)
        {
            InitializeComponent();

            serviceItemsSqlRepository = new ServiceItemsSqlRepository();

            this.serviceItem = serviceItem;

            SetServiceItemValues();
        }

        private void SetServiceItemValues()
        {
            LblName.Text = serviceItem.Name;
            LblPrice.Text = serviceItem.Price.ToString();
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            ShowServiceItemWindow showServiceItemWindow = new ShowServiceItemWindow(serviceItem);
            showServiceItemWindow.Show();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditServiceItemWindow editServiceItemWindow = new EditServiceItemWindow(serviceItem);
            editServiceItemWindow.Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            bool success = serviceItemsSqlRepository.Delete(serviceItem.Id);

            if (success)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }
    }
}
