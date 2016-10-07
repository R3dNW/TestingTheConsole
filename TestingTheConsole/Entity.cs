using System;
using CustomExtentions;
using System.Linq;

namespace TestingTheConsole {
    public abstract class Entity {
        Position _position;

        public Position position {
            get {
                return _position;
            }
            protected set {
                if (value.x < 0 || value.x >= Console.WindowWidth || value.y < 0 || value.y >= Console.WindowWidth) {
                    throw new Exception("Position -- Cannot have a position outside of the console's coordinates");
                }

                _position = value;
            }
        }

        protected char symbol;

        protected bool hidden = false;

        public Entity(char symbol) {
            this.symbol = symbol;
            this.position = new Position();
        }

        public Entity(char symbol, Position position) {
            this.symbol = symbol;
            this.position = position;
        }

        public Entity(char symbol, int x, int y) {
            this.symbol = symbol;
            this.position = new Position(x, y);
        }

        protected Position lastDrawPosition;

        public virtual void Draw() {
            if (position == lastDrawPosition) {
                return;
            }

            if (lastDrawPosition != null) {
                Console.SetCursorPosition(lastDrawPosition.x, lastDrawPosition.y);
                Console.Write(' ');
            }

            if (hidden) {
                return;
            }

            lastDrawPosition = position.Clone();

            Console.SetCursorPosition(position.x, position.y);
            Console.Write(symbol);
        }

        public abstract void Update(int deltaTimeMS);
    }
}
