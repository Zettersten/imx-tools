using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImxTools.Extensions;
public static class StringExtensions
{
    public static string TruncateBetween(this string valueToTruncate, int firstPartLength = 7, int lastPartLength = 4)
    {
        if (string.IsNullOrEmpty(valueToTruncate))
        {
            return string.Empty;
        }

        var count = valueToTruncate.Length;

        if (count < (firstPartLength + lastPartLength))
        {
            return valueToTruncate;
        }

        var firstPart = new string(valueToTruncate.Take(firstPartLength).ToArray());
        var lastPart = new string(valueToTruncate.TakeLast(lastPartLength).ToArray());

        return $"{firstPart}...{lastPart}";
    }
}