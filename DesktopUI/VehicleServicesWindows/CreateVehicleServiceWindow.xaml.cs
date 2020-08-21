using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DesktopUI.CustomControls;
using DesktopUI.ServiceItemsWindows;
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

namespace DesktopUI.VehicleServicesWindows
{
    /// <summary>
    /// Interaction logic for CreateVehicleServiceWindow.xaml
    /// </summary>
    public partial class CreateVehicleServiceWindow : Window
    {
        readonly ServiceItemsSqlRepository serviceItemsSqlRepository;
        readonly VehiclesSqlRepository vehiclesSqlRepository;
        
        public CreateVehicleServiceWindow()
        {
            InitializeComponent();

            serviceItemsSqlRepository = new ServiceItemsSqlRepository();
            vehiclesSqlRepository = new VehiclesSqlRepository();

            TbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            TbTime.Text = DateTime.Now.ToString("HH:MM:ss");
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnCreateServiceItem_Click(object sender, RoutedEventArgs e)
        {
            CreateServiceItemWindow createServiceItemWindow = new CreateServiceItemWindow();
            createServiceItemWindow.Show();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            LoadServiceItemsToStackPanel();
        }

        private void LoadServiceItemsToStackPanel()
        {
            SpServiceItems.Children.Clear();

            List<ServiceItem> serviceItems = serviceItemsSqlRepository.ReadAll();

            foreach (ServiceItem serviceItem in serviceItems)
            {
                ServiceItemPanel serviceItemPanel = new ServiceItemPanel(serviceItem);

                SpServiceItems.Children.Add(serviceItemPanel);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadVehiclesToComboBox();
        }

        private void LoadVehiclesToComboBox()
        {
            CbVehicles.ItemsSource = vehiclesSqlRepository.ReadAll();
        }
    }
}
