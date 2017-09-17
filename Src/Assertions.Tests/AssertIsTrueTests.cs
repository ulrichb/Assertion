using System;
using FluentAssertions;
using NUnit.Framework;

namespace Assertions.Tests
{
    [TestFixture]
    public class AssertIsTrueTests : AssertionsTestBase
    {
        [Test]
        public void IsTrue()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void IsTrue_WithFalseCondition()
        {
            Action act = () => Assert.IsTrue(false);

            act.ShouldThrow<AssertionException>().WithMessage("Condition is false in AssertIsTrueTests.cs:*.");
        }

        [Test]
        public void IsTrue_WithFalseCondition_AndCustomMessage()
        {
            Action act = () => Assert.IsTrue(false, "Something should be true");

            act.ShouldThrow<AssertionException>().WithMessage("Something should be true in AssertIsTrueTests.cs:*.");
        }
    }
}
