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
    /// Interaction logic for ViewOrderDetailDialog.xaml
    /// </summary>
    public partial class ViewOrderDetailDialog : Window
    {
        public OrderBook orderBook { get; set; }
        private readonly IOrderBookDetailService orderBookService;
        public ViewOrderDetailDialog()
        {
            InitializeComponent();
            orderBookService = new OrderBookDetailService();
        }
        public async void load()
        {
            if (orderBook == null)
            {
                MessageBox.Show("OrderBook is not set.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var list = await orderBookService.GetAllOrderBookDetailByOrderId(orderBook.OrderBookId);
            txtname.Text = orderBook.Member.FullName;
            dgOrderDetail.ItemsSource = list;
            txtDate.Text = orderBook.OrderDate.ToString();
            txttotalorder.Text = orderBook.TotalPrice.ToString();
        }


        private void dgBookingHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
