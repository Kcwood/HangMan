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
            HangMan();
            




            Console.ReadKey();
        }
        //Setting up the function for HangMan
        static void HangMan()
        {
            
            //Getting the users name
            Console.WriteLine("Hey you! What is your name?");
            Console.WriteLine();
            //Allowing the user to interact with the computer
            string name = Console.ReadLine();
            Console.WriteLine();
            //Greeting the user and explaining the rules 
            //and asking the user if they would like to play
            Console.WriteLine("Greetings fellow traveler " + name + "! I am the Doctor. I would like to play a game called Hangman with you. The rules are simple. I will make a word and you will guess a letter to see if it is in the word that I have made. If so, I will unveil those letters to you and you will continue guessing until you have run out of guesses or you have guessed the word. If you guess the word correctly, you will have had a grand adventure through time and space. If you don't, the Angels will have zapped you permantently to another time and you will die a slow death! Would you like to play?");
            Console.WriteLine();
            //Allowing the user to interact with the computer
            string gamePlay = Console.ReadLine();
            Console.WriteLine();
            //Getting the users answer
            while (gamePlay == "yes" || gamePlay == "Yes" || gamePlay == "y")
            {
                //Starting the game
                Console.WriteLine("Alright! Let's hop in the TARDIS and off we go! Geronimo!");
                Console.WriteLine();
                Console.WriteLine("I have thought of a word. Make your first guess!");
                //Making a list of words to generate
                string [] wordList = new string [] { "badwolf", "spoilers", "gallifrey", "custard", "pandorica", "ood", "timelash", "dalek", "cybermen", "rose", "martha", "clara", 
                "amy","rory", "mickie", "donna", "titanic", "screwdriver" };
                int i = 0; 
                //setting up the random word generator
                //to find an index of the word list 
                //we created
                Random word = new Random();
                word.Next(0, 17);
                string randomWord = wordList[i];
                //Creating some variables for our 
                //while loop
                int totalGuess = 10;
                int noGuess = 0;
                while (totalGuess > noGuess)
                {

                    
                }


                

                
            }

        }
        static void MaskedWord()
        {
            //Making a list of words to generate
            string[] wordList = new string[] { "badwolf", "spoilers", "gallifrey", "custard", "pandorica", "ood", "timelash", "dalek", "cybermen", "rose", "martha", "clara", 
                "amy","rory", "mickie", "donna", "titanic", "screwdriver" };
            int i = 0;
            //setting up the random word generator
            //to find an index of the word list 
            //we created
            Random word = new Random();
            word.Next(0, 17);
            string randomWord = wordList[i];
        }
    }
}
