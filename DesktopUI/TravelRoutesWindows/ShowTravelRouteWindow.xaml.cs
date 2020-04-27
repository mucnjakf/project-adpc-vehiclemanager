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

namespace DesktopUI.TravelRoutesWindows
{
    /// <summary>
    /// Interaction logic for ShowTravelRoutesWindow.xaml
    /// </summary>
    public partial class ShowTravelRouteWindow : Window
    {
        public ShowTravelRouteWindow(TravelRoute travelRoute)
        {
            InitializeComponent();

            LoadTravelRouteValues(travelRoute);
        }

        private void LoadTravelRouteValues(TravelRoute travelRoute)
        {
            LblId.Text = travelRoute.Id.ToString();
            LblDateIssued.Text = travelRoute.DateIssued.ToShortDateString();
            LblTimeIssued.Text = travelRoute.TimeIssued.ToString();
            LblOrigin.Text = travelRoute.Origin;
            LblDestination.Text = travelRoute.Destination;
            LblKilometersTraveled.Text = travelRoute.KilometersTraveled.ToString();
            LblAverageSpeed.Text = travelRoute.AverageSpeed.ToString();
            LblSpentFuel.Text = travelRoute.SpentFuel.ToString();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
