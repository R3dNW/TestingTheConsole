namespace TestingTheConsole
{
    using System;
    using CustomExtentions;

    /// <summary>
    /// An entity class to deal with all entities within the game.
    /// i.e. Players, Enemies etc.
    /// </summary>
    public abstract class Entity
    {
        private Position position;
        private Position lastDrawPosition;
        private bool hidden = false;

        public Entity(char symbol)
        {
            this.Symbol = symbol;
            this.Position = new Position();
        }

        public Entity(char symbol, Position position)
        {
            this.Symbol = symbol;
            this.Position = position;
        }

        public Entity(char symbol, int x, int y)
        {
            this.Symbol = symbol;
            this.Position = new Position(x, y);
        }

        public Position Position
        {
            get
            {
                return this.position;
            }

            protected set
            {
                if (value.X < 0 || value.X >= Console.WindowWidth || value.Y < 0 || value.Y >= Console.WindowWidth)
                {
                    throw new Exception("Position -- Cannot have a position outside of the console's coordinates");
                }

                this.position = value;
            }
        }

        public bool Hidden { get; protected set; }

        protected char Symbol { get; set; }

        public virtual void Draw()
        {
            if (this.Position == this.lastDrawPosition)
            {
                return;
            }

            if (this.lastDrawPosition != null)
            {
                Console.SetCursorPosition(this.lastDrawPosition.X, this.lastDrawPosition.Y);
                Console.Write(' ');
            }

            if (this.Hidden)
            {
                return;
            }

            this.lastDrawPosition = this.Position.Clone();

            Console.SetCursorPosition(this.Position.X, this.Position.Y);
            Console.Write(this.Symbol);
        }

        public abstract void Update(int deltaTimeMS);
    }
}
