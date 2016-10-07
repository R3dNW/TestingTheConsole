using System;
using CustomExtentions;

namespace TestingTheConsole {
    public class Enemy : Entity {
        public float speed;

        public float maxSpeed = 100;

        public int timeBetweenMovesMS {
            get {
                return (int)(1000 / speed);
            }
        }

        int timeSinceLastMoveMS;

        int sleepTimeMS;

        public Enemy(float speed, float maxSpeed = 100) : base('#', Console.WindowWidth - 1, Game.rand.Next(0, Console.WindowHeight - 2)) {
            this.speed = speed;
            this.maxSpeed = maxSpeed;
            this.sleepTimeMS = Game.rand.Next(0, 4000);
            this.hidden = true;
        }

        public override void Update(int deltaTimeMS) {
            if (this.sleepTimeMS > 0) {
                this.sleepTimeMS -= deltaTimeMS;
                if (this.sleepTimeMS <= 0) {
                    this.timeSinceLastMoveMS += -this.sleepTimeMS;
                    this.sleepTimeMS = 0;
                }
                else {
                    return;
                }
            }
            else {
                this.timeSinceLastMoveMS += deltaTimeMS;
                hidden = false;
            }

            if (this.timeSinceLastMoveMS < this.timeBetweenMovesMS) {
                return;
            }

            this.timeSinceLastMoveMS -= this.timeBetweenMovesMS;

            this.position.x -= 1;

            if (this.position.x <= 0) {
                this.position.x = Console.WindowWidth - 1;
                this.position.y = Game.rand.Next(0, Console.WindowHeight - 2);

                this.sleepTimeMS = Game.rand.Next(500, 2500);

                hidden = true;

                speed = MathExtended.Clamp(speed * 1.25f, 0, maxSpeed);
            }

            Update(0);
        }
    }
}
