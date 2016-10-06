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

            this.player = new Entity('@', 20, 20);
            this.enemies = new List<Entity>();

            for (int i = 0; i < 10; i++) {
                this.enemies.Add(new Enemy());            }

            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        public void UpdateLoop() {
            while (true) {
                float deltaTime = timeAtLastUpdateMS - stopwatch.ElapsedMilliseconds;

                player.Draw();
                foreach (Entity enemy in enemies) {
                    enemy.Draw();
                }

                timeAtLastUpdateMS = stopwatch.ElapsedMilliseconds;
            }
        }
    }
}
