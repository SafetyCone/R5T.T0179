using System;


namespace R5T.T0179
{
    public class TypedOperator : ITypedOperator
    {
        #region Infrastructure

        public static ITypedOperator Instance { get; } = new TypedOperator();


        private TypedOperator()
        {
        }

        #endregion
    }
}
