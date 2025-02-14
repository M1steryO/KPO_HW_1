
namespace src.Core.Inventory
{
    public class Thing : IInventory
    {
        public int Number { get; set; }

        public Thing(int number)
        {
            Number = number;
        }
    }
}
