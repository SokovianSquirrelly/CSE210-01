namespace greed
{
    public class Gem : Actor
    {
        private Color red = new Color(255, 0, 0);
        private Color green = new Color(0, 255, 0);
        private Color blue = new Color(0, 0, 255);
        private Color lightBlue = new Color(0, 255, 255);
        private Color purple = new Color (200, 0, 255);

        // The only thing I need to set for this constructor is the icon needed
        // to show that a gem is falling.

        public Gem()
        {
            setText("*");
        }

        // The following five methods will be called by a random number
        // generator.  Depending on which method gets called, the gem will
        // have a color and a point value set.

        private void createRuby()
        {
            setColor(red);
            setPointValue(8);
        }

        private void createEmerald()
        {
            setColor(green);
            setPointValue(6);
        }

        private void createSapphire()
        {
            setColor(blue);
            setPointValue(4);
        }

        private void createDiamond()
        {
            setColor(lightBlue);
            setPointValue(10);
        }

        private void createAmethyst()
        {
            setColor(purple);
            setPointValue(2);
        }

        // This method, selectGem(), will randomly pick a value to determine
        // which of the last five methods it will perform.

        public void selectGem()
        {
            Random selector = new Random();
            int select = selector.Next(1, 20);
            if (select < 3)
            {
                createDiamond();
            }
            else if (select < 6)
            {
                createRuby();
            }
            else if (select < 10)
            {
                createEmerald();
            }
            else if (select < 15)
            {
                createSapphire();
            }
            else
            {
                createAmethyst();
            }
        }
    }
}