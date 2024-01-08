using StringManipulation;
using System.Collections.Generic;

namespace StringManipulation
{
    public class ReadData
    {
        public String GetRandomWord()
        {
            string contents = "";
            try
            {
                // Get file name.
                string path = @"Files\word.txt";
                // Get path name.
                string filename = Path.GetFileName(path);
                // Open the text file using a stream reader. Read into a string
                using (var sr = new StreamReader(path))
                {
                    // Read the stream as a string, and write the string to the console.
                    contents = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file couldnot be read:");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("---------");
            //Store each word into an array using split on '\n'
            var array = contents.Split(new[] {'\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            Random rnd = new Random();
            String targetWord = array[rnd.Next(array.Length)].ToLower();

            //For debug
            Console.WriteLine(targetWord);
            return targetWord;
        }
    }
    internal class Program
    {
        static void Main()
        {
            ReadData data = new ReadData();
            string targetWord = data.GetRandomWord();
            HashSet<char> correctGuesses = new HashSet<char>();
            HashSet<char> incorrectGuesses = new HashSet<char>();
            char[] displayWord;
            displayWord = new string('_', targetWord.Length).ToCharArray();

            int lives = 6;
            while (lives > 0 && !targetWord.Equals(new string(displayWord)))
            {
                Console.WriteLine("Uncovered word so far is: {0}", new string(displayWord));
                Console.WriteLine("What letter would you like to guess next!");
                char letterToSearch = Char.ToLower(Console.ReadKey().KeyChar);
                Console.ReadLine();
                if (correctGuesses.Contains(letterToSearch) || incorrectGuesses.Contains(letterToSearch))
                {
                    Console.WriteLine("\nYou have already guessed '{0}'. Try a different letter.", letterToSearch);
                    continue;
                }
                if (targetWord.Contains(letterToSearch))
                {
                    correctGuesses.Add(letterToSearch);
                    Console.WriteLine("Letter {0} is in the word! {1} lives remaining!", letterToSearch, lives);
                    for (int i = 0; i < targetWord.Length; i++)
                    {
                        if (targetWord[i] == letterToSearch)
                        {
                            displayWord[i] = letterToSearch;
                        }
                    }
                }
                else
                {
                    lives--;
                    Console.WriteLine("Letter {0} is not in the word! {1} lives remaining!", letterToSearch, lives);
                    incorrectGuesses.Add(letterToSearch);
                }   
                }
                if (targetWord.Equals(new string(displayWord)))
                {
                    Console.WriteLine("Congratulations! You uncovered the word: {0}", new string(displayWord));
                    // So program does not break straight away
                }
                else
                {
                    Console.WriteLine("Lives over, game failed!");
                }
             // So program does not break straight away
                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();
        }
    }
}
            
            
     
                    