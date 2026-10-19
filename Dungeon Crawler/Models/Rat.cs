using Dungeon_Crawler;
using Dungeon_Crawler.Models;
using System.Drawing;
using System.Threading.Channels;
using System.Xml.Linq;
class Rat : Enemy
    
{


    private static readonly Random random = new Random();

    private LevelData levelData;
    private Player player;


    public Rat(LevelData levelData)
    {
        this.levelData = levelData;

        Name = "Rat";
        HP = 10;
        Symbol = 'r';
        Color = ConsoleColor.Red;

        AttackDice = new Dice(1, 6, 3);
        DefenceDice = new Dice(1, 6, 1);
    }

    public void SrtPlayer(Player player)
    {
        this.player = player;
    }

    public override void Update()
    {
        int direction = random.Next(4);

        int newX = X;
        int newY = Y;

        switch (direction)
        {
            case 0:
                newX++;
                break;

            case 1:
                newX--;
                break;

            case 2:
                newY++;
                break;

            case 3:
                newY--;
                break;
        }

        if (newX >=0 && newY >=0 &&
            newX < Console.WindowWidth &&
            newY < Console.WindowHeight&&
            !levelData.IsOccupied(newX,newY)&&
            !levelData.PlayerAhead(newX, newY, player))
        {
            X = newX;
            Y = newY;
        }
    }
}
