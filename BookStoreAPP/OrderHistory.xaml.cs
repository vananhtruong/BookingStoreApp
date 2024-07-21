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
    /// Interaction logic for OrderHistory.xaml
    /// </summary>
    public partial class OrderHistory : UserControl
    {
        private ICollection<OrderBook> orders = new List<OrderBook>();
        private readonly IOrderBookService order;
        public BookManagementMember member { get; set; }
        public OrderHistory()
        {
            InitializeComponent();
            order = new OrderBookService();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            var orderDetails = await order.GetOrderBookByMemberId(member.MemberId);
            dgOrderHistory.ItemsSource = null;
            dgOrderHistory.ItemsSource = orderDetails;
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            OrderBooks orderDialog = new OrderBooks();
            orderDialog.member = member;
            orderDialog.Closed += async (s, args) =>
            {
                if (orderDialog.DialogResult == true)
                {
                    UserControl_Loaded(sender, e);
                }
            };
            orderDialog.ShowDialog();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrderHistory.SelectedItem is OrderBook selectedBooking)
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
        

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrderHistory.SelectedItem is OrderBook selectedOrder)
            {
                if (MessageBox.Show($"Are you sure you want to delete Customer {selectedOrder.OrderBookId}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    var orderBook = selectedOrder;
                    orderBook.OrderStatus = false;
                    await order.Update(orderBook);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to delete.", "Delete Booking", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void dgBookingHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
