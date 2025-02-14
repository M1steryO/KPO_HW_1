using src.Core.Animals;
using ZooManagementSystem.src.Infrastructure;

namespace src.Infrastructure
{
    public class VeterinaryClinic : IVeterinaryClinic
    {
        private Random _random;

        public VeterinaryClinic()
        {
            _random = new Random();
        }

        public bool CheckHealth(Animal animal)
        {
            if (animal is Herbo herbo)
            {
                // У травоядных здоровье зависит от уровня доброты
                if (herbo.Kindness > 5)
                {
                    return true; // Здорово, если доброта больше 5
                }
                else
                {
                    return _random.Next(0, 2) == 0; // Случайная проверка здоровья
                }
            }
            else if (animal is Predator)
            {
                // У хищников случайная проверка здоровья
                return _random.Next(0, 100) >= 30; // 30% вероятность того, что хищник здоров
            }
            else
            {
                // Для других животных или общих условий
                return _random.Next(0, 100) >= 50; // 50% шанс на здоровье
            }
        }
    }
}
