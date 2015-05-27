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
    public partial class PrivateChat : Form,IChatCallback
    {
        DateTime dt;
        public string username;
        ChatClient chatProxy;
        public PrivateChat()
        {
            InitializeComponent();
            InstanceContext callBackInstance = new InstanceContext(this);
            chatProxy = new ChatClient(callBackInstance);
           // chatProxy.UnSubscribe();
            chatProxy.PrivateSubscribe();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text;

            textBox1.Text = "";
            textBox1.Focus();
            chatProxy.AddPrivateMessage(username, message);
        }



        public void onMessageAdded(DateTime timestamp, string playerName, string message)
        {
            listBox1.Items.Add(timestamp + ":" + playerName + ">" + message);
        }

        public void OnOnline(string username)
        {
            
        }
    }
}
