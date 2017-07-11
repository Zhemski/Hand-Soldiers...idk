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
    public partial class GameMat : Form
    {
        #region Fields
        private int numberOfTurns = 1;
        private int currentPhase = 50;
        private int playerID = 0;
        private int opponentID = 1;
        private int whosTurn;
        private string cardToDiscard;
        private bool discard = false;
        private bool battle = false;
        private string drawnCard;
        private Card selectedCard;
        private int selectedCardSlotHand;
        private int playerLife = 100;
        private int opponentLife = 100;
        private bool placeOnField = false;
        #endregion

        #region Properties
        public int NumberOfTurns
        {
            get { return numberOfTurns; }
            set
            {
                numberOfTurns = value;
                UpdateTurnCount();
            }
        }
        public int CurrentPhase
        {
            get { return currentPhase; }
            set
            {
                currentPhase = value;
                SelectedCard = null;
                DISCARD = false;
                Battle = false;
                switch (value)
                {
                    case (int)Phases.DRAW:
                        rtbCurrentEvent.Text = "Draw Phase";
                        lblDraw.ForeColor = Color.Red;
                        lblPreBattle.ForeColor = Color.White;
                        lblBattle.ForeColor = Color.White;
                        lblPostBattle.ForeColor = Color.White;
                        lblRefresh.ForeColor = Color.White;
                        lblEnd.ForeColor = Color.White;
                        btnNextPhase.Enabled = false;
                        DrawPhase();
                        break;
                    case (int)Phases.PREBATTLE:
                        rtbCurrentEvent.Text = "Pre-Battle Phase";
                        lblDraw.ForeColor = Color.White;
                        lblPreBattle.ForeColor = Color.Red;
                        lblBattle.ForeColor = Color.White;
                        lblPostBattle.ForeColor = Color.White;
                        lblRefresh.ForeColor = Color.White;
                        lblEnd.ForeColor = Color.White;
                        PreBattlePhase();
                        break;
                    case (int)Phases.BATTLE:
                        rtbCurrentEvent.Text = "Battle Phase";
                        lblDraw.ForeColor = Color.White;
                        lblPreBattle.ForeColor = Color.White;
                        lblBattle.ForeColor = Color.Red;
                        lblPostBattle.ForeColor = Color.White;
                        lblRefresh.ForeColor = Color.White;
                        lblEnd.ForeColor = Color.White;
                        BattlePhase();
                        break;
                    case (int)Phases.POSTBATTLE:
                        rtbCurrentEvent.Text = "Post-Battle Phase";
                        lblDraw.ForeColor = Color.White;
                        lblPreBattle.ForeColor = Color.White;
                        lblBattle.ForeColor = Color.White;
                        lblPostBattle.ForeColor = Color.Red;
                        lblRefresh.ForeColor = Color.White;
                        lblEnd.ForeColor = Color.White;
                        PostBattlePhase();
                        break;
                    case (int)Phases.REFRESH:
                        rtbCurrentEvent.Text = "Refresh Phase";
                        lblDraw.ForeColor = Color.White;
                        lblPreBattle.ForeColor = Color.White;
                        lblBattle.ForeColor = Color.White;
                        lblPostBattle.ForeColor = Color.White;
                        lblRefresh.ForeColor = Color.Red;
                        lblEnd.ForeColor = Color.White;
                        RefreshPhase();
                        break;
                    case (int)Phases.END:
                        rtbCurrentEvent.Text = "End Phase";
                        lblDraw.ForeColor = Color.White;
                        lblPreBattle.ForeColor = Color.White;
                        lblBattle.ForeColor = Color.White;
                        lblPostBattle.ForeColor = Color.White;
                        lblRefresh.ForeColor = Color.White;
                        lblEnd.ForeColor = Color.Red;
                        EndPhase();
                        break;
                }
            }
        }
        public int PlayerID
        {
            get { return playerID; }
        }
        public int OpponentID
        {
            get { return opponentID; }
        }
        public int WhosTurn
        {
            get { return whosTurn; }
            set
            {
                whosTurn = value;
                CurrentPhase = (int)Phases.DRAW;
                TurnLabel();
            }
        }
        public string CardToDiscard
        {
            get { return cardToDiscard; }
            set { cardToDiscard = value; }
        }
        public string DrawnCard
        {
            get { return drawnCard; }
            set { drawnCard = value; }
        }
        public Card SelectedCard
        {
            get { return selectedCard; }
            set { selectedCard = value; }
        }
        public int SelectedCardSlotHand
        {
            get { return selectedCardSlotHand; }
            set { selectedCardSlotHand = value; }
        }
        public bool DISCARD
        {
            get { return discard; }
            set
            {
                discard = value;
            }
        }
        public bool Battle
        {
            get { return battle; }
            set { battle = value; }
        }
        public int PlayerLife
        {
            get { return playerLife; }
            set { playerLife = value; }
        }
        public int OpponentLife
        {
            get { return opponentLife; }
            set { opponentLife = value; }
        }
        public bool PlaceOnField
        {
            get { return placeOnField; }
            set { placeOnField = value; }
        }
        public Card Attacker { get; set; }
        public Card Defender { get; set; }
        #endregion

        #region Card Collection
        CardCollection PlayerDeck = new CardCollection();
        CardCollection PlayerHand = new CardCollection();
        CardCollection PlayerDiscard = new CardCollection();
        CardCollection PlayerItems = new CardCollection();
        CardCollection PlayerSoldiers = new CardCollection();

        CardCollection OpponentDeck = new CardCollection();
        CardCollection OpponentHand = new CardCollection();
        CardCollection OpponentDiscard = new CardCollection();
        CardCollection OpponentItems = new CardCollection();
        CardCollection OpponentSoldiers = new CardCollection();
        #endregion

        public GameMat(CardCollection playerDeck, CardCollection opponentDeck, int turn)
        {
            InitializeComponent();

            PlayerDeck = playerDeck;
            OpponentDeck = opponentDeck;

            whosTurn = turn;
        }

        #region Phases
        private void StartGame()
        {
            PlayerDeck.ShuffleDeck();
            OpponentDeck.ShuffleDeck();
            DealHand(PlayerDeck);
            DisplayHand(PlayerID);
            DealHand(OpponentDeck);
            btnContinue.Text = "Continue";
            btnContinue.Enabled = false;
            btnNextPhase.Enabled = true;
            CurrentPhase = 0;
            UpdateTurnCount();
            TurnLabel();
            
            //for testing purposes
            OpponentSoldiers.Add(new MarigoldMugger());
            DisplaySoldiers(OpponentID);
        }
        private void DrawPhase()
        {
            if (WhosTurn == PlayerID)
            {
                pbDeckBottom.Enabled = true;
                rtbCurrentEvent.Text = "Draw a card";
            }
            else if (WhosTurn == OpponentID)
            {
                Draw(1, OpponentID);
                btnNextPhase.Enabled = true;
            }
        }
        private void PreBattlePhase()
        {
            if (WhosTurn == PlayerID)
            {
                btnNextPhase.Enabled = true;
                btnTop.Enabled = true;
                btnBottom.Enabled = true;

            }
            else
            {
                ComputerPreBattlePhase();
                btnNextPhase.Enabled = true;
            }
        }
        private void ComputerPreBattlePhase()
        {

        }
        private void BattlePhase()
        {
            if (WhosTurn == PlayerID)
            {
                btnNextPhase.Enabled = true;
                btnTop.Enabled = true;
                btnBottom.Enabled = true;
                Battle = true;
                rtbCurrentEvent.Text = "Choose an attacker and target.";
            }
            else
            {
                ComputerBattlePhase();
                btnNextPhase.Enabled = true;
            }

            btnTop.Text = "Yes";
            btnBottom.Text = "No";
        }
        private void ComputerBattlePhase()
        {

        }
        private void PostBattlePhase()
        {
            if (WhosTurn == PlayerID)
            {
                btnNextPhase.Enabled = true;
                btnTop.Enabled = true;
                btnBottom.Enabled = true;
            }
            else
            {
                ComputerPostBattlePhase();
                btnNextPhase.Enabled = true;
            }
        }
        private void ComputerPostBattlePhase()
        {
            
        }
        private void RefreshPhase()
        {
            if (WhosTurn == PlayerID)
            {
                btnNextPhase.Enabled = true;
                btnTop.Enabled = true;
                btnBottom.Enabled = true;
            }
            else
            {
                ComputerRefreshPhase();
                btnNextPhase.Enabled = true;
            }
        }
        private void ComputerRefreshPhase()
        {

        }
        private void EndPhase()
        {
            if (WhosTurn == PlayerID)
            {
                if (PlayerHand.Count > 5)
                {
                    rtbCurrentEvent.Text = rtbCurrentEvent.Text + "\n\nMore than 5 in hand. Select a card to discard.";
                    btnNextPhase.Enabled = false;
                    DISCARD = true;
                    btnTop.Enabled = true;
                    btnTop.Text = "Discard";
                }
            }
            else
            {
                ComputerEndPhase();
            }
        }
        private void ComputerEndPhase()
        {

        }
        #endregion

        #region Combat
        private void Combat(Card attacker, Card defender)
        {
            int damage = defender.Def - attacker.Atk;
            defender.Def = defender.Def - damage;
            rtbCurrentEvent.Text = "\n" + attacker.Name + " dealt" + attacker.Atk + " to " + defender.Name + " and " + damage + " to opponent";
            if (WhosTurn == PlayerID)   //attacker's damage
            {
                OpponentLife = OpponentLife - damage;
                updateLife();

                if(defender.Def > 0)    //defender not destroyed
                {
                    int counterDamage = attacker.Def - (defender.Atk / 2);
                    attacker.Def = attacker.Def - counterDamage;
                    PlayerLife = PlayerLife - counterDamage;
                    updateLife();
                    rtbCurrentEvent.Text = "\n" + defender.Name + " dealt" + (defender.Atk / 2) + " counter damage to " + attacker.Name + " and " + counterDamage + " to opponent";

                    if(attacker.Def <= 0)   //attacker destroyed
                    {
                        PlayerDiscard.Add(attacker);
                        rtbCurrentEvent.Text = "\n" + attacker.Name + " was destroyed";
                        PlayerSoldiers.Remove(attacker);
                    }
                }
                else   //defender destroyed
                {
                    OpponentDiscard.Add(defender);
                    rtbCurrentEvent.Text = "\n" + defender.Name + " was destroyed"; 
                    OpponentSoldiers.Remove(defender);
                }
            }
            attacker = null;
            defender = null;
            DisplaySoldiers(PlayerID);
            DisplaySoldiers(OpponentID);
        }
        #endregion

        #region hand operations
        private void DealHand(CardCollection passedDeck)
        {
            if (passedDeck.Equals(PlayerDeck))
            {
                Draw(5, PlayerID);
            }
            else if (passedDeck.Equals(OpponentDeck))
            {
                Draw(5, OpponentID);
            }
        }
        private void Draw(int numberToDraw, int whoDraws)
        {
            if (whoDraws == PlayerID && PlayerHand.Count < 8)
            {
                for (int i = 0; i < numberToDraw; i++)
                {
                    if (PlayerDeck.Count > 0)
                    {
                        switch (PlayerHand.Count)
                        {
                            case 0:
                                PlayerHand.Add(PlayerDeck[0]);
                                DrawnCard = PlayerDeck[0].Name;
                                PlayerDeck.RemoveAt(0);
                                pbHandBottom0.ImageLocation = PlayerHand[0].ImageLink;
                                break;
                            case 1:
                                PlayerHand.Add(PlayerDeck[0]);
                                DrawnCard = PlayerDeck[0].Name;
                                PlayerDeck.RemoveAt(0);
                                pbHandBottom1.ImageLocation = PlayerHand[1].ImageLink;
                                break;
                            case 2:
                                PlayerHand.Add(PlayerDeck[0]);
                                DrawnCard = PlayerDeck[0].Name;
                                PlayerDeck.RemoveAt(0);
                                pbHandBottom2.ImageLocation = PlayerHand[2].ImageLink;
                                break;
                            case 3:
                                PlayerHand.Add(PlayerDeck[0]);
                                DrawnCard = PlayerDeck[0].Name;
                                PlayerDeck.RemoveAt(0);
                                pbHandBottom3.ImageLocation = PlayerHand[3].ImageLink;
                                break;
                            case 4:
                                PlayerHand.Add(PlayerDeck[0]);
                                DrawnCard = PlayerDeck[0].Name;
                                PlayerDeck.RemoveAt(0);
                                pbHandBottom4.ImageLocation = PlayerHand[4].ImageLink;
                                break;
                            case 5:
                                PlayerHand.Add(PlayerDeck[0]);
                                DrawnCard = PlayerDeck[0].Name;
                                PlayerDeck.RemoveAt(0);
                                pbHandBottom5.ImageLocation = PlayerHand[5].ImageLink;
                                break;
                            case 6:
                                PlayerHand.Add(PlayerDeck[0]);
                                DrawnCard = PlayerDeck[0].Name;
                                PlayerDeck.RemoveAt(0);
                                pbHandBottom6.ImageLocation = PlayerHand[6].ImageLink;
                                break;
                            case 7:
                                PlayerHand.Add(PlayerDeck[0]);
                                DrawnCard = PlayerDeck[0].Name;
                                PlayerDeck.RemoveAt(0);
                                pbHandBottom7.ImageLocation = PlayerHand[7].ImageLink;
                                break;
                            case 8:
                                rtbCurrentEvent.Text = "Cannot have more than 8 cards in your hand.";
                                break;
                        }
                        rtbCurrentEvent.Text = rtbCurrentEvent.Text + "\nDrew " + PlayerHand.ElementAt(PlayerHand.Count - 1).Name + ".";
                        rtbCardDescription.Text = HandClickDisplay(PlayerHand.ElementAt(PlayerHand.Count - 1));
                        pbDisplay.ImageLocation = PlayerHand.ElementAt(PlayerHand.Count - 1).LargeImageLink;
                    }
                }
            }
            else if (whoDraws == OpponentID && OpponentHand.Count < 8)
            {
                for (int i = 0; i < numberToDraw; i++)
                {
                    if (OpponentDeck.Count > 0)
                    {
                        OpponentHand.Add(OpponentDeck[0]);
                        OpponentDeck.RemoveAt(0);
                    }
                }
                switch (OpponentHand.Count)
                {
                    case 0:
                        pbHandTop0.ImageLocation = null;
                        pbHandTop1.ImageLocation = null;
                        pbHandTop2.ImageLocation = null;
                        pbHandTop3.ImageLocation = null;
                        pbHandTop4.ImageLocation = null;
                        pbHandTop5.ImageLocation = null;
                        pbHandTop6.ImageLocation = null;
                        pbHandTop7.ImageLocation = null;
                        break;
                    case 1:
                        pbHandTop0.Image = Properties.Resources.back;
                        pbHandTop1.ImageLocation = null;
                        pbHandTop2.ImageLocation = null;
                        pbHandTop3.ImageLocation = null;
                        pbHandTop4.ImageLocation = null;
                        pbHandTop5.ImageLocation = null;
                        pbHandTop6.ImageLocation = null;
                        pbHandTop7.ImageLocation = null;
                        break;
                    case 2:
                        pbHandTop0.Image = Properties.Resources.back;
                        pbHandTop1.Image = Properties.Resources.back;
                        pbHandTop2.ImageLocation = null;
                        pbHandTop3.ImageLocation = null;
                        pbHandTop4.ImageLocation = null;
                        pbHandTop5.ImageLocation = null;
                        pbHandTop6.ImageLocation = null;
                        pbHandTop7.ImageLocation = null;
                        break;
                    case 3:
                        pbHandTop0.Image = Properties.Resources.back;
                        pbHandTop1.Image = Properties.Resources.back;
                        pbHandTop2.Image = Properties.Resources.back;
                        pbHandTop3.ImageLocation = null;
                        pbHandTop4.ImageLocation = null;
                        pbHandTop5.ImageLocation = null;
                        pbHandTop6.ImageLocation = null;
                        pbHandTop7.ImageLocation = null;
                        break;
                    case 4:
                        pbHandTop0.Image = Properties.Resources.back;
                        pbHandTop1.Image = Properties.Resources.back;
                        pbHandTop2.Image = Properties.Resources.back;
                        pbHandTop3.Image = Properties.Resources.back;
                        pbHandTop4.ImageLocation = null;
                        pbHandTop5.ImageLocation = null;
                        pbHandTop6.ImageLocation = null;
                        pbHandTop7.ImageLocation = null;
                        break;
                    case 5:
                        pbHandTop0.Image = Properties.Resources.back;
                        pbHandTop1.Image = Properties.Resources.back;
                        pbHandTop2.Image = Properties.Resources.back;
                        pbHandTop3.Image = Properties.Resources.back;
                        pbHandTop4.Image = Properties.Resources.back;
                        pbHandTop5.ImageLocation = null;
                        pbHandTop6.ImageLocation = null;
                        pbHandTop7.ImageLocation = null;
                        break;
                    case 6:
                        pbHandTop0.Image = Properties.Resources.back;
                        pbHandTop1.Image = Properties.Resources.back;
                        pbHandTop2.Image = Properties.Resources.back;
                        pbHandTop3.Image = Properties.Resources.back;
                        pbHandTop4.Image = Properties.Resources.back;
                        pbHandTop5.Image = Properties.Resources.back;
                        pbHandTop6.ImageLocation = null;
                        pbHandTop7.ImageLocation = null;
                        break;
                    case 7:
                        pbHandTop0.Image = Properties.Resources.back;
                        pbHandTop1.Image = Properties.Resources.back;
                        pbHandTop2.Image = Properties.Resources.back;
                        pbHandTop3.Image = Properties.Resources.back;
                        pbHandTop4.Image = Properties.Resources.back;
                        pbHandTop5.Image = Properties.Resources.back;
                        pbHandTop6.Image = Properties.Resources.back;
                        pbHandTop7.ImageLocation = null;
                        break;
                    case 8:
                        pbHandTop0.Image = Properties.Resources.back;
                        pbHandTop1.Image = Properties.Resources.back;
                        pbHandTop2.Image = Properties.Resources.back;
                        pbHandTop3.Image = Properties.Resources.back;
                        pbHandTop4.Image = Properties.Resources.back;
                        pbHandTop5.Image = Properties.Resources.back;
                        pbHandTop6.Image = Properties.Resources.back;
                        pbHandTop7.Image = Properties.Resources.back;
                        break;
                }
                rtbCurrentEvent.Text = rtbCurrentEvent.Text + "\nComputer drew a card.";
            }
        }
        private void DisplayHand(int id)
        {
            if (id == PlayerID)
            {
                switch (PlayerHand.Count)
                {
                    case 0:
                        pbHandBottom0.ImageLocation = null;
                        //pbHandBottom0.Refresh();
                        pbHandBottom1.ImageLocation = null;
                        //pbHandBottom1.Refresh();
                        pbHandBottom2.ImageLocation = null;
                        //pbHandBottom2.Refresh();
                        pbHandBottom3.ImageLocation = null;
                        //pbHandBottom3.Refresh();
                        pbHandBottom4.ImageLocation = null;
                        //pbHandBottom4.Refresh();
                        pbHandBottom5.ImageLocation = null;
                        //pbHandBottom5.Refresh();
                        pbHandBottom6.ImageLocation = null;
                        //pbHandBottom6.Refresh();
                        pbHandBottom7.ImageLocation = null;
                        //pbHandBottom7.Refresh();
                        break;
                    case 1:
                        pbHandBottom0.ImageLocation = PlayerHand[0].ImageLink;
                        //pbHandBottom0.Refresh();
                        pbHandBottom1.ImageLocation = null;
                        //pbHandBottom1.Refresh();
                        pbHandBottom2.ImageLocation = null;
                        //pbHandBottom2.Refresh();
                        pbHandBottom3.ImageLocation = null;
                        //pbHandBottom3.Refresh();
                        pbHandBottom4.ImageLocation = null;
                        //pbHandBottom4.Refresh();
                        pbHandBottom5.ImageLocation = null;
                        //pbHandBottom5.Refresh();
                        pbHandBottom6.ImageLocation = null;
                        //pbHandBottom6.Refresh();
                        pbHandBottom7.ImageLocation = null;
                        //pbHandBottom7.Refresh();
                        break;
                    case 2:
                        pbHandBottom0.ImageLocation = PlayerHand[0].ImageLink;
                        //pbHandBottom0.Refresh();
                        pbHandBottom1.ImageLocation = PlayerHand[1].ImageLink;
                        //pbHandBottom1.Refresh();
                        pbHandBottom2.ImageLocation = null;
                        //pbHandBottom2.Refresh();
                        pbHandBottom3.ImageLocation = null;
                        //pbHandBottom3.Refresh();
                        pbHandBottom4.ImageLocation = null;
                        //pbHandBottom4.Refresh();
                        pbHandBottom5.ImageLocation = null;
                        //pbHandBottom5.Refresh();
                        pbHandBottom6.ImageLocation = null;
                        //pbHandBottom6.Refresh();
                        pbHandBottom7.ImageLocation = null;
                        //pbHandBottom7.Refresh();
                        break;
                    case 3:
                        pbHandBottom0.ImageLocation = PlayerHand[0].ImageLink;
                        //pbHandBottom0.Refresh();
                        pbHandBottom1.ImageLocation = PlayerHand[1].ImageLink;
                        //pbHandBottom1.Refresh();
                        pbHandBottom2.ImageLocation = PlayerHand[2].ImageLink;
                        //pbHandBottom2.Refresh();
                        pbHandBottom3.ImageLocation = null;
                        //pbHandBottom3.Refresh();
                        pbHandBottom4.ImageLocation = null;
                        //pbHandBottom4.Refresh();
                        pbHandBottom5.ImageLocation = null;
                        //pbHandBottom5.Refresh();
                        pbHandBottom6.ImageLocation = null;
                        //pbHandBottom6.Refresh();
                        pbHandBottom7.ImageLocation = null;
                        //pbHandBottom7.Refresh();
                        break;
                    case 4:
                        pbHandBottom0.ImageLocation = PlayerHand[0].ImageLink;
                        //pbHandBottom0.Refresh();
                        pbHandBottom1.ImageLocation = PlayerHand[1].ImageLink;
                        //pbHandBottom1.Refresh();
                        pbHandBottom2.ImageLocation = PlayerHand[2].ImageLink;
                        //pbHandBottom2.Refresh();
                        pbHandBottom3.ImageLocation = PlayerHand[3].ImageLink;
                        //pbHandBottom3.Refresh();
                        pbHandBottom4.ImageLocation = null;
                        //pbHandBottom4.Refresh();
                        pbHandBottom5.ImageLocation = null;
                        //pbHandBottom5.Refresh();
                        pbHandBottom6.ImageLocation = null;
                        //pbHandBottom6.Refresh();
                        pbHandBottom7.ImageLocation = null;
                        //pbHandBottom7.Refresh();
                        break;
                    case 5:
                        pbHandBottom0.ImageLocation = PlayerHand[0].ImageLink;
                        //pbHandBottom0.Refresh();
                        pbHandBottom1.ImageLocation = PlayerHand[1].ImageLink;
                        //pbHandBottom1.Refresh();
                        pbHandBottom2.ImageLocation = PlayerHand[2].ImageLink;
                        //pbHandBottom2.Refresh();
                        pbHandBottom3.ImageLocation = PlayerHand[3].ImageLink;
                        //pbHandBottom3.Refresh();
                        pbHandBottom4.ImageLocation = PlayerHand[4].ImageLink;
                        //pbHandBottom4.Refresh();
                        pbHandBottom5.ImageLocation = null;
                        //pbHandBottom5.Refresh();
                        pbHandBottom6.ImageLocation = null;
                        //pbHandBottom6.Refresh();
                        pbHandBottom7.ImageLocation = null;
                        //pbHandBottom7.Refresh();
                        break;
                    case 6:
                        pbHandBottom0.ImageLocation = PlayerHand[0].ImageLink;
                        //pbHandBottom0.Refresh();
                        pbHandBottom1.ImageLocation = PlayerHand[1].ImageLink;
                        //pbHandBottom1.Refresh();
                        pbHandBottom2.ImageLocation = PlayerHand[2].ImageLink;
                        //pbHandBottom2.Refresh();
                        pbHandBottom3.ImageLocation = PlayerHand[3].ImageLink;
                        //pbHandBottom3.Refresh();
                        pbHandBottom4.ImageLocation = PlayerHand[4].ImageLink;
                        //pbHandBottom4.Refresh();
                        pbHandBottom5.ImageLocation = PlayerHand[5].ImageLink;
                        //pbHandBottom5.Refresh();
                        pbHandBottom6.ImageLocation = null;
                        //pbHandBottom6.Refresh();
                        pbHandBottom7.ImageLocation = null;
                        //pbHandBottom7.Refresh();
                        break;
                    case 7:
                        pbHandBottom0.ImageLocation = PlayerHand[0].ImageLink;
                        //pbHandBottom0.Refresh();
                        pbHandBottom1.ImageLocation = PlayerHand[1].ImageLink;
                        //pbHandBottom1.Refresh();
                        pbHandBottom2.ImageLocation = PlayerHand[2].ImageLink;
                        //pbHandBottom2.Refresh();
                        pbHandBottom3.ImageLocation = PlayerHand[3].ImageLink;
                        //pbHandBottom3.Refresh();
                        pbHandBottom4.ImageLocation = PlayerHand[4].ImageLink;
                        //pbHandBottom4.Refresh();
                        pbHandBottom5.ImageLocation = PlayerHand[5].ImageLink;
                        //pbHandBottom5.Refresh();
                        pbHandBottom6.ImageLocation = PlayerHand[6].ImageLink;
                        //pbHandBottom6.Refresh();
                        pbHandBottom7.ImageLocation = null;
                        //pbHandBottom7.Refresh();
                        break;
                    case 8:
                        pbHandBottom0.ImageLocation = PlayerHand[0].ImageLink;
                        //pbHandBottom0.Refresh();
                        pbHandBottom1.ImageLocation = PlayerHand[1].ImageLink;
                        //pbHandBottom1.Refresh();
                        pbHandBottom2.ImageLocation = PlayerHand[2].ImageLink;
                        //pbHandBottom2.Refresh();
                        pbHandBottom3.ImageLocation = PlayerHand[3].ImageLink;
                        //pbHandBottom3.Refresh();
                        pbHandBottom4.ImageLocation = PlayerHand[4].ImageLink;
                        //pbHandBottom4.Refresh();
                        pbHandBottom5.ImageLocation = PlayerHand[5].ImageLink;
                        //pbHandBottom5.Refresh();
                        pbHandBottom6.ImageLocation = PlayerHand[6].ImageLink;
                        //pbHandBottom6.Refresh();
                        pbHandBottom7.ImageLocation = PlayerHand[7].ImageLink;
                        //pbHandBottom7.Refresh();
                        break;
                }
            }
            else if (id == OpponentID)
            {
                switch (OpponentHand.Count)
                {
                    case 0:
                        pbHandTop0.Image = null;
                        //pbHandTop0.Refresh();
                        pbHandTop1.Image = null;
                        //pbHandTop1.Refresh();
                        pbHandTop2.Image = null;
                        //pbHandTop2.Refresh();
                        pbHandTop3.Image = null;
                        //pbHandTop3.Refresh();
                        pbHandTop4.Image = null;
                        //pbHandTop4.Refresh();
                        pbHandTop5.Image = null;
                        //pbHandTop5.Refresh();
                        pbHandTop6.Image = null;
                        //pbHandTop6.Refresh();
                        pbHandTop7.Image = null;
                        //pbHandTop7.Refresh();
                        break;
                    case 1:
                        pbHandTop0.Image = Properties.Resources.back;
                        //pbHandTop0.Refresh();
                        pbHandTop1.Image = null;
                        //pbHandTop1.Refresh();
                        pbHandTop2.Image = null;
                        //pbHandTop2.Refresh();
                        pbHandTop3.Image = null;
                        //pbHandTop3.Refresh();
                        pbHandTop4.Image = null;
                        //pbHandTop4.Refresh();
                        pbHandTop5.Image = null;
                        //pbHandTop5.Refresh();
                        pbHandTop6.Image = null;
                        //pbHandTop6.Refresh();
                        pbHandTop7.Image = null;
                        //pbHandTop7.Refresh();
                        break;
                    case 2:
                        pbHandTop0.Image = Properties.Resources.back;
                        //pbHandTop0.Refresh();
                        pbHandTop1.Image = Properties.Resources.back;
                        //pbHandTop1.Refresh();
                        pbHandTop2.Image = null;
                        //pbHandTop2.Refresh();
                        pbHandTop3.Image = null;
                        //pbHandTop3.Refresh();
                        pbHandTop4.Image = null;
                        //pbHandTop4.Refresh();
                        pbHandTop5.Image = null;
                        //pbHandTop5.Refresh();
                        pbHandTop6.Image = null;
                        //pbHandTop6.Refresh();
                        pbHandTop7.Image = null;
                        //pbHandTop7.Refresh();
                        break;
                    case 3:
                        pbHandTop0.Image = Properties.Resources.back;
                        //pbHandTop0.Refresh();
                        pbHandTop1.Image = Properties.Resources.back;
                        //pbHandTop1.Refresh();
                        pbHandTop2.Image = Properties.Resources.back;
                        //pbHandTop2.Refresh();
                        pbHandTop3.Image = null;
                        //pbHandTop3.Refresh();
                        pbHandTop4.Image = null;
                        //pbHandTop4.Refresh();
                        pbHandTop5.Image = null;
                        //pbHandTop5.Refresh();
                        pbHandTop6.Image = null;
                        //pbHandTop6.Refresh();
                        pbHandTop7.Image = null;
                        //pbHandTop7.Refresh();
                        break;
                    case 4:
                        pbHandTop0.Image = Properties.Resources.back;
                        //pbHandTop0.Refresh();
                        pbHandTop1.Image = Properties.Resources.back;
                        //pbHandTop1.Refresh();
                        pbHandTop2.Image = Properties.Resources.back;
                        //pbHandTop2.Refresh();
                        pbHandTop3.Image = Properties.Resources.back;
                        //pbHandTop3.Refresh();
                        pbHandTop4.Image = null;
                        //pbHandTop4.Refresh();
                        pbHandTop5.Image = null;
                        //pbHandTop5.Refresh();
                        pbHandTop6.Image = null;
                        //pbHandTop6.Refresh();
                        pbHandTop7.Image = null;
                        //pbHandTop7.Refresh();
                        break;
                    case 5:
                        pbHandTop0.Image = Properties.Resources.back;
                        //pbHandTop0.Refresh();
                        pbHandTop1.Image = Properties.Resources.back;
                        //pbHandTop1.Refresh();
                        pbHandTop2.Image = Properties.Resources.back;
                        //pbHandTop2.Refresh();
                        pbHandTop3.Image = Properties.Resources.back;
                        //pbHandTop3.Refresh();
                        pbHandTop4.Image = Properties.Resources.back;
                        //pbHandTop4.Refresh();
                        pbHandTop5.Image = null;
                        //pbHandTop5.Refresh();
                        pbHandTop6.Image = null;
                        //pbHandTop6.Refresh();
                        pbHandTop7.Image = null;
                        //pbHandTop7.Refresh();
                        break;
                    case 6:
                        pbHandTop0.Image = Properties.Resources.back;
                        //pbHandTop0.Refresh();
                        pbHandTop1.Image = Properties.Resources.back;
                        //pbHandTop1.Refresh();
                        pbHandTop2.Image = Properties.Resources.back;
                        //pbHandTop2.Refresh();
                        pbHandTop3.Image = Properties.Resources.back;
                        //pbHandTop3.Refresh();
                        pbHandTop4.Image = Properties.Resources.back;
                        //pbHandTop4.Refresh();
                        pbHandTop5.Image = Properties.Resources.back;
                        //pbHandTop5.Refresh();
                        pbHandTop6.Image = null;
                        //pbHandTop6.Refresh();
                        pbHandTop7.Image = null;
                        //pbHandTop7.Refresh();
                        break;
                    case 7:
                        pbHandTop0.Image = Properties.Resources.back;
                        //pbHandTop0.Refresh();
                        pbHandTop1.Image = Properties.Resources.back;
                        //pbHandTop1.Refresh();
                        pbHandTop2.Image = Properties.Resources.back;
                        //pbHandTop2.Refresh();
                        pbHandTop3.Image = Properties.Resources.back;
                        //pbHandTop3.Refresh();
                        pbHandTop4.Image = Properties.Resources.back;
                        //pbHandTop4.Refresh();
                        pbHandTop5.Image = Properties.Resources.back;
                        //pbHandTop5.Refresh();
                        pbHandTop6.Image = Properties.Resources.back;
                        //pbHandTop6.Refresh();
                        pbHandTop7.Image = null;
                        //pbHandTop7.Refresh();
                        break;
                    case 8:
                        pbHandTop0.Image = Properties.Resources.back;
                        //pbHandTop0.Refresh();
                        pbHandTop1.Image = Properties.Resources.back;
                        //pbHandTop1.Refresh();
                        pbHandTop2.Image = Properties.Resources.back;
                        //pbHandTop2.Refresh();
                        pbHandTop3.Image = Properties.Resources.back;
                        //pbHandTop3.Refresh();
                        pbHandTop4.Image = Properties.Resources.back;
                        //pbHandTop4.Refresh();
                        pbHandTop5.Image = Properties.Resources.back;
                        //pbHandTop5.Refresh();
                        pbHandTop6.Image = Properties.Resources.back;
                        //pbHandTop6.Refresh();
                        pbHandTop7.Image = Properties.Resources.back;
                        //pbHandTop7.Refresh();
                        break;
                }
            }
        }
        private void Discard(int cardSlot, int ID)
        {
            if (ID == PlayerID)
            {
                PlayerDiscard.Add(PlayerHand[cardSlot]);
                lboxDiscardBottom.Items.Add(PlayerHand[cardSlot].Name);

                PlayerHand.RemoveAt(cardSlot);

                DisplayHand(ID);

                btnNextPhase.Enabled = true;
                btnTop.Text = "Yes";
                DISCARD = false;
                SelectedCardSlotHand = 99;
                rtbCurrentEvent.Text = "Discarded " + CardToDiscard + ".";
                CardToDiscard = null;
            }
        }
        private void RefreshHand()
        {
            btnTop.Enabled = true;
            btnTop.Text = "Yes";
        }
        #endregion

        #region update labels
        private void updateLife()
        {
            lblHealthTop.Text = "" + OpponentLife;
            lblHealthBottom.Text = "" + PlayerLife;
        }
        private void TurnLabel()
        {
            if (WhosTurn == PlayerID)
            {
                lblPlayerTurn.ForeColor = Color.Red;
                lblOpponentTurn.ForeColor = Color.White;
            }
            else
            {
                lblPlayerTurn.ForeColor = Color.White;
                lblOpponentTurn.ForeColor = Color.Red;
            }
        }
        private void UpdateTurnCount()
        {
            lblTurnCount.Text = "" + NumberOfTurns;
        }
        #endregion

        #region Field Operations
        private void SoldierSummon()
        {
            if(SelectedCard.Level == 1)
            {
                if(CalculateTotalLevel(PlayerSoldiers) != 3)
                {
                    btnTop.Text = "Summon";
                    btnBottom.Text = "Set";
                    rtbCurrentEvent.Text = "Summon " + SelectedCard.Name + " in attack mode or place " + SelectedCard.Name + " in defense?";
                    PlaceOnField = true;
                }
                else
                {
                    btnTop.Text = "Yes";
                    btnBottom.Text = "No";
                    rtbCurrentEvent.Text = "Not enough free slots to sortie soldier.";
                    PlaceOnField = false;
                }
            }
            else if (SelectedCard.Level == 2)
            {
                if(CalculateTotalLevel(PlayerSoldiers) < 2)
                {
                    btnTop.Text = "Summon";
                    btnBottom.Text = "Set";
                    rtbCurrentEvent.Text = "Summon " + SelectedCard.Name + " in attack mode or place " + SelectedCard.Name + " in defense?";
                    PlaceOnField = true;
                }
                else
                {
                    btnTop.Text = "Yes";
                    btnBottom.Text = "No";
                    rtbCurrentEvent.Text = "Not enough free slots to sortie soldier.";
                    PlaceOnField = false;
                }
            }
            else if (SelectedCard.Level == 3)
            {
                if(CalculateTotalLevel(PlayerSoldiers) == 0)
                {
                    btnTop.Text = "Summon";
                    btnBottom.Text = "Set";
                    rtbCurrentEvent.Text = "Summon " + SelectedCard.Name + " in attack mode or place " + SelectedCard.Name + " in defense?";
                    PlaceOnField = true;
                }
                else
                {
                    btnTop.Text = "Yes";
                    btnBottom.Text = "No";
                    rtbCurrentEvent.Text = "Not enough free slots to sortie soldier.";
                    PlaceOnField = false;
                }
            }
        }
        private void MonsterAtkMode()
        {
            if (WhosTurn == playerID)
            {
                SelectedCard.FaceUp = true;
                AddSoldierToField();
            }
        }
        private void MonsterDef()
        {
            if (WhosTurn == PlayerID)
            {
                SelectedCard.FaceUp = false;
                AddSoldierToField();
            }
        }
        private void AddSoldierToField()
        {
            PlayerSoldiers.Add(SelectedCard);
            for (int i = 0; i < PlayerHand.Count; i++)
            {
                if (PlayerHand[i].Equals(SelectedCard))
                {
                    PlayerHand.RemoveAt(i);
                    break;
                }
            }
            DisplayHand(PlayerID);
            DisplaySoldiers(PlayerID);

            SelectedCard = null;
        }
        private void DisplaySoldiers(int ID)
        {
            if (ID == PlayerID)
            {
                switch (PlayerSoldiers.Count)
                {
                    case 0:
                        pbSoldierBottom0.Image = null;
                        pbSoldierBottom1.Image = null;
                        pbSoldierBottom2.Image = null;
                        break;
                    case 1:
                        if (PlayerSoldiers[0].FaceUp == true)
                        {
                            pbSoldierBottom0.ImageLocation = PlayerSoldiers[0].ImageLink;
                        }
                        else
                        {
                            pbSoldierBottom0.Image = Properties.Resources.back;
                        }
                        pbSoldierBottom1.Image = null;
                        pbSoldierBottom2.Image = null;
                        break;
                    case 2:
                        if (PlayerSoldiers[0].FaceUp == true)
                        {
                            pbSoldierBottom0.ImageLocation = PlayerSoldiers[0].ImageLink;
                        }
                        else
                        {
                            pbSoldierBottom0.Image = Properties.Resources.back;
                        }
                        if (PlayerSoldiers[1].FaceUp == true)
                        {
                            pbSoldierBottom1.ImageLocation = PlayerSoldiers[1].ImageLink;
                        }
                        else
                        {
                            pbSoldierBottom1.Image = Properties.Resources.back;
                        }
                        pbSoldierBottom2.Image = null;
                        break;
                    case 3:
                        if (PlayerSoldiers[0].FaceUp == true)
                        {
                            pbSoldierBottom0.ImageLocation = PlayerSoldiers[0].ImageLink;
                        }
                        else
                        {
                            pbSoldierBottom0.Image = Properties.Resources.back;
                        }
                        if (PlayerSoldiers[1].FaceUp == true)
                        {
                            pbSoldierBottom1.ImageLocation = PlayerSoldiers[1].ImageLink;
                        }
                        else
                        {
                            pbSoldierBottom1.Image = Properties.Resources.back;
                        }
                        if (PlayerSoldiers[2].FaceUp == true)
                        {
                            pbSoldierBottom2.ImageLocation = PlayerSoldiers[2].ImageLink;
                        }
                        else
                        {
                            pbSoldierBottom2.Image = Properties.Resources.back;
                        }
                        break;
                }
            }
            else if (ID == OpponentID)
            {
                switch (OpponentSoldiers.Count)
                {
                    case 0:
                        pbSoldierTop0.Image = null;
                        pbSoldierTop1.Image = null;
                        pbSoldierTop2.Image = null;
                        break;
                    case 1:
                        if (OpponentSoldiers[0].FaceUp == true)
                        {
                            pbSoldierTop0.ImageLocation = OpponentSoldiers[0].ImageLink;
                        }
                        else
                        {
                            pbSoldierTop0.Image = Properties.Resources.back;
                        }
                        pbSoldierTop1.Image = null;
                        pbSoldierTop2.Image = null;
                        break;
                    case 2:
                        if (OpponentSoldiers[0].FaceUp == true)
                        {
                            pbSoldierTop0.ImageLocation = OpponentSoldiers[0].ImageLink;
                        }
                        else
                        {
                            pbSoldierTop0.Image = Properties.Resources.back;
                        }
                        if (PlayerSoldiers[1].FaceUp == true)
                        {
                            pbSoldierTop1.ImageLocation = OpponentSoldiers[1].ImageLink;
                        }
                        else
                        {
                            pbSoldierTop1.Image = Properties.Resources.back;
                        }
                        pbSoldierTop2.Image = null;
                        break;
                    case 3:
                        if (OpponentSoldiers[0].FaceUp == true)
                        {
                            pbSoldierTop0.ImageLocation = OpponentSoldiers[0].ImageLink;
                        }
                        else
                        {
                            pbSoldierTop0.Image = Properties.Resources.back;
                        }
                        if (PlayerSoldiers[1].FaceUp == true)
                        {
                            pbSoldierTop1.ImageLocation = OpponentSoldiers[1].ImageLink;
                        }
                        else
                        {
                            pbSoldierTop1.Image = Properties.Resources.back;
                        }
                        if (OpponentSoldiers[2].FaceUp == true)
                        {
                            pbSoldierTop2.ImageLocation = OpponentSoldiers[2].ImageLink;
                        }
                        else
                        {
                            pbSoldierTop2.Image = Properties.Resources.back;
                        }
                        break;
                }
            }
        }
        private int CalculateTotalLevel(CardCollection passedSoldiers)
        {
            int x = 0;
            if (passedSoldiers.Count == 3)
            {
                return 3;
            }
            else
            {
                foreach (Card item in passedSoldiers)
                {
                    x = x + item.Level;
                }
            }
            return x;
        }
        #endregion

        #region Buttons
        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (btnContinue.Text == "Start")
            {
                StartGame();
            }
        }
        private void btnNextPhase_Click(object sender, EventArgs e)
        {
            if (CurrentPhase == (int)Phases.END)  //if endphase currently, change turns
            {
                SelectedCard = null;
                SelectedCardSlotHand = 99;
                NumberOfTurns++;
                if (WhosTurn == PlayerID)
                {
                    WhosTurn = OpponentID;
                }
                else if (WhosTurn == OpponentID)
                {
                    WhosTurn = PlayerID;
                }
            }
            else   //next phase
            {
                SelectedCard = null;
                SelectedCardSlotHand = 99;
                CurrentPhase++;
            }
        }
        private void btnTop_Click(object sender, EventArgs e)
        {
            if (SelectedCard != null)
            {
                if (DISCARD && WhosTurn == PlayerID)
                {
                    switch (SelectedCardSlotHand)
                    {
                        case 0:
                            if (pbHandBottom0.ImageLocation != null)
                            {
                                Discard(0, PlayerID);
                            }
                            break;
                        case 1:
                            if (pbHandBottom1.ImageLocation != null)
                            {
                                Discard(1, PlayerID);
                            }
                            break;
                        case 2:
                            if (pbHandBottom2.ImageLocation != null)
                            {
                                Discard(2, PlayerID);
                            }
                            break;
                        case 3:
                            if (pbHandBottom3.ImageLocation != null)
                            {
                                Discard(3, PlayerID);
                            }
                            break;
                        case 4:
                            if (pbHandBottom4.ImageLocation != null)
                            {
                                Discard(4, PlayerID);
                            }
                            break;
                        case 5:
                            if (pbHandBottom5.ImageLocation != null)
                            {
                                Discard(5, PlayerID);
                            }
                            break;
                        case 6:
                            if (pbHandBottom6.ImageLocation != null)
                            {
                                Discard(6, PlayerID);
                            }
                            break;
                        case 7:
                            if (pbHandBottom7.ImageLocation != null)
                            {
                                Discard(7, PlayerID);
                            }
                            break;
                    }
                }
                else if (CurrentPhase == (int)Phases.PREBATTLE || CurrentPhase == (int)Phases.POSTBATTLE)
                {
                    if (PlaceOnField)
                    {
                        if (SelectedCard.CardType == 1) //soldier card
                        {
                            MonsterAtkMode();
                        }
                    }
                }
                else if (CurrentPhase == (int)Phases.REFRESH)
                {
                    if (WhosTurn == PlayerID)
                    {
                        PlayerDeck.Add(SelectedCard);

                        PlayerHand.RemoveAt(SelectedCardSlotHand);
                        PlayerDeck.ShuffleDeck();
                        Draw(1, PlayerID);
                        btnTop.Enabled = false;
                        DisplayHand(PlayerID);
                    }
                }
            }
            if(Battle && Attacker != null && Defender != null)
            {
                Combat(Attacker, Defender);
            }
        }
        private void btnBottom_Click(object sender, EventArgs e)
        {
            if (Battle && Attacker != null && Defender != null)
            {
                Attacker = null;
                Defender = null;
                rtbCurrentEvent.Text = "Choose an attacker and target.";
            }
            if (PlaceOnField)
            {
                if (SelectedCard.CardType == 1)  //soldier
                {
                    MonsterDef();
                }
            }
        }
        #endregion

        #region Clicked on Hand
        private string HandClickDisplay(Card cardSelected)
        {
            switch (cardSelected.CardType)
            {
                case 1:
                    return "" + cardSelected.Name + "\nLevel: " + cardSelected.Level + "\tAtk: " + cardSelected.Atk + "\tDef: " + cardSelected.Def + "\n\nDescription: " + cardSelected.Description;
                default:
                    return "";
            }
        }

        private void pbHandBottom0_Click(object sender, EventArgs e)
        {
            pbDisplay.ImageLocation = PlayerHand[0].LargeImageLink;
            rtbCardDescription.Text = HandClickDisplay(PlayerHand[0]);
            SelectedCard = PlayerHand[0];
            SelectedCardSlotHand = 0;

            if (DISCARD)
                rtbCurrentEvent.Text = "Discard " + PlayerHand[0].Name + "?";

            else if (CurrentPhase == (int)Phases.PREBATTLE || CurrentPhase == (int)Phases.POSTBATTLE)
            {
                if (PlayerHand[0].CardType == 1)    //soldier
                {
                    SoldierSummon();
                }
            }
            else if (CurrentPhase == (int)Phases.REFRESH)
            {
                rtbCurrentEvent.Text = "Refresh using " + SelectedCard.Name;
                RefreshHand();
            }
        }

        private void pbHandBottom1_Click(object sender, EventArgs e)
        {
            pbDisplay.ImageLocation = PlayerHand[1].LargeImageLink;
            rtbCardDescription.Text = HandClickDisplay(PlayerHand[1]);
            SelectedCard = PlayerHand[1];
            SelectedCardSlotHand = 1;

            if (DISCARD)
                rtbCurrentEvent.Text = "Discard " + PlayerHand[0].Name + "?";

            else if (CurrentPhase == (int)Phases.PREBATTLE || CurrentPhase == (int)Phases.POSTBATTLE)
            {
                if (PlayerHand[1].CardType == 1)    //soldier
                {
                    SoldierSummon();
                }
            }
            else if (CurrentPhase == (int)Phases.REFRESH)
            {
                rtbCurrentEvent.Text = "Refresh using " + SelectedCard.Name;
                RefreshHand();
            }
        }

        private void pbHandBottom2_Click(object sender, EventArgs e)
        {
            pbDisplay.ImageLocation = PlayerHand[2].LargeImageLink;
            rtbCardDescription.Text = HandClickDisplay(PlayerHand[2]);
            SelectedCard = PlayerHand[2];
            SelectedCardSlotHand = 2;

            if (DISCARD)
                rtbCurrentEvent.Text = "Discard " + PlayerHand[0].Name + "?";

            else if (CurrentPhase == (int)Phases.PREBATTLE || CurrentPhase == (int)Phases.POSTBATTLE)
            {
                if (PlayerHand[2].CardType == 1)    //soldier
                {
                    SoldierSummon();
                }
            }
            else if (CurrentPhase == (int)Phases.REFRESH)
            {
                rtbCurrentEvent.Text = "Refresh using " + SelectedCard.Name;
                RefreshHand();
            }
        }

        private void pbHandBottom3_Click(object sender, EventArgs e)
        {
            pbDisplay.ImageLocation = PlayerHand[3].LargeImageLink;
            rtbCardDescription.Text = HandClickDisplay(PlayerHand[3]);
            SelectedCard = PlayerHand[3];
            SelectedCardSlotHand = 3;

            if (DISCARD)
                rtbCurrentEvent.Text = "Discard " + PlayerHand[0].Name + "?";

            else if (CurrentPhase == (int)Phases.PREBATTLE || CurrentPhase == (int)Phases.POSTBATTLE)
            {
                if (PlayerHand[3].CardType == 1)    //soldier
                {
                    SoldierSummon();
                }
            }
            else if (CurrentPhase == (int)Phases.REFRESH)
            {
                rtbCurrentEvent.Text = "Refresh using " + SelectedCard.Name;
                RefreshHand();
            }
        }

        private void pbHandBottom4_Click(object sender, EventArgs e)
        {
            pbDisplay.ImageLocation = PlayerHand[4].LargeImageLink;
            rtbCardDescription.Text = HandClickDisplay(PlayerHand[4]);
            SelectedCard = PlayerHand[4];
            SelectedCardSlotHand = 4;

            if (DISCARD)
                rtbCurrentEvent.Text = "Discard " + PlayerHand[0].Name + "?";

            else if (CurrentPhase == (int)Phases.PREBATTLE || CurrentPhase == (int)Phases.POSTBATTLE)
            {
                if (PlayerHand[4].CardType == 1)    //soldier
                {
                    SoldierSummon();                   
                }
            }
            else if (CurrentPhase == (int)Phases.REFRESH)
            {
                rtbCurrentEvent.Text = "Refresh using " + SelectedCard.Name;
                RefreshHand();
            }
        }

        private void pbHandBottom5_Click(object sender, EventArgs e)
        {
            pbDisplay.ImageLocation = PlayerHand[5].LargeImageLink;
            rtbCardDescription.Text = HandClickDisplay(PlayerHand[5]);
            SelectedCard = PlayerHand[5];
            SelectedCardSlotHand = 5;

            if (DISCARD)
                rtbCurrentEvent.Text = "Discard " + PlayerHand[0].Name + "?";

            else if (CurrentPhase == (int)Phases.PREBATTLE || CurrentPhase == (int)Phases.POSTBATTLE)
            {
                if (PlayerHand[5].CardType == 1)    //soldier
                {
                    SoldierSummon();
                }
            }
            else if (CurrentPhase == (int)Phases.REFRESH)
            {
                rtbCurrentEvent.Text = "Refresh using " + SelectedCard.Name;
                RefreshHand();
            }
        }

        private void pbHandBottom6_Click(object sender, EventArgs e)
        {
            pbDisplay.ImageLocation = PlayerHand[6].LargeImageLink;
            rtbCardDescription.Text = HandClickDisplay(PlayerHand[6]);
            SelectedCard = PlayerHand[6];
            SelectedCardSlotHand = 6;

            if (DISCARD)
                rtbCurrentEvent.Text = "Discard " + PlayerHand[0].Name + "?";

            else if (CurrentPhase == (int)Phases.PREBATTLE || CurrentPhase == (int)Phases.POSTBATTLE)
            {
                if (PlayerHand[6].CardType == 1)    //soldier
                {
                    SoldierSummon();                    
                }
            }
            else if (CurrentPhase == (int)Phases.REFRESH)
            {
                rtbCurrentEvent.Text = "Refresh using " + SelectedCard.Name;
                RefreshHand();
            }
        }

        private void pbHandBottom7_Click(object sender, EventArgs e)
        {
            pbDisplay.ImageLocation = PlayerHand[7].LargeImageLink;
            rtbCardDescription.Text = HandClickDisplay(PlayerHand[7]);
            SelectedCard = PlayerHand[7];
            SelectedCardSlotHand = 7;

            if (DISCARD)
                rtbCurrentEvent.Text = "Discard " + PlayerHand[0].Name + "?";

            else if (CurrentPhase == (int)Phases.PREBATTLE || CurrentPhase == (int)Phases.POSTBATTLE)
            {
                if (PlayerHand[7].CardType == 1)    //soldier
                {
                    SoldierSummon();
                }
            }
            else if (CurrentPhase == (int)Phases.REFRESH)
            {
                rtbCurrentEvent.Text = "Refresh using " + SelectedCard.Name;
                RefreshHand();
            }
        }
        #endregion

        #region Clicked on Deck
        private void pbDeckBottom_Click(object sender, EventArgs e)
        {
            if (WhosTurn == PlayerID)
            {
                if (CurrentPhase == (int)Phases.DRAW && NumberOfTurns != 0)
                {
                    Draw(1, PlayerID);
                    btnNextPhase.Enabled = true;
                    pbDeckBottom.Enabled = false;
                }
            }
            pbDeckBottom.Enabled = false;
            btnNextPhase.Enabled = true;
        }
        #endregion

        #region Clicked on Soldiers
        private void pbSoldierBottom0_Click(object sender, EventArgs e)
        {
            if(pbSoldierBottom0.Image != null)
            {
                pbDisplay.ImageLocation = PlayerSoldiers[0].LargeImageLink;
                rtbCardDescription.Text = HandClickDisplay(PlayerSoldiers[0]);

                if (Battle)
                {
                    Attacker = PlayerSoldiers[0];
                    rtbCurrentEvent.Text = Attacker.Name + "chosen to attack. Choose a target.";
                }
            }
        }

        private void pbSoldierBottom1_Click(object sender, EventArgs e)
        {
            if(pbSoldierBottom1.Image != null)
            {
                pbDisplay.ImageLocation = PlayerSoldiers[1].LargeImageLink;
                rtbCardDescription.Text = HandClickDisplay(PlayerSoldiers[1]);

                if (Battle)
                {
                    Attacker = PlayerSoldiers[1];
                    rtbCurrentEvent.Text = Attacker.Name + "chosen to attack. Choose a target.";
                }
            }
        }

        private void pbSoldierBottom2_Click(object sender, EventArgs e)
        {
            if(pbSoldierBottom2.Image != null)
            {
                pbDisplay.ImageLocation = PlayerSoldiers[2].LargeImageLink;
                rtbCardDescription.Text = HandClickDisplay(PlayerSoldiers[2]);

                if (Battle)
                {
                    Attacker = PlayerSoldiers[2];
                    rtbCurrentEvent.Text = Attacker.Name + "chosen to attack. Choose a target.";
                }
            }
        }

        private void pbSoldierTop0_Click(object sender, EventArgs e)
        {
            if(pbSoldierTop0.Image != null)
            {
                if (OpponentSoldiers[0].FaceUp)
                {
                    pbDisplay.ImageLocation = OpponentSoldiers[0].LargeImageLink;
                    rtbCardDescription.Text = HandClickDisplay(OpponentSoldiers[0]);

                    if (Battle)
                    {
                        Defender = OpponentSoldiers[0];
                        rtbCurrentEvent.Text = Defender.Name + " chosen as target. Attack?";
                    }
                }
            }
        }

        private void pbSoldierTop1_Click(object sender, EventArgs e)
        {
            if(pbSoldierTop1.Image != null)
            {
                if (OpponentSoldiers[1].FaceUp)
                {
                    pbDisplay.ImageLocation = OpponentSoldiers[1].LargeImageLink;
                    rtbCardDescription.Text = HandClickDisplay(OpponentSoldiers[1]);

                    if (Battle)
                    {
                        Defender = OpponentSoldiers[1];
                        rtbCurrentEvent.Text = Defender.Name + " chosen as target. Attack?";
                    }
                }
            }
        }

        private void pbSoldierTop2_Click(object sender, EventArgs e)
        {
            if(pbSoldierTop2.Image != null)
            {
                if (OpponentSoldiers[2].FaceUp)
                {
                    pbDisplay.ImageLocation = OpponentSoldiers[2].LargeImageLink;
                    rtbCardDescription.Text = HandClickDisplay(OpponentSoldiers[2]);
                }

                if (Battle)
                {
                    Defender = OpponentSoldiers[2];
                    rtbCurrentEvent.Text = Defender.Name + " chosen as target. Attack?";
                }
            }
        }
        #endregion
    }
}
