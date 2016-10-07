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

        public Enemy(float speed, float maxSpeed = 100) : base('#', Console.WindowWidth - 1, Game.Rand.Next(0, Console.WindowHeight - 2))
        {
            this.Speed = speed;
            this.MaxSpeed = maxSpeed;
            this.sleepTimeMS = Game.Rand.Next(0, 4000);
            this.Hidden = true;
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
                this.Hidden = false;
            }

            if (this.timeSinceLastMoveMS < this.TimeBetweenMovesMS)
            {
                return;
            }

            this.timeSinceLastMoveMS -= this.TimeBetweenMovesMS;

            this.Position.X -= 1;

            if (this.Position.X <= 0)
            {
                this.Position.X = Console.WindowWidth - 1;
                this.Position.Y = Game.Rand.Next(0, Console.WindowHeight - 2);

                this.sleepTimeMS = Game.Rand.Next(500, 2500);

                this.Hidden = true;

                this.Speed = MathExtended.Clamp(this.Speed * 1.25f, 0, this.MaxSpeed);
            }

            this.Update(0);
        }
    }
}