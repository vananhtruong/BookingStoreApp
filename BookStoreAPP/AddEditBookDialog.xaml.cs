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
using System.Windows.Shapes;

namespace BookStoreAPP
{
    /// <summary>
    /// Interaction logic for AddEditBookDialog.xaml
    /// </summary>
    public partial class AddEditBookDialog : Window
    {
        public Book Customer { get; set; }
        private readonly IBookCategoryService categoryService;

        public  AddEditBookDialog(Book customer = null)
        {
            
            InitializeComponent();
            categoryService = new BookCategoryService();
            if (customer != null)
            {

                Customer = customer;
                txtname.Text = customer.BookName;
                txtdes.Text = customer.Description;
                dpReleaseDate.SelectedDate = customer.ReleaseDate?.ToDateTime(TimeOnly.MinValue);
                txtquantity.Text = customer.Quantity.ToString();
                txtprice.Text = customer.Price.ToString();
                cboCategory.SelectedValue = customer.BookCategoryId;
                txtauthor.Text = customer.Author;



            }
            else
            {
                Customer = new Book();
            }
            Load();
        }
        public async void Load()
        {
            var liscate = await categoryService.GetAllBookCategory();
            cboCategory.ItemsSource = liscate;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtname.Text) &&
                !string.IsNullOrEmpty(txtauthor.Text) &&
                !string.IsNullOrEmpty(txtdes.Text) &&
                !string.IsNullOrEmpty(txtprice.Text) &&
                !string.IsNullOrEmpty(txtquantity.Text) &&
                dpReleaseDate.SelectedDate!= null &&
                cboCategory.SelectedValue != null &&
                !string.IsNullOrEmpty(txtname.Text) &&
                !string.IsNullOrEmpty(txtdes.Text))
            {
                // All fields are filled, proceed with assigning values
                try
                {
                    Customer.BookName = txtname.Text;
                    Customer.Description = txtdes.Text;
                    Customer.ReleaseDate = DateOnly.FromDateTime(dpReleaseDate.SelectedDate.Value);
                    Customer.Quantity = int.Parse(txtquantity.Text);
                    Customer.Price = int.Parse(txtprice.Text);
                    Customer.BookCategoryId = (int)cboCategory.SelectedValue;
                    Customer.Author = txtauthor.Text;
                    Customer.BookImg = null;
                }
                catch
                {
                    MessageBox.Show("Please enter valid input!");
                    return;
                }

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
