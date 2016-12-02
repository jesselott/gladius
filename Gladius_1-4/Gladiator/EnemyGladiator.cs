using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladius
{
    //this class defines what an enemy gladiator does
    //need to implement fighter-specific logic and special skills
    //again, this is still at the mapping-out stage with < 0 polish
    class EnemyGladiator : Fighter
    {
        public EnemyGladiator(int character)
        {
            switch (character)
            {
                case 1:
                    Name = "Rich Ro$$";
                    Strength = 18;
                    Agility = 12;
                    Intelligence = 12;
                    Luck = 12;
                    Constitution = 12;
                    MaxHitPoints = 50;
                    CurrentHitPoints = 50;
                    break;
                case 2:
                    Name = "Macho Dan";
                    Strength = 15;
                    Agility = 15;
                    Intelligence = 6;
                    Luck = 10;
                    Constitution = 14;
                    MaxHitPoints = 50;
                    CurrentHitPoints = 50;
                    break;
                case 3:
                    Name = "Rafaela Fuego";
                    Strength = 12;
                    Agility = 18;
                    Intelligence = 14;
                    Luck = 18;
                    Constitution = 11;
                    MaxHitPoints = 36;
                    CurrentHitPoints = 36;
                    break;
                case 4:
                    Name = "Mr. Biscuits";
                    Strength = 24;
                    Agility = 6;
                    Intelligence = 10;
                    Luck = 10;
                    Constitution = 18;
                    MaxHitPoints = 100;
                    CurrentHitPoints = 100;
                    break;

            }//end switch



        }//end ctor

    }//end class

}//end namespace
