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
            Program.Main(new string[0]);

            string welcomeMessage = "OMGHAI!";

            Assert.That(System.Console.Out.ToString(), Is.EqualTo(welcomeMessage));
            
        }
    }
}
