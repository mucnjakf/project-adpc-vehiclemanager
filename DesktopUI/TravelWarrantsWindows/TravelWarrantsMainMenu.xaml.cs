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

namespace DesktopUI.TravelWarrantsWindows
{
    /// <summary>
    /// Interaction logic for TravelWarrantsMainMenu.xaml
    /// </summary>
    public partial class TravelWarrantsMainMenu : Window
    {
        TravelWarrantsSqlRepository travelWarrantsSqlRepository;
        public TravelWarrantsMainMenu()
        {
            InitializeComponent();

            travelWarrantsSqlRepository = new TravelWarrantsSqlRepository();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            LoadTravelWarrantsToStackPanel();
        }

        private void LoadTravelWarrantsToStackPanel()
        {
            SpTravelWarrants.Children.Clear();

            List<TravelWarrant> travelWarrants = travelWarrantsSqlRepository.ReadAll();

            foreach (TravelWarrant travelWarrant in travelWarrants)
            {
                TravelWarrantPanel travelWarrantPanel = new TravelWarrantPanel(travelWarrant);

                SpTravelWarrants.Children.Add(travelWarrantPanel);
            }
        }

        private void BtnBackToStart_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            Close();
        }

        private void BtnCreateTravelWarrant_Click(object sender, RoutedEventArgs e)
        {
            CreateTravelWarrantWindow createTravelWarrantWindow = new CreateTravelWarrantWindow();
            createTravelWarrantWindow.Show();
        }

        private void RbAll_Checked(object sender, RoutedEventArgs e)
        {
            SpTravelWarrants.Children.Clear(); 
            LoadTravelWarrantsToStackPanel();
        }

        private void RbOpen_Checked(object sender, RoutedEventArgs e)
        {
            SpTravelWarrants.Children.Clear();

            List<TravelWarrant> travelWarrants = travelWarrantsSqlRepository.ReadAll();

            foreach (TravelWarrant travelWarrant in travelWarrants)
            {
                if (travelWarrant.WarrantStatus == "Open")
                {
                    TravelWarrantPanel travelWarrantPanel = new TravelWarrantPanel(travelWarrant);

                    SpTravelWarrants.Children.Add(travelWarrantPanel);
                }
            }
        }

        private void RbClosed_Checked(object sender, RoutedEventArgs e)
        {
            SpTravelWarrants.Children.Clear();

            List<TravelWarrant> travelWarrants = travelWarrantsSqlRepository.ReadAll();

            foreach (TravelWarrant travelWarrant in travelWarrants)
            {
                if (travelWarrant.WarrantStatus == "Closed")
                {
                    TravelWarrantPanel travelWarrantPanel = new TravelWarrantPanel(travelWarrant);

                    SpTravelWarrants.Children.Add(travelWarrantPanel);
                }
            }
        }
    }
}
