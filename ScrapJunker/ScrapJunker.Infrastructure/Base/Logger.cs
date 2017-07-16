using ScrapJunker.Infrastructure.Core.Interface;
using System;

namespace ScrapJunker.Infrastructure.Base
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
