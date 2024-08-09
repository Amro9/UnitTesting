using TestNinja.Mocking.Models;

namespace TestNinja.MockingExample.Interfaces
{
    public interface IFileReader
    {
        string Read(string fileName);
    }
}