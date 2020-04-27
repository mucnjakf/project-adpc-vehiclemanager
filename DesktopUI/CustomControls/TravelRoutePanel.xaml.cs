using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DesktopUI.TravelRoutesWindows;
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
    /// Interaction logic for TravelRoutePanel.xaml
    /// </summary>
    public partial class TravelRoutePanel : UserControl
    {
        TravelRoutesSqlRepository travelRoutesSqlRepository;

        private TravelRoute travelRoute;

        public TravelRoutePanel(TravelRoute travelRoute)
        {
            InitializeComponent();

            travelRoutesSqlRepository = new TravelRoutesSqlRepository();

            this.travelRoute = travelRoute;

            SetTravelRouteValues();
        }

        private void SetTravelRouteValues()
        {
            LblId.Text = travelRoute.Id.ToString();
            LblOrigin.Text = travelRoute.Origin;
            LblDestination.Text = travelRoute.Destination;
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            ShowTravelRouteWindow showTravelRouteWindow = new ShowTravelRouteWindow(travelRoute);
            showTravelRouteWindow.Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            bool success = travelRoutesSqlRepository.Delete(travelRoute.Id);

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
