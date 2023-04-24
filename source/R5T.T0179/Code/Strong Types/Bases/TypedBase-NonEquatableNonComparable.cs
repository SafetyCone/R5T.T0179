using System;
using System.Reflection.Emit;

namespace R5T.T0179.N001
{
    /// <summary>
    /// A base implementation for strong-type implementations with underlying types that are not <see cref="IEquatable{T}"/> not <see cref="IComparable{T}"/>.
    /// Instead, implementations must supply methods that perform these operations on their values.
    /// </summary>
    /// <typeparam name="T">The underlying type of the strong-type.</typeparam>
    public abstract class TypedBase<T> : ITyped<T>, IEquatable<ITyped<T>>, IComparable<ITyped<T>>
    {
        #region Static

        public static bool operator ==(TypedBase<T> a, TypedBase<T> b)
        {
            if (a is null)
            {
                var output = b is null;
                return output;
            }
            else
            {
                var output = a.Equals(b);
                return output;
            }
        }

        public static bool operator !=(TypedBase<T> a, TypedBase<T> b)
        {
            var output = !(a == b);
            return output;
        }

        /// <summary>
        /// Allow comparison directly to a string.
        /// </summary>
        public static bool operator ==(TypedBase<T> a, T b)
        {
            if (a is null)
            {
                var output = b is null;
                return output;
            }
            else
            {
                var output = a.Value.Equals(b);
                return output;
            }
        }

        /// <inheritdoc cref="operator ==(TypedBase{T}, T)"/>
        public static bool operator !=(TypedBase<T> a, T b)
        {
            var equals = a == b;

            var output = !equals;
            return output;
        }

        /// <summary>
        /// Allow implicit conversion to the underlying type, allowing a <see cref="ITyped{T}"/> to be just as good as a <typeparamref name="T"/> when required.
        /// </summary>
        public static implicit operator T(TypedBase<T> typedString)
        {
            if (typedString is null)
            {
                return default;
            }

            return typedString.Value;
        }

        #endregion


        public T Value { get; }


        // Protected constructor, in case sub-types want to limit access.
        protected TypedBase(T value)
        {
            this.Value = value;
        }

        protected abstract int Value_CompareTo(T a, T b);

        public int CompareTo(ITyped<T> other)
        {
            var output = this.Value_CompareTo(this.Value, other.Value);
            return output;
        }

        public bool Equals(ITyped<T> other)
        {
            var otherIsNull = other is null;
            if (otherIsNull)
            {
                // This instance can't be null (since we are calling a method on it), so if the other is null, then the two instance are not equal.
                return false;
            }

            // Required type-check for derived classes using the base class TypedString.Equals(TypedString).
            var typesAreSame = other.GetType().Equals(this.GetType());
            if (!typesAreSame)
            {
                return false;
            }

            var isEqual = this.Equals_ByValue(other);
            return isEqual;
        }

        protected abstract bool Value_Equals(T a, T b);

        protected virtual bool Equals_ByValue(ITyped<T> other)
        {
            if(this.Value is null)
            {
                var output = other.Value is null;
                return output;
            }

            var isEqual = this.Value_Equals(this.Value, other.Value);
            return isEqual;
        }

        public override bool Equals(object obj)
        {
            // No type-check required since performing GetType() on (obj as Typed<T>) will still return the actual original type, in the Equals(ITyped<T>) method.

            var objAsTyped = obj as ITyped<T>;

            var isEqual = this.Equals(objAsTyped);
            return isEqual;
        }

        public override int GetHashCode()
        {
            var hashCode = this.Value.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            var representation = this.Value.ToString();
            return representation;
        }
    }
}
