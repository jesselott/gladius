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
        public string tagLine = "";
        public string description = "";
        public EnemyGladiator(int character, Fighter f)
        {
            switch (character)
            {
                case 1:
                    Name = "Glass Jody";
                    Strength = 12;
                    Agility = 12;
                    Intelligence = 12;
                    Luck = 12;
                    Constitution = 12;
                    MaxHitPoints = 25;
                    CurrentHitPoints = 25;
                    Notoriety = 1;
                    tagLine = "Please don't hurt me, sir.";
                    description = "Cousin of boxer \"Glass\" Joe, Jody fights similarly.  Horribly bad.";
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
                    Notoriety = 2;
                    tagLine = "Ooooh Yeeeah!";
                    description = "Macho Dan watched a lot of wrestling in the 80's apparantly.  He wears a bandana and shades with his cuirass.";
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
                    Notoriety = 3;
                    tagLine = "Que?";
                    description = "Andrés no se siente bien. Estuvo en una fiesta anoche y llegó a casa a las 3 am.\n Tiene dolor de cabeza y siente náusea. Bebió mucho y comió demasiados camarones. ";
                    break;
                case 4:
                    Name = "Mr. Biscuits";
                    Strength = 24;
                    Agility = 6;
                    Intelligence = 4;
                    Luck = 2;
                    Constitution = 24;
                    MaxHitPoints = 150;
                    CurrentHitPoints = 150;
                    Notoriety = 4;
                    tagLine = "Get in mah belly";
                    description = "Fat and Happy, Mr. Biscuits eats EVERYTHING he can get his stubby fingers on.\n  He stands 6'8\" and weighs 650 lbs. He wears a striped tent as a tunic in the arena for his matches.\n";
                    break;
                case 5:
                    Name = "Rich Ro$$";
                    Strength = 18;
                    Agility = 13;
                    Intelligence = 12;
                    Luck = 12;
                    Constitution = 18;
                    MaxHitPoints = 70;
                    CurrentHitPoints = 70;
                    Notoriety = 5;
                    tagLine = "Everyday I'm hustlin'";
                    description = "Put molly all in her champagne, She ain't even know it, I took her home and I enjoyed that, She ain't even know it.";
                    break;
                case 6:
                    Name = "Caesar the Conqueror";
                    Strength = 24;
                    Agility = 18;
                    Intelligence = 18;
                    Luck = 18;
                    Constitution = 18;
                    MaxHitPoints = 120;
                    CurrentHitPoints = 120;
                    Notoriety = 10;
                    tagLine = "I will crush you, you...you swine";
                    description = "He's the boss.  Think Commodus in 'Gladiator', not that this game parallels that movie (at all).";
                    break;

                default:
                    MainMenu.WinGame(f);
                    break;
            }//end switch



        }//end ctor

        public void Die(Fighter f, EnemyGladiator e, int enemyPick)
        {
            Console.WriteLine("You have felled the notorious gladiator, {0}", e.Name);
            Console.WriteLine("You collect your reward and hear the crowd cheer as you exit the arena");
            f.Fame += e.Notoriety;
            f.Money += (e.Notoriety * 500);
            f.MoneyEarned += f.Money;
            f.Fury = 0;
            f.Spirit = 0;
            f.Notoriety++;
            f.Kills++;
            f.CurrentHitPoints = f.MaxHitPoints;
            enemyPick++;
            Console.WriteLine("You head back to the Gladiator quarters for some much-needed rest");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            MainMenu mm = new MainMenu(f, enemyPick);

        }//end enemyDie

    }//end class

}//end namespace
