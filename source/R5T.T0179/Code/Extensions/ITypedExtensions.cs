﻿using System;
using System.Collections.Generic;
using System.Linq;


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

        public static bool Equals_ByValue<T>(this ITyped<T> a,
            ITyped<T> b)
        {
            var output = Instances.TypedOperator.Equals_ByValue(a, b);
            return output;
        }

        public static IEnumerable<T> Enumerate_Values<T>(this IEnumerable<ITyped<T>> typeds)
        {
            return Instances.TypedOperator.Enumerate_Values(typeds);
        }

        public static T[] Get_Values<T>(this IEnumerable<ITyped<T>> typeds)
        {
            return Instances.TypedOperator.Get_Values(typeds);
        }

        public static IEnumerable<string> ToStrings<T>(this IEnumerable<ITyped<T>> typeds)
        {
            return Instances.TypedOperator.ToStrings(typeds);
        }

        public static IEnumerable<TTyped> To_Typeds<T, TTyped>(this IEnumerable<T> values,
            Func<T, TTyped> typedConstructor)
            where TTyped : ITyped<T>
        {
            var output = values
                .Select(value => typedConstructor(value))
                ;

            return output;
        }

        public static IEnumerable<TTyped> To<T, TTyped>(this IEnumerable<T> values,
            Func<T, TTyped> typedConstructor)
            where TTyped : ITyped<T>
        {
            return Instances.TypedOperator.To(
                values,
                typedConstructor);
        }
    }
}
