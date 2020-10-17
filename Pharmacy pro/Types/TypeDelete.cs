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

namespace P507Pr0ject.Types
{
    public partial class TypeDelete : Form
    {
        private readonly P507ProjectEntities _db;
        public TypeDelete()
        {
            InitializeComponent();
            _db = new P507ProjectEntities();
        }

        private void TypeDelete_Load(object sender, EventArgs e)
        {
            cmbTypeDelete.DataSource = _db.Types.Where(t=>t.Deleted==false).Select(t=>new CB_Type {
                Id=t.Id,
                Name=t.Name
            }).ToArray();
        }

        private async void btnDeleteType_Click(object sender, EventArgs e)
        {
            int Id = ((CB_Type)cmbTypeDelete.SelectedItem).Id;

            Type type = _db.Types.Find(Id);
            type.Deleted = true;
            await _db.SaveChangesAsync();

            MessageBox.Show("Succussfully delete !!!", "Deleted",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
