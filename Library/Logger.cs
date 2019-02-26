using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Surveys.Library
{
    public static class Logger
    {
        static Logger()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static void HttpRequestOutput(string RequestType, string API)
        {
            Console.WriteLine("Incoming http " + RequestType + " request received: " + API);
        }
    }
}
