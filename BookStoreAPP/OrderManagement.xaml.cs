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
    /// Interaction logic for OrderManagement.xaml
    /// </summary>
    public partial class OrderManagement : UserControl
    {
        private readonly IOrderBookService booking;
        private ICollection<OrderBook> orders = new List<OrderBook>();
        public OrderManagement()
        {
            InitializeComponent();
            booking = new OrderBookService();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            var bookingDetails = await booking.GetAllOrderBook();
            orders = bookingDetails;
            dgBookingHistory.ItemsSource = null;
            dgBookingHistory.ItemsSource = bookingDetails;
        }
        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (dgBookingHistory.SelectedItem is OrderBook selectedBooking)
            {
                if (MessageBox.Show($"Are you sure you want to view detail of booking {selectedBooking.OrderBookId}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ViewOrderDetailDialog detailDialog = new ViewOrderDetailDialog()
                    {
                        orderBook = selectedBooking
                    };
                    detailDialog.load();
                    detailDialog.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to view.", "View Booking", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void dgBookingHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var list = orders.Where(t => t.Member.FullName.Contains(txtSearchName.Text)).ToList();
            dgBookingHistory.ItemsSource = null;
            dgBookingHistory.ItemsSource = list;
        }
    }
}
