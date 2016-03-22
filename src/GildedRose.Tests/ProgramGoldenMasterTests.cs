using System;
using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ProgramGoldenMasterTests
    {
        private static void RunProgramMain(IConsoleReader consoleReader = null,
            IConsoleWriter consoleWriter = null,
            IQualityAdjuster qualityAdjuster = null)
        {
            Program.In = consoleReader ?? new ConsoleReader();
            Program.Out = consoleWriter ?? new ConsoleWriter();
            Program.QualityAdjuster = qualityAdjuster ?? new QualityAdjuster();
            Program.Main(new string[0]);
        }

        [Test]
        public void CheckItemName()
        {
            var testQualityAdjuster = new TestQualityAdjuster();

            RunProgramMain(qualityAdjuster: testQualityAdjuster);

            Assert.That(testQualityAdjuster.Items.Count, Is.EqualTo(6));
        }

        [Test]
        public void ReadKeyOnce()
        {
            var testConsoleReader = new TestConsoleReader();

            RunProgramMain(testConsoleReader);

            Assert.That(testConsoleReader.Counter, Is.EqualTo(1));
        }

        [Test]
        public void WelcomeMessageIsOmgHai()
        {
            var testConsoleWriter = new TestConsoleWriter();

            RunProgramMain(consoleWriter: testConsoleWriter);

            var welcomeMessage = "OMGHAI!";
            Assert.That(testConsoleWriter.Written.Last(), Is.EqualTo(welcomeMessage));
        }
    }

    public class TestQualityAdjuster : IQualityAdjuster
    {
        public List<Item> Items { get; } = new List<Item>();

        public void UpdateQuality(IList<Item> items)
        {
            Items.AddRange(items);
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