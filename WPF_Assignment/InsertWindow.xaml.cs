using BO;
using Repository;
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
    /// Interaction logic for InsertWindow.xaml
    /// </summary>
    public partial class InsertWindow : Window
    {
        private readonly IAccountRepo _accountRepo;
        private Member _member;
        public InsertWindow(IAccountRepo accountRepo, Member member)
        {
            InitializeComponent();
            _accountRepo = accountRepo;
            _member = member;
        }

        private Member GetMember()
        {
            Member member = null;
            try
            {
                member = new Member
                {
                    Id = int.Parse(tb_id.Text),
                    Name = tb_Name.Text,
                    Email = tb_Email.Text,
                    Password = pb_Password.Password,
                    Gender = cbx_Gender.Text,
                    Role = int.Parse(cbx_Role.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return member;
        }
        private void btn_Insert_Click(object sender, RoutedEventArgs e)
        {
            Member member = GetMember();
            _accountRepo.AddMemberAccounts(member);
            this.Close();
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
