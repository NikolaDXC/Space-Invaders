namespace SpaceInvaders.Enviroment
{
    public class Delay
    {
        private readonly int _limit;
        private int _counter;
        public Delay(int limit)
        {
            _limit = limit;
            _counter = 0;
        }

        public bool IsCounting()
        {
            bool result = true;

            _counter++;
            if(_counter >= _limit)
            {
                result = false;
                _counter = 0;
            }
            return result;
        }
    }
}
