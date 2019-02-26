using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Surveys.Library
{
    public static class Logger
    {
        public static void HttpRequestOutput(string RequestType, string API)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Incoming http " + RequestType + " request received: " + API);
        }
    }
}
