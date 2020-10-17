using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P507Pr0ject
{
    public partial class Login : Form
    {
        private readonly P507ProjectEntities _db;
        public Login()
        {
            InitializeComponent();
            _db = new P507ProjectEntities();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register(this);
            register.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtLoginEmail.Text.Trim();
            string password = txtLoginPassword.Text.Trim();

            if (email == "" || password == "")
            {
                MessageBox.Show("Fill all input!!!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user = _db.Users.FirstOrDefault(u => u.Email == email);

            if (!IsValid(user, password))
            {
                return;
            }

            if (user.IsAdmin)
            {
                AdminPanel admin = new AdminPanel(this);
                admin.Show();
                this.Hide();
                return;
            }
            Dashboard dashboard = new Dashboard(this,user.Id);
            dashboard.Show();
            this.Hide();
        }

        private bool IsValid(User user,string password)
        {
            if (user == null)
            {
                MessageBox.Show("Not find user releted this email !!!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (user.IsDeleted)
            {
                MessageBox.Show("Your account is blocked !!!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!user.IsActivated)
            {
                MessageBox.Show("Please wait activation!!!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (user.Password != password.HashPassword())
            {
                MessageBox.Show("Password is wrong!!!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
