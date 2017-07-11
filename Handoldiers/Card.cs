using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handoldiers
{
    public class Card
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }   //string for image for card
        public string LargeImageLink { get; set; }
        public int CardType { get; set; }
        public bool Effect { get; set; }    //Effect monster?
        public bool FlipEffect { get; set; }    //Flip-Effect monster?
        public int Level { get; set; }  //Monster Level, Non-Monster = 0
        public int Atk { get; set; }    //Monster Atk, Non-Monster = 0
        public int StartingAtk { get; set; }
        public int StartingDef { get; set; }
        public int Def { get; set; }    //Monster Def, Non-Monster = 0        
        public string Description { get; set; } //Description of card
        public bool FaceUp { get; set; }

        public Card()
        {
            ID = 0;
            Name = null;
            ImageLink = null;
            LargeImageLink = null;
            CardType = 0;
            Effect = false;
            FlipEffect = false;
            Level = 0;
            Atk = 0;
            Def = 0;
            Description = null;
            FaceUp = true;
        }
    }
}
