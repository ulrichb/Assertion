using System;
using System.Runtime.CompilerServices;
using Assertions.Configuration;
using JetBrains.Annotations;

namespace Assertions
{
    public static class Assert
    {
        internal static AssertionConfiguration Configuration = AssertionConfiguration.Default;

        public static void ChangeConfiguration(Func<AssertionConfiguration, AssertionConfiguration> update)
        {
            Configuration = update(Configuration);
        }

        [AssertionMethod]
        [ContractAnnotation("condition:false=>halt")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsTrue(
            bool condition,
            string message = null,
            [CallerFilePath] string callerFilePath = null,
            [CallerLineNumber] int callerLineNumber = 0)
        {
            if (!condition)
            {
                throw new AssertionException(message ?? "Condition is false", callerFilePath, callerLineNumber);
            }
        }

        [AssertionMethod]
        [ContractAnnotation("value:null=>halt")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNull<T>(
            [CanBeNull] T value,
            [CallerFilePath] string callerFilePath = null,
            [CallerLineNumber] int callerLineNumber = 0)
            where T : class
        {
            if (value == null)
            {
                throw new AssertionException($"{typeof(T).Name} value expected to be non-null", callerFilePath, callerLineNumber);
            }
        }

        [AssertionMethod]
        [ContractAnnotation("value:null=>halt")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNull<T>(
            T? value,
            [CallerFilePath] string callerFilePath = null,
            [CallerLineNumber] int callerLineNumber = 0)
            where T : struct
        {
            if (!value.HasValue)
            {
                throw new AssertionException($"{typeof(T).Name} value expected to be non-null", callerFilePath, callerLineNumber);
            }
        }

        // TODO: AssertNonEmpty
        // TODO: AssertNonDefault
        // TODO: AssertSingle(OrDefault)
    }
}
