namespace SpaceInvaders
{
    using SpaceInvaders.Render;

    public class Program
    {
        private static void Main(string[] args)
        {
            var game = new GameConsole();
            game.Run();
        }
    }
}
