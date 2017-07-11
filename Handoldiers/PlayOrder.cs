using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Handoldiers
{
    public partial class PlayOrder : Form
    {
        public int whosTurn = 0;
        public int PLAYERID = 0;
        public int OPPONENTID = 1;
        CardCollection PlayerDeck = new CardCollection();
        CardCollection OpponentDeck = new CardCollection();

        public PlayOrder(CardCollection playerDeck, CardCollection opponentDeck)
        {
            InitializeComponent();
            PlayerDeck = playerDeck;
            OpponentDeck = opponentDeck;
        }

        public int CoinFlip()
        {
            Random rnd = new Random();
            return rnd.Next() % 2;
        }

        #region Buttons
        private void btnPlayOrderHeads_Click(object sender, EventArgs e)
        {
            btnPlayOrderHeads.Enabled = false;
            btnPlayOrderTails.Enabled = false;

            if(CoinFlip() == 0)
            {
                pbPlayOrderCoin.Image = Properties.Resources.Heads;
                btnFirst.Enabled = true;
                btnSecond.Enabled = true;
            }
            else
            {
                pbPlayOrderCoin.Image = Properties.Resources.Tails;
                if(CoinFlip() == 0)
                {
                    rtbPlayOrder.Text = "Computer chose to go first";
                    btnPlayOrderContinue.Enabled = true;
                    whosTurn = OPPONENTID;
                }
                else
                {
                    rtbPlayOrder.Text = "Computer chose to go second";
                    btnPlayOrderContinue.Enabled = true;
                }
            }
        }

        private void btnPlayOrderTails_Click(object sender, EventArgs e)
        {
            btnPlayOrderHeads.Enabled = false;  //disable heads & tails buttons
            btnPlayOrderTails.Enabled = false;

            if (CoinFlip() == 0)   //heads, computer chooses
            {
                pbPlayOrderCoin.Image = Properties.Resources.Heads;
                if (CoinFlip() == 0) //heads, computer goes first
                {
                    rtbPlayOrder.Text = "Computer chose to go first";
                    btnPlayOrderContinue.Enabled = true;
                    whosTurn = OPPONENTID;
                }
                else  //tails, player goes first
                {
                    rtbPlayOrder.Text = "Computer chose to go second";
                    btnPlayOrderContinue.Enabled = true;
                    whosTurn = PLAYERID;
                }
            }
            else   //tails, player chooses
            {
                pbPlayOrderCoin.Image = Properties.Resources.Tails;
                btnFirst.Enabled = true;    //enable first and second button to choose order
                btnSecond.Enabled = true;
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new GameMat(PlayerDeck, OpponentDeck, whosTurn);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void btnSecond_Click(object sender, EventArgs e)
        {
            whosTurn = OPPONENTID;
            this.Hide();
            var form2 = new GameMat(PlayerDeck, OpponentDeck, whosTurn);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void btnPlayOrderContinue_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new GameMat(PlayerDeck, OpponentDeck, whosTurn);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
        #endregion
    }
}
