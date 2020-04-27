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
    /// Interaction logic for CreateDriverWindow.xaml
    /// </summary>
    public partial class CreateDriverWindow : Window
    {
        DriversSqlRepository driversSqlRepository;

        public CreateDriverWindow()
        {
            InitializeComponent();

            driversSqlRepository = new DriversSqlRepository();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            CreateDriver();
        }

        private void CreateDriver()
        {
            if (TbFirstName.Text != string.Empty && TbLastName.Text != string.Empty && TbPhoneNumber.Text != string.Empty && TbDriversLicenceNumber.Text != string.Empty)
            {
                Driver createdDriver = new Driver()
                {
                    FirstName = TbFirstName.Text,
                    LastName = TbLastName.Text,
                    PhoneNumber = TbPhoneNumber.Text,
                    DriversLicenceNumber = TbDriversLicenceNumber.Text
                };

                bool success = driversSqlRepository.Create(createdDriver);

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
