namespace SpaceInvaders.Entities
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
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool revert);

        private const int MAXIMIZE = 3;
        private const int SC_SIZE = 0xF000;
        private const int SC_RESTORE = 0xF120;
        private const int COMMAND = 0x0000000;

        public void Setup()
        {
            DisableResize();

            ShowWindow(GetConsoleWindow(), MAXIMIZE);

            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.CursorVisible = false;
        }
        public void DisableResize()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            DeleteMenu(sysMenu, SC_SIZE, COMMAND);
            DeleteMenu(sysMenu, SC_RESTORE, COMMAND);
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
