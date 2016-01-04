using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace ACMA.TestUnit
{
    [TestFixture]
    public class UnitTest
    {
        [TestFixtureSetUp]
        public void GlobalVariables() { 

        }

        [Test]
        public void TestSomaNumeros()
        {
            Program program = new Program();
            int result = program.TesteSomaNumeros(3, 3);
            Assert.AreEqual(6, result);
            // 4. Runs Once; This is your Test!
        }



        [TestFixtureTearDown]
        public void RunOnceAfterAll()
        {
            // 5. Runs Once After All of The Aformentioned Methods
            // Dispose all Mocks and Global Objects
        }
    }
}
