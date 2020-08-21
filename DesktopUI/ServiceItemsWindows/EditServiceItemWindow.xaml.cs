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
    /// Interaction logic for EditServiceItemWindow.xaml
    /// </summary>
    public partial class EditServiceItemWindow : Window
    {
        readonly ServiceItemsSqlRepository serviceItemsSqlRepository;

        readonly ServiceItem serviceItem;

        public EditServiceItemWindow(ServiceItem serviceItem)
        {
            InitializeComponent();

            serviceItemsSqlRepository = new ServiceItemsSqlRepository();

            this.serviceItem = serviceItem;

            LoadServiceItemToForm(serviceItem);
        }

        private void LoadServiceItemToForm(ServiceItem serviceItem)
        {
            TbName.Text = serviceItem.Name;
            TbPrice.Text = serviceItem.Price.ToString();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            UpdateServiceItem();
        }

        private void UpdateServiceItem()
        {
            if (TbName.Text != string.Empty && TbPrice.Text != string.Empty)
            {
                if (decimal.TryParse(TbPrice.Text, out decimal price))
                {
                    ServiceItem updatedServiceItem = new ServiceItem()
                    {
                        Id = serviceItem.Id,
                        Name = TbName.Text,
                        Price = price
                    };

                    bool success = serviceItemsSqlRepository.Update(updatedServiceItem);

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
