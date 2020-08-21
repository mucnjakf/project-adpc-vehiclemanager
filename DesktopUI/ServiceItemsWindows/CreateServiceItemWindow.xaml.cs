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

namespace DesktopUI.ServiceItemsWindows
{
    /// <summary>
    /// Interaction logic for CreateServiceItemWindow.xaml
    /// </summary>
    public partial class CreateServiceItemWindow : Window
    {
        readonly ServiceItemsSqlRepository serviceItemsSqlRepository;
        
        public CreateServiceItemWindow()
        {
            InitializeComponent();

            serviceItemsSqlRepository = new ServiceItemsSqlRepository();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            CreateServiceItem();
        }

        private void CreateServiceItem()
        {
            if (TbName.Text != string.Empty && TbPrice.Text != string.Empty)
            {
                if (decimal.TryParse(TbPrice.Text, out decimal price))
                {
                    ServiceItem createdServiceItem = new ServiceItem()
                    {
                        Name = TbName.Text,
                        Price = price
                    };

                    bool success = serviceItemsSqlRepository.Create(createdServiceItem);

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
                    MessageBox.Show("Price must be number");
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
