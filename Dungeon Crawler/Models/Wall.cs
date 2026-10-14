using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dungeon_Crawler.Models
{
     class Wall : LevelElement

    {
        public Wall()
        {
            Symbol = '#';
            Color = ConsoleColor.Gray;

        }
        
    }

   
}
