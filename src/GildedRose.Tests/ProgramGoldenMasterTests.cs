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
            Program.In = consoleReader ?? new TestConsoleReader();
            Program.Out = consoleWriter ?? new TestConsoleWriter();
            Program.QualityAdjuster = qualityAdjuster ?? new QualityAdjuster();
            Program.Main(new string[0]);
        }

        [Test]
        public void CheckItemsEquivalent()
        {
            var testQualityAdjuster = new TestQualityAdjuster();

            var items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            RunProgramMain(qualityAdjuster: testQualityAdjuster);

            Assert.That(testQualityAdjuster.Items, Is.EqualTo(items));
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