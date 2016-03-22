using System;

namespace GildedRose.Console
{
    internal interface IConsoleReader
    {
        ConsoleKeyInfo ReadKey();
    }
}