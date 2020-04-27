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

namespace DesktopUI.DriversWindows
{
    /// <summary>
    /// Interaction logic for ShowDriverWindow.xaml
    /// </summary>
    public partial class ShowDriverWindow : Window
    {
        public ShowDriverWindow(Driver driver)
        {
            InitializeComponent();

            LoadDriverValues(driver);
        }

        private void LoadDriverValues(Driver driver)
        {
            LblId.Text = driver.Id.ToString();
            LblFirstName.Text = driver.FirstName;
            LblLastName.Text = driver.LastName;
            LblPhoneNumber.Text = driver.PhoneNumber;
            LblDriversLicenceNumber.Text = driver.DriversLicenceNumber;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
