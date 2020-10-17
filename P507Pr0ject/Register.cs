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
    public partial class Register : Form
    {
        private readonly Form _login;
        private readonly P507ProjectEntities _db;
        public Register(Form login)
        {
            InitializeComponent();
            _login = login;
            _db = new P507ProjectEntities();
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Show();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtRgsEmail.Text.Trim();
            string fullname = txtRgsName.Text.Trim();
            string password = txtRgsPassword.Text.Trim();
            string checkPassword = txtRgsRepeatPassword.Text.Trim();

            if (!IsValid(email, fullname, password, checkPassword))
            {
                return;
            }

            bool emailInDb = _db.Users.Any(u => u.Email == email);

            if (emailInDb)
            {
                MessageBox.Show("This email already exist !!!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user = new User
            {
                Fullname = fullname,
                Password = password.HashPassword(),
                Email=email
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            MessageBox.Show("Successfully regiter. Please wait confirmation !!!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private bool IsValid(string email,string fullname,string password,string checkPassword)
        {
            if (email == "" || fullname == "" || password == "" || checkPassword == "")
            {
                MessageBox.Show("Fill all input!!!","Warning",
                                MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }

            if (!email.IsEmail())
            {
                MessageBox.Show("Please enter valid mail!!!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (password != checkPassword)
            {
                MessageBox.Show("Please repeat password correctly!!!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
