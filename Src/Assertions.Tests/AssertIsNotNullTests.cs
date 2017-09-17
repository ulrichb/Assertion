using System;
using FluentAssertions;
using NUnit.Framework;

namespace Assertions.Tests
{
    [TestFixture]
    public class AssertIsNotNullTests : AssertionsTestBase
    {
        [Test]
        public void WithNonNullValue()
        {
            Assert.IsNotNull(new object());
        }

        [Test]
        public void WithNullValue()
        {
            Action act = () => Assert.IsNotNull((object) null);

            act.ShouldThrow<AssertionException>().WithMessage("Object value expected to be non-null in AssertIsNotNullTests.cs:*.");
        }

        [Test]
        public void WithNullValue_AndStringType()
        {
            Action act = () => Assert.IsNotNull((string) null);

            act.ShouldThrow<AssertionException>().WithMessage("String value expected to be non-null in AssertIsNotNullTests.cs:*.");
        }

        [Test]
        public void WithNonNullValueTypeValue()
        {
            Assert.IsNotNull((int?) 42);
        }

        [Test]
        public void WithNullValueType()
        {
            Action act = () => Assert.IsNotNull((int?) null);

            act.ShouldThrow<AssertionException>().WithMessage("Int32 value expected to be non-null in AssertIsNotNullTests.cs:*.");
        }
    }
}
