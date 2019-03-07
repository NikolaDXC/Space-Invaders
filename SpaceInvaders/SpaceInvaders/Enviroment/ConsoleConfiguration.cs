namespace SpaceInvaders.Enviroment
{
    using System;
    using System.Runtime.InteropServices;

    public class ConsoleConfiguration
    {
        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr menu, int position, int flags);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool revert);

        private const int SIZE = 0xF000;
        private const int MAXIMIZE = 0xF030;
        private const int COMMAND = 0x0000000;
        private const int WINDOW_WIDTH = 120;
        private const int WINDOW_HEIGHT = 45;
        protected int _drawX;
        protected int _drawY;

        public void Setup()
        {
            DisableResize();
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void DisableResize()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            DeleteMenu(sysMenu, SIZE, COMMAND);
            DeleteMenu(sysMenu, MAXIMIZE, COMMAND);
        }
        public void Draw(int x, int y, string sprite)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sprite);
        }
        public void SetColor(ConsoleColor color) => Console.ForegroundColor = color;

        public void DrawColor(ConsoleColor color, string str)
        {
            SetColor(color);
            Draw(_drawX, _drawY, str);
        }
    }
}
