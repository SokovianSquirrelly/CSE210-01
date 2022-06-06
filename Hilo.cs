/******************************************************************************
* Class Name: Player
* Purpose: This is simply the person playing the game.  This class keeps track
*   of the player's score, how many turns they've taken, and how many turns
*   they've guessed correctly on.  The player also gets to choose if he/she
*   wants to keep playing or not after each round.
******************************************************************************/

public class Player
{
    public int score = 300;
    public int correctCards = 0;
    public int totalCards = 0;

    public Player(int score, int correctCards, int totalCards)
    {
        this.score = score;
        this.correctCards = correctCards;
        this.totalCards = totalCards;
    }

    public int getScore(int score)
    {
        return score;
    }

    public int getCorrect(int correctCards)
    {
        return correctCards;
    }

    public int getTotal(int totalCards)
    {
        return totalCards;
    }

    // This method is meant to get the user input.  If it's high, it returns
    // true, but if not, it will return false.
    public bool guessHigh()
    {
        bool highGuess = false;
        bool invalid = false;
        do
        {
            Console.Write("Will the next card be higher or lower? (h/l) ");
            string playerGuess = Console.ReadLine();
            if (playerGuess == "h")
            {
                invalid = false;
                highGuess = true;
            }
            else if (playerGuess == "l")
            {
                invalid = false;
                highGuess = false;
            }
            else
            {
                Console.WriteLine("Invalid input");
                invalid = true;
            }
        }
        while (invalid);
        return highGuess;
    }

    // After each round, the player will decide if he/she wants to play again or not.
    public bool playAgain()
    {
        bool again = false;
        bool invalid = true;
        do
        {
            Console.Write("Would you like to play another round? (y/n) ");
            string response = Console.ReadLine();

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
                invalid = true;
                Console.WriteLine("Not a valid response");
            }
            Console.WriteLine("");
        }
        while (invalid);
        return again;
    }
}

/******************************************************************************
* Class Name: Card
* Purpose: These are the cards in play.  They only have one variable, being the
*   card value, but this class also randomly draws a new card each turn.
******************************************************************************/
public class Card
{
    public int value = 7;

    public Card(int value)
    {
        this.value = value;
    }

    // I used a random number generator to draw cards and return the value on
    // each of those cards.
    public int draw()
    {
        Random rnd = new Random();
        value = rnd.Next(1, 14);
        return value;
    }
}

/******************************************************************************
* Class Name: Game
* Purpose: This class does quite a bit.  It takes one player and two cards.  It
*   holds the code for gameplay.
******************************************************************************/
public class Game
{
    public Card oldCard;
    public Card newCard;
    public Player player;

    public Game()
    {
        oldCard = new Card(7);
        newCard = new Card(7);
        player = new Player(300, 0, 0);
    }

    // This method is meant to see if the second card is higher than the first
    // card.  It will return a true if it is, and a false if it's lower.
    public bool compareCards()
    {
        bool isHigher = false;
        if (oldCard.value < newCard.value)
        {
            isHigher = true;
        }
        return isHigher;
    }

    // This determines if two cards carry the same value.  If they do, the
    // player won't gain nor lose points.
    public bool sameCard()
    {
        bool same = false;
        if (oldCard.value == newCard.value)
        {
            same = true;
        }
        else
        {
            same = false;
        }
        return same;
    }

    // Probably my most complex method of this program.  if the boolean
    // statements of compareCards() and guessHigh() are the same, the player
    // gains 100 points.  If they're not, and the old and new card aren't
    // the same value, the player loses 75 points.  It also acts as a display
    // method, showing points and correct/total guesses.
    public void gamePlay()
    {
        Console.WriteLine($"The card is: {oldCard.value}.");
        bool upGuess = player.guessHigh();
        bool upAnswer = compareCards();
        bool isSame = sameCard();

        if (isSame)
        {
            Console.WriteLine("They're actually the same numbers.");
            Console.WriteLine("You neither gain nor lose points.");
        }
        else if (upGuess == upAnswer)
        {
            Console.WriteLine($"That's correct!  The new card is {newCard.value}.");
            Console.WriteLine("You gain 100 points!");
            player.getScore(player.score += 100);
            player.getCorrect(player.correctCards += 1);
        }
        else
        {
            Console.WriteLine($"Sorry, that ain't it chief.  The new card is {newCard.value}.");
            Console.WriteLine("You lose 75 points...");
            player.getScore(player.score -= 75);
        }

        player.getTotal(player.totalCards += 1);
        Console.WriteLine($"Your score is {player.score}.");
        Console.WriteLine($"Correct Guesses: {player.correctCards}/{player.totalCards}");
    }
}

/******************************************************************************
* Class Name: Program
* Purpose: The driver of the program.  This contains one method, being Main().
*   It also calls the draw() method each round from the Card class.  It will
*   keep running until either the player decides not to play or if their score
*   hits zero or less.
******************************************************************************/
public class Program
{
    static void Main()
    {
        Game g = new Game();
        bool keepPlaying = true;
        g.oldCard.draw();
        while (keepPlaying)
        {
            g.newCard.draw();
            g.gamePlay();
            if (g.player.score > 0)
            {
                g.oldCard.value = g.newCard.value;
                keepPlaying = g.player.playAgain();
            }
            else
            {
                keepPlaying = false;
                Console.WriteLine("Lol, you lost noob!  Game over!");
            }
        }
    }
}
