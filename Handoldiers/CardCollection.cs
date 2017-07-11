using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handoldiers
{
    public class CardCollection: List<Card>
    {
        public void BuildUrlsavaDeck()
        {
            //build Urlava deck
            this.Add(new Urslava());
            this.Add(new Urslava());
            this.Add(new DevilPickle());
            this.Add(new DevilPickle());
            this.Add(new DevilPickle());
            this.Add(new DevilPickle());
            this.Add(new DevilPickle());
            this.Add(new RoyalRockArmy());
            this.Add(new RoyalRockArmy());
            this.Add(new RoyalRockArmy());
        }
        public void BuildPicklechewDeck()
        {
            //build picklechew deck
            this.Add(new Picklechew());
            this.Add(new Picklechew());
            this.Add(new MarigoldMugger());
            this.Add(new MarigoldMugger());
            this.Add(new MarigoldMugger());
            this.Add(new MarigoldMugger());
            this.Add(new MarigoldMugger());
            this.Add(new CurseOfGrandma());
            this.Add(new CurseOfGrandma());
            this.Add(new CurseOfGrandma());
        }
        public void BuildHand(CardCollection passedDeck)
        {
            for (int i = 0; i < 5; i++)
            {
                this.Add(passedDeck[0]);
                passedDeck.RemoveAt(0);
            }
        }
        public void ShuffleDeck()
        {
            Random rnd = new Random();
            int n = this.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Card temp = this[k];
                this[k] = this[n];
                this[n] = temp;
            }
        }
    }
}
