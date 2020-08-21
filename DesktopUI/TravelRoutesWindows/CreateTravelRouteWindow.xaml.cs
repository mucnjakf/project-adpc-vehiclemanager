using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace DesktopUI.TravelRoutesWindows
{
    /// <summary>
    /// Interaction logic for CreateTravelRouteWindow.xaml
    /// </summary>
    public partial class CreateTravelRouteWindow : Window
    {
        readonly TravelRoutesSqlRepository travelRoutesSqlRepository;

        public CreateTravelRouteWindow()
        {
            InitializeComponent();

            travelRoutesSqlRepository = new TravelRoutesSqlRepository();

            TbDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            TbTime.Text = DateTime.Now.ToString("HH:MM:ss");
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            CreateTravelRoute();
        }

        private void CreateTravelRoute()
        {
            if (TbDate.Text != string.Empty && TbTime.Text != string.Empty && TbOrigin.Text != string.Empty && TbDestination.Text != string.Empty && TbKilometersTraveled.Text != string.Empty && TbAverageSpeed.Text != string.Empty && TbSpentFuel.Text != string.Empty)
            {
                if (DateTime.TryParse(TbDate.Text, out DateTime date) && TimeSpan.TryParse(TbTime.Text, out TimeSpan time) && float.TryParse(TbKilometersTraveled.Text, out float kilometersTraveled) && float.TryParse(TbAverageSpeed.Text, out float averageSpeed) && float.TryParse(TbSpentFuel.Text, out float spentFuel))
                {
                    if ((Regex.IsMatch(TbDate.Text, @"\d\d/\d\d/\d\d\d\d") || Regex.IsMatch(TbDate.Text, @"\d/\d\d/\d\d\d\d")) && Regex.IsMatch(TbTime.Text, @"\d\d:\d\d:\d\d"))
                    {
                        TravelRoute createdTravelRoute = new TravelRoute()
                        {
                            DateIssued = date,
                            TimeIssued = time,
                            Origin = TbOrigin.Text,
                            Destination = TbDestination.Text,
                            KilometersTraveled = kilometersTraveled,
                            AverageSpeed = averageSpeed,
                            SpentFuel = spentFuel
                        };

                        bool success = travelRoutesSqlRepository.Create(createdTravelRoute);

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
                    MessageBox.Show("Kilometers traveled, average speed and spent fuel must be numbers\nDate format must be: \"MM/dd/yyyy\"\nTime format must be: \"HH:MM:ss\"");
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
