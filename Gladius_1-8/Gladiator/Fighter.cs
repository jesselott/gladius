using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladius
{
    //this class defines the hero by holding his fields and properties.  It also defines how the fighter 
    //(and his counterpart) do their fighting.  Stay tuned for more derivations for this fighter class,
    //possibly a menu option to choose a class with special skills or spells, etc.

    public class Fighter
    {
        //Fighter class fields
        #region Fighter fields
        private string fName/*CharactersName*/;
        private int fHP/*CurrentHitPoints*/, fMHP/*MaxHitPoints*/, fXP/*ExperiencePoints*/, fLvl = 1/*Level*/, 
            fStr/*Strength*/, fAgl/*Agility*/, fInt/*Intelligence*/, fLck/*Luck*/, fChr/*Charisma*/,
            fCon/*Constitution*/, fSpr/*Spirit*/, fFry/*Fury*/, fNot/*Noteriety*/, fFam/*Fame*/,
            fMny/*Money*/,fMnyErn/*MoneyEarned*/, fKills/*Kills*/;
        private object fWeapon, fArmor;
        #endregion

        //Fighter class properties
        #region Fighter Class Props

        public string Name
        { get { return fName; } set { fName = value; } }

        public object Weapon
        { get { return fWeapon;} set {fWeapon = value;} }

        public object Armor
        { get { return fArmor; } set { fArmor = value; } }

        public int Strength
        { get { return fStr; } set { fStr = value; } }

        public int Agility
        { get { return fAgl; } set { fAgl = value; } }

        public int Intelligence
        { get { return fInt; } set { fInt = value; } }

        public int Luck
        { get { return fLck; } set { fLck = value; } }

        public int Charisma
        { get { return fChr; } set { fChr = value; } }

        public int Constitution
        { get { return fCon; } set { fCon = value; } }

        public int Spirit
        { get { return fSpr; } set { fSpr = value; } }

        public int Fury
        { get { return fFry; } set { fFry = value; } }

        public int Notoriety
        { get { return fNot; } set { fNot = value; } }

        public int Fame
        { get { return fFam; } set { fFam = value; } }

        public int Money
        { get { return fMny; } set { fMny = value; } }

        public int MoneyEarned
        { get { return fMnyErn; } set { fMnyErn = value; } }

        public int CurrentHitPoints
        { get { return fHP; } set { fHP = value; } }

        public int MaxHitPoints
        { get { return fMHP; } set { fMHP = value; } }

        public int ExperiencePoints
        { get { return fXP; } set { fXP = value; } }

        public int Level
        { get { return fLvl; } set { fLvl = value; } }

        public int Kills
        { get { return fKills; } set { fKills = value; } }


        #endregion

        //Fighter base constructor
        #region Fighter Ctor, uses a dictionary built in the Roller class to add the core stats to fields and props

        public Fighter()
        {
            Name = "Glad Jr.";

        }
        
        public Fighter (Dictionary<string, int>RollCharStats)
        {
           int value;
            Name = "Glad Jr.";
            if (RollCharStats.TryGetValue("Strength", out value))
            { Strength = value; }
            if (RollCharStats.TryGetValue("Agility", out value))
            { Agility = value; }
            if (RollCharStats.TryGetValue("Intelligence", out value))
            { Intelligence = value; }
            if (RollCharStats.TryGetValue("Luck", out value))
            { Luck = value; }
            if (RollCharStats.TryGetValue("Charisma", out value))
            { Charisma = value; }
            if (RollCharStats.TryGetValue("Constitution", out value))
            { Constitution = value; }
            Spirit = 0;
            Fury = 0;
            Notoriety = 0;
            Fame = 0;
            Money = 500;
            if (RollCharStats.TryGetValue("CurrentHitPoints", out value))
            { CurrentHitPoints = value; }
            if (RollCharStats.TryGetValue("MaxHitPoints", out value))
            { MaxHitPoints = value; }
            ExperiencePoints = 0;
            Level = 1;                          
        }
        #endregion

        //Fighter methods
        #region Fighter Methods
        public int AttackEnemy()
        {
            int toHit = Roller.rollXSidedDice(20,1,1) + (Agility + (Strength / 2) + (Intelligence / 2) + (Luck / 2));
           
            return toHit;
        }
       
        public int Avoid()
        {
            int avoid = Roller.rollXSidedDice(20,1,1) + (Agility + (Constitution / 2) + (Intelligence / 2) + (Luck / 2));

            return avoid;
            
        }

        public int CalculateDamage()
        { 
           int inflict = ((Strength / 3) + (Roller.rollXSidedDice(12,1,1)));

           return inflict;
        }

        public int ReceiveDamage(int damage)
        {
            CurrentHitPoints -= damage;
            return damage;
        }
        public static int CalculateBaseAtkBonus(int Level)//not implemented yet
        {//calculates attack bonus to modify attack roll
            int baseAtkBonus = Level;
            int additionalAtkBonus = -5 + Level;
            int thirdAtkBonus = -11 + Level;  
            int sumAtkBonus = 0;
            if (Level < 6)
                sumAtkBonus = baseAtkBonus;
            else if (Level < 12)
                sumAtkBonus = baseAtkBonus + additionalAtkBonus;
            else
                sumAtkBonus = baseAtkBonus + additionalAtkBonus + thirdAtkBonus;

            return sumAtkBonus;
        }

        public static int CalculateStrengthBonus(int Strength)//not implemented yet
        {//calculates the effect of strength on melee attack roll / damage)
            int strengthBonus = 0;
            if (Strength > 21)
                strengthBonus = 6;
            else if (Strength > 19)
                strengthBonus = 5;
            else if (Strength > 17)
                strengthBonus = 4;
            else if (Strength > 15)
                strengthBonus = 3;
            else if (Strength > 13)
                strengthBonus = 2;
            else if (Strength > 11)
                strengthBonus = 1;
            else if (Strength < 10)
                strengthBonus = -1;
            else if (Strength < 8)
                strengthBonus = -2;
            else if (Strength < 6)
                strengthBonus = -3;
            else
                strengthBonus = 0;

            return strengthBonus;
        }
        public static int CalculateAgilityBonus(int Agility)
        {//calculates the effect of agility on ranged attack roll / armor class)
            int agilityBonus = 0;
            if (Agility > 21)
                agilityBonus = 6;
            else if (Agility > 19)
                agilityBonus = 5;
            else if (Agility > 17)
                agilityBonus = 4;
            else if (Agility > 15)
                agilityBonus = 3;
            else if (Agility > 13)
                agilityBonus = 2;
            else if (Agility > 11)
                agilityBonus = 1;
            else if (Agility < 10)
                agilityBonus = -1;
            else if (Agility < 8)
                agilityBonus = -2;
            else if (Agility < 6)
                agilityBonus = -3;
            else
                agilityBonus = 0;

            return agilityBonus;
        }
        public void Die()
        {
            Console.WriteLine("{0} has died and has gone to Valhalla with the others who \n have died a glorious death in the arena.", Name);
            Console.WriteLine("Do you wish to start a new game?");
            string yesno = Console.ReadLine();
            yesno = yesno.ToLower();
            switch (yesno)
            {
                case "y":
                    {
                        //enter game stats here
                        MainMenu.CharCreator();
                        break;
                    }
                case "n":
                    {
                        //enter stats here (kills, money, fame, etc.)
                        Console.WriteLine("Come back to the arena soon");
                        MainMenu.QuitGame();
                        break;
                        
                    }
                default:
                    MainMenu.QuitGame();
                    break;
                    
            }
            
        }
        #endregion

    }//end Fighter Class


}//end namespace
