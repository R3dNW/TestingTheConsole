namespace ConsolePositions
{
    using System;
    using CustomExtentions;

    public class Bounds
    {
        private static Bounds consoleBounds;

        private int xMin;
        private int xMax;

        private int yMin;
        private int yMax;

        public Bounds()
        {
            return;
        }

        public Bounds(int xMin, int xMax, int yMin, int yMax)
        {
            this.XMin = xMin;
            this.XMax = xMax;
            this.YMin = yMin;
            this.YMax = yMax;
        }

        public Bounds(Position min, Position max)
        {
            this.Min = min;
            this.Max = max;
        }

        public static Bounds ConsoleBounds
        {
            get
            {
                if (consoleBounds == null)
                {
                    consoleBounds = new Bounds(0, Console.WindowWidth, 0, Console.WindowHeight);
                }

                return consoleBounds;
            }

            set
            {
                Console.SetWindowSize(value.XMax, value.YMax);
                consoleBounds = value;
            }
        }

        public int XMin
        {
            get { return this.xMin; }
            set { this.xMin = value; }
        }

        public int XMax
        {
            get { return this.xMax; }
            set { this.xMax = value; }
        }

        public int YMin
        {
            get { return this.yMin; }
            set { this.yMin = value; }
        }

        public int YMax
        {
            get { return this.yMax; }
            set { this.yMax = value; }
        }

        public Position Min
        {
            get
            {
                return new Position(this.XMin, this.YMin);
            }

            set
            {
                this.XMin = value.X;
                this.YMin = value.Y;
            }
        }

        public Position Max
        {
            get
            {
                return new Position(this.XMax, this.YMax);
            }

            set
            {
                this.XMax = value.X;
                this.YMax = value.Y;
            }
        }

        public bool BoundsContainPoint(Position position)
        {
            if (position.X < this.XMin || position.X >= this.XMax || position.Y < this.YMin || position.Y >= this.YMax)
            {
                return false;
            }

            return true;
        }

        public Position ClampPositionToBounds(Position position)
        {
            position.X = MathExtended.Clamp(position.X, this.XMin, this.XMax);
            position.Y = MathExtended.Clamp(position.Y, this.YMin, this.YMax);
            return position;
        }
    }
}
