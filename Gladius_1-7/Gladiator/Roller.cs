using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladius
{   
    //this class will return values for "dice" used by the Program for various
    //uses, to include character creation, combat, etc.

    public static class Roller
        {
        
        //creates a static Random object that can be called throughout the entire namespace without red squigglies.
        private static Random rnd = new Random();
        //instance variable that is the return variable for rollXSidedDice() 
        public static int result;
        // get the corresponding die type from the method call 
        // and set diceType to the value of the argument 
        // passed
        public static int rollXSidedDice(int diceType,int minRoll, int numberOfDice)
         {

            result = 0;

            for (int i = 0; i < numberOfDice ; i++)
            {
                result += rnd.Next(minRoll, diceType + 1);
            }

            return result;
        
        }//end method rollXSIdedDice           
        public static Dictionary<string, int> RollCharStats()
        {
            int strengthRaw, agilityRaw, intelligenceRaw, luckRaw, charismaRaw,
            constitutionRaw, maxHitPointsRaw, currentHitPointsRaw, maxRaw;

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
                Console.WriteLine("***Your Character Rolls***\n");
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
                    Console.Clear();
                }
                else
                {// try again if fat-finger
                    Console.WriteLine("Please enter a valid input");
                    #endregion
                }// end if

            }// end while


            return charStats;

        }//end RollCharStats method 
        #region Obsolete static rolling code (by dice type)
        /*
    #region 4-sided die rolling method group
    //roll 1d4
    public int rollFourSidedDie(int die4)
    {
        die4 = (int)(generator.NextDouble() * 4) + 1;
        return die4;
    }

    //roll 2d4
    public int roll2FourSidedDice(int die4, int secondDie4)
    {
        die4 = (int)(generator.NextDouble() * 4) + 1;
        secondDie4 = (int)(generator.NextDouble() * 4) + 1;
        return die4 + secondDie4;
    }

    //roll 3d4
    public int roll3FourSidedDice(int die4, int secondDie4, int thirdDie4)
    {
        die4 = (int)(generator.NextDouble() * 4) + 1;
        secondDie4 = (int)(generator.NextDouble() * 4) + 1;
        thirdDie4 = (int)(generator.NextDouble() * 4) + 1;
        return die4 + secondDie4 + thirdDie4;
    }
    #endregion

    #region 6-sided die rolling method group
    //roll 1d6
    public int rollSixSidedDie(int die6)
    {
        die6 = (int)(generator.NextDouble() * 6) + 1;
        return die6;
    }

    //roll 2d6
    public int roll2SixSidedDice(int die6, int secondDie6)
    {
        die6 = (int)(generator.NextDouble() * 6) + 1;
        secondDie6 = (int)(generator.NextDouble() * 6) + 1;
        return die6 + secondDie6;
    }

    //roll 3d6
    public int roll3SixSidedDice(int die6, int secondDie6, int thirdDie6)
    {
        die6 = (int)(generator.NextDouble() * 6) + 1;
        secondDie6 = (int)(generator.NextDouble() * 6) + 1;
        thirdDie6 = (int)(generator.NextDouble() * 6) + 1;
        return die6 + secondDie6 + thirdDie6;
    }
    #endregion

    #region 8-sided die rolling method group

    //roll 1d8
    public int rollEightSidedDie(int die8)
    {
        die8 = (int)(generator.NextDouble() * 8) + 1;
        return die8;
    }

    //roll 2d8
    public int roll2EightSidedDice(int die8, int secondDie8)
    {
        die8 = (int)(generator.NextDouble() * 8) + 1;
        secondDie8 = (int)(generator.NextDouble() * 8) + 1;
        return die8 + secondDie8;
    }

    //roll 3d8
    public int roll3EightSidedDice(int die8, int secondDie8, int thirdDie8)
    {
        die8 = (int)(generator.NextDouble() * 8) + 1;
        secondDie8 = (int)(generator.NextDouble() * 8) + 1;
        thirdDie8 = (int)(generator.NextDouble() * 8) + 1;
        return die8 + secondDie8 + thirdDie8;
    }
    #endregion

    #region 10-sided die rolling method group
    //roll 1d10
    public int rollTenSidedDie(int die10)
    {
        die10 = (int)(generator.NextDouble() * 10) + 1;
        return die10;
    }

    //roll 2d10
    public int roll2TenSidedDice(int die10, int secondDie10)
    {
        die10 = (int)(generator.NextDouble() * 10) + 1;
        secondDie10 = (int)(generator.NextDouble() * 10) + 1;
        return die10 + secondDie10;
    }

    //roll 3d10
    public int roll3TenSidedDice(int die10, int secondDie10, int thirdDie10)
    {
        die10 = (int)(generator.NextDouble() * 10) + 1;
        secondDie10 = (int)(generator.NextDouble() * 10) + 1;
        thirdDie10 = (int)(generator.NextDouble() * 10) + 1;
        return die10 + secondDie10 + thirdDie10;
    }
    #endregion
    */
        #endregion


    }//end class

}//end namespace

    

