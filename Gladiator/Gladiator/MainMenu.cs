using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator
{

    public class MainMenu
    {
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
        }//end while*/
            #endregion

        }//end Main

        public MainMenu()
        {
            RollCharStats();
        }

        public static Dictionary<string, int> RollCharStats()
        {
            Dictionary<string, int> charStats = new Dictionary<string, int>();
            // just keeps the while loop going
            bool rolling = true;
            while (rolling)
            {
                //roll stats for Fighter
                #region actual rolls for character core stats
                strengthRaw = (Roller.rollXSidedDice(6, 3) + 1);
                agilityRaw = (Roller.rollXSidedDice(6, 3) + 1);
                intelligenceRaw = (Roller.rollXSidedDice(6, 3) + 1);
                luckRaw = (Roller.rollXSidedDice(6, 3) + 1);
                charismaRaw = (Roller.rollXSidedDice(6, 3) + 1);
                constitutionRaw = (Roller.rollXSidedDice(6, 3) + 1);
                maxHitPointsRaw = (Roller.rollXSidedDice(20, 3) + 10);
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

                Console.Write("Are you satisfied with your stats and ready to proceed? (Y/N) ");
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


            // creating fighter object and passing dictionary or rolled stats as parameter
            Fighter fighter = new Fighter(charStats);

            // just want to stop the program here to see if the vars that were populated
            // were populated correctly
            Console.ReadLine();
            //returns a dictionary of type charStats;
            return charStats;
            
        }//end RollCharStats method               

    }//end class

}//end namespace

