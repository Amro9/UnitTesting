using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.MockingExample.CustomExceptions
{
    public class VideoTitleIsNullException: Exception
    {
        public VideoTitleIsNullException() { }

        public VideoTitleIsNullException(string message)
            : base(message) { }

        public VideoTitleIsNullException(string message, Exception inner)
            : base(message, inner) { }
    }
}
