using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DesktopUI.TravelWarrantsWindows;
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
    /// Interaction logic for TravelWarrantPanel.xaml
    /// </summary>
    public partial class TravelWarrantPanel : UserControl
    {
        TravelWarrantsSqlRepository travelWarrantsSqlRepository;

        private TravelWarrant travelWarrant;

        public TravelWarrantPanel(TravelWarrant travelWarrant)
        {
            InitializeComponent();

            travelWarrantsSqlRepository = new TravelWarrantsSqlRepository();

            this.travelWarrant = travelWarrant;

            SetTravelWarrantValues();
        }

        private void SetTravelWarrantValues()
        {
            LblWarrantStatus.Text = travelWarrant.WarrantStatus;
            LblDateIssued.Text = travelWarrant.DateIssued.ToShortDateString();
            LblTimeIssued.Text = travelWarrant.TimeIssued.ToString();
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            ShowTravelWarrantWindow showTravelWarrantWindow = new ShowTravelWarrantWindow(travelWarrant);
            showTravelWarrantWindow.Show();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            bool success = travelWarrantsSqlRepository.Delete(travelWarrant.Id);

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
