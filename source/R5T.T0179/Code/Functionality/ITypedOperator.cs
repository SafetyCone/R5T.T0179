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
            Func<T, TOutput> outputConstrctor)
            where TInput : ITyped<T>
            where TOutput : ITyped<T>
        {
            var output = outputConstrctor(input.Value);
            return output;
        }

        public bool Equals_ByValue<T>(
            ITyped<T> a,
            ITyped<T> b)
        {
            var output = a.Value.Equals(b.Value);
            return output;
        }

        public IEnumerable<T> Get_Values<T>(IEnumerable<ITyped<T>> typeds)
        {
            var output = typeds
                .Select(x => x.Value)
                ;

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
