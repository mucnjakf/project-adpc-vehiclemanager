using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DesktopUI.DriversWindows;
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
    /// Interaction logic for DriverPanel.xaml
    /// </summary>
    public partial class DriverPanel : UserControl
    {
        DriversSqlRepository driversSqlRepository;

        private Driver driver;

        public DriverPanel(Driver driver)
        {
            InitializeComponent();

            driversSqlRepository = new DriversSqlRepository();

            this.driver = driver;

            SetDriverValues();
        }

        private void SetDriverValues()
        {
            LblFirstName.Text = driver.FirstName;
            LblLastName.Text = driver.LastName;
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            ShowDriverWindow showDriverWindow = new ShowDriverWindow(driver);
            showDriverWindow.Show();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditDriverWindow editDriverWindow = new EditDriverWindow(driver);
            editDriverWindow.Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteDriver();
        }

        private void DeleteDriver()
        {
            bool success = driversSqlRepository.Delete(driver.Id);

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
