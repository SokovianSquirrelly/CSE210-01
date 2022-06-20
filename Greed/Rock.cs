namespace greed
{
    public class Rock : Actor
    {
        private Color gray = new Color(150, 150, 150);

        // Unlike the Gem class, this class doesn't really need more than just
        // a constructor.  The setters to build a rock are already part of the
        // Actor class.

        public Rock()
        {
            setPointValue(-5);
            setText("O");
            setColor(gray);
        }
    }
}