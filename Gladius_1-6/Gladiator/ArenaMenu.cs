using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladius
{
    public class ArenaMenu
    {
        
        string input;
        public ArenaMenu(Fighter f, int enemyPick) 
        {
        Console.WriteLine("***Arena Menu***");
            Console.WriteLine();
            Console.WriteLine("A massive, scarred-up, retired Gladiator looks you up and down and says: ");
            Console.WriteLine("Welcome to the Arena, runt. What can I do for you? ");
            Console.WriteLine();
            Console.WriteLine("P)ractice (***not implemented yet***");
            Console.WriteLine("F)ight Opponent");
            Console.WriteLine("E)quipment Store(***not implemented yet***");
            Console.WriteLine("G)o back to Main Menu");
            input = Console.ReadLine();
            ChooseOption(input.ToLower(), f, enemyPick);

        }//end ctor
        public string ChooseOption(string input, Fighter f, int enemyPick)
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
                        EnemyGladiator enemy1 = new EnemyGladiator(enemyPick, f);
                        Console.WriteLine("You will be fighting {0} in the arena!", enemy1.Name);
                        CombatMenu cm = new CombatMenu(f, enemy1, enemyPick);
                        break;
                    //goes to Gladiator Store (TO-DO)
                    case "c":
                        break;
                    //goes to Character View Page (TO-DO)
                    case "g":
                        MainMenu mm = new MainMenu(f, enemyPick);
                        break;
                   //throws exception if format is screwy
                    default:
                        throw new FormatException("Incorrect input, please try again.");
                        
                }//end switch

            }//end try
            catch (FormatException)
            {
                Console.WriteLine("Invalid input, try again.");
                ArenaMenu arenaMenu = new ArenaMenu(f, enemyPick);
            }//end catch
            return input;
        }//end MainMenu ChooseOption method
    }
}
