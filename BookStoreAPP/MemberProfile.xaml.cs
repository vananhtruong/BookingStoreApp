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
    /// Interaction logic for MemberProfile.xaml
    /// </summary>
    public partial class MemberProfile : UserControl
    {
        private readonly IBookManagementMemberService bookManagementMemberService;
        public BookManagementMember BookManagementMember { get; set; }


    public MemberProfile()
        {
            InitializeComponent();
            bookManagementMemberService = new BookManagementMemberService();
            Loaded += LoadData;
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
                txtFullName.Text = BookManagementMember.FullName;
                txtEmailAddress.Text = BookManagementMember.Email;
                txtPassword.Password = BookManagementMember.Password;
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BookManagementMember.FullName = txtFullName.Text;
                BookManagementMember.Email = txtEmailAddress.Text;
                BookManagementMember.Password = txtPassword.Password;

                   await bookManagementMemberService.Update(BookManagementMember);
                    MessageBox.Show("Update Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtFullName.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
            txtPassword.Password = string.Empty;
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Close();
            }
        }
    }
}
