using System;
using FluentAssertions;
using NUnit.Framework;

namespace Assertions.Tests
{
    [TestFixture]
    public class AssertNotNullExtensionTests : AssertionsTestBase
    {
        [Test]
        public void WithNonNullValue()
        {
            var value = new object();

            var result = value.AssertNotNull();

            result.Should().BeSameAs(value);
        }

        [Test]
        public void WithNullValue()
        {
            Action act = () => ((object) null).AssertNotNull();

            act.ShouldThrow<AssertionException>().WithMessage("Object value expected to be non-null in AssertNotNullExtensionTests.cs:*.");
        }

        [Test]
        public void WithNullValue_AndStringType()
        {
            Action act = () => ((string) null).AssertNotNull();

            act.ShouldThrow<AssertionException>().WithMessage("String value expected to be non-null in AssertNotNullExtensionTests.cs:*.");
        }

        [Test]
        public void WithNonNullValueTypeValue()
        {
            var value = (int?) 42;

            int result = value.AssertNotNull();

            result.Should().Be(value);
        }

        [Test]
        public void WithNullValueType()
        {
            Action act = () => ((int?) null).AssertNotNull();

            act.ShouldThrow<AssertionException>().WithMessage("Int32 value expected to be non-null in AssertNotNullExtensionTests.cs:*.");
        }
    }
}
