using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QVend.Ecr.Communication.TerminalMessages.Extensions
{
    public static class IEnumerableExtensions
    {
        public static int CalculateHashCode<T>(this IEnumerable<T> source, int start = 17)
        {
            if (source == null)
                return start;

            int result = start;
            
            foreach (var item in source)
            {
                if (item != null)
                {
                    result = (result * 23) + item.GetHashCode();
                }
            }

            return result;
        }

        public static int CalculateHashCode(this IEnumerable source, int start = 17)
        {
            if (source == null)
                return start;

            int result = start;

            foreach (var item in source)
            {
                result = (result * 23) + item.GetHashCode();
            }

            return result;
        }

        public static bool SequenceEqualNullSafe<T>(this IEnumerable<T> source, IEnumerable<T> value)
        {
            if (source == null && value == null)
            {
                return true;
            }

            if (source == null)
            {
                return false;
            }
            
            if (value == null)
            {
                return false;
            }

            return source.SequenceEqual(value);            
        }

        public static bool SequenceEqualNullSafe(this IEnumerable source, IEnumerable value)
        {
            if (source == null && value == null)
            {
                return true;
            }

            if (source == null)
            {
                return false;
            }

            if (value == null)
            {
                return false;
            }

            return source.Cast<object>().ToList().SequenceEqual(value.Cast<object>());
        }

        public static string Concatenate<T>(this IEnumerable<T> source, string separator, Expression<Func<T, string>> predicate)
        {
            return string.Join(separator, source);            
        }
    }
}
