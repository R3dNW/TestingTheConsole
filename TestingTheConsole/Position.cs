namespace TestingTheConsole
{
    using System;

    /// <summary>
    /// A basic class to store positions in the console.
    /// These value will be integers and will be 2-Dimensional.
    /// </summary>
    public class Position
    {
        private int x = 0;
        private int y = 0;

        public Position()
        {
            this.X = 0;
            this.Y = 0;
        }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        
        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                /*if (value < 0 || value > Console.WindowWidth) {
                    throw new Exception("Position -- Cannot have a position outside of the console's coordinates");
                }*/
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                /*if (value < 0 || value > Console.WindowWidth) {
                    throw new Exception("Position -- Cannot have a position outside of the console's coordinates");
                }*/
                this.y = value;
            }
        }

        public static Position Clone(Position original)
        {
            return new Position(original.X, original.Y);
        }

        public Position Clone()
        {
            return Clone(this);
        }
    }
}
