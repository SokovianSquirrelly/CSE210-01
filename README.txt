Class 1: Player
    The player starts with 300 points and has not drawn any cards yet.  Each turn, it guesses if the second card has a value that is
higher or lower than the first card.  It will gain or lose points based on if it's correct.  It can also decide if it wants to keep
playing the game or not.

Class 2: Card
    A random number generator that produces numbers between 1 and 13 is programmed into the draw() method.

Class 3: Game
    The Game class will compare the old and new cards in play as well as the player's answer to determine if the player gains or loses points.
If the value of the cards is the same, the player neither gains nor loses points.  If the player is correct, he/she gains 100 points.  But if
not, and the cards aren't the same value, he/she loses 75 points.

Class 4: Program
    This final class is the driver of the program.  It draws the cards during gameplay and will keep running the game until either the player
decides they're done playing, or until he/she runs out of points.