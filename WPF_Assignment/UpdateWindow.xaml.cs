using BO;
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
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        private Member _data;
        public UpdateWindow(Member data)
        {
            InitializeComponent();
            _data = data;

            tb_Id.Text = _data.Id.ToString();
            tb_Name.Text = _data.Name;
            tb_Email.Text = _data.Email;
            tb_Password.Text = _data.Password;
            cbx_Gender.Text = _data.Gender.ToString();
            cbx_Role.Text = _data.Role.ToString();

        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            if (_data != null)
            {
                _data.Id = int.Parse(tb_Id.Text);
                _data.Name = tb_Name.Text;
                _data.Email = tb_Email.Text;
                _data.Password = tb_Password.Text;
                _data.Gender = cbx_Gender.Text;
                _data.Role = int.Parse(cbx_Role.Text);
            }          
            this.Close();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
