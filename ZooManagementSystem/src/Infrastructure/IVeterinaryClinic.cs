using src.Core;
using src.Core.Animals;

namespace ZooManagementSystem.src.Infrastructure
{
    public interface IVeterinaryClinic
    {
        bool CheckHealth(Animal animal);
    }

}

