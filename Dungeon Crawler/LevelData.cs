

using Dungeon_Crawler.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Linq;

namespace Dungeon_Crawler
{
    internal class LevelData
    {
        private List<LevelElement> elements = new List<LevelElement>();
        private HashSet<(int, int)> discoveredWalls = new HashSet<(int, int)>();

        public int PlayerStartX { get; private set; }
        public int PlayerStartY { get; private set; }
        public void Load(string filename)
        {
            elements.Clear();

            String[] Lines = File.ReadAllLines(filename);

            for (int i = 0; i < Lines.Length; i++)
            {
                for (int j = 0; j < Lines[i].Length; j++)
                {

                    char symbol = Lines[i][j];

                    if (symbol == '#')
                    {
                        Wall wall = new Wall();

                        wall.X = j;
                        wall.Y = i;
                        elements.Add(wall);
                    }

                    if (symbol == 'r')
                    {
                        Rat rat = new Rat(this);
                        rat.X = j;
                        rat.Y = i;
                        elements.Add(rat);
                    }
                    if (symbol == 's')
                    {
                        Snake snake = new Snake(this);
                        snake.X = j;
                        snake.Y = i;
                        elements.Add(snake);
                    }

                    if (symbol == '@')
                    {
                        PlayerStartX = j;
                        PlayerStartY = i;
                    }
                }

            }
        }

        public List<LevelElement> Elements
        {
            get { return elements; }
        }

        public void SetPlayerForSnakes(Player player)
        {
            foreach (LevelElement element in elements)
            {
                if (element is Snake snake)
                {
                    snake.setPlayer(player);
                }
                if (element is Rat rat)
                {
                    rat.SrtPlayer(player);
                }
            }
        }

        public bool WallAhead(int newX, int newY)
        {
            foreach (LevelElement element in Elements)
            {
                if (element is Wall &&
                    element.X == newX &&
                    element.Y == newY)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsOccupied(int x, int y)
        {
            foreach(LevelElement element in Elements)
            {
                if  (element.X== x && element.Y== y)
                {
                    return true;
                }
            }

            return false;
        }
        
        public bool PlayerAhead(int x, int y, Player player)
        {
            return player.X == x && player.Y == y;
        }
        public bool IsVisible(LevelElement element, Player player)
        {

            int dx = element.X - player.X;
            int dy = element.Y - player.Y;
            return dx * dx + dy * dy <= 25;
        }

        public void UpdateWalls(Player player)
        {
            foreach (Wall w  in elements.OfType<Wall>())
                if (IsVisible(w, player))
                    discoveredWalls.Add((w.X, w.Y));

        }
        public bool IsWallDiscoverd(Wall wall)
        {
            return discoveredWalls.Contains((wall.X, wall.Y));
        }

        public void DrawLevel(Player player)
        {
            UpdateWalls(player);
            Console.Clear();

            foreach (LevelElement e in elements)
                if (e is Wall w && IsWallDiscoverd(w) ||
                    e is Enemy && IsVisible(e, player))
                    e.Draw();

            player.Draw();

        }

    }


        
}
    