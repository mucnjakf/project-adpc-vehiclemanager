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

namespace DesktopUI.FuelCostsWindows
{
    /// <summary>
    /// Interaction logic for ShowFuelCostWindow.xaml
    /// </summary>
    public partial class ShowFuelCostWindow : Window
    {
        public ShowFuelCostWindow(FuelCost fuelCost)
        {
            InitializeComponent();

            LoadFuelCostValues(fuelCost);
        }

        private void LoadFuelCostValues(FuelCost fuelCost)
        {
            LblId.Text = fuelCost.Id.ToString();
            LblDateIssued.Text = fuelCost.DateIssued.ToShortDateString();
            LblTimeIssued.Text = fuelCost.TimeIssued.ToString();
            LblPosition.Text = fuelCost.Position;
            LblAmount.Text = fuelCost.Amount.ToString();
            LblPrice.Text = fuelCost.Price.ToString();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
