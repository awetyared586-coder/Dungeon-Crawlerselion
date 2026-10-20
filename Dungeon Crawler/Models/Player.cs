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

        public int Attack()
        {
            return AttackDice.Throw(); 
        }

        public void AttackEnemy(Enemy enemey)
        {
            enemey.TakeDamage(Math.Max(0, AttackDice.Throw() - enemey.DefenceDice.Throw()));
            if (!enemey.IsDead())
                HP -= Math.Max(0, enemey.AttackDice.Throw() - DefenceDice.Throw());
            
        }

        public bool IsDead()
        {
            return HP <=0;
        }
    }

}
