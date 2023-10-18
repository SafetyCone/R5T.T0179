using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.T0179
{
    [FunctionalityMarker]
    public partial interface ITypedOperator : IFunctionalityMarker
    {
        public TOutput As<T, TInput, TOutput>(
            TInput input,
            Func<T, TOutput> outputConstructor)
            where TInput : ITyped<T>
            where TOutput : ITyped<T>
        {
            var output = outputConstructor(input.Value);
            return output;
        }

        public TOutput To<TInput, TOutput>(
            TInput input,
            Func<TInput, TOutput> outputConstructor)
            where TOutput : ITyped<TInput>
        {
            var output = outputConstructor(input);
            return output;
        }

        public IEnumerable<TOutput> To<TInput, TOutput>(
            IEnumerable<TInput> inputs,
            Func<TInput, TOutput> outputConstructor)
            where TOutput : ITyped<TInput>
        {
            var output = inputs
                .Select(input => this.To(input, outputConstructor))
                ;

            return output;
        }

        public bool Equals_ByValue<T>(
            ITyped<T> a,
            ITyped<T> b)
        {
            var output = a.Value.Equals(b.Value);
            return output;
        }

        public Func<TInput, TOutput> Get_Converter<T, TInput, TOutput>(
            Func<T, TOutput> outputConstructor)
            where TInput : ITyped<T>
            where TOutput : ITyped<T>
        {
            TOutput Internal(TInput input)
            {
                var output = outputConstructor(input.Value);
                return output;
            }

            return Internal;
        }


        public IEnumerable<T> Enumerate_Values<T>(IEnumerable<ITyped<T>> typeds)
        {
            var output = typeds
                .Select(x => x.Value)
                ;

            return output;
        }

        public T[] Get_Values<T>(IEnumerable<ITyped<T>> typeds)
        {
            var output = this.Enumerate_Values(typeds)
                .ToArray();

            return output;
        }

        public IEnumerable<string> ToStrings<T>(IEnumerable<ITyped<T>> typeds)
        {
            var output = typeds
                .Select(x => x.ToString())
                ;

            return output;
        }
    }
}
