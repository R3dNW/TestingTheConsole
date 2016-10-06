using System;

namespace TestingTheConsole {
    public class Enemy : Entity {
        public Enemy() : base('#', Console.WindowWidth-1, Game.rand.Next(0, Console.WindowHeight - 1)) {
        }
    }
}
