using FinanicalManagement.DTO;
using Lib.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace FinanicalManagement
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query = "SELECT * FROM dbo.Account WHERE UserName = N'" + userName + "' AND Password = N'" + passWord + "' ";

            DataTable result = DataProvider.Instance.ExecuteQuerytoDTbl(query);

            return result.Rows.Count > 0;
        }
        public Dictionary<int, string> GetDataForDisplayInCmb(int cmbType = 0)
        {
            var items = new Dictionary<int, string>();
            if (cmbType == CmbType.CmbSortNum)
            {
                string query = "SELECT * FROM dbo.Account";

                DataTable result = DataProvider.Instance.ExecuteQuerytoDTbl(query);
                if (result.Rows.Count > 0)
                {
                    for (var item = 0; item < result.Rows.Count; item++)
                    {
                        items.Add(item, result.Rows[item].ToString());
                    }
                    return items;
                }
            }
            else if (cmbType == CmbType.CmbUporDownNum)
            {
                items.Add(1, "ASC");
                items.Add(2, "DESC");
                return items;
            }
            else if (cmbType == CmbType.CmbRecordsPerPageNum)
            {
                items.Add(1, "10");
                items.Add(2, "20");
                items.Add(3, "50");
                items.Add(4, "100");
                items.Add(5, "All");
                return items;
            }
            return new Dictionary<int, string>();
        }
    }
}
