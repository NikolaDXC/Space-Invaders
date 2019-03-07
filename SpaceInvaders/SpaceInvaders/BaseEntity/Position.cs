namespace SpaceInvaders.BaseEntity
{
    public class Position
    {
        public Position(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }

        public int PositionX { get; set; }

        public int PositionY { get; set; }
    }
}
