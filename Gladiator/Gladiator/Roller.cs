using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator
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
        public static int rollXSidedDice(int diceType, int numberOfDice)
         { 
            switch (diceType)
            {
                case 2:
                    diceType = 2;
                    break;
                case 4:
                    diceType = 4;
                    break;
                case 6:
                    diceType = 6;
                    break;
                case 8:
                    diceType = 8;
                    break;
                case 10:
                    diceType = 10;
                    break;
                case 12:
                    diceType = 12;
                    break;
                case 20:
                    diceType = 20;
                    break;
                case 100:
                    diceType = 100;
                    break;
                default:
                    throw new ArgumentException("We don't have that type of die. We have 2,4,6,8,10,12,20 & 100 sided dice \n" +
                        "and can roll up to 3 times per type of die.  Please stay within those parameters.");
                    
            }//end switch 

            //this if statement checks the number of dice in the argument passed 
            //and rolls the appopriate number of times with a Randomly generated number
                        
            if (numberOfDice == 1)
            {
                result = (rnd.Next(0, diceType) + 1);
            }
            else if (numberOfDice == 2)
            {
                result = (rnd.Next(0, diceType) + 1) + (rnd.Next(0, diceType) + 1);
            }
            else
            {
                result = (rnd.Next(0, diceType)+ 1) + (rnd.Next(0, diceType)+ 1) + (rnd.Next(0, diceType)+ 1); 
                        
            }//end if

            return result;
        
        }//end method rollXSIdedDice           

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

    

