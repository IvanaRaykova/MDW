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

namespace ChatClientMDW
{
    public partial class LogIn : Form
    {
        LoginClient proxy;
        public LogIn()
        {
            InitializeComponent();
            //textBox1.Text = "username";
            //textBox2.Text = "password";

            proxy = new LoginClient();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (proxy.Login(username,password))
            {
                this.Hide();
                new Form1(username).Show();

            }
            else
            {
                const string message = "There is no such a user?";
                const string caption = "Form Closing";
                var result = MessageBox.Show(message,caption,MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    proxy.Register(username,password);
                    label3.Text = "u have been registered";
                    
                }
               
                
                label3.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

    }
}
