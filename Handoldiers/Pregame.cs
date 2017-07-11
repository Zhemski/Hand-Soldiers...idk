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
    public partial class PreGame : Form
    {
        public PreGame()
        {
            InitializeComponent();
        }

        public CardCollection PlayerDeck = new CardCollection();
        public CardCollection OpponentDeck = new CardCollection();

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(radDeck1.Checked)    //player chooses urslava
            {
                PlayerDeck.BuildUrlsavaDeck();
                OpponentDeck.BuildPicklechewDeck();
            }
            else   //player chooses picklechew
            {
                PlayerDeck.BuildPicklechewDeck();
                OpponentDeck.BuildUrlsavaDeck();
            }
            this.Hide();
            var form2 = new PlayOrder(PlayerDeck, OpponentDeck);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
