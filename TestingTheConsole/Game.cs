namespace TestingTheConsole
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using CustomExtentions;

    /// <summary>
    /// This is the main Game class.
    /// </summary>
    public class Game
    {
        private static Game instance;

        private Entity player;
        private List<Entity> enemies;

        private Stopwatch stopwatch;

        private long timeAtLastUpdateMS;

        private int score;

        private Bounds gameBounds;
        private Bounds entityBounds;

        public Game()
        {
            if (Instance != null)
            {
                throw new Exception("You cannot have two instances of Game at the same time.");
            }

            Instance = this;

            Console.CursorVisible = false;
            Console.Clear();

            this.gameBounds = new Bounds(0, Bounds.ConsoleBounds.XMax, 0, Bounds.ConsoleBounds.YMax - 3);

            ConsoleExtended.DrawBounds(gameBounds);

            ConsoleExtended.DrawBounds(new Bounds(gameBounds.XMin, gameBounds.XMax, gameBounds.YMax, gameBounds.YMax + 2));

            this.entityBounds = new Bounds(gameBounds.XMin + 1,
                                             gameBounds.XMax - 1,
                                             gameBounds.YMin + 1,
                                             gameBounds.YMax - 1);

            Rand = new Random();

            this.player = new Player(this.entityBounds);
            this.enemies = new List<Entity>();

            for (int i = 0; i < 20; i++)
            {
                this.enemies.Add(
                    new Enemy((((float)Rand.NextDouble() * 0.5f) + 0.75f) * 12.5f, this.entityBounds));
            }

            this.stopwatch = new Stopwatch();
            this.stopwatch.Start();
        }

        public static Random Rand { get; protected set; }

        public static Game Instance
        {
            get
            {
                return instance;
            }

            protected set
            {
                instance = value;
            }
        }

        public void UpdateLoop()
        {
            while (true)
            {
                int deltaTimeMS = (int)(this.stopwatch.ElapsedMilliseconds - this.timeAtLastUpdateMS);

                this.timeAtLastUpdateMS = this.stopwatch.ElapsedMilliseconds;

                this.player.Update(deltaTimeMS);
                foreach (Entity enemy in this.enemies)
                {
                    enemy.Update(deltaTimeMS);
                    if (this.player.IsCollidingWith(enemy))
                    {
                        this.GameOver();
                        return;
                    }
                }

                this.player.Draw();
                foreach (Entity enemy in this.enemies)
                {
                    enemy.Draw();
                }

                Console.SetCursorPosition(2, Console.WindowHeight - 3);
                Console.Write(string.Format("Score: {0}", this.score));
            }
        }

        public void ScoreAdd()
        {
            this.score += 1;
        }

        private void GameOver()
        {
            Console.Clear();
            Console.SetCursorPosition(2, 1);
            Console.WriteLine("Game Over!");

            ConsoleExtended.DrawBounds(gameBounds);

            Console.SetCursorPosition(2, 3);
            if (score > 0)
            {
                Console.WriteLine(string.Format("Score: {0}", this.score));
            }
            else
            {
                Console.WriteLine("Pathetic -- You Scored 0 Points");
            }

            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.ReadLine(); // Stops the console from closing

            Instance = null;
        }
    }
}