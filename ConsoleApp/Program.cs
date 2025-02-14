using Microsoft.Extensions.DependencyInjection;
using src.Infrastructure;
using src.Core.Animals;
using src.Core.Inventory;
using ZooManagementSystem.src.Infrastructure;

public class Program
{
    private static ServiceProvider serviceProvider;

    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        serviceProvider = serviceCollection.BuildServiceProvider();

        Zoo zoo = serviceProvider.GetService<Zoo>();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить животное");
            Console.WriteLine("2. Добавить инвентарь");
            Console.WriteLine("3. Показать животных");
            Console.WriteLine("4. Показать животных для контактного зоопарка");
            Console.WriteLine("5. Показать инвентарь");
            Console.WriteLine("6. Выход");
            Console.Write("Выберите опцию: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddAnimalMenu(zoo);
                    break;
                case "2":
                    AddInventoryMenu(zoo);
                    break;
                case "3":
                    zoo.ShowAnimals();
                    WaitForKey();
                    break;
                case "4":
                    zoo.ShowContactZooAnimals();
                    WaitForKey();
                    break;
                case "5":
                    zoo.ShowInventory();
                    WaitForKey();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    WaitForKey();
                    break;
            }
        }
    }

    static void AddAnimalMenu(Zoo zoo)
    {
        Console.WriteLine("Добавление животного:");

        Console.Write("Введите имя животного: ");
        string name = Console.ReadLine();

        Console.Write("Введите тип животного (хищник/травоядное): ");
        string type = Console.ReadLine().ToLower();

        Console.Write("Введите количество еды, которое потребляет животное в день (кг): ");
        int food = int.Parse(Console.ReadLine());

        if (type == "травоядное")
        {
            Console.Write("Введите доброту животного (0-10): ");
            int kindness = int.Parse(Console.ReadLine());
            zoo.AddAnimal(new Herbo(name, food, kindness));
        }
        else if (type == "хищник")
        {
            zoo.AddAnimal(new Predator(name, food));
        }
        else
        {
            Console.WriteLine("Некорректный тип животного.");
        }
    }

    static void AddInventoryMenu(Zoo zoo)
    {
        Console.WriteLine("Добавление инвентаря:");

        Console.Write("Введите тип инвентаря (стол/компьютер): ");
        string type = Console.ReadLine().ToLower();

        Console.Write("Введите инвентаризационный номер: ");
        int number = int.Parse(Console.ReadLine());

        if (type == "стол")
        {
            zoo.AddInventory(new Table(number));
        }
        else if (type == "компьютер")
        {
            zoo.AddInventory(new Computer(number));
        }
        else
        {
            Console.WriteLine("Некорректный тип инвентаря.");
        }
    }

    static void WaitForKey()
    {
        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IVeterinaryClinic, VeterinaryClinic>();
        services.AddSingleton<Zoo>();
    }
}
