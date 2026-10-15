using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Dungeon_Crawler.Models
{
    internal class Dice
    {
        
       public int NumberOfDice { get; set; }
       public int SidePerDice { get; set; }
       public int Modifier { get; set; }
        
        public Dice(int NumberOfDice, int SidePerDice, int Modifier)
        {
            this.NumberOfDice = NumberOfDice;
            this.SidePerDice = SidePerDice;
            this.Modifier = Modifier;
        }
    }
}
