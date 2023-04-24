using System;


namespace R5T.T0179.Construction
{
    public class TypedStringA : TypedBase<string>, ITypedStringA
    {
        public TypedStringA(string value)
            : base(value)
        {
        }
    }
}
