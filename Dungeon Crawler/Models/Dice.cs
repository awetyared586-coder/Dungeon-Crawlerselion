using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Dungeon_Crawler.Models
{
    internal class Dice

    {
    private static readonly Random random = new Random();

    public int NumberOfDice { get; set; }
       public int SidePerDice { get; set; }
       public int Modifier { get; set; }
        
        public Dice(int numberOfDice, int SidePerDice, int Modifier)
        {
            this.NumberOfDice = numberOfDice;
            this.SidePerDice = SidePerDice;
            this.Modifier = Modifier;
            
            
        }

        public int Throw()
        {
            
            int total = 0;

            for(int i =0; i < NumberOfDice; i++)
            {
                total += random.Next(1, SidePerDice + 1);
            }

            return total + Modifier;
            
        }

        public override string ToString()
        {
            return $"{NumberOfDice}d{SidePerDice}+{Modifier}";
        }
       
    }    
   
}
    