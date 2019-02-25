namespace SpaceInvaders
{
    using System;

    public class Program
    {

        private static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.WriteLine($"{Console.LargestWindowWidth} {Console.LargestWindowHeight}");

            //Console.WriteLine(Console.WindowTop);
            //Console.SetBufferSize(Console.BufferWidth, Console.BufferHeight);
            var game = new Game();
            game.Run();
        }
    }
}
