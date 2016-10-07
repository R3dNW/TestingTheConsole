using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Timers;

namespace TestingTheConsole {
    public class Game {
        Entity player;
        List<Entity> enemies;

        public static Random rand { get; protected set; }

        Stopwatch stopwatch;

        long timeAtLastUpdateMS;
        
        public Game() {
            Console.CursorVisible = false;

            rand = new Random();

            this.player = new Player();
            this.enemies = new List<Entity>();

            for (int i = 0; i < 10; i++) {
                this.enemies.Add(new Enemy(((float)rand.NextDouble() + 0.5f) * 7.5f));
            }

            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        public void UpdateLoop() {
            while (true) {
                int deltaTimeMS = (int)(stopwatch.ElapsedMilliseconds - timeAtLastUpdateMS);

                timeAtLastUpdateMS = stopwatch.ElapsedMilliseconds;

                player.Update(deltaTimeMS);
                foreach (Entity enemy in enemies) {
                    enemy.Update(deltaTimeMS);
                }

                player.Draw();
                foreach (Entity enemy in enemies) {
                    enemy.Draw();
                }

                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write("Time Since Start: ");
                Console.Write((float)timeAtLastUpdateMS / 1000.0f);
                Console.Write("        FPS: ");
                Console.Write(1000.0f / (float)deltaTimeMS);
            }
        }
    }
}
