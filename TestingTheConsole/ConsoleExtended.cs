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

            Console.SetCursorPosition(0, 0);
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
            ConsoleExtended.SetCursorPosition(position);
            Console.Write(symbol);
        }

        public static void DrawSymbol(char symbol, int xPos, int yPos)
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(symbol);
        }

        public static void DrawArray<T>(T[] array, Position startPosition)
        {
            int yPos = startPosition.Y;

            foreach (T element in array)
            {
                Console.SetCursorPosition(startPosition.X, yPos);
                Console.Write(element.ToString());
                yPos++;
            }

            Console.SetCursorPosition(0, 0);
        }
    }
}