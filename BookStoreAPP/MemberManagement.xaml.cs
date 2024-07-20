using BusnessObject;
using Service;
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

namespace BookStoreAPP
{
    /// <summary>
    /// Interaction logic for MemberManagement.xaml
    /// </summary>
    public partial class MemberManagement : UserControl
    {
        private readonly IBookManagementMemberService customerService;
        public MemberManagement()
        {
            InitializeComponent();
            customerService = new BookManagementMemberService();
            LoadData();
        }
        private async void LoadData()
        {
            dgCustomers.ItemsSource = null;
            var customers = await customerService.GetAllMember();
            dgCustomers.ItemsSource = customers;
        }



        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                try
                {
                    var customers =await customerService.Search(txtSearch.Text);
                    dgCustomers.ItemsSource = null;
                    dgCustomers.ItemsSource = customers;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                LoadData();
            }
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addEditCustomerDialog = new AddEditCustomerDialog();
            if (addEditCustomerDialog.ShowDialog() == true)
            {
                var newCustomer = addEditCustomerDialog.Customer;
                await customerService.Create(newCustomer);
                
            }
            LoadData();
        }

        private async void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is BookManagementMember selectedCustomer)
            {
                var addEditCustomerDialog = new AddEditCustomerDialog(selectedCustomer);
                if (addEditCustomerDialog.ShowDialog() == true)
                {
                    var updatedCustomer = addEditCustomerDialog.Customer;
                    await customerService.Update(updatedCustomer);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.", "Edit Customer", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is BookManagementMember selectedCustomer)
            {
                if (MessageBox.Show($"Are you sure you want to delete Customer {selectedCustomer.FullName}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    await customerService.Delete(selectedCustomer.MemberId);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "Delete Customer", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
