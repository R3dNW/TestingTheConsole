namespace TestingTheConsole
{
    using System;
    using CustomExtentions;

    /// <summary>
    /// A simple class to act as a player for user.
    /// Can move about according to Keyboard input.
    /// </summary>
    public class Player : Entity
    {
        public Player(Bounds bounds) : base('@', Console.WindowWidth / 2, Console.WindowHeight / 2, bounds)
        {
        }

        public override void Update(int deltaTimeMS)
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.NumPad6:
                        this.Position.X += 1;
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.NumPad4:
                        this.Position.X -= 1;
                        break;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.NumPad8:
                        this.Position.Y -= 1;
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.NumPad2:
                        this.Position.Y += 1;
                        break;
                }

                this.Position = EntityBounds.ClampPositionToBounds(this.Position);
            }
        }
    }
}
