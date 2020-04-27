using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
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
    /// Interaction logic for EditDriverWindow.xaml
    /// </summary>
    public partial class EditDriverWindow : Window
    {
        DriversSqlRepository driversSqlRepository;

        private Driver driver;

        public EditDriverWindow(Driver driver)
        {
            InitializeComponent();

            driversSqlRepository = new DriversSqlRepository();

            this.driver = driver;

            LoadDriverToForm(driver);
        }

        private void LoadDriverToForm(Driver driver)
        {
            TbFirstName.Text = driver.FirstName;
            TbLastName.Text = driver.LastName;
            TbPhoneNumber.Text = driver.PhoneNumber;
            TbDriversLicenceNumber.Text = driver.DriversLicenceNumber;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            UpdateDriver();
        }

        private void UpdateDriver()
        {
            if (TbFirstName.Text != string.Empty && TbLastName.Text != string.Empty && TbPhoneNumber.Text != string.Empty && TbDriversLicenceNumber.Text != string.Empty)
            {
                Driver updatedDriver = new Driver()
                {
                    Id = driver.Id,
                    FirstName = TbFirstName.Text,
                    LastName = TbLastName.Text,
                    PhoneNumber = TbPhoneNumber.Text,
                    DriversLicenceNumber = TbDriversLicenceNumber.Text
                };

                bool success = driversSqlRepository.Update(updatedDriver);

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
                MessageBox.Show("All input fields are required");
            }            
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
