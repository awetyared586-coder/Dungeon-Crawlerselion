using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Crawler.Models
{
    abstract class Enemy:LevelElement
    {
        public string Name { get; set; } = "";
        public int HP { get; set; }
        public Dice AttackDice { get; set; } = new Dice(1, 6, 0);
        public Dice DefenceDice { get; set; } = new Dice(1, 6, 0);
        public abstract void Update();

        public void TakeDamage(int damage)
        {
            HP -= damage;
        }

        public bool IsDead()
        {
            return HP <= 0;
        }

        public void AttackPlayer(Player player)
        {
            int damage = Math.Max(0, AttackDice.Throw() - player.DefenceDice.Throw());
            player.HP -= damage;
        }

    }


}
