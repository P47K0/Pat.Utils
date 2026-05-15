using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QVend.Ecr.Communication.TerminalMessages.Extensions
{
    public static class TypeExtensions
    {
        private static HashSet<Type> NumericTypes = new HashSet<Type>
        {
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(decimal)
        };

        public static Type GetNonNullableType(this Type source)
        {            
            Type underLyingType = Nullable.GetUnderlyingType(source);
            if (underLyingType != null)
            {
                return underLyingType;
            }

            return source;
        }

        public static bool IsNullable<T>(this T source)
        {
            if (source == null)
                return true;
            
            Type type = typeof(T);
            
            return IsNullable(type);                        
        }

        public static bool IsNullable(this Type source)
        {
            if (!source.IsValueType)
                return true; // ref-type

            if (Nullable.GetUnderlyingType(source) != null)
                return true; // Nullable<T>

            return false; // value-type
        }

        public static bool IsNumber(this Type source)
        {
            return NumericTypes.Contains(source) ||
               NumericTypes.Contains(Nullable.GetUnderlyingType(source));
        }

        /// <summary>
        /// Determines whether the specified type is a collection which implements the IEnumerable interface.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>True if the type is a collection which implements the IEnumerable interface; False otherwise.</returns>
        public static bool IsEnumerable(this Type type)
        {
            if (type == null)
            {
                return false;
            }

            bool result = type.GetInterface("IEnumerable") != null && type != typeof(string) && !type.IsArray;
            return result;
        }
    }
}
