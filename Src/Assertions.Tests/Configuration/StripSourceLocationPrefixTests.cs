using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable ExplicitCallerInfoArgument

namespace Assertions.Tests.Configuration
{
    [TestFixture]
    public class StripSourceLocationPrefixTests : AssertionsTestBase
    {
        [Test]
        public void WithParentDirectory()
        {
            Assert.ChangeConfiguration(x => x.WithStripSourceLocationPrefix(Path.GetDirectoryName(GetFullCallerFilePath())));

            Action act = () => Assert.IsNotNull((object) null);

            act.ShouldThrow<AssertionException>()
                .WithMessage("Object value expected to be non-null in Configuration\\StripSourceLocationPrefixTests.cs:*.");
        }

        [Test]
        public void WithSubDirectory()
        {
            var prefix = Path.Combine(Path.GetDirectoryName(GetFullCallerFilePath()).AssertNotNull(), "Sub", "Dir", "File.cs");
            Assert.ChangeConfiguration(x => x.WithStripSourceLocationPrefix(prefix));

            Action act = () => Assert.IsNotNull((object) null);

            act.ShouldThrow<AssertionException>()
                .WithMessage("Object value expected to be non-null in StripSourceLocationPrefixTests.cs:*.");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("INVALID")]
        public void WithInvalidPrefixStrings_ReturnsFullPath(string prefix)
        {
            Assert.ChangeConfiguration(x => x.WithStripSourceLocationPrefix(prefix));

            Action act = () => Assert.IsNotNull((object) null);

            act.ShouldThrow<AssertionException>()
                .WithMessage($"Object value expected to be non-null in {GetFullCallerFilePath()}:*.");
        }

        [Test]
        public void WithDifferentCasingInPaths()
        {
            Assert.ChangeConfiguration(x => x.WithStripSourceLocationPrefix(GetFullCallerFilePath().ToUpper()));

            Action act = () => Assert.IsNotNull((object) null);

            act.ShouldThrow<AssertionException>()
                .WithMessage("Object value expected to be non-null in StripSourceLocationPrefixTests.cs:*.");
        }
    }
}
