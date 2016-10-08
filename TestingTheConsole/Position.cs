namespace ConsolePositions
{
    using System;

    /// <summary>
    /// A basic class to store positions in the console.
    /// These value will be integers and will be 2-Dimensional.
    /// </summary>
    public class Position : IEquatable<Position>
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
            get { return this.x; }

            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }

            set { this.y = value; }
        }

        public bool OutOfConsole
        {
            get
            {
                return Bounds.ConsoleBounds.BoundsContainPoint(this);
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

        public bool Equals(Position other)
        {
            if (other == null)
            {
                return false;
            }

            if (this.X == other.X && this.Y == other.Y)
            {
                return true;
            }

            return false;
        }
    }
}
