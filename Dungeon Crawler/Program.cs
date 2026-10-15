
using System.Linq;
using Dungeon_Crawler;
using Dungeon_Crawler.Models;

LevelData levelData = new LevelData();
levelData.Load("Level1.txt");

foreach(LevelElement element in levelData.Elements)
{
    element.Draw();
}

Player player = new Player();
levelData.SetPlayerForSnakes(player);

player.X = levelData.PlayerStartX;
player.Y = levelData.PlayerStartY;

player.Draw();

while (true)
{
    ConsoleKeyInfo Key = Console.ReadKey(true);

    int newX = player.X;
    int newY = player.Y;
    
    switch (Key.Key)
    {
        case ConsoleKey.LeftArrow:
            newX--;
            break;
        case ConsoleKey.RightArrow:
           newX++;
            break;
        case ConsoleKey.UpArrow: 
            newY--;
            break;
        case ConsoleKey.DownArrow:
            newY++;
            break;                
    }
    bool wallAhead = false;
    bool enemyAhead = false;
    foreach(LevelElement element in levelData.Elements) 
    { 
    
        if (element is Enemy && element.X == newX && element.Y == newY)
        {
            enemyAhead = true;
        }
    
        if (element is Wall && element.X==newX && element.Y == newY)
        {
            wallAhead = true;
            break;
        }
    }

    if (!wallAhead && !enemyAhead)
    {
        Console.SetCursorPosition(player.X, player.Y);
        Console.Write(' ' );

        player.X = newX;
        player.Y = newY;

        levelData.SetPlayerForSnakes(player);
        player.Draw();

    }
    foreach (Enemy enemy in levelData.Elements.OfType<Enemy>())
    {
        Console.SetCursorPosition(enemy.X, enemy.Y);
        Console.Write(' ');
        enemy.Update();
        enemy.Draw();
    }

}
 

