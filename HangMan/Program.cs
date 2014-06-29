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
           Console.WriteLine("                                 --");
		   Console.WriteLine("                                |  |");
		   Console.WriteLine("                    ---------------------------");
	       Console.WriteLine("                    |   Police  Public  Box   |");
	       Console.WriteLine("                    |___________Call__________|");
	       Console.WriteLine("                    |__ ___ __  | |  __ ___ __|");
	       Console.WriteLine("                    |  |   |  | | | |  |   |  |");
	       Console.WriteLine("                    |__|___|__| | | |__|___|__|");	
	       Console.WriteLine("                    |  |   |  | | | |  |   |  |");
	       Console.WriteLine("                    |__|___|__| | | |__|___|__|");
	       Console.WriteLine("                    |           | |           |");
	       Console.WriteLine("                    |  _____    | |    _____  |");	
	       Console.WriteLine("                    | |     |   | |   |     | |");
	       Console.WriteLine("                    | |     |   | |   |     | |");
	       Console.WriteLine("                    | |_____|   | |_  |_____| |");
	       Console.WriteLine("                    |  _____    | |_|  _____  |");
	       Console.WriteLine("                    | |     |   | |   |     | |");
	       Console.WriteLine("                    | |     |   | |   |     | |");
	       Console.WriteLine("                    | |_____|   | |   |_____| |");
	       Console.WriteLine("                    |  _____    | |    _____  |");
	       Console.WriteLine("                    | |     |   | |   |     | |");
           Console.WriteLine("                    | |     |   | |   |     | |");
	       Console.WriteLine("                    | |_____|   | |   |_____| |");
	       Console.WriteLine("                    |           | |           |");
           Console.WriteLine("                  -------------------------------");
           Console.WriteLine();
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
            //Setting up a bool to run certain things
            //if the users guess is correct or incorrect
            bool won = false;
            //Variables being used throughout the game
            int letterRevealed = 0;
            string input;
            char guess;
            //Setting up a loop to start the game
            while (!won && lives > 0)
            {
                //Getting the user to tell me their first guess.
                Console.Write("I have a word in mind. Please either guess a letter or a word?");
                //Getting the game to recognize
                //if the user puts in UPPERCASE or 
                //lowercase letters
                input = Console.ReadLine().ToUpper();
                //If the user types in something
                //longer than 1 character, the computer
                //will check to see if it is the randomly
                //generated word and if so the game will end
                if (input.Length > 1)
                {
                    if (input == wordToGuessUpperCase)
                    {
                        won = true;
                    }
                    //Otherwise, the computer will tell the user
                    //that they were incorrect and to guess again
                    else
                    {
                        won = false;
                        Console.WriteLine("Rats, your guess was incorrect. Please try another letter.");
                        //Reduces the number of guess that
                        //the user now has.
                        lives--;
                        Console.WriteLine();
                        //Tells the user how many guesses
                        //that they now have left
                        Console.WriteLine("You have " + lives + " guess left to save all of time and space!");
                        Console.WriteLine();
                    }
                }
                else
                {
                    guess = input[0];
                    //If the user guesses a letter they
                    //they have already tried then this 
                    //will be printed to them
                    if (correctGuesses.Contains(guess))
                    {
                        //Telling the user that they have already
                        //attempted that letter and shows them 
                        //the letters that they have guessed up
                        //until that point
                        Console.WriteLine("You have already attempted that " + guess);
                        Console.WriteLine();
                        Console.Write("These are the letters you have already tried: ");
                        //Loops created to cycle through and
                        //print what letters have already
                        //been guessed, both incorrect and correct
                        loop(correctGuesses);
                        loop(incorrectGuesses);
                        Console.WriteLine();
                        //Tells the user how many guesses
                        //that they now have left
                        Console.WriteLine("You have " + lives + " guesses left companion. All of space and time is counting on you.");
                        Console.WriteLine();
                        continue;
                    }
                    else if (incorrectGuesses.Contains(guess))
                    {
                        //If the user guesses a letter not
                        //contained in the word then this 
                        //will get printed to the user
                        Console.WriteLine("I am sorry but " + guess + " was attempted and it was incorrect.");
                        Console.WriteLine();
                        //Shows the user the letters that they 
                        //have already guessed
                        Console.Write("These are the letters you have already tried: ");
                        //Loops created to cycle through and
                        //print what letters have already
                        //been guessed, both incorrect and correct
                        loop(correctGuesses);
                        loop(incorrectGuesses);
                        Console.WriteLine();
                        //Tells the user how many guesses
                        //that they now have left
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
                                //Loops created to cycle through and
                                //print what letters have already
                                //been guessed, both incorrect and correct
                                loop(correctGuesses);
                                loop(incorrectGuesses);
                                Console.WriteLine();
                                //Tells the user how many guesses
                                //that they now have left
                                Console.WriteLine("You have " + lives + " guesses left companion. All of space and time is counting on you.");
                                Console.WriteLine();
                            }
                        }
                        //If the user has guessed all the letters
                        //correctly then the computer will 
                        //reveal the word and the game will then end
                        if (letterRevealed == wordToGuess.Length)
                        {
                            won = true;
                        }
                    }
                    else
                    {
                        incorrectGuesses.Add(guess);
                        Console.WriteLine("I am sorry but " + guess + " was attempted and it was incorrect.");
                        //Reduces the number of guess that
                        //the user now has.
                        lives--;
                        Console.WriteLine();
                        Console.Write("These are the letters you have already tried: ");
                        //Loops created to cycle through and
                        //print what letters have already
                        //been guessed, both incorrect and correct
                        loop(correctGuesses);
                        loop(incorrectGuesses);
                        Console.WriteLine();
                        //Tells the user how many guesses
                        //that they now have left
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

