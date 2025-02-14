namespace src.Core.Animals
{
    public class Herbo : Animal
    {
        public int Kindness { get; set; }

        public Herbo(string name, int food, int kindness) : base(name, food)
        {
            Kindness = kindness;
        }
    }
}
