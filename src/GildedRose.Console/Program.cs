using System;
using System.Collections.Generic;
using System.IO;

namespace GildedRose.Console
{
    internal class Program
    {
        private IList<Item> Items;
        private readonly IQualityAdjuster m_QualityAdjuster;

        static Program()
        {
            In = new ConsoleReader();
            Out = new ConsoleWriter();
            QualityAdjuster = new QualityAdjuster();
        }

        public Program(IQualityAdjuster qualityAdjuster)
        {
            m_QualityAdjuster = qualityAdjuster;
        }

        internal static IConsoleReader In { get; set; }

        internal static IConsoleWriter Out { get; set; }

        internal static IQualityAdjuster QualityAdjuster { get; set; }

        internal static void Main(string[] args)
        {
            Out.WriteLine("OMGHAI!");

            var app = new Program(QualityAdjuster)
            {
                Items = new List<Item>
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
                }
            };

            app.m_QualityAdjuster.UpdateQuality(app.Items);

            In.ReadKey();
        }
    }

    public class Item : IEquatable<Item>
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public bool Equals(Item other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && Quality == other.Quality && SellIn == other.SellIn;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Item) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Quality;
                hashCode = (hashCode*397) ^ SellIn;
                return hashCode;
            }
        }
    }
}