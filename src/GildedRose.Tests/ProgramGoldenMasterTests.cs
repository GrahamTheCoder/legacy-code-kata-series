﻿using System;
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
        public void WelcomeMessageIsOmgHai()
        {
            var testConsoleWriter = new TestConsoleWriter();
            Program.In = new TestConsoleReader();
            Program.Out = testConsoleWriter;
            Program.Main(new string[0]);

            string welcomeMessage = "OMGHAI!";

            Assert.That(testConsoleWriter.Written.Last(), Is.EqualTo(welcomeMessage));
        }

        [Test]
        public void ReadKeyOnce()
        {
            var testConsoleWriter = new TestConsoleWriter();
            var testConsoleReader = new TestConsoleReader();

            Program.In = testConsoleReader;
            Program.Out = testConsoleWriter;
            Program.Main(new string[0]);

            Assert.That(testConsoleReader.Counter, Is.EqualTo(1));
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

        public int Counter { get; private set; }

        public ConsoleKeyInfo ReadKey()
        {

            Counter++;
            return new ConsoleKeyInfo();
        }
    }
}
