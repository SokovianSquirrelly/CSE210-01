/******************************************************************************
* Class: WordList
* Purpose: This class stores a bunch of words that the player may need to
*   guess.  The words are also picked at random.
******************************************************************************/

public class WordList
{
    private List<string> fiveLetterWords;
    private List<string> sixLetterWords;
    private List<string> sevenLetterWords;
    private string chosenWord;

    // WordList Constructor

    public WordList()
    {
        fiveLetterWords = new List<string>();
        sixLetterWords = new List<string>();
        sevenLetterWords = new List<string>();
        chosenWord = "";
        populate();
    }

    // There are 15 words for each category of five, six, or seven letters.
    // This method is meant to add all 45 words into their respective lists.

    private void populate()
    {
        fiveLetterWords.Add("mayor");
        fiveLetterWords.Add("aware");
        fiveLetterWords.Add("thumb");
        fiveLetterWords.Add("bible");
        fiveLetterWords.Add("taste");
        fiveLetterWords.Add("piece");
        fiveLetterWords.Add("trash");
        fiveLetterWords.Add("coast");
        fiveLetterWords.Add("tease");
        fiveLetterWords.Add("order");
        fiveLetterWords.Add("wrong");
        fiveLetterWords.Add("state");
        fiveLetterWords.Add("twist");
        fiveLetterWords.Add("range");
        fiveLetterWords.Add("share");

        sixLetterWords.Add("notice");
        sixLetterWords.Add("freeze");
        sixLetterWords.Add("insure");
        sixLetterWords.Add("letter");
        sixLetterWords.Add("create");
        sixLetterWords.Add("speech");
        sixLetterWords.Add("sticky");
        sixLetterWords.Add("forget");
        sixLetterWords.Add("effort");
        sixLetterWords.Add("spread");
        sixLetterWords.Add("dollar");
        sixLetterWords.Add("system");
        sixLetterWords.Add("string");
        sixLetterWords.Add("attack");
        sixLetterWords.Add("smooth");

        sevenLetterWords.Add("traffic");
        sevenLetterWords.Add("compete");
        sevenLetterWords.Add("freedom");
        sevenLetterWords.Add("install");
        sevenLetterWords.Add("station");
        sevenLetterWords.Add("serious");
        sevenLetterWords.Add("fortune");
        sevenLetterWords.Add("account");
        sevenLetterWords.Add("plastic");
        sevenLetterWords.Add("distant");
        sevenLetterWords.Add("protest");
        sevenLetterWords.Add("suggest");
        sevenLetterWords.Add("thirsty");
        sevenLetterWords.Add("contact");
        sevenLetterWords.Add("thinker");
    }

    // Depending on how many letters the player wants to guess, this method
    // will randomly select a word from the correct category.

    public string chooseAWord(int numberOfLetters)
    {
        Random rnd = new Random();
        if (numberOfLetters == 5)
        {
            int num = rnd.Next(fiveLetterWords.Count);
            chosenWord = fiveLetterWords[num];
        }
        else if (numberOfLetters == 6)
        {
            int num = rnd.Next(sixLetterWords.Count);
            chosenWord = sixLetterWords[num];
        }
        else
        {
            int num = rnd.Next(sevenLetterWords.Count);
            chosenWord = sevenLetterWords[num];
        }

        return chosenWord;
    }
}

/******************************************************************************
* Class: Skydiver
* Purpose: Keeps track of the number of lives the jumper has before he dies.
*   If the player guesses a letter wrong, the jumper loses a life.  When he
*   dies, the round is over.
******************************************************************************/

public class Skydiver
{
    private int lives;
    private bool alive;

    // Skydiver Constructor

    public Skydiver()
    {
        lives = 4;
        alive = true;
    }

    // This method will be called each time the player guesses a wrong letter.

    public int subtractLife()
    {
        return lives--;
    }

    // Every time the player guesses a wrong letter, this method will be called
    // to see if the jumper is still alive.  If not, the player loses the
    // round.

