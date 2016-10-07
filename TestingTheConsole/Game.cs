namespace TestingTheConsole
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// This is the main Game class.
    /// </summary>
    public class Game
    {
        private Entity player;
        private List<Entity> enemies;

        private Stopwatch stopwatch;

        private long timeAtLastUpdateMS;

        public Game()
        {
            Console.CursorVisible = false;

            Rand = new Random();

            this.player = new Player();
            this.enemies = new List<Entity>();

            for (int i = 0; i < 10; i++)
            {
                this.enemies.Add(new Enemy(((float)Rand.NextDouble() + 0.5f) * 7.5f));
            }

            this.stopwatch = new Stopwatch();
            this.stopwatch.Start();
        }

        public static Random Rand { get; protected set; }

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
                }

                this.player.Draw();
                foreach (Entity enemy in this.enemies)
                {
                    enemy.Draw();
                }

                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write("Time Since Start: ");
                Console.Write((float)this.timeAtLastUpdateMS / 1000.0f);
                Console.Write("        FPS: ");
                Console.Write(1000.0f / (float)deltaTimeMS);
            }
        }
    }
}