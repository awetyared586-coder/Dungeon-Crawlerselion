using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Crawler.Models
{
    internal class Player:LevelElement
    {
        public int HP { get; set; }
        public Dice DefenceDice { get; set; }
        public Dice AttackDice { get; set; }


        public Player()
        {
            HP = 100;
            Symbol = '@';
            Color = ConsoleColor.DarkGreen;
            AttackDice = new Dice(2, 6, 2);
            DefenceDice = new Dice(2, 6, 0);
        }
    }

}
