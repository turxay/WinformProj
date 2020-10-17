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
    public partial class Report : Form
    {
        private readonly P507ProjectEntities _db;
        public Report()
        {
            InitializeComponent();
            _db = new P507ProjectEntities();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            List<SalesDetail> report = _db.SalesDetails.ToList();

            foreach (SalesDetail item in report)
            {
                List<SaleMedicine> saleMedicines = _db.SaleMedicines.Where(sm => sm.SaleId == item.Id).ToList();
                string allMedicines = "";
                foreach (SaleMedicine saleM in saleMedicines)
                {
                    allMedicines += saleM.Medicine.Name + "-" + saleM.Amount+"  ";
                }

                dgvReport.Rows.Add(item.Id, item.Fullname, item.Email, item.Total, item.Time, allMedicines);
            }
        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            dgvReport.Rows.Clear();

            List<SalesDetail> report = _db.SalesDetails
                .Where(sd=>sd.Time>=startDate.Value.Date&&sd.Time<=endDate.Value.Date).ToList();

            foreach (SalesDetail item in report)
            {
                List<SaleMedicine> saleMedicines = _db.SaleMedicines.Where(sm => sm.SaleId == item.Id).ToList();
                string allMedicines = "";
                foreach (SaleMedicine saleM in saleMedicines)
                {
                    allMedicines += saleM.Medicine.Name + "-" + saleM.Amount + "  ";
                }

                dgvReport.Rows.Add(item.Id, item.Fullname, item.Email, item.Total, item.Time, allMedicines);
            }
        }
    }
}
