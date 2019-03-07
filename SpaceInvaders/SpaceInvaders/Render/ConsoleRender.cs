namespace SpaceInvaders.Render
{
    using SpaceInvaders.GameObjects;
    using System;

    public class ConsoleRender
    {
        public ConsoleRender()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        protected void Draw(int x, int y, string sprite)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sprite);
        }

        protected void SetColor(ConsoleColor color) => Console.ForegroundColor = color;

        protected void AddHeader(int score, int lives)
        {
            SetColor(ConsoleColor.Gray);
            Draw(0, 1, "LIVES: ");
            Draw(50, 1, "SCORE: ");
            //At(105, 1, "LEVEL: ");

            Digit.PlotScore(score);

            Digit.PlotLives(lives);

            Console.SetCursorPosition(0, 0);
            SetColor(ConsoleColor.Red);

            for(int i = 0; i < 120; i++)
            {
                Console.Write("*");
            }

            Console.SetCursorPosition(0, 2);

            for(int i = 0; i < 120; i++)
            {
                Console.Write("*");
            }
        }

        protected void GetReady()
        {
            var delay = new Delay(100);

            while(delay.IsCounting())
            {
                Draw(55, 22, "GET READY");
                System.Threading.Thread.Sleep(15);
            }
            Draw(55, 22, "          ");
        }

        protected void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(55, 22);
            Console.WriteLine("G A M E O V E R!");
            Console.SetCursorPosition(0, 44);
        }

        protected void Complete()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(55, 22);
            Console.WriteLine("C O M P L E T E");
            Console.SetCursorPosition(0, 44);
        }
    }
}