    public bool isHeAlive()
    {
        if (lives == 0)
        {
            alive = false;
        }
        else
        {
            alive = true;
        }
        
        return alive;
    }

    // This method shows parts of the jumper depending on how many lives he has
    // left.  With each incorrect guess, the jumper loses one layer of his
    // parachute until he dies due to the player's wrong decisions.  This game
    // is now much darker because of that statement.

    public void displayDiver()
    {
        Console.WriteLine("");

        if (lives == 4)
        {
            Console.WriteLine("  ___");
        }

        if (lives >= 3)
        {
            Console.WriteLine(" /___\\");
        }

        if (lives >= 2)
        {
            Console.WriteLine(" \\   /");
        }

        if (alive)
        {
            Console.WriteLine("  \\ /");
            Console.WriteLine("   o");
        }
        else
        {
            Console.WriteLine("   x");
        }
        
        Console.WriteLine("  /|\\");
        Console.WriteLine("  / \\");
        Console.WriteLine("");
        Console.WriteLine("^^^^^^^");
    }
}

/******************************************************************************
* Class: Player
* Purpose: Controls the user inputs for the game.  The player can decide how
*   many letters they want to guess, what letter to guess, and if they want to
*   play again or not.  I've also added a score counter.  If the player wins a
*   round, they earn points based on how many letters a word had.
******************************************************************************/

public class Player
{

    private int score;

    // Player Constructor

    public Player()
    {
        score = 0;
    }

    // Because score is a private variable, we need this getter in order to
    // access it outside the class.  It will also be called when the player
    // wins a round in order to add to the score.

    public int getScore(int points)
    {
        return (score += points);
    }

    // This method asks the player how many letters they'd like their word to
    // be.  Because this is just the beta version, they can only have up to 7
    // letters.  Gosh darn these game developers and their cutting corners to
    // make a deadline!  I swear this game was made by EA and they're gonna
    // include paid DLC to add an extra letter!

    public int chooseWordLength()
    {
        int response = 0;
        string responseStr = "";
        bool invalid = true;

        do
        { // or do not.  There is no
            try
            {
                Console.Write("How many letters would you like the word to be? (Pick 5-7) ");
                responseStr = Console.ReadLine();
                response = Int32.Parse(responseStr);

                if (response < 5)
                {
                    Console.WriteLine("Bruh, that number is too small.");
                    invalid = true;
                }
                else if (response > 7)
                {
                    Console.WriteLine("Bruh, that number is too big.");
                    invalid = true;
                }
                else
                {
                    invalid = false;
                }
            }
            catch
            {
                Console.WriteLine("ERROR: Response must be a number!");
                invalid = true;
            } 
        }
        while (invalid);


        return response;
    }

    // Allows the player to input a letter to guess with.  If the input fails,
    // I've made sure to put some error handling in place.

    public char inputLetter()
    {
        char letterChar = 'a';
        bool invalid = true;
        do
        { // or do not. There is no
            try
            {
                Console.Write("Please choose a letter. ");
                string letterString = Console.ReadLine();
                string lowerString = letterString.ToLower();
                letterChar = (char.Parse(lowerString));
                if (!char.IsLetter(letterChar))
                {
                    Console.WriteLine("ERROR: Response must be a letter!");
                    invalid = true;
                }
                else
                {
                    invalid = false;
                }

            }
            catch
            {
                Console.WriteLine("ERROR: Response must be a single letter!");
                invalid = true;
            }
        }
        while (invalid);

        return letterChar;
    }

    // This method simply asks the player if they'd like to play again.  This
    // will appear after each round, even if the player loses.

    public bool playAgain()
    {
        string response = "";
        bool again = false;
        bool invalid = true;
        do
        {
            Console.Write("Would you like to play again? (y/n) ");
            response = Console.ReadLine();
            if (response == "y")
            {
                invalid = false;
                again = true;
            }
            else if (response == "n")
            {
                invalid = false;
                again = false;
            }
            else
            {
                Console.WriteLine("Invalid input");
                invalid = true;
            }
        }
        while(invalid);

        return again;
    }
}

