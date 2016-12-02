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
        int eSalve = 3;
        int turn = 0;
        int opponent = 0;
        
        public CombatMenu(Fighter f, EnemyGladiator e)
        {           
             
            
            while (CombatActive)
            {
                int f20Roll = Roller.rollXSidedDice(20, 1, 1);
                int e20Roll = Roller.rollXSidedDice(20, 1, 1);

                if (salve == 0)
                {
                    Console.WriteLine("\nAs you walk through the narrow pathway to the arena,\n" +
                        "a fair maiden hands you a satchel.  She says, \"Good luck, warrior. Take this\n" +
                        "magic salve to heal your wounds during your fight.\"\n");

                    salve += 3;
                }
                else
                {
                    Console.WriteLine("The enemy has {0} hit points left", e.CurrentHitPoints);
                    Console.WriteLine("You have {0} hit points left",f.CurrentHitPoints);
                    Console.WriteLine("You have fought {0} round(s)", turn);
                    Console.WriteLine();
                    //Display Menu - perform menu actions
                    Console.WriteLine("1) Melee Attack");
                    Console.WriteLine("2) Ranged Attack");
                    Console.WriteLine("3) Close with Enemy");
                    Console.WriteLine("4) Use salve");
                    Console.WriteLine("5) Yield");
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
                                Console.WriteLine("\nYou swing your sword at the enemy, thoroughly expecting to lop his ugly head off.");
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
                                            CombatActive = false;
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
                            Console.WriteLine("\n You sprint towards the enemy and make the craziest, most bloodthirsty face you can muster");
                            range--;
                            break;

                        //apply salve to heal
                        case 4:
                            if (salve > 0)
                            {
                                Console.WriteLine("\nYou use the magic salve on your wounds, and feel better immediately");
                                f.CurrentHitPoints += 20;
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
                            e.CurrentHitPoints -= 35;
                            break;


                    }//end switch

                    //enemyTurn
                    int enemyTurn = Roller.rollXSidedDice(6, 1, 1);
                    if (range > 1 && e.CurrentHitPoints > 15)
                    {
                        Console.WriteLine("\n{0} moves closer to you.", e.Name);
                        range--;
                    }
                    else if (e.CurrentHitPoints <= 15 && e.CurrentHitPoints > 0)
                    {
                        Console.WriteLine("\n{0}, injured and wobbly, applies the magic salve", e.Name);
                        eSalve--;
                        e.CurrentHitPoints += 20;
                    }
                    else
                    {
                        Console.WriteLine("\n {0} winds up and swings his sword with all of his might!", e.Name);
                        if (e.AttackEnemy() > f.Avoid())
                        {
                            int damage2 = e.CalculateDamage();
                            f.ReceiveDamage(damage2);
                            Console.WriteLine("\nhe hit you for {0} damage", damage2);
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
