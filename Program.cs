using System;
namespace Application;

class Program
{
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<VeterinaryClinic>()
            .AddSingleton<Zoo>()
            .BuildServiceProvider();

        var zoo = serviceProvider.GetService<Zoo>();

        zoo?.AddAnimal(new Rabbit(1, 7));
        zoo?.AddAnimal(new Tiger(2));
        zoo?.AddThing(new Table(101));
        zoo?.AddThing(new Computer(102));
    }
}

