using BusnessObject;
using Repositories;
using Service;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IBookManagementMemberService bookManagementMemberService;
        public MainWindow()
        {
            InitializeComponent();
            bookManagementMemberService = new BookManagementMemberService();
        }
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            BookManagementMember account = await bookManagementMemberService.GetMemberByEmail(txtEmail.Text);
            if (!String.IsNullOrEmpty(txtEmail.Text) && !String.IsNullOrEmpty(txtPassword.Password))
            {
                if (account != null && account.Password.Equals(txtPassword.Password))
                {
                    if (account.MemberRole == 1)
                    {
                        MessageBox.Show("Login Successful - You are Admin");
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login Successful - You are Member");
                        MemberWindow memberWindow = new MemberWindow();
                        memberWindow.bookManagement = account;
                        memberWindow.Show();
                    }

                    Close();
                }
                else
                {
                    MessageBox.Show("Invalid email or password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter email and password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            MemberRegister registerWindow = new MemberRegister();
            registerWindow.Show();

            Close();
        }
    }
}