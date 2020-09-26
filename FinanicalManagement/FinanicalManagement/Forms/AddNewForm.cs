using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanicalManagement
{
    public partial class AddNewForm : Form
    {
        public AddNewForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public bool SaveAccountDetail(Account acc) // calling SaveStudentMethod for insert a new record  
        {
            bool result = false;
            using (FinancialManagementEntities _entity = new FinancialManagementEntities())
            {
                _entity.Accounts.Add(acc);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
