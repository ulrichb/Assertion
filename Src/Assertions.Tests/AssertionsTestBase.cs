using System.Runtime.CompilerServices;
using Assertions.Configuration;
using NUnit.Framework;

namespace Assertions.Tests
{
    public abstract class AssertionsTestBase
    {
        [SetUp]
        public void SetUp()
        {
            Assert.ChangeConfiguration(x => x.WithStripSourceLocationPrefix());
        }

        [TearDown]
        public void TearDown()
        {
            Assert.ChangeConfiguration(x => AssertionConfiguration.Default);
        }

        protected string GetFullCallerFilePath([CallerFilePath] string callerFilePath = null) => callerFilePath.AssertNotNull();
    }
}
