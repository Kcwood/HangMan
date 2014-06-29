using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            //Starting the game
            Console.Write("Hey you there! What's your name?");
            //Getting info from the game player
            string name = Console.ReadLine();
            //Telling the player the rules of the game
            Console.WriteLine("Greetings " + name + ", I am the Doctor. I would like for you to be my companion on an adventure through time and space.");
            Console.WriteLine("On this adventure you and I will be playing a game. A game that will decide the fate of the universe.");
            Console.WriteLine("If you choose to accept it, we will attempt to save all of time and space from a horrible race called the Weeping Angels. We will do this by playing a game of hangman. You will guess letters to words that I am thinking and I will help guide you to the correct answer. You only have a limited number of guesses, so be vigilent. All of time and space is depending on you!");
            //Getting the users answer to whether or not
            //they would like to play our game
            string confirm = Console.ReadLine().ToLower();
            Console.Write("Are you ready to depart in the TARDIS?");
            confirm = Console.ReadLine().ToLower();
            //If the users answer is "no" 
            //the game will end with the following 
            //printed to the console
            if (confirm == "no")
            {
                Console.WriteLine();
                Console.WriteLine("The Weeping Angels have no destroyed us all. All of time and space is doomed thanks to you.");
            }
            //If the user answers "yes"
            //then the game will start
            else if (confirm == "yes")
            {
                HangMan();
            }
            //Keeps the console open
            Console.ReadKey();
        }
        static void HangMan()
        {
            //Setting up the random word generator
            //with a list of words of my choosing
            Random wordRandom = new Random();
            string[] wordBank = { "geronimo", "fezzes", "bowties", "dalek", "sweetie", "screwdriver", "custard", "fantastic"};
            string wordToGuess = wordBank[wordRandom.Next(0, wordBank.Length)];
            //Making it so if the user enters in 
            //lowercase or uppercase letters 
            //the game will still function
            string wordToGuessUpperCase = wordToGuess.ToUpper();
            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
            //For the length of the randomly 
            //choosen word it will display "_"
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                displayToPlayer.Append("_");
            }
            //Setting up to count the number of 
            //correct and incorrect guesses
            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();
            //Allowing the user to only have 
            //10 attempts at guessing the word
            int lives = 10;
            bool won = false;
            int letterRevealed = 0;
            string input;
            char guess;
            while (!won && lives > 0)
            {
                Console.Write("I have a word in mind. What is your guess?");
                input = Console.ReadLine().ToUpper();
                if (input.Length > 1)
                {
                    if (input == wordToGuessUpperCase)
                    {
                        won = true;
                    }
                    else
                    {
                        won = false;
                        Console.WriteLine("Rats, your guess was incorrect. Please try another letter.");
                        lives--;
                        Console.WriteLine();
                        Console.WriteLine("You have " + lives + " guess left to save all of time and space!");
                        Console.WriteLine();
                    }
                }
                else
                {
                    guess = input[0];
                    if (correctGuesses.Contains(guess))
                    {
                        Console.WriteLine("You have already attempted that " + guess);
                        Console.WriteLine();
                        Console.Write("These are the letters you have already tried: ");
                        loop(correctGuesses);
                        loop(incorrectGuesses);
                        Console.WriteLine();
                        Console.WriteLine("You have " + lives + " guesses left companion. All of space and time is counting on you.");
                        Console.WriteLine();
                        continue;
                    }
                    else if (incorrectGuesses.Contains(guess))
                    {
                        Console.WriteLine("I am sorry but " + guess + " was attempted and it was incorrect.");
                        Console.WriteLine();
                        Console.Write("These are the letters you have already tried: ");
                        loop(correctGuesses);
                        loop(incorrectGuesses);
                        Console.WriteLine();
                        Console.WriteLine("You have " + lives + " guesses left companion. All of space and time is counting on you.");
                        Console.WriteLine();
                        continue;
                    }
                    if (wordToGuessUpperCase.Contains(guess))
                    {
                        correctGuesses.Add(guess);
                        for (int i = 0; i < wordToGuess.Length; i++)
                        {
                            if (wordToGuessUpperCase[i] == guess)
                            {
                                displayToPlayer[i] = wordToGuess[i];
                                letterRevealed++;
                                Console.WriteLine();
                                Console.Write("These are the letters you have already tried: ");
                                loop(correctGuesses);
                                loop(incorrectGuesses);
                                Console.WriteLine();
                                Console.WriteLine("You have " + lives + " guesses left companion. All of space and time is counting on you.");
                                Console.WriteLine();
                            }
                        }
                        if (letterRevealed == wordToGuess.Length)
                        {
                            won = true;
                        }
                    }
                    else
                    {
                        incorrectGuesses.Add(guess);
                        Console.WriteLine("I am sorry but " + guess + " was attempted and it was incorrect.");
                        lives--;
                        Console.WriteLine();
                        Console.Write("These are the letters you have already tried: ");
                        loop(correctGuesses);
                        loop(incorrectGuesses);
                        Console.WriteLine();
                        Console.WriteLine("You have " + lives + " guesses left companion. All of space and time is counting on you.");
                        Console.WriteLine();
                    }
                    Console.WriteLine(string.Join(" ", displayToPlayer.ToString().ToList()));
                }
            }
            //If the user has succeed in guessing the word that 
            //that was generated it will print the following
            //and the game will end
            if (won)
            {
                Console.WriteLine();
                Console.WriteLine("You have saved all of time and space! You are by far the best companion that I have ever had the please of having!");
            }
            //If the user did not guess the correct word
            //in the amount of guesses given then
            //this will print and the game will end
            else
            {
                Console.WriteLine();
                Console.WriteLine("The Weeping Angels got us in the end. You shall now die a slow death and you have doomed all of time and space.");
            }
        }
        //Setting up a loop to help the 
        //lives counter run correctly throughout
        //the game
        static void loop(List<char> a)
        {
            foreach (char b in a)
            {
                Console.Write(b + " ");
            }
        }
    }
}

