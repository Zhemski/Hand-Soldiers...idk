using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handoldiers
{
    public class Urslava : Card
    {
        //Type of Card, 1 = Soldier, 2 = Tool
        public Urslava()
        {
            ID = 1;
            Name = "Urslav";
            ImageLink = @"C:\Users\Ben\Desktop\Program_Practice\C#\Handoldiers\Handoldiers\Resources\01.png";
            LargeImageLink = @"C:\Users\Ben\Desktop\Program_Practice\C#\Handoldiers\Handoldiers\Resources\01L.png";
            CardType = 1;
            Level = 3;
            Atk = 35;
            StartingAtk = 25;
            Def = 60;
            StartingDef = 60;
            Description = "The wild Urslav may be seen in its natural habitat performing its mating ritual, the squat. It is rarely seen without its affifas attire.";
        }
    }
    public class Picklechew : Card
    {
        public Picklechew()
        {
            ID = 2;
            Name = "Picklechew";
            ImageLink = @"C:\Users\Ben\Desktop\Program_Practice\C#\Handoldiers\Handoldiers\Resources\02.png";
            LargeImageLink = @"C:\Users\Ben\Desktop\Program_Practice\C#\Handoldiers\Handoldiers\Resources\02L.png";
            CardType = 1;
            Level = 3;
            Atk = 25;
            StartingAtk = 20;
            Def = 70;
            StartingDef = 70;
            Description = "A monsterous creature, capable of, and very interessted in, devouring all that will fit in its large mouth. Loves pickles";
        }
    }
    public class DevilPickle : Card
    {
        public DevilPickle()
        {
            ID = 3;
            Name = "Devil Pickle";
            ImageLink = @"C:\Users\Ben\Desktop\Program_Practice\C#\Handoldiers\Handoldiers\Resources\03.png";
            LargeImageLink = @"C:\Users\Ben\Desktop\Program_Practice\C#\Handoldiers\Handoldiers\Resources\03L.png";
            CardType = 1;
            Level = 1;
            Atk = 8;
            StartingAtk = 8;
            Def = 8;
            StartingDef = 8;
            Description = "Guardians of Veggie Hell, a place where only soured veggies go. The only veggie more sour than pickle is a devil pickle.";
        }
    }
    public class MarigoldMugger: Card
    {
        public MarigoldMugger()
        {
            ID = 4;
            Name = "Marigold-Mugger";
            ImageLink = @"C:\Users\Ben\Desktop\Program_Practice\C#\Handoldiers\Handoldiers\Resources\04.png";
            LargeImageLink = @"C:\Users\Ben\Desktop\Program_Practice\C#\Handoldiers\Handoldiers\Resources\04L.png";
            CardType = 1;
            Level = 1;
            Atk = 12;
            StartingAtk = 12;
            Def = 4;
            StartingDef = 4;
            Description = "A frail and stupid, but violent plant. The only size comparison Marigold-Mugger makes is between his wallet and yours.";
        }
    }
    public class RoyalRockArmy : Card
    {
        public RoyalRockArmy()
        {
            ID = 5;
            Name = "The Royal Rock Army";
            ImageLink = @"C:\Users\Ben\Desktop\Program_Practice\C#\Handoldiers\Handoldiers\Resources\05.png";
            LargeImageLink = @"C:\Users\Ben\Desktop\Program_Practice\C#\Handoldiers\Handoldiers\Resources\05L.png";
            CardType = 1;
            Level = 2;
            Atk = 10;
            StartingAtk = 10;
            Def = 30;
            StartingDef = 30;
            Description = "A very sturdy army of minerals. The Royal Rock Army strives to become the fastest, most aggresive, fighting force on the planet. They'll get there...someday...maybe.";
        }
    }
    public class CurseOfGrandma : Card
    {
        public CurseOfGrandma()
        {
            ID = 6;
            Name = "Curse of Grandma";
            ImageLink = @"C:\Users\Ben\Desktop\Program_Practice\C#\Handoldiers\Handoldiers\Resources\06.png";
            LargeImageLink = @"C:\Users\Ben\Desktop\Program_Practice\C#\Handoldiers\Handoldiers\Resources\06L.png";
            CardType = 1;
            Level = 2;
            Atk = 20;
            StartingAtk = 20;
            Def = 20;
            StartingDef = 20;
            Description = "\"Aw blast it all! I forgot to record wrasslin\'\"";

        }
    }
}
