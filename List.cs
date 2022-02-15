using System;
using System.Data.SqlClient;

namespace RDP
{
    public partial class List : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DBAccess objDBAccess = new DBAccess();

        public List()
        {
            InitializeComponent();
        }

        private void List_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rDPDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.rDPDataSet.Users);
        }

        private void gridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Login login = new Login();
            login.txtIP.Text = gridView.GetRowCellValue(e.RowHandle, "IP_Address").ToString();
            login.txtUserName.Text = gridView.GetRowCellValue(e.RowHandle, "Username").ToString();
            login.txtPassword.Text = gridView.GetRowCellValue(e.RowHandle, "Password").ToString();
            login.txtDescription.Text = gridView.GetRowCellValue(e.RowHandle, "Description").ToString();
            login.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string IP_Address = txtIPAddress.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string description = txtDescription.Text;

            SqlCommand insertCommand = new SqlCommand("insert into Users(IP_Address,Username,Password,Description) values(@IP_Address,@username,@password,@description)");
            insertCommand.Parameters.AddWithValue("@IP_Address", IP_Address);
            insertCommand.Parameters.AddWithValue("@username", username);
            insertCommand.Parameters.AddWithValue("@password", password);
            insertCommand.Parameters.AddWithValue("@description", description);

            objDBAccess.executeQuery(insertCommand);

            this.usersTableAdapter.Fill(this.rDPDataSet.Users);

            txtIPAddress.Text = String.Empty;
            txtUsername.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtDescription.Text = String.Empty;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit edit = new Edit();
            edit.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.usersTableAdapter.Fill(this.rDPDataSet.Users);
        }
    }
}
