
using DataAccess;
using BusnessObject;
using System.Windows;

namespace BookStoreAPP
{
    /// <summary>
    /// Interaction logic for AddEditCustomerDialog.xaml
    /// </summary>
    public partial class AddEditCustomerDialog : Window
    {
        public BookManagementMember Customer { get; set; }

        public AddEditCustomerDialog(BookManagementMember customer = null)
        {
            InitializeComponent();
            if (customer != null)
            {
                
                Customer = customer;
                
                txtFullName.Text = customer.FullName;
                txtEmail.Text = customer.Email;
                txtPassword.Text = customer.Password;
            }
            else
            {
                Customer = new BookManagementMember();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFullName.Text) &&
                !string.IsNullOrEmpty(txtEmail.Text) &&
                !string.IsNullOrEmpty(txtPassword.Text))
            {
                // All fields are filled, proceed with assigning values
                Customer.FullName = txtFullName.Text;
                Customer.Email = txtEmail.Text;
                Customer.MemberRole = 2;
                Customer.Password = txtPassword.Text;

                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
