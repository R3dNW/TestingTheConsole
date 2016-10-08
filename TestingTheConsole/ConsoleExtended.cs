namespace CustomExtentions
{
    using System;

    public static class ConsoleExtended
    {
        public static void DrawBounds(Bounds bounds, char symbol = '=')
        {
            Console.SetCursorPosition(bounds.XMin, bounds.YMin);
            Console.WriteLine(new string(symbol, bounds.Box.Width + 1));

            for (int yPos = bounds.YMin; yPos < bounds.YMax; yPos++)
            {
                DrawSymbol(symbol, bounds.XMin, yPos);
                DrawSymbol(symbol, bounds.XMax, yPos);
            }

            Console.SetCursorPosition(bounds.XMin, bounds.YMax);
            Console.WriteLine(new string(symbol, bounds.Box.Width + 1));
        }

        public static void SetCursorPosition(Position position)
        {
            Console.SetCursorPosition(position.X, position.Y);
        }

        public static void SetCursorPosition(int xPos, int yPos)
        {
            Console.SetCursorPosition(xPos, yPos);
        }

        public static void DrawSymbol(char symbol, Position position)
        {
            SetCursorPosition(position);
            Console.Write(symbol);
        }

        public static void DrawSymbol(char symbol, int xPos, int yPos)
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(symbol);
        }
    }
}