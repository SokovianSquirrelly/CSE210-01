The following classes were borrowed from the Robot Meets Kitten program:
    -Actor
    -Cast
    -Color
    -Director
    -KeyboardService
    -Point
    -Program
    -VideoService

    There were, however, modifications made to many of them to make the Greed program work.  For example,
this game was designed to be two-player.  In KeyboardService, I added a function to allow player 2's avatar
to move independent of player 1's.  While player 1 is using the left and right arrow keys on the keyboard to
move, player 2 uses A and D.  Furthermore, the Cast class was changed to allow both gems and rocks to be part
of the "stones" list.  In order to do this, I had to give Actor another value, being the point value.  Some
actors (specifically the players and score banners), didn't need the point value.  That value was only being
used by Rock and Gem, and that value determines how many points the player wins or loses when they touch an
object.

    The Gem and Rock classes are subclasses of Actor.  Both gems and rocks are falling from the top of the
screen and hold their own colors and point values.  There are 5 different kinds of gems, being:
    -Amethyst: purple and holds a point value of 2
    -Sapphire: blue and holds a point value of 4
    -Emerald: green and holds a point value of 6
    -Ruby: red and holds a point value of 8
    -Diamond: light blue and holds a point value of 10

    Rocks, however, are all gray and hold a point value of -5.  When these point values get passes into the
players' addScore() method, those points are either added or subtracted from the respective player's score.

    Finally, we have Player.  Two Player objects are created when the games starts.  Player 1 is marked by a
white hashtag while Player 2 is marked by a pink one.  They only move left and right across the screen and
try to catch as many gems as they can, attempting to avoid falling rocks.  Whenever a rock or gem is caught,
the doUpdates() method in Director ensures that the rock or gem will be replaced by another rock or gem.