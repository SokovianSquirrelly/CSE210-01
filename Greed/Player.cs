namespace greed;

public class Player : Actor
{
    private int points;

    // Both players will start out with 0 points.  Their on-screen avatar will
    // be hashtags.

    public Player()
    {
        setText("#");
        points = 0;
    }

    // This is your typical "getter", which simply returns the number of points
    // a player has.

    public int getPoints()
    {
        return points;
    }

    // You could technically consider this method a "setter" since it does set
    // the player's score.  Depending on whether the player hits a rock or a
    // gem, the score will be raised or lowered.

    public void addPoints(int score)
    {
        points += score;
    }
}