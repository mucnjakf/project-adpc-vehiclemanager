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

namespace DesktopUI.FuelCostsWindows
{
    /// <summary>
    /// Interaction logic for CreateFuelCost.xaml
    /// </summary>
    public partial class CreateFuelCostWindow : Window
    {
        FuelCostsSqlRepository fuelCostsSqlRepository;

        public CreateFuelCostWindow()
        {
            InitializeComponent();

            fuelCostsSqlRepository = new FuelCostsSqlRepository();

            TbDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            TbTime.Text = DateTime.Now.ToString("HH:MM:ss");
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            CreateFuelCost();            
        }

        private void CreateFuelCost()
        {
            if (TbDate.Text != string.Empty && TbTime.Text != string.Empty && TbPosition.Text != string.Empty && TbAmount.Text != string.Empty && TbPrice.Text != string.Empty)
            {
                if (DateTime.TryParse(TbDate.Text, out DateTime date) && TimeSpan.TryParse(TbTime.Text, out TimeSpan time) && float.TryParse(TbAmount.Text, out float amount) && decimal.TryParse(TbPrice.Text, out decimal price))
                {
                    if ((Regex.IsMatch(TbDate.Text, @"\d\d/\d\d/\d\d\d\d") || Regex.IsMatch(TbDate.Text, @"\d/\d\d/\d\d\d\d")) && Regex.IsMatch(TbTime.Text, @"\d\d:\d\d:\d\d"))
                    {
                        FuelCost createdFuelCost = new FuelCost()
                        {
                            DateIssued = date,
                            TimeIssued = time,
                            Position = TbPosition.Text,
                            Amount = amount,
                            Price = price
                        };

                        bool success = fuelCostsSqlRepository.Create(createdFuelCost);

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
                    MessageBox.Show("Amount and price must be numbers\nDate format must be: \"MM/dd/yyyy\"\nTime format must be: \"HH:MM:ss\"");
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
