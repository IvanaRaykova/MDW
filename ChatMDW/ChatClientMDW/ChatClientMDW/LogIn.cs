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
    public partial class LogIn : Form
    {
        LoginClient proxy;
        Image Cancel = Resources.cancel;
        Image Padlock = Resources.padlock;
        Image PadlockOpen = Resources.padlockopen;
        //curve form
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
        public LogIn()
        {
            InitializeComponent();
            //textBox1.Text = "username";
            //textBox2.Text = "password";
            pictureBox2.Image = Cancel;
            pictureBox1.Image = Padlock;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.CenterToScreen();
            proxy = new LoginClient();

        }

 
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (proxy.Login(username, password))
            {
                pictureBox1.Image = PadlockOpen;
                this.Hide();
                new Form1(username).Show();

            }
            else
            {
                const string message = "There is no such a user! Do you want to make a registration with this username and password";
                const string caption = "Form Closing";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    proxy.Register(username, password);
                    label3.Text = "u have been registered";

                }


                label3.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

    }
}
