namespace TestingTheConsole
{
    using System;
    using CustomExtentions;

    /// <summary>
    /// An simple enemy for the game with a simple AI.
    /// Will continually move from right to left before going back to the right when it reaches the left.
    /// </summary>
    public class Enemy : Entity
    {
        private int timeSinceLastMoveMS;

        private int sleepTimeMS;

        private char[] trailSymbols = new char[4] { '#', '>', '=', '-' };

        private int trailLength = 4;

        private Position[] lastPositions;

        public Enemy(
            float speed,
            Bounds bounds,
            float maxSpeed = 100) : base(
                '#',
                bounds.XMax + 1,
                Game.Rand.Next(bounds.YMin, bounds.YMax + 1),
                bounds)
        {
            this.Speed = speed;
            this.MaxSpeed = maxSpeed;
            this.sleepTimeMS = Game.Rand.Next(0, 4000);

            this.lastPositions = new Position[this.trailLength];
        }

        public float Speed { get; set; }

        public float MaxSpeed { get; set; }

        public int TimeBetweenMovesMS
        {
            get
            {
                return (int)(1000 / this.Speed);
            }
        }

        public override void Update(int deltaTimeMS)
        {
            if (this.sleepTimeMS > 0)
            {
                this.sleepTimeMS -= deltaTimeMS;
                if (this.sleepTimeMS <= 0)
                {
                    this.timeSinceLastMoveMS += -this.sleepTimeMS;
                    this.sleepTimeMS = 0;
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.timeSinceLastMoveMS += deltaTimeMS;
            }

            if (this.timeSinceLastMoveMS < this.TimeBetweenMovesMS)
            {
                return;
            }

            this.timeSinceLastMoveMS -= this.TimeBetweenMovesMS;

            if (this.Position.X <= EntityBounds.XMin)
            {
                this.Position.X = EntityBounds.XMax + 1;
                this.Position.Y = Game.Rand.Next(EntityBounds.YMin, EntityBounds.YMax + 1);

                this.sleepTimeMS = Game.Rand.Next(500, 2500);

                this.Speed = MathExtended.Clamp(this.Speed * 1.25f, 0, this.MaxSpeed);

                Game.Instance.ScoreAdd();

                return;
            }

            this.Position.X -= 1;

            this.Update(0);
        }
    }
}