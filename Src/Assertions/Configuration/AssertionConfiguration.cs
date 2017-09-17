using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Assertions.Configuration
{
    public class AssertionConfiguration
    {
        private AssertionConfiguration([CanBeNull] string stripSourceLocation)
        {
            StripSourceLocation = stripSourceLocation;
        }

        [CanBeNull]
        internal string StripSourceLocation { get; }

        public static AssertionConfiguration Default => new AssertionConfiguration(
            stripSourceLocation: null);

        public AssertionConfiguration WithStripSourceLocationPrefix([CallerFilePath] string callerFilePath = null)
        {
            return new AssertionConfiguration(stripSourceLocation: callerFilePath);
        }
    }
}
