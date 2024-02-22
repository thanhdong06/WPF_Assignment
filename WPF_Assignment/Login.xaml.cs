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
using System.Windows.Shapes;

namespace WPF_Assignment
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly IAccountRepo _accountRepo;
        private readonly ILoginService _loginService;
        public Login(IAccountRepo accountRepo,
                        ILoginService loginService)
        {
            InitializeComponent();
            _accountRepo = accountRepo;
            _loginService = loginService;
        }

    private void Login_Click(object sender, RoutedEventArgs e)
        {
            string email = tb_Email.Text;
            string password = pb_password.Password;

            Member member = _loginService.Login(email, password);

            if (member != null && member.Role.Equals(1))
            {
                MessageBox.Show("Login successful !");
                MainWindow mainWindow = new MainWindow(_accountRepo, member, _loginService);
                mainWindow.Show();
                this.Close();
            }
            else if (member != null && member.Role.Equals(2))
            {
                MessageBox.Show("You dont have permission!");
            }
            else
            {
                MessageBox.Show("Login failed. Please check your username and password.");
            }
        }
    }
}
