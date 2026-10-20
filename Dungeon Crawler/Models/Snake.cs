using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Dungeon_Crawler.Models
{
    class Snake : Enemy

    {

        private Player player;
        private LevelData levelData;
       
        public Snake(LevelData levelData)

        {
            this.levelData = levelData;

            Name = "Snake";
            Symbol = 's';
            HP = 25;
            Color = ConsoleColor.Blue;
            AttackDice = new Dice(3, 4, 2);
            DefenceDice = new Dice(1, 8, 5);

        }
        public void setPlayer(Player player)

        {
            this.player = player;

        }

        public override void Update()
        {
            if (player == null)
                return;
            int dx = player.X - X;
            int dy = player.Y - Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (distance > 2)
                return;


            int newX = X;
            int newY = Y;

            if (Math.Abs(dx) >= Math.Abs (dy) && dx != 0) 
            {
                newX -= Math.Sign(dx);
            }
            else if (dy != 0)
            {
                newY -= Math.Sign(dy);

            }

            if (newX < 0 || newY <= 0 ||
                levelData.WallAhead(newX, newY) ||
                levelData.IsOccupied(newX, newY))
                return;
            
                X = newX;
                Y = newY;
                 
        }
    }

}
