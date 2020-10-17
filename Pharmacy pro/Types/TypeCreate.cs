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
    public partial class TypeCreate : Form
    {
        private readonly P507ProjectEntities _db;
        public TypeCreate()
        {
            InitializeComponent();
            _db = new P507ProjectEntities();
        }

        private async void btnCreateType_Click(object sender, EventArgs e)
        {
            string typeName = txtCreateTypeName.Text.Trim();
            if (typeName == "")
            {
                MessageBox.Show("Fill all input !!!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_db.Types.Any(t => t.Name == typeName))
            {
                MessageBox.Show("This type name already exist !!!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Type type = new Type
            {
                Name = typeName
            };

            _db.Types.Add(type);
            await _db.SaveChangesAsync();

            MessageBox.Show("Succussfully added !!!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
