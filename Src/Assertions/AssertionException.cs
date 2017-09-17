using System;
using System.IO;
using JetBrains.Annotations;
#if !NETSTANDARD1_6
using System.Runtime.Serialization;

#endif

namespace Assertions
{
#if !NETSTANDARD1_6
    [Serializable]
#endif
    public class AssertionException : Exception
    {
        public AssertionException(string assertionText, [CanBeNull] string callerFilePath, int callerLineNumber) :
            base(FormatMessage(assertionText, callerFilePath, callerLineNumber))
        {
        }

#if !NETSTANDARD1_6
        protected AssertionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
#endif

        private static string FormatMessage(string assertionText, [CanBeNull] string callerFilePath, int callerLineNumber)
            => $"{assertionText} in {FormatCallerFilePath(callerFilePath)}:{callerLineNumber}.";

        [CanBeNull]
        private static string FormatCallerFilePath([CanBeNull] string callerFilePath)
        {
            var stripSourceLocation = Assert.Configuration.StripSourceLocation;

            if (callerFilePath == null || stripSourceLocation == null)
                return callerFilePath;

            return FindCommonAncestorPath(callerFilePath, stripSourceLocation);
        }

        private static readonly char[] DirectorySeparators = {Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar};

        private static string FindCommonAncestorPath(string callerFilePath, string stripSourceLocation)
        {
            int i = 0;
            int nextI;

            while (
                (nextI = callerFilePath.IndexOfAny(DirectorySeparators, i)) >= 0 &&
                stripSourceLocation.IndexOfAny(DirectorySeparators, i) == nextI &&
                string.Equals(callerFilePath.Substring(i, nextI - i), stripSourceLocation.Substring(i, nextI - i),
                    StringComparison.OrdinalIgnoreCase))
            {
                i = nextI + 1;
            }

            return callerFilePath.Substring(i, callerFilePath.Length - i);
        }
    }
}
