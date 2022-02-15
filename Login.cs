using System;
using System.Windows.Forms;

namespace RDP
{
    public partial class Login : Form
    {
        public static string IPAddress = "";
        public static string userName = "";
        public static string password = "";
        public static string description = "";
        public Login()
        {
            InitializeComponent();
        }

        public void btnConnect_Click(object sender, EventArgs e)
        {
            IPAddress = txtIP.Text;
            password = txtPassword.Text;
            userName = txtUserName.Text;
            description = txtDescription.Text;

            axMsRdpClient6NotSafeForScripting1.Server = Login.IPAddress;
            axMsRdpClient6NotSafeForScripting1.UserName = Login.userName;
            axMsRdpClient6NotSafeForScripting1.AdvancedSettings2.ClearTextPassword = Login.password;
            axMsRdpClient6NotSafeForScripting1.AdvancedSettings7.EnableCredSspSupport = true;
            axMsRdpClient6NotSafeForScripting1.ColorDepth = 16;
            axMsRdpClient6NotSafeForScripting1.DesktopWidth = 1920;
            axMsRdpClient6NotSafeForScripting1.DesktopHeight = 1080;
            axMsRdpClient6NotSafeForScripting1.FullScreen = true;

            axMsRdpClient6NotSafeForScripting1.Connect();

            this.Hide();
        }
    }
}
