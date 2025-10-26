using System;
using System.Windows.Forms;
using LastMileAPP;

namespace LastMileAPP

{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_MouseClick(object sender, MouseEventArgs e)
        {
            bool ok = DatabaseCon.CheckLogin(UsernameText.Text, PasswordText.Text);

            if (ok)
            {
                var main = new MainApp();
                main.FormClosed += (s, args) => this.Close();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong credentials");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
