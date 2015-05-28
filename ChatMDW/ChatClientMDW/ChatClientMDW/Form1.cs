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
using System.Runtime.InteropServices;
using ChatClientMDW.Properties;

namespace ChatClientMDW
{
    public partial class Form1 : Form ,IChatCallback
    {
        DateTime dt;
        public string username;
        ChatClient chatProxy;
        Image Cancel = Resources.cancel;
        Image Send = Resources.sent;
        private bool isConnected = false;

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
        public Form1(string username)
        {
            InitializeComponent();
            pictureBox2.Image = Cancel;
            pictureBox1.Image = Send;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.CenterToScreen();
            InstanceContext callBackInstance = new InstanceContext(this);
            chatProxy = new ChatClient(callBackInstance);
            this.username = username;
            label1.Text = " Hello  " + username;
            chatProxy.Subscribe();
           
            foreach (var player in chatProxy.GetOnlinePlayers())
            {
                listBox2.Items.Add(player.name);
            }
            
            
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            chatProxy.UnSubscribe();


        }
        public void onMessageAdded(DateTime timestamp, string playerName, string message)
        {
            listBox1.Items.Add(timestamp + ":" + playerName + ">" + message);
        }
       
        public void OnOnline(string username)
        {
            listBox2.Items.Add(username);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PrivateChat().Show();

            chatProxy.PrivateSubscribe();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            this.Close();
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text;

            textBox1.Text = "";
            textBox1.Focus();

            chatProxy.AddMessageAsync(username, message);
        }
    }
}
