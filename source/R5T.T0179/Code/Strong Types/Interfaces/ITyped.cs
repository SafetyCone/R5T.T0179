using System;

using R5T.T0142;
using R5T.T0178;


namespace R5T.T0179
{
    /// <summary>
    /// Interface for strongly-typed types.
    /// Strong-types wrap an underlying type.
    /// </summary>
    /// <typeparam name="T">The underlying type.</typeparam>
    [UtilityTypeMarker, TypeMarker, StrongTypeMarker]
    public interface ITyped<T> : IStrongTypeMarker
    {
        //#region Static

        ///// <summary>
        ///// Having this implicit conversion would be really nice, as it would avoid needing to add .Value everywhere.
        ///// But it is explicitly disallowed by C#.
        ///// This is probably why no one has thought of strong-types.
        ///// Some useful links:
        ///// <list type="bullet">
        ///// <item><see href="https://stackoverflow.com/a/2433220"/>https://stackoverflow.com/a/2433220</item> - Conversion from interface suggests a change in reference, which would not be true!
        ///// <item><see href="https://github.com/dotnet/csharplang/discussions/3464"/>GitHub Issue</item>
        ///// <item><see href="https://www.damirscorner.com/blog/posts/20180914-NoCustomConversionsForInterfacesInC.html"/>https://www.damirscorner.com/blog/posts/20180914-NoCustomConversionsForInterfacesInC.html</item>: as-of 20180914.
        ///// </list>
        ///// </summary>
        /////CS0552: 'ITyped<T>.implicit operator T(ITyped<T>)': user-defined conversions to or from an interface are not allowed
        //public static implicit operator T(ITyped<T> typed)
        //{
        //    return typed.Value;
        //}

        //// Not available until .NET 7.0.
        //public abstract static bool operator ==(ITyped<T> x, ITyped<T> y);

        //#endregion

        /// <summary>
        /// The value.
        /// </summary>
        T Value { get; }
    }
}
