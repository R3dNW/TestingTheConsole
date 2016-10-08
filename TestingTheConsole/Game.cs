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
        private Bounds gameInfoBounds;
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

            this.gameBounds = new Bounds(
                0,
                Bounds.ConsoleBounds.XMax, 
                0,
                Bounds.ConsoleBounds.YMax - 2);

            ConsoleExtended.DrawBounds(this.gameBounds);

            this.gameInfoBounds = new Bounds(
                this.gameBounds.XMin,
                this.gameBounds.XMax,
                this.gameBounds.YMax,
                this.gameBounds.YMax + 2);

            ConsoleExtended.DrawBounds(gameInfoBounds);

            this.entityBounds = new Bounds(
                this.gameBounds.XMin + 1,
                this.gameBounds.XMax - 1,
                this.gameBounds.YMin + 1,
                this.gameBounds.YMax - 1);

            Rand = new Random();

            this.player = new Player(this.entityBounds);
            this.enemies = new List<Entity>();

            for (int i = 0; i < 20; i++)
            {
                this.enemies.Add(
                    new Enemy((((float)Rand.NextDouble() * 0.5f) + 0.75f) * 12.5f, this.entityBounds, 125));
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

                Console.SetCursorPosition(2, Console.WindowHeight - 2);
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

            ConsoleExtended.DrawArray(GameOverText, Position.zero);

            ConsoleExtended.DrawBounds(this.gameInfoBounds);

            Console.SetCursorPosition(5, Console.WindowHeight - 2);
            if (this.score < 20)
            {
                Console.Write(string.Format("Pathetic... You scored {0} Points", this.score));
            }
            else if (this.score < 50)
            {
                Console.Write(string.Format("Just {0} Points... Really?", this.score));
            }
            else if (this.score < 100)
            {
                Console.Write(string.Format("Okay then: {0} Points. That makes you... average...", this.score));
            }
            else if (this.score < 250)
            {
                Console.Write(string.Format("Decent: {0} Points. Not great, but decent.", this.score));
            }
            else if (this.score < 500)
            {
                Console.Write(string.Format("Oohhh: {0} Points. Getting a bit good are we? Nope", this.score));
            }
            else if (this.score < 1000)
            {
                Console.Write(string.Format("*Slow Clap* {0} Points.", this.score));
            }
            else if (this.score < 2500)
            {
                Console.Write(string.Format("{0} Points? I could do better than that...", this.score));
            }
            else if (this.score < 5000)
            {
                Console.Write(string.Format("Somebody''s using a hacked client or something -- {0} Points", this.score));
            }
            else
            {
                Console.Write(string.Format("Okay You're definitely cheating -- {0} Points", this.score));
            }

            Console.SetCursorPosition(0, 0);
            Console.ReadLine(); // Makes the game wait for return to be pressed before restarting

            Instance = null;

            Instance = new Game();
            Instance.UpdateLoop();
        }

        private static string[] GameOverText = new string[] 
        {   "================================================================================",
            "=        GGGGGGG           AAAAAAAA      MMM          MMM  EEEEEEEEEEEEEEEE    =",
            "=      GGGGGGGGGGG        AAAAAAAAAA     MMMM        MMMM  EEEEEEEEEEEEEEEE    =",
            "=     GGGG     GGGG      AAA      AAA    MMMMM      MMMMM  EEE                 =",
            "=    GGG         GGG    AAA        AAA   MMMMMM    MMMMMM  EEE                 =",
            "=    GGG               AAA          AAA  MMM MMM  MMM MMM  EEEEEEEEEEEEE       =",
            "=    GGG      GGGGGGG  AAAAAAAAAAAAAAAA  MMM  MMMMMM  MMM  EEEEEEEEEEEEE       =",
            "=    GGG         GGG   AAAAAAAAAAAAAAAA  MMM   MMMM   MMM  EEE                 =",
            "=     GGGG     GGGG    AAA          AAA  MMM    MM    MMM  EEE                 =",
            "=      GGGGGGGGGGG     AAA          AAA  MMM          MMM  EEEEEEEEEEEEEEEE    =",
            "=        GGGGGGG       AAA          AAA  MMM          MMM  EEEEEEEEEEEEEEEE    =",
            "=                                                                              =",
            "=        OOOOOOOO      VVV          VVV  EEEEEEEEEEEEEEEE  RRRRRRRRRRRRR       =",
            "=      OOOOOOOOOOOO    VVV          VVV  EEEEEEEEEEEEEEEE  RRRRRRRRRRRRRR      =",
            "=     OOOO      OOOO    VVV        VVV   EEE               RRR         RRR     =",
            "=    OOO          OOO    VVV      VVV    EEE               RRR          RRR    =",
            "=    OOO          OOO    VVV      VVV    EEEEEEEEEEEEE     RRRRRRRRRRRRRR      =",
            "=    OOO          OOO     VVV    VVV     EEEEEEEEEEEEE     RRRRRRRRRRRRRR      =",
            "=    OOO          OOO      VVV  VVV      EEE               RRR         RRR     =",
            "=     OOOO      OOOO       VVV  VVV      EEE               RRR          RRR    =",
            "=      OOOOOOOOOOOO         VVVVVV       EEEEEEEEEEEEEEEE  RRR          RRR    =",
            "=        OOOOOOOO            VVVV        EEEEEEEEEEEEEEEE  RRR          RRR    =",
            "================================================================================",
        };
    }
}