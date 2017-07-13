using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecPattern.Extensions
{
    public static class StringExtensions
    {
        public static bool NotNullOrBlank(this string str)
        {
            return !(str == null || string.IsNullOrWhiteSpace(str));
        }

        public static bool NullOrBlank(this string str)
        {
            return str == null || string.IsNullOrWhiteSpace(str);
        }

    }
}
