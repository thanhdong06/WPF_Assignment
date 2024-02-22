using BO;
using Repository;
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

namespace WPF_Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IAccountRepo _accountRepo;
        ILoginService _loginService;
        private Member _member;
        public MainWindow(IAccountRepo accountRepo, Member member, ILoginService loginService)
        {
            InitializeComponent();
            _accountRepo = accountRepo;
            _member = member;
            _loginService = loginService;
        }
        public void loadMemberAccount()
        {
            lvAccounts.ItemsSource = _accountRepo.GetMemberAccounts();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                loadMemberAccount();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "load member account!");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            _loginService.Logout();
            Login loginWindow = new Login(_accountRepo, _loginService);
            loginWindow.Show();
            this.Close();
        }

        private void btn_Insert_Click(object sender, RoutedEventArgs e)
        {
            InsertWindow insertWindow = new InsertWindow(_accountRepo, _member);
            insertWindow.Show();
        }

        private void lvAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvAccounts.SelectedItems.Count > 0)
            {
                _member = (Member)lvAccounts.SelectedItems[0];
            }
        }
        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            
            if(_member != null)
            {
                UpdateWindow updateWindow = new UpdateWindow(_member);
                updateWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("You didnt chose anything!");
            }
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if(lvAccounts.SelectedItems != null)
            {
                Member selectedMember = (Member)lvAccounts.SelectedItems[0];

                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {selectedMember.Name}?", "Confirm Delete", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _accountRepo.DeleteMemberAccount(selectedMember);

                        loadMemberAccount();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error to delete !");
                    }
                }
                else
                {
                    Close();
                }
            }
        }
    }
}
