using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DesktopUI.CustomControls;
using DesktopUI.SharedWindows;
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

namespace DesktopUI.DriversWindows
{
    /// <summary>
    /// Interaction logic for DriversMainMenu.xaml
    /// </summary>
    public partial class DriversMainMenu : Window
    {
        DriversSqlRepository driversSqlRepository;

        public DriversMainMenu()
        {
            InitializeComponent();

            driversSqlRepository = new DriversSqlRepository();
        }



        private void BtnCreateDriver_Click(object sender, RoutedEventArgs e)
        {
            CreateDriverWindow createDriverWindow = new CreateDriverWindow();
            createDriverWindow.Show();
        }

        private void BtnBackToStart_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            LoadDriversToStackPanel();
        }

        private void LoadDriversToStackPanel()
        {
            SpDrivers.Children.Clear();

            List<Driver> drivers = driversSqlRepository.ReadAll();

            foreach (Driver driver in drivers)
            {
                DriverPanel driverPanel = new DriverPanel(driver);
                
                SpDrivers.Children.Add(driverPanel);
            }
        }
    }
}
