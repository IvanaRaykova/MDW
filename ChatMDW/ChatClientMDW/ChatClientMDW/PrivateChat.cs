using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatClientMDW.ServiceReference1;
using System.ServiceModel;
using ChatClientMDW.Properties;
using System.Runtime.InteropServices;

namespace ChatClientMDW
{
    public partial class PrivateChat : Form,IChatCallback
    {
        DateTime dt;
        public string username;
        ChatClient chatProxy;
        Image Cancel = Resources.cancel;
        Image Send = Resources.sent;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );
        public PrivateChat()
        {
            InitializeComponent();
            InstanceContext callBackInstance = new InstanceContext(this);
            pictureBox1.Image = Cancel;
            pictureBox2.Image = Send;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.CenterToScreen();
            chatProxy = new ChatClient(callBackInstance);
           // chatProxy.UnSubscribe();
            chatProxy.PrivateSubscribe();
        }


        public void onMessageAdded(DateTime timestamp, string playerName, string message)
        {
            listBox1.Items.Add(timestamp + ":" + playerName + ">" + message);
        }

        public void OnOnline(string username)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text;

            textBox1.Text = "";
            textBox1.Focus();
            chatProxy.AddPrivateMessage(username, message);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
