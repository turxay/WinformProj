using P507Pr0ject.Medicines;
using P507Pr0ject.Types;
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
    public partial class AdminPanel : Form
    {
        private readonly Form _login;
        private readonly P507ProjectEntities _db;
        private enum Grant {Activate=0,Admin=1,Delete=2 }
        public AdminPanel(Form login)
        {
            InitializeComponent();
            _login = login;
            _db = new P507ProjectEntities();
        }

        private void AdminPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            RefreshDgv();
            cmbCase.DataSource = Enum.GetValues(typeof(Grant));

        }

        private void RefreshDgv()
        {
            lbNewUserCount.Text = _db.Users.Count(u => u.IsActivated == false
                                                         && u.IsDeleted == false).ToString();
            dgvUsers.DataSource = _db.Users.Where(u => u.IsActivated == false && u.IsDeleted == false).
                Select(u => new
                {
                    u.Id,
                    u.Fullname,
                    u.Email,
                    u.IsActivated
                }).ToList();
            lbStatus.Text = "New Users";
        }

        private void RefreshDgvActivatedUser()
        {
            dgvUsers.DataSource = _db.Users.Where(u => u.IsActivated == true).
                Select(u => new
                {
                    u.Id,
                    u.Fullname,
                    u.Email,
                    u.IsActivated,
                    u.IsAdmin
                }).ToList();
            lbStatus.Text = "Activated Users";
        }

        private void RefreshDgvDeletedUser()
        {
            dgvUsers.DataSource = _db.Users.Where(u => u.IsDeleted == true).
                Select(u => new
                {
                    u.Id,
                    u.Fullname,
                    u.Email,
                    u.IsDeleted
                }).ToList();
            lbStatus.Text = "Deleted Users";
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUserEmail.Text=dgvUsers.Rows[e.RowIndex].Cells["Email"].Value.ToString();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (txtUserEmail.Text.Trim() == "")
            {
                MessageBox.Show("eee doldur o zadi");
                return;
            }
            User user = _db.Users.First(u => u.Email == txtUserEmail.Text.Trim());
            int SelectedCase = cmbCase.SelectedIndex;

            switch (SelectedCase)
            {
                case (int)Grant.Activate:
                    user.IsActivated = true;
                    user.IsDeleted = false;
                    user.IsAdmin = false;
                    break;
                case (int)Grant.Admin:
                    user.IsAdmin = true;
                    user.IsActivated = true;
                    user.IsDeleted = false;
                    break;
                case (int)Grant.Delete:
                    user.IsDeleted = true;
                    user.IsAdmin = false;
                    user.IsActivated = false;
                    break;
                default:
                    break;
            }
            await _db.SaveChangesAsync();
            txtUserEmail.Text = "";

            if(lbStatus.Text.Trim()== "New Users")
            {
                RefreshDgv();
            }else if(lbStatus.Text.Trim() == "Activated Users")
            {
                RefreshDgvActivatedUser();
            }
            else
            {
                RefreshDgvDeletedUser();
            }

            
        }

        private void newUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void activeUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshDgvActivatedUser();
        }

        private void deletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshDgvDeletedUser();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeCreate type = new TypeCreate();
            type.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeDelete type = new TypeDelete();
            type.ShowDialog();
        }

        private void medicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedicineList medicine = new MedicineList();
            medicine.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.ShowDialog();
        }
    }
}
