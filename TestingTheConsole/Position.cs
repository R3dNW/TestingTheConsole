using System;
using System.Linq;

namespace TestingTheConsole {
    public class Position {
        int _x = 0;
        public int x {
            get {
                return this._x;
            }
            set {
                /*if (value < 0 || value > Console.WindowWidth) {
                    throw new Exception("Position -- Cannot have a position outside of the console's coordinates");
                }*/
                this._x = value;
            }
        }


        int _y = 0;
        public int y {
            get {
                return this._y;
            }
            set {
                /*if (value < 0 || value > Console.WindowWidth) {
                    throw new Exception("Position -- Cannot have a position outside of the console's coordinates");
                }*/
                this._y = value;
            }
        }

        public Position() {
            this.x = 0;
            this.y = 0;
        }

        public Position(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public Position Clone() {
            return Clone(this);
        }

        public static Position Clone(Position original) {
            return new Position(original.x, original.y);
        }
    }
}
