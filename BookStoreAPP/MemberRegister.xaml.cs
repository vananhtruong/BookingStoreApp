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
    /// Interaction logic for MemberRegister.xaml
    /// </summary>
    public partial class MemberRegister : Window
    {
        private readonly IBookManagementMemberService bookManagementMemberService;
        public MemberRegister()
        {
            InitializeComponent();
            bookManagementMemberService = new BookManagementMemberService();
        }
        public async void LoadData()
        {
            try
            {
                var employees = await bookManagementMemberService.GetAllMember();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of Members");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var employees = await bookManagementMemberService.GetAllMember();
                if (employees.Any(emp => emp.Email.Equals(txtEmail.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Email already exists! Please use a different email address.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; 
                }
                BookManagementMember book = new BookManagementMember();
                book.FullName = txtFullName.Text;
                book.Email = txtEmail.Text;
                book.Password = txtPassword.Password;
                book.MemberRole = 2;
                await bookManagementMemberService.Create(book);
                MessageBox.Show("Register Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadData();
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

        private async void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }
    }
}
