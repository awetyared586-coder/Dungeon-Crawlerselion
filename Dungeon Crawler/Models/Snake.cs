using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Crawler.Models
{
    class Snake : Enemy
    {
        private static readonly Random random = new Random();

        public Snake()
        {
            Name = "Snake";
            Symbol = 's';
            HP = 25;
            Color = ConsoleColor.Blue;
            AttackDice = new Dice(3, 4, 2);
            DefenceDice = new Dice(1, 8, 5);

        }
        public override void Update() 
        {
            int direktion = random.Next(4);
        }

        

        


    }


}
