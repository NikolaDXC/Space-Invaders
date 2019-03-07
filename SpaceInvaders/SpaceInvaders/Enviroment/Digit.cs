using System;

namespace SpaceInvaders.Enviroment
{
    public static class Digit
    {
        private const int DIGIT_ROWS = 1;
        private const int SCORE_POSITION = 58;
        private const int LIVES_POSITION = 7;

        public static void PlotScore(int score) => Plot(score, 6, SCORE_POSITION);

        public static void UnplotLives() => Unplot(1, LIVES_POSITION);

        public static void PlotLives(int lives) => Plot(lives, 0, LIVES_POSITION);
        private static void Plot(int value, int format, int x)
        {
            string numberstr = value.ToString();
            int step = 0;

            Console.ForegroundColor = ConsoleColor.White;

            if(numberstr.Length < format)
            {
                for(int i = 0; i < format - numberstr.Length; i++)
                {
                    PlotDigit(0, step, x);
                    step += 2;
                }
            }
            foreach(char c in numberstr)
            {
                PlotDigit(int.Parse(c.ToString()), step, x);
                step += 2;
            }
        }
        private static void PlotDigit(int value, int step, int x)
        {
            for(int i = 0; i < DIGIT_ROWS; i++)
            {
                Console.SetCursorPosition(x + step, i + 1);
                Console.Write(value);
            }
        }
        private static void Unplot(int format, int x)
        {
            int step = 0;
            for(int i = 0; i < format; i++)
            {
                for(int j = 0; j < DIGIT_ROWS; j++)
                {
                    Console.SetCursorPosition(x + step, j + 1);
                }
                step += 2;
            }
        }
    }
}
