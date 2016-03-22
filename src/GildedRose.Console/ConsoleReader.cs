using System;

namespace GildedRose.Console
{
    internal class ConsoleReader : IConsoleReader
    {
        public ConsoleKeyInfo ReadKey()
        {
            return System.Console.ReadKey();
        }
    }
}