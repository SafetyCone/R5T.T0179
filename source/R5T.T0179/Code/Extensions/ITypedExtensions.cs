using System;
using System.Collections.Generic;


namespace R5T.T0179.Extensions
{
    public static class ITypedExtensions
    {
        public static TOutput As<T, TInput, TOutput>(
            this TInput input,
            Func<T, TOutput> outputConstrctor)
            where TInput : ITyped<T>
            where TOutput : ITyped<T>
        {
            var output = outputConstrctor(input.Value);
            return output;
        }

        public static IEnumerable<T> Get_Values<T>(this IEnumerable<ITyped<T>> typeds)
        {
            return Instances.TypedOperator.Get_Values(typeds);
        }

        public static IEnumerable<string> ToStrings<T>(this IEnumerable<ITyped<T>> typeds)
        {
            return Instances.TypedOperator.ToStrings(typeds);
        }
    }
}