/******************************************************************************
* Class: Game
* Purpose: The most complex class of the program.  This class holds the rules
*   and gameplay mechanics that get the whole thing working.
******************************************************************************/

public class Game
{
    public Player player = new Player();
    public WordList wordList = new WordList();
    public Skydiver jumper;

    // This method creates an array full of underscores.  This array will be
    // modified whenever the player guesses a correct letter.

    public char[] makeWordspace(int wordLength)
    {
        char[] letters = new char[wordLength];
        for (int i = 0; i < wordLength; i++)
        {
            letters[i] = '_';
        }

        return letters;
    }

    // This method takes the word chosen by the WordList class and converts it
    // into an array of characters.

    public char[] splitWord(string word)
    {
        char[] charArr = word.ToCharArray();
        return charArr;
    }

    // This method is complicated, so I'll explain the different parts of it
    // throughout the code.

    public void gameplay()
    {

        // I needed to make sure to call all these methods once, and then have
        // a variable representing the returned value of each method.  I also
        // didn't construct a Skydiver object until now because after each
        // round, we'll need to reset the values it holds.

        int wordLength = player.chooseWordLength();
        string theWord = wordList.chooseAWord(wordLength);
        char[] sepLetters = makeWordspace(wordLength);
        char[] letterArray = splitWord(theWord);
        bool hasWon = false;
        jumper = new Skydiver();

        do
        {
            Console.WriteLine("");

            // This loop displays the values from the makeWordspace method.
            // It shows both the correctly guessed letters and the blanks in
            // the array.

            foreach(char ch in sepLetters)
            {
                Console.Write($"{ch} ");
            }

            Console.WriteLine("");

            jumper.displayDiver();

            // This loop checks if the player guessed a letter correctly.  It
            // looks through the array from splitWord() and compares each
            // letter to the letter the player guessed.  If at least one is
            // correct, this code makes sure that no lives are lost.  It also
            // replaces the blanks from the above array with letters.

            char letter = player.inputLetter();
            int i = 0;
            int correct = 0;
            foreach(char ch in letterArray)
            {
                if (letter == ch)
                {
                    sepLetters[i] = letter;
                    correct ++;
                }

                i++;
            }

            // If the player guesses a letter incorrectly, the jumper loses one
            // life.

            if (correct == 0)
            {
                jumper.subtractLife();
            }

            int blanks = 0;

            // This loop checks for blanks, or underscores in the sepLetters
            // array.  If there are no blanks left, the player wins this round
            // and points can be awarded.

            foreach(char ch in sepLetters)
            {
                if (ch == '_')
                {
                    blanks ++;
                }
            }

            if (blanks == 0)
            {
                awardPoints(wordLength);
                hasWon = true;
            }
        }
        while (jumper.isHeAlive() && !hasWon);

        // Depending on the outcome of the game, the user could receive either
        // a "congrats" message and be awarded points, or a "sorry, you lose"
        // message.

        if (!jumper.isHeAlive())
        {
            jumper.displayDiver();
            Console.WriteLine($"Sorry, the word was {theWord}.");
        }
        else
        {
            Console.WriteLine($"The word was {theWord}!  Congrats!");
        }
        Console.WriteLine("");
    }

    // This method gives the player points depending on how many letters the
    // word had.

    public void awardPoints(int length)
    {
        player.getScore(length);
    }
}

/******************************************************************************
* Class: Program
* Purpose: This is really just the driver of the program.  A game object is
*   created and will continue running until the player gets bored.  It also
*   displays the final score.
******************************************************************************/

public class Program
{
    static void Main()
    {
        Game g = new Game();
        bool again = true;
        do
        {
            g.gameplay();
            again = g.player.playAgain();
        }
        while (again);
        Console.WriteLine($"Final score: {g.player.getScore(0)}");
    }
}