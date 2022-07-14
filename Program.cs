/* A simple game based on fighting enemies. it isn't complete, it needs levels and other things I'm still thinking on! */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stuff
{
    class Program
    {
        /* ================================= CLASSES ================================= */
        public class Player
        {
            public int health = 1000;
            public int weapon;
            public void Choose_Wep()
            {
            Choose:
                var inp = Console.ReadLine().ToString();
                if (inp == "1")
                {
                    Console.WriteLine("You chose axe!\n");
                    weapon = 1;
                }
                else if (inp == "2")
                {
                    Console.WriteLine("You chose sword!\n");
                    weapon = 2;
                }
                else
                {
                    Console.WriteLine("Please enter valid input!");
                    goto Choose;
                }
            }
            public Player()
            {
                Console.WriteLine("Choose your weapon: (1: axe, 2: sword)");
                Choose_Wep();
            }
        }

        // Inventory 
        public interface IWeapon
        {
            void Message();
        }

        public class Axe : IWeapon
        {
            public int damage;
            public void Message()
            {
                Console.WriteLine("Axe of Truth!");
            }
            public Axe(int _damage)
            {
                damage = _damage;
            }
        }

        public class Sword : IWeapon
        {
            public int damage;
            public void Message()
            {
                Console.WriteLine("Sword of Destiny!");
            }
            public Sword(int _damage)
            {
                damage = _damage;
            }
        }

        /* ================================= METHODS ================================= */

        public static void Fight(string enemy, int HP, int damage)
        {
            Console.WriteLine("You chose to fight! You're a brave one!\n");
            if (enemy[0] == 'a' || enemy[0] == 'e' || enemy[0] == 'i' || enemy[0] == 'o' || enemy[0] == 'u')
            {
                Console.WriteLine("An {0} is coming! Quick, pull your weapon!", enemy);
            }
            else
            {
                Console.WriteLine("A {0} is coming! Quick, pull your weapon!", enemy);
            }
            Console.WriteLine("He's got {0} HP", HP);
            while (HP > 0)
            {
                HP -= damage;
                if (HP > 0)
                    Console.WriteLine("HIT! The {0} has got {1} HP left!", enemy, HP);
                else
                    Console.WriteLine("Good job! You killed it!");
            }
            Console.WriteLine('\n');
        }

        public static void Bail(int numF)
        {
            if (numF == 0)
            {
                Console.WriteLine("You bailed, everyone is disappointed in you! You're going to be hanged!\n");
                Console.WriteLine(" --------- ");
                Console.WriteLine("| X     X |");
                Console.WriteLine("|         |");
                Console.WriteLine("|    _    |");
                Console.WriteLine(" --------- \n");
                Console.WriteLine("You're dead!");
            }
            else
            {
                Console.WriteLine("You have fought well, warrior! Your courage will be never forgotten!");
                Console.WriteLine(" ----------- ");
                Console.WriteLine("| 0       0 |");
                Console.WriteLine("|  _     _  |");
                Console.WriteLine("|    \\ /    |");
                Console.WriteLine(" --------- \n");
                Console.WriteLine("See you in another life!");
            }
        }

        /* ================================= MAIN ================================= */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, mighty warrior! Welcome to my RPG!\n");
            Console.WriteLine("You've got 1000 HP, good luck!");

            Sword sw = new Sword(90);
            Axe ax = new Axe(75);

            // Player Spawn
            Player pl = new Player();
            int damage = 0;
            if (pl.weapon == 1)
            {
                // Axe:
                ax.Message();
                Console.WriteLine(ax.damage + " damage per hit" + "\n");
                damage = ax.damage;
            }
            else if (pl.weapon == 2)
            {
                // Sword
                sw.Message();
                Console.WriteLine(sw.damage + " damage per hit" + "\n");
                damage = sw.damage;
            }

            Dictionary<string, int> enemies = new Dictionary<string, int>();
            enemies.Add("dragon", 900);
            enemies.Add("giant", 700);
            enemies.Add("elf", 300);
            enemies.Add("troll", 400);
            enemies.Add("medusa", 800);

            int numFights = 0;

            Console.WriteLine("You are going on a rampage! Let's see how much you last before bailing!");
            bool gameOver = false;
            while (!gameOver)
            {
            Decision:
                Console.WriteLine("You are going to face an enemy... [fight] or [bail]?");
                var decision = Console.ReadLine().ToString().ToLower();

                if (decision == "fight")
                {
                    string enemy = null;
                    Random rand = new Random();
                    var i = rand.Next(enemies.Count);
                    int x = 1;
                    foreach (string enm in enemies.Keys)
                    {
                        enemy = enm;
                        if (x == i)
                            break;
                        x++;
                    }
                    Fight(enemy, enemies[enemy], damage);
                    numFights++;
                }
                else if (decision == "bail")
                {
                    Bail(numFights);
                    gameOver = true;
                }
                else
                {
                    Console.WriteLine("Please enter valid input!\n");
                    goto Decision;
                }
            }
        }
    }
}