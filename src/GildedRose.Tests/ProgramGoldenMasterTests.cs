using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ProgramGoldenMasterTests
    {
        [Test]
        public void GoldenMaster()
        {
            var testConsoleWriter = new TestConsoleWriter();
            Program.In = new TestConsoleReader();
            Program.Out = testConsoleWriter;
            Program.Main(new string[0]);

            string welcomeMessage = "OMGHAI!";

            Assert.That(testConsoleWriter.Written.Last(), Is.EqualTo(welcomeMessage));
        }
    }

    public class TestConsoleWriter : IConsoleWriter
    {
        public List<string> Written { get; } = new List<string>();

        public void WriteLine(string value)
        {
            Written.Add(value);
        }
    }

    public class TestConsoleReader : IConsoleReader
    {
        public ConsoleKeyInfo ReadKey()
        {
            return new ConsoleKeyInfo();
        }
    }
}
