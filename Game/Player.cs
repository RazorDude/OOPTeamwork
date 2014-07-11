namespace Game
{
    using System;

    class Player : Hero
    {
        private Inventory inventory = new Inventory();

        public Player()
            : base()
        {

        }
        public Player(string name, byte age, Gender gender, Inventory inventory)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            this.inventory = inventory;
        }

        public string Name
        {
            get
            {
                return this.Name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The player name can't be empty!");
                }
                else if (value.Length < 3)
                {
                    throw new ArgumentException("The player name must be a least 3 symbols");
                }
                else
                {
                    this.Name = value;
                }
            }
        }

        public byte Age
        {
            get
            {
                return this.Age;
            }
            set
            {
                if (value < 0 || value > 127)
                {
                    throw new ArgumentOutOfRangeException("Incorrect Player Age");
                }
                else
                {
                    this.Age = value;
                }
            }
        }
        public Enum Gender { get; set; }
    }
}

