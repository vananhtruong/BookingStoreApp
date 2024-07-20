using BusnessObject;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    /// Interaction logic for OrderBooks.xaml
    /// </summary>
    public partial class OrderBooks : Window
    {
        public Book Book { get; set; }
        public BookManagementMember member { get; set; }

        private readonly IBookService bookService;
        private readonly IOrderBookService orderBookService;
        public OrderBook Order { get; private set; }
        private Book book { get; set; }
        private OrderBookDetail detail { get; set; }
        public List<OrderBookDetail> orderDetailsDTOs { get; set; }
        public OrderBooks()
        {
            InitializeComponent();
            bookService = new BookService();
            orderBookService = new OrderBookService();
            if (Order is null)
            {
                Order = new OrderBook();
                orderDetailsDTOs = new List<OrderBookDetail>();
            }
            //else
            //{
            //    bookingDetailsDTOs = Booking.BookingDetails;
            //}

            Loaded += LoadBook;
            Loaded += LoadOrderDetails;
        }
        private async void LoadBook(object sender, RoutedEventArgs e)
        {
            var data = await bookService.GetAllBook();
            dgBook.ItemsSource = null;
            dgBook.ItemsSource = data;
        }

        private async void LoadOrderDetails(object sender, RoutedEventArgs e)
        {
            var selectedOrderDetail = dgOrderDetails.SelectedItem;
            dgOrderDetails.ItemsSource = null;
            dgOrderDetails.ItemsSource = orderDetailsDTOs;
            if (selectedOrderDetail != null && orderDetailsDTOs.Contains(selectedOrderDetail))
            {
                dgOrderDetails.SelectedItem = selectedOrderDetail;
            }
            //txtTotalPrice.Text = CalculateTotalPrice().ToString();
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                try
                {
                    var book = await bookService.Search(txtSearch.Text);
                    dgBook.ItemsSource = null;
                    dgBook.ItemsSource = book;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                LoadBook(sender, e);
            }
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (dgBook.SelectedItems.Count > 0)
            {
                book = (Book)dgBook.SelectedItem;
                detail = (OrderBookDetail)dgOrderDetails.SelectedItem;

                foreach (var r in orderDetailsDTOs)
                {

                    if (r.Book.BookId == book.BookId)
                    {
                        MessageBox.Show("Book has in list");
                        return;
                    }
                }
                var TotalPrice = (book.Price * int.Parse(txtQuantity.Text));

                var orderDetail = new OrderBookDetail()
                {
                    Book = book,
                    Quantity = int.Parse(txtQuantity.Text),
                    TotalPrice = TotalPrice,

                };
                orderDetailsDTOs.Add(orderDetail);
                txtTotalPrice.Text = CalculateTotalPrice().ToString();
                LoadOrderDetails(sender, e);
            }
        }





        private decimal? CalculateTotalPrice()
        {
            decimal? total = 0;
            foreach (var item in orderDetailsDTOs)
            {
                total += (item.TotalPrice);
            }

            return total;
        }

        private async void dgBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgBook.SelectedItems.Count > 0)
            {
                book = (Book)dgBook.SelectedItem;
                txtBookCategoryName.Text = book.BookCategory.BookCategoryName;
                txtBookName.Text = book.BookName;
                txtReleaseDate.Text = book.ReleaseDate.ToString();
                txtDescription.Text = book.Description;
                txtPrice.Text = book.Price.ToString();
                txtAuthor.Text = book.Author;
                txtQuantity.TextChanged += (s, args) =>
                {
                    if (int.TryParse(txtQuantity.Text, out int quantity))
                    {
                        txtQuantity.Text = quantity.ToString();
                    }
                };
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrderDetails.SelectedItems.Count > 0)
            {
                var orderdetail = (OrderBookDetail)dgOrderDetails.SelectedItem;
                orderDetailsDTOs.Remove(orderdetail);
                LoadOrderDetails(sender, e);
            }
        }

        private async void dgBookingDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgOrderDetails.SelectedItems.Count > 0)
            {
                detail = (OrderBookDetail)dgOrderDetails.SelectedItem;
                txtBookNamedt.Text = book.BookName;
                txtBookCategoryNamedt.Text = book.BookCategory.BookCategoryName;
                txtReleaseDatedt.Text = book.ReleaseDate.ToString();
                txtDescriptiondt.Text = book.Description;
                txtAuthordt.Text = book.Author;
                txtQuantitydt.Text = detail.Quantity.ToString();
                txtActualPrice.Text = detail.TotalPrice.ToString();
            }
        }
        private async void txtDecrease_Click(object sender, RoutedEventArgs e)
        {
            if (detail.Quantity > 0 && detail.Quantity <= book.Quantity)
            {
                detail.Quantity = (int.Parse(txtQuantitydt.Text) - 1);
            }
            if (detail.Quantity == 0)
                btnDelete_Click(sender, e);
            txtQuantitydt.Text = detail.Quantity.ToString();
            detail.TotalPrice = detail.Quantity * book.Price;
            txtTotalPrice.Text = CalculateTotalPrice().ToString();
            txtActualPrice.Text = detail.TotalPrice.ToString();
            LoadOrderDetails(sender, e);
        }

        private async void txtIncrease_Click(object sender, RoutedEventArgs e)
        {
            if (detail.Quantity > 0 && detail.Quantity < book.Quantity)
            {
                detail.Quantity = (int.Parse(txtQuantitydt.Text)) + 1;
            }
            else
            {
                MessageBox.Show("The store don't enough book");
            }
            txtQuantitydt.Text = detail.Quantity.ToString();
            detail.TotalPrice = detail.Quantity * book.Price;
            txtTotalPrice.Text = CalculateTotalPrice().ToString();
            txtActualPrice.Text = detail.TotalPrice.ToString();
            LoadOrderDetails(sender, e);
        }
        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order.OrderDate = DateOnly.FromDateTime(DateTime.Now);
                Order.OrderStatus = true;
                Order.TotalPrice = CalculateTotalPrice();
                Order.MemberId = 1;

                // Ensure RoomInformation entities are retrieved correctly
                foreach (var detail in orderDetailsDTOs)
                {
                    var existingBook = bookService.GetBookById(detail.Book.BookId);
                    if (existingBook != null)
                    {
                        detail.Book = await existingBook;
                    }
                }

                orderBookService.AddOrder(Order, orderDetailsDTOs);
                //reset data
                Order = null;
                orderDetailsDTOs = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }


    }
}
