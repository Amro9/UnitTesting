using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using TestNinja.MockingExample.Interfaces;
using UnitTesting.Tests.MockingExample.FakeServices;

namespace UnitTesting.Tests.MockingExample
{
    [TestClass]
    public class VideoServiceTest
    {

        [TestMethod]
        public void ReadVideoTitle_VideoTitleValueIsNull_ThrowsVideoParsingException()
        {
            FakeFileReaderWithNullTitle fr = new FakeFileReaderWithNullTitle();
            VideoService vs = new VideoService(fr);


            Assert.ThrowsException<NullReferenceException>(() => vs.ReadVideoTitle());

        }

        [TestMethod]
        public void ReadVideoTitle_VideoTitleValueIsNull_ThrowsVideoParsingException_Moq()
        {
            var fr = new Mock<IFileReader>();
            fr.Setup(x => x.Read("video.txt")).Returns("{ \"Id\": 1, \"Title\": null, \"IsProcessed\": false }");
            VideoService vs = new VideoService(fr.Object);


            Assert.ThrowsException<NullReferenceException>(() => vs.ReadVideoTitle());
        }

        [TestMethod]
        public void ReadVideoTitle_VideoTitleValueIsNotNull_ReturnsVideoTitle()
        {
            FakeFileReader fr = new FakeFileReader();

            VideoService vs = new VideoService(fr);

            string title = vs.ReadVideoTitle();


            Assert.IsInstanceOfType(title, typeof(string));
        }

        [TestMethod]
        public void GetIdsAsCSV_ListIsNull_ThrowsException()
        {
            List<string> ids = null;
            FakeFileReader fr = new FakeFileReader();
            VideoService vs = new VideoService(fr);

            Assert.ThrowsException<ArgumentNullException>(() => vs.GetIdsAsCsv(ids));

        }
        [TestMethod]
        public void GetIdsAsCSV_ListIsFull_ReturnsString()
        {
            List<string> ids = new List<string>() { "1","2","3"};
            FakeFileReader fr = new FakeFileReader();
            VideoService vs = new VideoService(fr);

            string csv = vs.GetIdsAsCsv(ids);

            StringAssert.StartsWith(csv, ids.First());
            StringAssert.EndsWith(csv, ids.Last());

        }

    }
}
