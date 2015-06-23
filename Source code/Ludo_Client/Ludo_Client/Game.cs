using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LudoService;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Ludo_Client
{
    public partial class Game : Form ,IGameCallBack
    {
        GameReff.GameClient proxy;
        public string playername;

        public Game(string playername)
        {
            InitializeComponent();
            this.playername = playername;
            InstanceContext callback = new InstanceContext(this);
            proxy = new GameReff.GameClient(callback);
            proxy.Subscribe();
        }
        public void OnMovePiece(Player player)
        {
            this.Focus();
        }

        public void onMessageAdded(DateTime timestamp, string playerName, string message)
        {
            richTextBox1.AppendText(timestamp + ":" + playerName + ">" + message);
        }

        public void OnRollDie(Player player, int dieresult)
        {
            richTextBox1.AppendText(player.name +" rolled a " + dieresult.ToString());

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRollDie_Click(object sender, EventArgs e)
        {
            int dievalue = proxy.RollDie();
            richTextBox1.Text = "";
            richTextBox1.Focus();
            proxy.RollDieAsync();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = listBox1.Text;

            richTextBox1.Text = "";
            richTextBox1.Focus();

            proxy.AddMessageAsync(playername, message);

        }
        public void OnPlayerTurn(Player player)
        {
            if (player.isturn == true)
            {
            btnRollDie.Enabled = true;
            }
            else
            {
                btnRollDie.Enabled = false;
            }
            

        }
        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            proxy.Unsubscribe();
        }
    }
}
