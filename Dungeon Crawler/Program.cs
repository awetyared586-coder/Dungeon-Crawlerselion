
using System.Linq;
using Dungeon_Crawler;
using Dungeon_Crawler.Models;

LevelData levelData = new LevelData();
levelData.Load("Level1.txt");

Player player = new Player();
player.X = levelData.PlayerStartX;
player.Y = levelData.PlayerStartY;

foreach (LevelElement element in levelData.Elements)
{
    if (element is Wall || levelData.IsVisible(element, player))
        element.Draw();
}

levelData.SetPlayerForSnakes(player);
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
    Enemy targetEnemy = null;
    foreach(LevelElement element in levelData.Elements) 
    { 
    
        if (element is Enemy enemy && element.X == newX && element.Y == newY)
        {
            enemyAhead = true;
            targetEnemy = enemy;
        }
    
        if (element is Wall && element.X==newX && element.Y == newY)
        {
            wallAhead = true;
            break;
        }
    }
    if (enemyAhead && targetEnemy != null)
    {
        player.AttackEnemy(targetEnemy);
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
    foreach (Enemy enemy in levelData.Elements.OfType<Enemy>().ToList())
    {

    if (enemy.IsDead())
    
    {
        Console.SetCursorPosition(enemy.X, enemy.Y);
        Console.Write(' ');
        levelData.Elements.Remove(enemy);
        continue;
    }


        Console.SetCursorPosition(enemy.X, enemy.Y);
        Console.Write(' ' );


        enemy.Update();
        enemy.Draw();

    }
 }

    

 

