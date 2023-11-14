using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstPlayable_WillB
{
    internal class Program
    {
        // int variables
        static int milliseconds;
        //float variables
        static float playerHealth;
        static float playerDamage;
        static float enemyHealth;
        static float enemyDamage;
        //string variables
        static string gameStart;
        static string startCheck;
        static string userName;
        static string tutorialCheck;

        static char[,] map = new char[,]
        {
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },// 20  by 20
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },
            {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.' },

        };
        static void Main(string[] args)
        {
            Console.Write("+-----------------------+\n" +
                          "|Welcome to Bumper fun  |\n" +
                          "|Press any key to begin |\n" +
                          "+-----------------------+\n");
            Console.ReadKey();
            Console.WriteLine("Would you like to begin? Yes or No");
            gameStart = Console.ReadLine();
            if(gameStart == "Yes" |  gameStart == "yes")
            {
                MainMenu();
            }
            else
            {
                annoyPlayer();
            }
        }
        static void annoyPlayer()
        { 
            Console.WriteLine("Are you sure?");
                startCheck = Console.ReadLine();
                if(startCheck == "Yes" | startCheck == "yes")
                {
                    annoyPlayer();
                }
            else
            {
                Console.WriteLine("Than lets begin finally!");
                Console.WriteLine();
                MainMenu();
            }
        }
        static void MainMenu()
        {
            Console.WriteLine("Hello brave user! Please enter your name:");
            userName = Console.ReadLine();
            Console.WriteLine("Hello " + userName +"!");
            Console.WriteLine("Would you like to start off with a tutorial? Yes or No");
            tutorialCheck = Console.ReadLine();
            if(tutorialCheck == "yes" | tutorialCheck == "Yes") 
            {
                tutorial();
            }
            else
            {
                Console.WriteLine("Alrighty than " + userName);
                Console.WriteLine("Lets begin");
            }
            Console.ReadKey();
        }
        static void Status()
        {

        }
        static void tutorial()
        {
            Console.Write("Welcome to the tutorial! Here we will cover the basics to playing the game:\n First off is you the player");
            milliseconds = 2000;
            Thread.Sleep(milliseconds);
            Console.WriteLine("\nYou are the main character of this adventure\n if you die and your lives reach 0\n The journeys over, you died.");

        }
        
    }
}
