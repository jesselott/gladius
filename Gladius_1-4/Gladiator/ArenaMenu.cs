using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladius
{
    public class ArenaMenu
    {
        int enemyPick = 1;
        string input;
        public ArenaMenu(Fighter f) 
        {
        Console.WriteLine("***Arena Menu***");
            Console.WriteLine();
            Console.WriteLine("Welcome tah de Arena, runt. Wat can ah do fer yah? ");
            Console.WriteLine();
            Console.WriteLine("P)ractice (***not implemented yet***");
            Console.WriteLine("F)ight Opponent");
            Console.WriteLine("C)hoose Weapon(***not implemented yet***");
            Console.WriteLine("G)o back to Main Menu");
            input = Console.ReadLine();
            ChooseOption(input.ToLower(), f);

        }//end ctor
        public string ChooseOption(string input, Fighter f)
        {
            try
            {
                switch (input)
                {
                    case "p":
                        //goes to Practice Fight vs. Pip (TO-DO)
                        break;
                    //goes to the Combat Menu
                    case "f":
                        EnemyGladiator enemy1 = new EnemyGladiator(enemyPick);
                        enemyPick++;
                        CombatMenu cm = new CombatMenu(f, enemy1);
                        break;
                    //same deal, user CAPS
                    //goes to Choose Weapon Menu
                    case "c":
                        break;
                    //goes to Character View Page (TO-DO)
                    case "g":
                        MainMenu mm = new MainMenu(f);
                        break;
                   //throws exception if format is screwy
                    default:
                        //throw new FormatException("Incorrect input, please try again.");
                        break;    
                }//end switch

            }//end try
            catch (FormatException)
            {
                Console.WriteLine("Invalid input, try again.");
                ArenaMenu arenaMenu = new ArenaMenu(f);
            }//end catch
            return input;
        }//end MainMenu ChooseOption method
    }
}
