using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator
{
    
    class Inventory
    {
    }

    public class WeaponDamage
    {
     public static int ItHit(int attackRoll, int dieType, int numberOfTimesRolled, int criticalHitModifier)
        {
            int weaponDamage = Roller.rollXSidedDice(dieType, 1, numberOfTimesRolled);
            int criticalWeaponDamage = (Roller.rollXSidedDice(dieType, 1, numberOfTimesRolled) * criticalHitModifier);
            if (attackRoll >= 19)
            {
                return criticalWeaponDamage;
            }    
            else
            {
                return weaponDamage;
            }
        }
    }
    public class GreatBigAxe
    {
        public string description = "This axe is soooo big, it gives other axes penis envy.";
        public string name;
        public int durability;
        public GreatBigAxe()
        {
            name = "Great Big Axe";
            durability = 12;

        }
        public static int GBAHit(int attackRoll)
        {
            int damage = WeaponDamage.ItHit(attackRoll, 6, 1, 2);
            return damage;
        }
    }//endGBA
        public class SmediumSword
        {
            public string description = "This sword is just right...if you're Pee-Wee Herman.";
            public string name;
            public int durability;
            public SmediumSword()
            {
                name = "Smedium Sword";
                durability = 12;

            }
            public static int SmediumSwordHit(int attackRoll)
            {
                int damage = WeaponDamage.ItHit(attackRoll, 6, 1, 2);
                return damage;
            }
        } //end smedium 
        public class FlimsyRapier
        {
            public string description = "This sword was bought from the JV fencing team for 52 cents.";
            public string name;
            public int durability;
            public FlimsyRapier()
            {
                name = "Flimsy Rapier";
                durability = 12; 

            }
            public static int FlimsyRapierHit(int attackRoll)
            {
                int damage = WeaponDamage.ItHit(attackRoll, 6, 1, 2);
                return damage;
            }

        }//end flimsy
   
}//end namespace
