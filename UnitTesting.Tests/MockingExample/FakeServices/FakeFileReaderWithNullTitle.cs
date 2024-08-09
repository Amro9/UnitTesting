using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.MockingExample.Interfaces;

namespace UnitTesting.Tests.MockingExample.FakeServices
{
    public class FakeFileReaderWithNullTitle : IFileReader
    {
        public string Read(string fileName)
        {
            return "{ \"Id\": 1, \"Title\": null, \"IsProcessed\": false }";
        }
    }
}
