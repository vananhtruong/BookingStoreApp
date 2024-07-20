using BusnessObject;
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

namespace BookStoreAPP
{
    /// <summary>
    /// Interaction logic for AddEditBookCategoryDialog.xaml
    /// </summary>
    public partial class AddEditBookCategoryDialog : Window
    {
        public BookCategory Customer { get; set; }

        public AddEditBookCategoryDialog(BookCategory customer = null)
        {
            InitializeComponent();
            if (customer != null)
            {

                Customer = customer;
                txtname.Text = customer.BookCategoryName;
                txtdes.Text = customer.Description;
            }
            else
            {
                Customer = new BookCategory();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtname.Text) &&
                !string.IsNullOrEmpty(txtdes.Text))
            {
                // All fields are filled, proceed with assigning values
                Customer.BookCategoryName = txtname.Text;
                Customer.Description = txtdes.Text;
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
