namespace AC
{
    public class GameFlag
    {
        private int _value = 0;
        public int Value{ get; set; }

        public GameFlag(int value = 0)
        {
            _value = value;
        }

        public void Add(int flag)
        {
            if (!Has(flag))
                _value |= flag;
        }
        public void Remove(int flag)
        {
            if (Has(flag))
                _value &= (~flag);
        }
        public bool Has(int flag)
        {
            return (_value & flag) != 0;
        }
    }
}

