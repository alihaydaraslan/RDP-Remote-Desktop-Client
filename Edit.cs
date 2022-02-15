using System;

namespace RDP
{
    public partial class Edit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Edit()
        {
            InitializeComponent();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rDPDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.rDPDataSet.Users);
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (!(gridView1.PostEditor() && gridView1.UpdateCurrentRow()))
            {
                return;
            }

            this.usersTableAdapter.Update(this.rDPDataSet.Users);
        }
    }
}
