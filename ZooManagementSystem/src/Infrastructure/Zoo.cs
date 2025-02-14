using src.Core;
using src.Core.Animals;
using src.Infrastructure;
using ZooManagementSystem.src.Infrastructure;

public class Zoo
{
    private List<Animal> animals = new List<Animal>();
    private List<IInventory> inventory = new List<IInventory>();
    private readonly IVeterinaryClinic clinic;

    public Zoo(IVeterinaryClinic clinic)
    {
        this.clinic = clinic;
    }

    public void AddAnimal(Animal animal)
    {
        if (clinic.CheckHealth(animal))
        {
            animals.Add(animal);
            Console.WriteLine($"{animal.Name} принят в зоопарк.");
        }
        else
        {
            Console.WriteLine($"{animal.Name} не прошел проверку здоровья.");
        }
    }

    public void AddInventory(IInventory item)
    {
        inventory.Add(item);
        Console.WriteLine($"Инвентарь с номером {item.Number} добавлен.");
    }

    public void ShowAnimals()
    {
        foreach (var animal in animals)
        {
            Console.WriteLine($"{animal.Name} – потребляет {animal.Food} кг еды в день.");
        }
    }

    public void ShowContactZooAnimals()
    {
        foreach (var animal in animals)
        {
            if (animal is Herbo herbo && herbo.Kindness > 5)
            {
                Console.WriteLine($"{herbo.Name} может быть в контактном зоопарке (доброта: {herbo.Kindness})");
            }
        }
    }

    public void ShowInventory()
    {
        foreach (var item in inventory)
        {
            Console.WriteLine($"Инвентарный номер {item.Number}");
        }
    }

    public void AddAnimal(IAlive @object)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<IAlive> Animals => animals.AsReadOnly();

}