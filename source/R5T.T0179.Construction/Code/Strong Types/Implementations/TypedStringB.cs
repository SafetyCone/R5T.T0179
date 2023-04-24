using System;


namespace R5T.T0179.Construction
{
    public class TypedStringB : TypedBase<string>, ITypedStringB
    {
        public TypedStringB(string value)
            : base(value)
        {
        }
    }
}
