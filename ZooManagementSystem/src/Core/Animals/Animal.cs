namespace src.Core.Animals
{
    public abstract class Animal : IAlive
    {
        public string Name { get; set; }
        public int Food { get; set; }

        public Animal(string name, int food)
        {
            Name = name;
            Food = food;
        }
    }
}
