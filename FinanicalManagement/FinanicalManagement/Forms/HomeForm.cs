using FinanicalManagement.DTO;
using Lib.Common;
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
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Show();
            Dispose();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            LoadDatatoCmb();
            Display();
        }
        Dictionary<int, string> GetDataForDisplayInCmb(int cmbType)
        {
            return AccountDAO.Instance.GetDataForDisplayInCmb(cmbType);
        }
        void LoadDatatoCmb()
        {
            var itemsSortBy = GetDataForDisplayInCmb(CmbType.CmbSortNum);
            var itemsCmbUporDownNum = GetDataForDisplayInCmb(CmbType.CmbUporDownNum);
            var itemsCmbRecordsPerPageNum = GetDataForDisplayInCmb(CmbType.CmbRecordsPerPageNum);
            foreach (var item in itemsSortBy)
            {
                cmbSort.Items.Add(item.Value);
            }
            foreach (var item in itemsCmbUporDownNum)
            {
                cmbUpDown.Items.Add(item.Value);
            }
            foreach (var item in itemsCmbRecordsPerPageNum)
            {
                cmbRecordsPerPage.Items.Add(item.Value);
            }
        }
        public void Display()   // Display Method is a common method to bind the Student details in datagridview after save,update and delete operation perform.
        {
            using (FinancialManagementEntities _entity = new FinancialManagementEntities())
            {
                List<Account> accounts = new List<Account>();

                accounts = _entity.Accounts.ToList();
                dgvAccounts.DataSource = accounts;
            }
        }
    }
}
