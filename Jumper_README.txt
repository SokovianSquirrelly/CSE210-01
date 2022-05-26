Class: WordList
Purpose: This holds three lists of words that could potentially be used in
    gameplay.  There is also a method to randomly pick one of those words for
    the player to guess.

Class: Skydiver
Purpose: Think hangman, but instead of hanging a dude because you guessed the
    wrong letters, you're getting rid of a skydiver's parachute little by
    little until he hits the ground without a chute and dies, you sick twisted
    freak!  Anyway, this will also display the skydiver and determine if he's
    still alive or not.

Class: Player
Purpose: This class represents the user.  It holds a value for the player's
    score.  The player's score increases each time he/she guesses a word
    correctly before the skydiver loses his parachute.  This class also allows
    the player to guess what letters are in the mystery word.  The player can
    also decide if they want to keep playing after each round.

Class: Game
Purpose: This is where the other three classes come into, and the Main()
    function in the Program class will create a game object that everything in
    this program is centered around.  It creates two arrays to start with.  One
    array starts off as just an array of underscores, representing blanks where
    letters are supposed to go.  Whenever the player guesses a letter
    correctly, the underscore is replaced by the respective letter.  The second
    array is the chosen word from the WordList class converted into an array of
    characters, which allows the program to loop through each letter to see if
    the player's guessed letter matches.  If the player guesses wrong, a life
    is taken away from the skydiver.  This process continues until either the
    skydiver dies or the player gets the whole word correct.  If the player
    guesses the word, he/she is awarded points based on how long the word is.

Extra Note: take a look between lines 274-276 for an Easter egg.