using TestNinja.Mocking.Models;
using TestNinja.MockingExample.Interfaces;


namespace UnitTesting.Tests.MockingExample.FakeServices
{
    public class FakeFileReader : IFileReader
    {
        public string Read(string fileName)
        {
            return "{ \"Id\": 1, \"Title\": \"Test\", \"IsProcessed\": false }";
        }
    }
}
