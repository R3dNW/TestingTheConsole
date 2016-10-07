using System;
using CustomExtentions;

namespace TestingTheConsole {
    public class Player : Entity {
        public Player() : base('@', Console.WindowWidth/2, Console.WindowHeight/2) {
        }

        public override void Update(int deltaTimeMS) {
            if(Console.KeyAvailable) {
                switch (Console.ReadKey(true).Key) {
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.NumPad6:
                        this.position.x = MathExtended.Clamp(position.x+1, 0, Console.WindowWidth - 1);
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.NumPad4:
                        this.position.x = MathExtended.Clamp(position.x - 1, 0, Console.WindowWidth - 1);
                        break;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.NumPad8:
                        this.position.y = MathExtended.Clamp(position.y - 1, 0, Console.WindowHeight - 1);
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.NumPad2:
                        this.position.y = MathExtended.Clamp(position.y + 1, 0, Console.WindowHeight - 1);
                        break;
                }
            }
        }
    }
}
