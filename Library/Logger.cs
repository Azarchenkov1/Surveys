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

        public static void ExceptionOutput(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
        }

        public static void ExceptionMethod(string MethodName)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Exception occured in: " + MethodName);
        }

        public static void MessageOutput(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Message);
        }
    }
}
