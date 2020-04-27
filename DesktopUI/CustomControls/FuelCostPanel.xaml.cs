using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DesktopUI.FuelCostsWindows;
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
    /// Interaction logic for FuelCostPanel.xaml
    /// </summary>
    public partial class FuelCostPanel : UserControl
    {
        FuelCostsSqlRepository fuelCostsSqlRepository;

        private FuelCost fuelCost;

        public FuelCostPanel(FuelCost fuelCost)
        {
            InitializeComponent();

            fuelCostsSqlRepository = new FuelCostsSqlRepository();

            this.fuelCost = fuelCost;

            SetFuelCostValues();
        }

        private void SetFuelCostValues()
        {
            LblId.Text = fuelCost.Id.ToString();
            LblAmount.Text = fuelCost.Amount.ToString();
            LblPrice.Text = fuelCost.Price.ToString();
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            ShowFuelCostWindow showFuelCostWindow = new ShowFuelCostWindow(fuelCost);
            showFuelCostWindow.Show();
        }  

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            bool success = fuelCostsSqlRepository.Delete(fuelCost.Id);

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
