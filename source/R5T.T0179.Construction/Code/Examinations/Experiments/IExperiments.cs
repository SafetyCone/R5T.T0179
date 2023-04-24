using System;

using R5T.T0141;


namespace R5T.T0179.Construction
{
    [ExperimentsMarker]
    public partial interface IExperiments : IExperimentsMarker
    {
        public void EqualsMethod_OnInstanceAsInterface()
        {
            ITypedStringA a = new TypedStringA("A");
            ITypedStringA b = a;

            // This uses Object.Equals(), which is overridden by Typed<T>, so that this calls Typed<T>.Equals().
            var equals = a.Equals(b);

            Console.WriteLine(equals);
        }

        public void EqualityOperator_OnInstanceAsInterface()
        {
            ITypedStringA a = new TypedStringA("A");
            ITypedStringA b = a;

            // This uses Object.op_Equality, not Typed<T>.op_Equality.
            var equals = a == b;

            Console.WriteLine(equals);
        }

        public void EqualityOperator_SameInstance()
        {
            var a = new TypedStringA("A");
            var b = a;

            var equals = a == b;

            Console.WriteLine(equals);
        }
    }
}
