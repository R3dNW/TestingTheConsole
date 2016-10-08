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
        private Bounds entityBounds;
        private Position position;
        private Position lastDrawPosition;
        private bool hidden = false;

        public Entity(char symbol)
        {
            this.Symbol = symbol;
            this.Position = new Position();
            this.EntityBounds = Bounds.ConsoleBounds;
        }

        public Entity(char symbol, Bounds entityBounds)
        {
            this.Symbol = symbol;
            this.Position = new Position();
            this.EntityBounds = entityBounds;
        }

        public Entity(char symbol, Position position)
        {
            this.Symbol = symbol;
            this.Position = position;
            this.EntityBounds = Bounds.ConsoleBounds;
        }

        public Entity(char symbol, Position position, Bounds entityBounds)
        {
            this.Symbol = symbol;
            this.Position = position;
            this.EntityBounds = entityBounds;
        }

        public Entity(char symbol, int x, int y)
        {
            this.Symbol = symbol;
            this.Position = new Position(x, y);
            this.EntityBounds = Bounds.ConsoleBounds;
        }

        public Entity(char symbol, int x, int y, Bounds entityBounds)
        {
            this.Symbol = symbol;
            this.Position = new Position(x, y);
            this.EntityBounds = entityBounds;
        }

        public Position Position
        {
            get
            {
                return this.position;
            }

            protected set
            {
                this.position = value;
            }
        }

        public Bounds EntityBounds
        {
            get { return this.entityBounds; }
            set { this.entityBounds = value; }
        }

        public bool Hidden { get; protected set; }

        protected char Symbol { get; set; }

        protected Position LastDrawPosition {
            get
            {
                return lastDrawPosition;
            }
            set
            {
                lastDrawPosition = value;
            }
        }

        public virtual void Draw()
        {
            if (this.Position.Equals(this.lastDrawPosition))
            {
                return;
            }

            if (this.lastDrawPosition != null)
            {
                Console.SetCursorPosition(this.lastDrawPosition.X, this.lastDrawPosition.Y);
                Console.Write(' ');
            }

            if (Bounds.ConsoleBounds.BoundsContainPoint(this.Position) == false)
            {
                return;
            }

            if (this.EntityBounds.BoundsContainPoint(this.Position) == false)
            {
                return;
            }

            if (this.Hidden)
            {
                return;
            }

            this.lastDrawPosition = this.Position.Clone();

            ConsoleExtended.DrawSymbol(this.Symbol, this.Position);
        }

        public bool IsCollidingWith(Entity other)
        {
            if (this.position.Equals(other.position))
            {
                return true;
            }

            return false;
        }

        public abstract void Update(int deltaTimeMS);
    }
}
