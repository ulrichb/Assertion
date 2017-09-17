using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Assertions
{
    public static class AssertExtensions
    {
        [AssertionMethod]
        [ContractAnnotation("value:null=>halt; =>notnull")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T AssertNotNull<T>(
            [CanBeNull] this T value,
            [CallerFilePath] string callerFilePath = null,
            [CallerLineNumber] int callerLineNumber = 0)
            where T : class
        {
            // ReSharper disable ExplicitCallerInfoArgument
            Assert.IsNotNull(value, callerFilePath, callerLineNumber);
            // ReSharper restore ExplicitCallerInfoArgument
            return value;
        }

        [AssertionMethod]
        [ContractAnnotation("value:null=>halt")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T AssertNotNull<T>(
            this T? value,
            [CallerFilePath] string callerFilePath = null,
            [CallerLineNumber] int callerLineNumber = 0)
            where T : struct
        {
            // ReSharper disable ExplicitCallerInfoArgument
            Assert.IsNotNull(value, callerFilePath, callerLineNumber);
            // ReSharper restore ExplicitCallerInfoArgument
            return value.Value;
        }
    }
}
