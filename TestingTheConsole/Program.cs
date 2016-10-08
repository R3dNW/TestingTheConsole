namespace TestingTheConsole
{
    /// <summary>
    /// The class that is used to start the program.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            new Game();

            Game.Instance.UpdateLoop();
        }
    }
}