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

namespace P507Pr0ject.Medicines
{
    public partial class MedicineList : Form
    {
        private readonly P507ProjectEntities _db;
        public MedicineList()
        {
            InitializeComponent();
            _db = new P507ProjectEntities();
        }

        private void MedicineList_Load(object sender, EventArgs e)
        {
            cmbTypeMedicine.DataSource = _db.Types.Where(t => t.Deleted == false).Select(t => new CB_Type
            {
                Id = t.Id,
                Name = t.Name
            }).ToArray();
            RefreshDgv();
        }

        private void RefreshDgv()
        {
            dgvMedicineList.DataSource = _db.Medicines.Where(m => m.Deleted == false).Select(m => new
            {
                m.Name,
                Type = m.Type.Name,
                m.Price,
                m.Amount
            }).ToList();
        }

        private void RefreshAllField()
        {
            txtMedicineName.Text = "";
            nmMedicineAmout.Value = 0;
            nmPriceMedicine.Value = 0;
        }

        private async void btnCreateOrUpdateMed_Click(object sender, EventArgs e)
        {
            string name = txtMedicineName.Text.Trim().ToLower();
            if (name == "")
            {
                MessageBox.Show("eee doldur bu zibli");
                return;
            }
            int typeId = ((CB_Type)cmbTypeMedicine.SelectedItem).Id;
            int amount;
            try
            {
                amount = int.Parse(nmMedicineAmout.Value.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Please add only integer number");
                return;
            }
            decimal price = nmPriceMedicine.Value;

            Medicine medicineDb = _db.Medicines.FirstOrDefault(m => m.Name == name);

            if (medicineDb == null)
            {
                Medicine medicineNew = new Medicine
                {
                    Name = name,
                    TypesId = typeId,
                    Price = price,
                    Amount = amount
                };
                _db.Medicines.Add(medicineNew);
            }
            else
            {
                medicineDb.Amount = amount;
                medicineDb.TypesId = typeId;
                medicineDb.Price = price;
            }
            await _db.SaveChangesAsync();
            MessageBox.Show("Success");
            RefreshDgv();
            RefreshAllField();
        }

        private void dgvMedicineList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string name=dgvMedicineList.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            Medicine medicine = _db.Medicines.First(m => m.Name == name);
            txtMedicineName.Text = name;
            nmMedicineAmout.Value = (decimal)medicine.Amount;
            nmPriceMedicine.Value = medicine.Price;
            cmbTypeMedicine.SelectedIndex = cmbTypeMedicine.FindStringExact(medicine.Type.Name);
        }

        private void txtMedicineName_TextChanged(object sender, EventArgs e)
        {
            string searchMedicineName = txtMedicineName.Text.Trim().ToLower();

            if (searchMedicineName.Length > 1)
            {
                dgvMedicineList.DataSource = _db.Medicines.Where(m => m.Deleted == false&& m.Name.Contains(searchMedicineName)).Select(m => new
                {
                    m.Name,
                    Type = m.Type.Name,
                    m.Price,
                    m.Amount
                }).ToList();
            }

            if (searchMedicineName == "")
            {
                RefreshDgv();
            }
        }

        private async void btnDeleteMedicine_Click(object sender, EventArgs e)
        {
            string name = txtMedicineName.Text.Trim();
            Medicine medicine = _db.Medicines.FirstOrDefault(m => m.Name == name);

            if (medicine != null)
            {
                medicine.Deleted = true;
                await _db.SaveChangesAsync();
                RefreshDgv();
                RefreshAllField();
                MessageBox.Show("Deleted", "Deleted",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("This medicine is not exist!", "Information", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
