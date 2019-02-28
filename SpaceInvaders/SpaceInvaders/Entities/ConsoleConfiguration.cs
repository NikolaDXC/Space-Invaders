namespace SpaceInvaders.Entities
{
    using System;
    using System.Runtime.InteropServices;

    public class ConsoleConfiguration
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int MAXIMIZE = 3;

        public void Setup()
        {
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.CursorVisible = false;
            ShowWindow(GetConsoleWindow(), MAXIMIZE);
        }
        public void At(Position position, string str)
        {
            Console.SetCursorPosition(position.PositionX, position.PositionY);
            Console.Write(str);
        }
        public void SetColor(ConsoleColor color) => Console.ForegroundColor = color;

        public void AtColor(Position position, ConsoleColor color, string str)
        {
            SetColor(color);
            At(position, str);
        }
    }
}
