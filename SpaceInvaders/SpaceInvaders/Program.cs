namespace SpaceInvaders
{
    using System;
    using System.Runtime.InteropServices;

    public class Program
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;
        private static void Main(string[] args)
        {
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(GetConsoleWindow(), MAXIMIZE);
            var game = new Game();
            game.Run();
        }
    }
}
