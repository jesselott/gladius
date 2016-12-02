using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladius
{
    //This class serves as the entry point to the program and main interface that navigates the user to 
    //a selected action (right now there is no choice but to navigate to where I tell you to go)
    //More choices will be implemented as I steadily upgrade the functionality of the code
    public class MainMenu
    {
        string input;
        
        

        public static void Main(string[] args)
        {          
           CharCreator();
        }

        public static Fighter CharCreator()
        {
            Console.WriteLine("***Welcome to the world of Gladius***");
            Console.WriteLine();
            Console.WriteLine("Insert beginning story here, how did character get here?");
            Console.WriteLine();
            Console.WriteLine("***Roll your character stats until satisfied, Gladiator***");
            Console.WriteLine();
            Console.WriteLine("Can you fight, or are you just another morsel for the Emperor's lions?");
            Console.WriteLine();
            Fighter fighter = new Fighter(Roller.RollCharStats());
            Console.Write("Tell me your name, prisoner. ");
            fighter.Name = Console.ReadLine();
            MainMenu mm = new MainMenu(fighter);
            return fighter;
        }
        public MainMenu(Fighter f)
        {
            Console.WriteLine();
            Console.WriteLine("***Gladius Main Menu***");
            Console.WriteLine();
            Console.WriteLine("Choose an option, {0}, and make it quick.", f.Name);
            Console.WriteLine("The Emperor arrives soon, and he wants to see blood.\n");
            Console.WriteLine("E)nter Arena");
            Console.WriteLine("C)haracter Options ***NOT IMPLEMENTED(yet)***");
            Console.WriteLine("V)iew Active Gladiator***NOT IMPLEMENTED(yet)***");
            Console.WriteLine("Q)uit");
            input = ChooseOption(Console.ReadLine(), f);
            
        }
        public string ChooseOption(string input, Fighter f)
        {
            try
            {//make sure user doesn't fat finger this menu, 
             //wanted to implement String.ToLower, but can't 
             //get it to work at this time (do more research)

                switch (input)
                {
                    //goes to the Arena Menu (TO-DO)
                    case "e":
                        ArenaMenu arena = new ArenaMenu(f);
                        break;
                    //same deal, user CAPS
                    case "E":
                        ArenaMenu arenaa = new ArenaMenu(f);
                        break;
                    //goes to Options Menu
                    case "c":
                        break;
                    //user CAPS
                    case "C":
                        break;
                    //goes to Character View Page (TO-DO)
                    case "v":
                        break;
                    //user CAPS
                    case "V":
                        break;
                    //quits game, prompts save (TO-DO)
                    case "q":
                        break;
                    //quits game in ALL CAPS
                    case "Q":
                        break;
                    //starts loop over when user inputs something other than menu 
                    default:
                        throw new FormatException("Incorrect input, please try again.");

                }//end switch

            }//end try
            catch(FormatException)
            {
                MainMenu mm = new MainMenu(f);
            }//end catch
            return input;
        }//end MainMenu ChooseOption method
        
        
        
        #region Gladius version 1.2
        /*public string name;
        static int strengthRaw, agilityRaw, intelligenceRaw, luckRaw, charismaRaw,
            constitutionRaw, maxHitPointsRaw, currentHitPointsRaw, maxRaw;

        
        public static void Main(string[] args)
        {
            
            MainMenu mm = new MainMenu();

            #region Infinite loop that checks functionality of XRoller results
            /*bool keepGoing = true;

            while (keepGoing == true)

            {//checking my XRoller results by rolling in infinite loop

                    
                    int result1 = Roller.rollXSidedDice(4, 1);
                    Console.WriteLine("\nThis is one 4 sided die: " + (result1));
                    int result2 = Roller.rollXSidedDice(6, 2);
                    Console.WriteLine("\nThese are two 6 sided dice: " + (result2));
                    int result3 = Roller.rollXSidedDice(8, 3);
                    Console.WriteLine("\nThese are three 8 sided dice: " + (result3));
                    int result4 = Roller.rollXSidedDice(10, 1);
                    Console.WriteLine("\nThis is one 10 sided die: " + (result4));
                    int result5 = Roller.rollXSidedDice(12, 3);
                    Console.WriteLine("\nThese are three 12 sided dice: " + (result5));
                    int result6 = Roller.rollXSidedDice(20, 1);
                    Console.WriteLine("\nThis is one 20 sided die: " + (result6));
                    int result7 = Roller.rollXSidedDice(100, 2);
                    Console.WriteLine("\nThese are two 100 sided dice: " + (result7));
                    Console.ReadLine();

            }//end if
        }//end while
            #endregion

        }//end Main

        public MainMenu()
        {
            //Dictionary<string, int> charStats = new Dictionary<string, int>();
            Console.Write("What is your name, Gladiator? ");
            name = Console.ReadLine();
            Fighter fighter = new Fighter(RollCharStats());
            EnemyGladiator enemy = new EnemyGladiator(Roller.rollXSidedDice(4,1,1)+1);
            fighter.Name = name;
            Console.WriteLine("{1} will be facing {0} in the Arena for 200 Caesars!!", enemy.Name, fighter.Name);
            CombatMenu cm = new CombatMenu(fighter, enemy);

        }//end MainMenu

        public static Dictionary<string, int> RollCharStats()
        {
            Dictionary<string, int> charStats = new Dictionary<string, int>();
            // just keeps the while loop going
            bool rolling = true;

            while (rolling)
            {
                //roll stats for Fighter
                #region actual rolls for character core stats
                strengthRaw = Roller.rollXSidedDice(6, 2, 3);
                agilityRaw = Roller.rollXSidedDice(6, 2, 3);
                intelligenceRaw = Roller.rollXSidedDice(6, 2, 3);
                luckRaw = Roller.rollXSidedDice(6, 2, 3);
                charismaRaw = Roller.rollXSidedDice(6, 2, 3);
                constitutionRaw = Roller.rollXSidedDice(6, 2, 3);
                maxHitPointsRaw = Roller.rollXSidedDice(20, 4, 3);
                maxRaw = maxHitPointsRaw;
                currentHitPointsRaw = maxRaw;
                #endregion

                #region displaying stats to the user and prompting to continue or roll again
                Console.WriteLine("Your strength is:   \t\t {0}  \n", strengthRaw);
                Console.WriteLine("Your agility is:\t\t  {0} \n", agilityRaw);
                Console.WriteLine("Your intelligence is:\t\t  {0} \n", intelligenceRaw);
                Console.WriteLine("Your luck is:\t\t\t  {0} \n", luckRaw);
                Console.WriteLine("Your charisma is:\t\t  {0} \n", charismaRaw);
                Console.WriteLine("Your constitution is:\t\t  {0} \n", constitutionRaw);
                Console.WriteLine("Your max hit points are:\t  {0} \n", maxHitPointsRaw);
                Console.WriteLine("Your current hit points are:\t  {0} \n", currentHitPointsRaw);

                Console.Write("Are you satisfied with your stats and ready to proceed? (Y/N)\n ");
                string input = Console.ReadLine();
                #endregion


                // if statement that checks if the user wishes to continue or re-roll
                // and adds stats rolled in last region to the Dictionary returned in
                // this method
                #region if statement
                
                if (input == "Y" || input == "y")
                {// adding rolled attributes to dictionary 
                    charStats.Add("Strength", strengthRaw);
                    charStats.Add("Agility", agilityRaw);
                    charStats.Add("Intelligence", intelligenceRaw);
                    charStats.Add("Luck", luckRaw);
                    charStats.Add("Charisma", charismaRaw);
                    charStats.Add("Constitution", constitutionRaw);
                    charStats.Add("MaxHitPoints", maxHitPointsRaw);
                    charStats.Add("CurrentHitPoints", currentHitPointsRaw);
                    rolling = false;
                    break;
                }
                else if (input == "N" || input == "n")
                {// continue loop
                    rolling = true;
                }
                else
                {// try again if fat-finger
                    Console.WriteLine("Please enter a valid input");
                #endregion
                }// end if

            }// end while
               
            
           return charStats;

        }//end RollCharStats method   */       
        #endregion Gladius 1.2

    }//end class

}//end namespace