﻿using System;
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
        public string tagLineTough = "";
        public string tagLineSoft = "";
        public string description = "";
        public string specialMove = "";
        public EnemyGladiator(int character, ref Fighter f)
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
                    MaxHitPoints = 35;
                    CurrentHitPoints = 35;
                    Notoriety = 1;
                    tagLineSoft = "Please don't hurt me, sir.";
                    tagLineTough = "Put em up, Put em up!";
                    description = "First cousin of boxer \"Glass\" Joe, Jody fights similarly.  Horribly bad.";
                    specialMove = "Jody throws a tantrum and slaps you with all of his might.\nYes, this IS Jody's 'special' attack!";
                    break;

                case 2:
                    Name = "Macho Dan";
                    Strength = 15;
                    Agility = 15;
                    Intelligence = 6;
                    Luck = 10;
                    Constitution = 14;
                    MaxHitPoints = 75;
                    CurrentHitPoints = 75;
                    Notoriety = 2;
                    tagLineSoft = "Snap into it?";
                    tagLineTough = "Ooooh Yeeeah!";
                    description = "Macho Dan watched a lot of wrestling in the 80's apparantly and is a \"Rex-Kwon Do\" master.\nHe wears a bandana and shades with his cuirass.";
                    specialMove = "Macho Dan finds a turnbuckle in the arena and jumps off of it,\nperforming a crushing elbow drop that would have made Randy Savage proud.";
                    break;

                case 3:
                    Name = "Rafaela Fuego";
                    Strength = 6;
                    Agility = 20;
                    Intelligence = 20;
                    Luck = 20;
                    Constitution = 12;
                    MaxHitPoints = 48;
                    CurrentHitPoints = 48;
                    Notoriety = 3;
                    tagLineTough = "Que te rompo!\nsubtitle: I must break you!";
                    tagLineSoft = "Se me rompe.\nsubtitle: You must break me";
                    description = "Andrés no se siente bien. Estuvo en una fiesta anoche y llegó a casa a las 3 am.\n Tiene dolor de cabeza y siente náusea. Bebió mucho y comió demasiados camarones. ";
                    specialMove = "Fuego unleashes a blindingly fast flurry of stabs and jabs,\nthat turns your torso into swiss cheese";
                    break;

                case 4:
                    Name = "Mr. Biscuits";
                    Strength = 20;
                    Agility = 2;
                    Intelligence = 8;
                    Luck = 8;
                    Constitution = 24;
                    MaxHitPoints = 150;
                    CurrentHitPoints = 150;
                    Notoriety = 4;
                    tagLineTough = "Get in mah belly!";
                    tagLineSoft = "Get in mah belly?";
                    description = "Fat and Happy, Mr. Biscuits eats EVERYTHING he can get his stubby fingers on.\nHe stands 6'8\" and weighs 650 lbs. He wears a striped tent as a tunic in the arena for his matches.\n";
                    specialMove = "\nMr. Biscuits throws you down and sits on you, crushing the life out of you slowly, but surely.\nThe faint smell of twinkie, bacon and ass permeate your senses as you start to fade away.";
                    break;

                case 5:
                    Name = "Rich Ro$$";
                    Strength = 18;
                    Agility = 13;
                    Intelligence = 12;
                    Luck = 12;
                    Constitution = 18;
                    MaxHitPoints = 100;
                    CurrentHitPoints = 100;
                    Notoriety = 5;
                    tagLineTough = "Everyday I'm hustlin'";
                    tagLineSoft = "Push it to the limit.";
                    description = "Put molly all in her champagne, She ain't even know it, I took her home and I enjoyed that, She ain't even know it.";
                    specialMove = "Rich Ro$$ pulls out a Glock 9mm and pops a cap in your ass.\nYou wonder how the hell he got that thing in a freaking time period before Jesus was born.";
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
                    tagLineTough = "I will crush you, you...you swine";
                    tagLineSoft = "Guards!!! Seize him! Guards???";
                    description = "He's the boss.  Think Commodus in 'Gladiator', not that this game parallels that movie (at all).";
                    specialMove = "Caesar swings for your neck like he wants to put it on a pike for the entire month of Augustus. You feel honored.";
                    break;

                default:
                    MainMenu.WinGame(f);
                    break;
            }//end switch



        }//end ctor

        public void WinFight(ref Fighter f, EnemyGladiator e, int enemyPick)
        {
            Console.WriteLine("You have felled the notorious gladiator, {0}", e.Name);
            Console.WriteLine("You collect your reward and hear the crowd cheer as you exit the arena");                      
            f.Fame += (e.Notoriety * 2 + f.Notoriety);
            var charismaMod = (f.Charisma / 2);
            charismaMod += f.Fame;                        
            f.Money += (e.Notoriety * 500);
            Console.WriteLine("You earned {0} Caesars for winning in the arena!", f.Money);
            f.MoneyEarned += f.Money;
            Console.WriteLine("You have earned {0} Caesars in your career to date.", f.MoneyEarned);            
            f.Fury = 0;
            f.Spirit = 0;
            f.Notoriety++;
            f.Kills++;
            f.Level++;
            Console.WriteLine("You have offed {0} enemy gladiators.", f.Kills);
            f.CurrentHitPoints = f.MaxHitPoints;
            enemyPick++;
            if (enemyPick > 6)
                MainMenu.WinGame(f);
                
            Console.WriteLine("You head back to the Gladiator quarters for some much-needed rest");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            MainMenu.LevelUp(ref f);
            MainMenu mm = new MainMenu(ref f, enemyPick);

        }//end enemyDie

    }//end class

}//end namespace
