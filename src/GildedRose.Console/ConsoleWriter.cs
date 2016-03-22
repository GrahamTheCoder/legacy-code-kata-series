namespace GildedRose.Console
{
    class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string value)
        {
            System.Console.Out.WriteLine(value);
        }
    }
}