using P507Pr0ject.ViewModels;
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
    public partial class Dashboard : Form
    {
        private readonly Form _login;
        private readonly P507ProjectEntities _db;
        private readonly int _userId;
        public Dashboard(Form login,int Id)
        {
            InitializeComponent();
            _db = new P507ProjectEntities();
            _login = login;
            _userId = Id;
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            RefreshDgv();
            cmbMedicine.DataSource = _db.Medicines.Where(m=>m.Deleted==false).Select(m => new CB_Medicine
            {
                Id=m.Id,
                Name=m.Name,
                Price=m.Price,
                Amount=m.Amount
            }).ToArray();
        }

        private void RefreshDgv(string search=null)
        {
            dgvMedicines.Rows.Clear();
            List<Medicine> medicines;
            if (search == null)
            {
                medicines = _db.Medicines.Where(m => m.Deleted == false).ToList();
            }
            else
            {
                medicines= _db.Medicines.Where(m => m.Deleted == false)
                    .Where(m=>m.Name.Contains(search)||m.Type.Name.Contains(search)).ToList();
            }
            

            foreach (Medicine item in medicines)
            {
                dgvMedicines.Rows.Add(
                    item.Name,
                    item.Type.Name,
                    item.Price,
                    item.Amount
                );
            }

        }

        private void txtMedicineName_TextChanged(object sender, EventArgs e)
        {
            string seacrh = txtMedicineSearch.Text.Trim();
            if (seacrh.Length > 1)
            {
                RefreshDgv(seacrh);
            }

            if (seacrh.Length == 0)
            {
                RefreshDgv();
            }
        }

        private void dgvMedicines_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dgvMedicines.Rows[e.RowIndex].Cells[0].Value.ToString();
            cmbMedicine.SelectedIndex = cmbMedicine.FindStringExact(name);
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {

            CB_Medicine selectedMedicine = (CB_Medicine)cmbMedicine.SelectedItem;
            int amount =int.Parse(nmMedicineAmout.Value.ToString());

            if (amount > selectedMedicine.Amount)
            {
                MessageBox.Show("Say Db-den choxdur)))");
                return;
            }

            FillListBox(selectedMedicine,amount);

            selectedMedicine.Amount -= amount;

            decimal total = decimal.Parse(lbTotal.Text);
            total += selectedMedicine.Price * amount;
            lbTotal.Text = total.ToString();

            nmMedicineAmout.Value = 0;
        }

        private void FillListBox(CB_Medicine selectedMedicine,int amount)
        {
            foreach (LSB_Medicine item in lsbMedicine.Items)
            {
                if(item.Id== selectedMedicine.Id)
                {
                    lsbMedicine.Items.Remove(item);
                    item.Amount += amount;
                    lsbMedicine.Items.Add(item);
                    return;
                }
            }

            lsbMedicine.Items.Add(new LSB_Medicine
            {
                Id = selectedMedicine.Id,
                Name = selectedMedicine.Name,
                Amount = amount,
                Price = selectedMedicine.Price
            });
        }

        private void btnRemoveList_Click(object sender, EventArgs e)
        {
            LSB_Medicine selectedMedicine = (LSB_Medicine)lsbMedicine.SelectedItem;
            foreach (CB_Medicine item in cmbMedicine.Items)
            {
                if (selectedMedicine.Id == item.Id)
                {
                    item.Amount += selectedMedicine.Amount;
                }
            }
            lsbMedicine.Items.Remove(selectedMedicine);
            decimal total = decimal.Parse(lbTotal.Text);
            total -= selectedMedicine.Price * (int)selectedMedicine.Amount;
            lbTotal.Text = total.ToString();
        }

        private async void btnBuy_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Today;
            decimal total = decimal.Parse(lbTotal.Text);

            Sale sale = new Sale
            {
                Time = date,
                Total = total,
                UserId = _userId
            };

            foreach (LSB_Medicine item in lsbMedicine.Items)
            {
                sale.SaleMedicines.Add(new SaleMedicine
                {
                    SaleId=sale.Id,
                    MedicineId=item.Id,
                    Amount=(int)item.Amount
                });
            }
            DecreaseMedicineAmount();
            _db.Sales.Add(sale);
            await _db.SaveChangesAsync();
            lsbMedicine.Items.Clear();
            lbTotal.Text = "0.00";
            RefreshDgv();
        }

        private void DecreaseMedicineAmount()
        {
            foreach (LSB_Medicine item in lsbMedicine.Items)
            {
                Medicine dbMedicine = _db.Medicines.Find(item.Id);
                dbMedicine.Amount -= item.Amount;
            }
        }
    }
}
