using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Media;

namespace FirstPlayable_WillB
{
    internal class Program
    {
        // int variables
        static int milliseconds;
        static int startingStage = 1;
        static int lives = 3;
        static int playerPOSy = 10;
        static int playerPOSx = 10;
        //float variables
        static float playerHealth = 100;
        static float playerDamage;
        static float enemyHealth = 100;
        static float enemyDamage;
        //string variables
        static string gameStart;
        static string startCheck;
        static string userName;
        static string tutorialCheck;
        static string path = @"Map.txt";
        static string[] arrayString;
        static char [,] arrayChar;
        static string[] playerPOS;
        static string[] enemyPOS;


        static void Main(string[] args)
        {

            Console.Write("+-------------------------+\n" +
                          "|Welcome to Cave explorers|\n" +
                          "|Made by Will Boudreau    |\n" +
                          "+-------------------------+\n");
            Console.WriteLine("Would you like to begin? Yes or No");
            gameStart = Console.ReadLine();
            if (gameStart == "Yes" | gameStart == "yes")
            {
                Menu();
            }
            if(gameStart == "Skip" | gameStart == "skip")
            {
                stage(startingStage);
            }
            else
            {
                annoyPlayer();
            }
        }
        static void annoyPlayer()
        {
            //Method to annoy the player until they quit or play the game
            Console.WriteLine("Are you sure?");
            startCheck = Console.ReadLine();
            if (startCheck == "Yes" | startCheck == "yes")
            {
                annoyPlayer();
            }
            else
            {
                Console.WriteLine("Than lets begin finally!");
                Console.WriteLine();
                Menu();
            }
        }
        static void Menu()
        {
            //MAin menu of the game
            Console.WriteLine("Hello brave user! Please enter your name:");
            userName = Console.ReadLine();
            Console.WriteLine("Hello " + userName + "!");
            Console.WriteLine("Would you like to start off with a tutorial? Yes or No");
            tutorialCheck = Console.ReadLine();
            if (tutorialCheck == "yes" | tutorialCheck == "Yes")
            {
                tutorial();
            }
            else
            {
                Console.WriteLine("Alrighty than " + userName);
                Console.WriteLine("Lets begin");
                stage(startingStage);
            }
            Console.ReadKey();
        }
        static void ShowHUD()
        {
            Console.Write("+-------------+\n" +
                          "| Health " + playerHealth + " |\n" +
                          "+-------------+\n");
        }
        static void tutorial()
        {
            // Allows the Player to understand the game
            Console.Write("Welcome to the tutorial! Here we will cover the basics to playing the game:" +
                          "\nFirst off is you the player");
            milliseconds = 2000;
            Thread.Sleep(milliseconds);
            Console.WriteLine("\nIn this world, you will face monsters of unimaginable horrors!" +
                              "\nMonsters that want to eat you alive!");
            Thread.Sleep(milliseconds);
            Console.WriteLine("You are the main character of this adventure" +
                              "\n if you die and your lives reach 0" +
                              "\n The journeys over, you died.");
            Thread.Sleep(milliseconds);
            Console.WriteLine("In this game you will use the WASD keys to move" +
                              "\nW-To move up" +
                              "\nA-To move right" +
                              "\nS-To move down" +
                              "\nD-To move Left" +
                              "\nWhen you reach a monster, move into them to do damage. But if they move into you, they do damage to you");
            Thread.Sleep(milliseconds);
            Console.WriteLine("\nGive it a try");
            stage(1);
        }
        static void stage(int stage)
        {
            Console.Clear();
            Console.WriteLine("Welcome to stage " + stage);
            while (true)
            {
                ShowHUD();
                Map();
                player();
                Enemy();

            }
        }
        static void Map()
        {
            // while loop shows off the map
            bool start = true;
            while (start == true)
            {
                
                arrayString = File.ReadAllLines(path);
                for (int i = 0; i < arrayString.Length; i++)
                {
                    Console.WriteLine(arrayString[i]);
                }
                break;
            }
        }
        static void stringTochar()
        {
            
        }
        static void Enemy()
        {
            //Hold the information of the enemy
            enemyPOS = new string[2];
            enemyPOS[0] = "#";
            //Enemy stats
            enemyDamage = 15;
        }
        static void player()
        {
            int playerx = playerPOSx + 1;
            int playerY = playerPOSy + 1;
            // Stats
            Console.Write(playerHealth);
            playerDamage = 25;
            //Movement
            while (true)
            {
                ConsoleKeyInfo input;
                input = Console.ReadKey();
                playerPOS = new string[2];
                playerPOS[0] = "*";
                Console.Write(playerPOS[0]);
                Console.SetCursorPosition(playerPOSx, playerPOSy);
                if (input.Key == ConsoleKey.W)//key on keyboard
                {
                    if (arrayString[playerY] == ".")
                    { 
                        playerPOSy--;
                    }
                    if (arrayString[playerY] == "^" | arrayString[playerY] == "|") 
                    {
                        playerPOSy++;
                    }
                   
                }
                if (input.Key == ConsoleKey.A)
                {
                    if (arrayString[playerPOSx--] == ".")
                    {
                        playerPOSx--;
                    }
                    if (arrayString[playerPOSx--] == "^" | arrayString[playerPOSx] == "|") 
                    {
                        playerPOSx++;
                    }
                }
                if (input.Key == ConsoleKey.D)
                {
                    playerPOSx++;
                }
                if (input.Key == ConsoleKey.S)
                {
                    playerPOSy++;
                }
                if (playerPOS == enemyPOS)
                {
                    TakeDamage();
                }
            }
        }
        static void TakeDamage()
        {
            Console.WriteLine("You are about to take " + enemyDamage + " Damage");
            playerHealth -= enemyDamage;
            if (playerHealth >= 75)
            {
                Console.WriteLine("Health Good");
            }
            if (playerHealth < 75 | playerHealth >= 50)
            {
                Console.WriteLine("Health okay");
            }
            if(playerHealth < 50 | playerHealth >= 25)
            {
                Console.WriteLine("Health Bad");
            }
            if(playerHealth > 25 | playerHealth > 0)
            {
                Console.WriteLine("Health Critical");
            }
            if (playerHealth <= 0)
            {
                playerHealth = 0;
                Console.WriteLine("You have died");
                if(lives >= 0)
                {
                    stage(1);
                }
                else
                {
                    gameOver();
                }
            }
        }
        static void gameOver()
        {
            Console.WriteLine("Game Over");
            Console.WriteLine("Would you like to start over? ");
            Console.ReadLine();

        }
    }

}   