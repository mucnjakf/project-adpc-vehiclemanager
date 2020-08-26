using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DesktopUI.VehicleServicesWindows;
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
    /// Interaction logic for ServicePanel.xaml
    /// </summary>
    public partial class ServicePanel : UserControl
    {
        readonly Service service;
        readonly ServicesSqlRepository servicesSqlRepository;

        public ServicePanel(Service service)
        {
            InitializeComponent();

            servicesSqlRepository = new ServicesSqlRepository();

            this.service = service;

            SetServiceValues();
        }

        private void SetServiceValues()
        {
            LblDateIssued.Text = service.DateIssued.ToShortDateString();
            LblTimeIssued.Text = service.TimeIssued.ToString();
            LblTotalPrice.Text = service.TotalPrice.ToString();
            LblVehicle.Text = service.Vehicle.Make + " " + service.Vehicle.Model;
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            ShowVehicleServiceWindow showVehicleServiceWindow = new ShowVehicleServiceWindow(service);
            showVehicleServiceWindow.Show();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            bool success = servicesSqlRepository.Delete(service.Id);

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
