using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DesktopUI.CustomControls;
using DesktopUI.ServiceItemsWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
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
        readonly ServicesSqlRepository servicesSqlRepository;

        public CreateVehicleServiceWindow()
        {
            InitializeComponent();

            serviceItemsSqlRepository = new ServiceItemsSqlRepository();
            vehiclesSqlRepository = new VehiclesSqlRepository();
            servicesSqlRepository = new ServicesSqlRepository();

            TbDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            TbTime.Text = DateTime.Now.ToString("HH:MM:ss");
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            CreateVehicleService();
        }

        private void CreateVehicleService()
        {
            if (TbDate.Text != string.Empty && TbTime.Text != string.Empty && CbVehicles.Text != string.Empty && SpServiceItems.Children.Count > 0)
            {
                if (DateTime.TryParse(TbDate.Text, out DateTime date) && (TimeSpan.TryParse(TbTime.Text, out TimeSpan time)))
                {
                    if (Regex.IsMatch(TbDate.Text, @"\d\d/\d\d/\d\d\d\d") && Regex.IsMatch(TbTime.Text, @"\d\d:\d\d:\d\d"))
                    {
                        decimal totalPrice = 0;
                        List<ServiceItem> serviceItems = new List<ServiceItem>();
                        
                        foreach (ServiceItemPanel serviceItemPanel in SpServiceItems.Children)
                        {
                            if (serviceItemPanel.ChBxServiceItem.IsChecked == true)
                            {
                                totalPrice += decimal.Parse(serviceItemPanel.LblPrice.Text);
                            }
                        }

                        for (int i = 0; i < SpServiceItems.Children.Count; i++)
                        {
                            ServiceItemPanel serviceItemPanel = (ServiceItemPanel)SpServiceItems.Children[i];

                            if (serviceItemPanel.ChBxServiceItem.IsChecked == true)
                            {
                                int serviceItemId = int.Parse(serviceItemPanel.LblId.Text);
                                ServiceItem serviceItem = serviceItemsSqlRepository.ReadById(serviceItemId);
                                serviceItems.Add(serviceItem);
                            }
                        }

                        int vehicleId = int.Parse(CbVehicles.Text.Substring(0, CbVehicles.Text.IndexOf(' ')));
                        Vehicle vehicle = vehiclesSqlRepository.ReadById(vehicleId);

                        Service service = new Service()
                        {
                            DateIssued = date,
                            TimeIssued = time,
                            TotalPrice = totalPrice
                        };

                        bool success = servicesSqlRepository.Create(service, vehicle, serviceItems);

                        if (success)
                        {
                            MessageBox.Show("Success");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Fail");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Date format must be: \"MM/dd/yyyy\"\nTime format must be: \"HH:MM:ss\"");
                    }
                }
                else
                {
                    MessageBox.Show("Date format must be: \"MM/dd/yyyy\"\nTime format must be: \"HH:MM:ss\"");
                }
            }
            else
            {
                MessageBox.Show("All input fields are required");
            }
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
