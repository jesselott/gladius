using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gladius
{
    //This class will pit a fighter against an enemy gladiator and fight to the death.
    //This is a very rudimentary interface, more will be added as I test and add features
    class CombatMenu
    {
        bool CombatActive = true;
        int range = 4;
        int salve = 0;
        int eSalve = 1;
        int turn = 0;
                       
        public CombatMenu(Fighter f, EnemyGladiator e, int enemyPick)
        {           
             
            
            while (CombatActive)
            {
                int f20Roll = Roller.rollXSidedDice(20, 1, 1);
                int e20Roll = Roller.rollXSidedDice(20, 1, 1);
                
                if (salve == 0 && turn == 0)
                {
                    Console.WriteLine("As you walk through the narrow pathway to the arena,\n" +
                        "a fair maiden hands you a satchel.  She says, \"Good luck, warrior. Take this\n" +
                        "magic salve to heal your wounds during your fight.\"\n");
                    Console.WriteLine("Your coach, Leonardo tells you a little something about your opponent that you might not have known: ");
                    Console.WriteLine("{0}\n",e.description);
                   
                    salve += 1;
                }
                else
                {
                    Console.WriteLine("{0} is {1} passus away ('passus' is Roman for paces)", e.Name, range);
                    Console.WriteLine("The enemy has {0} hit points left", e.CurrentHitPoints);
                    Console.WriteLine("You have {0} hit points left",f.CurrentHitPoints);
                    Console.WriteLine("You have fought {0} round(s)", turn - 1);
                    Console.WriteLine();
                    //Display Menu - perform menu actions
                    Console.WriteLine("1) Melee Attack");
                    Console.WriteLine("2) Ranged Attack");
                    Console.WriteLine("3) Close with Enemy");
                    Console.WriteLine("4) Use salve");
                    Console.WriteLine("5) Yield");
                    //conduct special attack if fury or spirit is at appropriate level
                    if (f.Fury > 3 || f.Spirit > 3)
                    { Console.WriteLine("6) Special Attack"); }

                    int yourMove = Convert.ToInt32(Console.ReadLine());
                    //start switch
                    switch (yourMove)
                    {
                        //attempt to attack enemy if close enough
                        case 1:
                            if (range < 2)
                            {
                                
                                Console.WriteLine("You swing your sword at the enemy, thoroughly expecting to lop his ugly head off.");
                                Console.WriteLine();
                                Console.WriteLine("\nYou catch him on his heels and swing for the fences.", f.Name);
                                    if (f.AttackEnemy() > e.Avoid())
                                    {
                                        int damage1 = f.CalculateDamage();
                                        e.ReceiveDamage(damage1);
                                        Console.WriteLine("\nyou hit {0} for {1} damage", e.Name, damage1);
                                        f.Spirit++;
                                        e.Fury++;

                                        if (e.CurrentHitPoints <= 0)
                                        {
                                            e.Die(ref f, e, enemyPick);
                                            break;
                                        }

                                    }
                                    else
                                    {
                                        
                                        Console.WriteLine("\nYou miss");
                                        f.Spirit--;
                                    }
                                
                                #region Obsolete counter-attack code
                                /*{
                                    Console.WriteLine("\n Your attack whiffs, {0} attacks you, instead!", e.Name);
                                    if (e.AttackEnemy() > f.Avoid())
                                    {
                                        int damage2 = e.CalculateDamage();
                                        f.ReceiveDamage(damage2);
                                        Console.WriteLine("he hit you for {0} damage", damage2);
                                        f.Fury++;
                                        e.Spirit++;

                                        if (f.CurrentHitPoints <= 0)
                                        {
                                            CombatActive = false;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("The enemy misses");
                                        e.Spirit--;

                                    }



                                }//end if*/
                                #endregion

                            }//end range if 
                            else
                            {
                                
                                Console.WriteLine("You're not close enough to perform that action.");
                            }
                            break;

                        //ranged attack if range > 1

                        case 2:
                            if (range > 1)
                            {
                                
                                Console.WriteLine("You don't have a ranged weapon yet!");
                                break;
                            }
                            else
                            {
                               
                                Console.WriteLine("You cannot hit with ranged weapons in your current proximity to the enemy.\n" +
                                    "You shoot your imaginary arrow and it does nothing.  Your opponent laughs.");
                                break;
                            }

                        //close range to enemy
                        case 3:
                            if (range > 1)
                            {
                                
                                Console.WriteLine("You sprint towards the enemy and make the craziest, most bloodthirsty face you can muster\n");
                                range--;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You ram into the enemy by running full speed into him, say, \"mi Scusi\", and... ");
                                break;
                            }

                        //apply salve to heal
                        case 4:
                            if (salve > 0)
                            {
                                Console.WriteLine("\nYou use the magic salve on your wounds, and feel better immediately");
                                f.CurrentHitPoints += (f.MaxHitPoints - f.CurrentHitPoints);
                                salve--;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nYou don't have any magic salve left.");
                                break;
                            }

                        //case 5: 

                        //
                        
                        case 6:
                            Console.WriteLine("You focus all of your energy into a mighty finishing blow that staggers the enemy.");
                            e.ReceiveDamage(35);
                            if (e.CurrentHitPoints <= 0)
                            {
                                CombatActive = false;
                                e.Die(ref f, e, enemyPick);
                                continue;
                            }
                            break;


                    }//end switch

                    //enemyTurn
                    int enemyTurn = Roller.rollXSidedDice(6, 1, 1);

                    if (range == 1 && e.Fury >= 6 || e.Spirit >= 6)
                    {
                        Console.WriteLine(e.specialMove);
                        f.ReceiveDamage(30);
                        if (f.CurrentHitPoints <= 0)
                            {
                                f.Die();
                                CombatActive = false;
                                break;
                            }
                    }

                    if (range > 1 && e.CurrentHitPoints > 15)
                    {
                        
                        Console.WriteLine("\n{0} moves closer to you.", e.Name);
                        Console.WriteLine("{0}", e.tagLineTough);
                        range--;
                    }

                    else if (e.CurrentHitPoints <= 15 && eSalve > 0)
                    {
                        Console.WriteLine("{0}", e.tagLineSoft);
                        Console.WriteLine("\n{0}, injured and wobbly, applies the magic salve", e.Name);
                        eSalve--;
                        e.CurrentHitPoints += 25;
                    }

                    else if (e.CurrentHitPoints <= 15 && eSalve == 0)
                    {
                        Console.WriteLine("\n{0} winds up and swings his sword with all of his remaining strength.", e.Name);
                        Console.WriteLine("{0}", e.tagLineSoft);
                        if (e.AttackEnemy() > f.Avoid())
                        {
                            int damage2 = e.CalculateDamage();
                            f.ReceiveDamage(damage2);
                            Console.WriteLine("he hit you for {0} damage\n", damage2);
                            f.Fury++;
                            e.Spirit++;

                            if (f.CurrentHitPoints <= 0)
                            {
                                f.Die();
                                CombatActive = false;
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nThe enemy misses");
                            e.Spirit--;
                            f.Spirit++;
                        }
                    }
                    else
                    {

                        Console.WriteLine("\n{0} winds up and swings his sword with all of his might!", e.Name);
                        Console.WriteLine("{0}", e.tagLineTough);
                        if (e.AttackEnemy() > f.Avoid())
                        {
                            int damage2 = e.CalculateDamage();
                            f.ReceiveDamage(damage2);
                            Console.WriteLine("he hit you for {0} damage\n", damage2);
                            f.Fury++;
                            e.Spirit++;

                            if (f.CurrentHitPoints <= 0)
                            {
                                f.Die();
                                CombatActive = false;
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nThe enemy misses");
                            e.Spirit--;
                            f.Spirit++;
                        }
                    }//end enemyTurn                    

                }//end if
                turn++;
                }//end while                           
            
        }//end method       
    
    }//end class

}//end namespace
