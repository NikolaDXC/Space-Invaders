namespace SpaceInvaders.Entity
{
    using System;

    public class SpaceShip
    {
        public void GameObject()
        {
            string[] alien = new string[5]
            {
               @"  /\  ",
                "  ||  ",
               @" /||\ ",
                "|:||:|",
               @"|/||\|"
            };
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    //Console.SetCursorPosition(57 + j, 25 + i);
                    Console.Write(alien[i][j]);
                }
            }

        }
    }
}
