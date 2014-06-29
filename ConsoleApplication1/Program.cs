using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What's your name? ");
            string name = Console.ReadLine();
            Console.WriteLine("Welcome " + name + " to the HangMan game.");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("                                HANGMAN GAME              ");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("In this game, you are going to guess the letters of the word I'll give you. You have 5 guesses.");
            Console.Write("Are you ready? ");
            string confirm = Console.ReadLine().ToLower();
            while (confirm != "yes" && confirm != "no")
            {
                Console.WriteLine();
                Console.WriteLine("I don't understand you.");
                Console.Write("Are you ready? ");
                confirm = Console.ReadLine().ToLower();
            }
            if (confirm == "no")
            {
                Console.WriteLine();
                Console.WriteLine("Well then, see you later...");
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine("Press any key to exit...");
            }
            else if (confirm == "yes")
            {
                hangMan();
            }
            Console.ReadKey();
        }
        static void hangMan()
        {
            Random random = new Random();
            string[] wordBank = { "Blue", "Black", "Yellow", "Orange", "Green", "Purple" };
            string wordToGuess = wordBank[random.Next(0, wordBank.Length)];
            string wordToGuessUppercase = wordToGuess.ToUpper();
            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                displayToPlayer.Append("_");
            }
            List<char> correctGuessess = new List<char>();
            List<char> incorrectGuesses = new List<char>();
            int lives = 5;
            bool won = false;
            int lettersRevealed = 0;
            string input;
            char guess;
            while (!won && lives > 0)
            {
                Console.Write("Guess a letter: ");
                input = Console.ReadLine().ToUpper();
                if (input.Length > 1)
                {
                    if (input == wordToGuessUppercase)
                    {
                        won = true;
                    }
                    else
                    {
                        won = false;
                        Console.WriteLine("Nope, you're wrong");
                        lives--;
                        Console.WriteLine();
                        Console.WriteLine("Guess left: " + lives);
                        Console.WriteLine();
                    }
                }
                else
                {
                    guess = input[0];
                    if (correctGuessess.Contains(guess))
                    {
                        Console.WriteLine("You've already tried " + guess + ", and it was correct!");
                        Console.WriteLine();
                        Console.Write("Letter guessed: ");
                        loop(correctGuessess);
                        loop(incorrectGuesses);
                        Console.WriteLine();
                        Console.WriteLine("Guess left: " + lives);
                        Console.WriteLine();
                        continue;
                    }
                    else if (incorrectGuesses.Contains(guess))
                    {
                        Console.WriteLine("You've already tried " + guess + ", and it was incorrect.");
                        Console.WriteLine();
                        Console.Write("Letter guessed: ");
                        loop(correctGuessess);
                        loop(incorrectGuesses);
                        Console.WriteLine();
                        Console.WriteLine("Guess left: " + lives);
                        Console.WriteLine();
                        continue;
                    }
                    if (wordToGuessUppercase.Contains(guess))
                    {
                        correctGuessess.Add(guess);
                        for (int i = 0; i < wordToGuess.Length; i++)
                        {
                            if (wordToGuessUppercase[i] == guess)
                            {
                                displayToPlayer[i] = wordToGuess[i];
                                lettersRevealed++;
                                Console.WriteLine();
                                Console.Write("Letter guessed: ");
                                loop(correctGuessess);
                                loop(incorrectGuesses);
                                Console.WriteLine();
                                Console.WriteLine("Guess left: " + lives);
                                Console.WriteLine();
                            }
                        }
                        if (lettersRevealed == wordToGuess.Length)
                        {
                            won = true;
                        }
                    }
                    else
                    {
                        incorrectGuesses.Add(guess);
                        Console.WriteLine("Nope, there's no " + guess + " in it!");
                        lives--;
                        Console.WriteLine();
                        Console.Write("Letter guessed: ");
                        loop(correctGuessess);
                        loop(incorrectGuesses);
                        Console.WriteLine();
                        Console.WriteLine("Guess left: " + lives);
                        Console.WriteLine();
                    }
                    Console.WriteLine(string.Join(" ", displayToPlayer.ToString().ToList()));
                }

            }
            if (won)
            {
                Console.WriteLine();
                Console.WriteLine("You won!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You lost! It was " + wordToGuess);
            }
            Console.WriteLine("Press any key to exit...");
        }
        static void loop(List<char> a)
        {
            foreach (char b in a)
            {
                Console.Write(b + " ");
            }
        }
    }
}
