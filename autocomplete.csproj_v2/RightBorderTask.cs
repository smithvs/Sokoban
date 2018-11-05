using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    public class RightBorderTask
    {
        /// <returns>
        /// Возвращает индекс правой границы. То есть индекс минимального элемента, который не начинается с prefix и большего prefix.
        /// Если такого нет, то возвращает items.Length
        /// </returns>
        /// <remarks>
        /// Функция должна быть НЕ рекурсивной
        /// и работать за O(log(items.Length)*L), где L — ограничение сверху на длину фразы
        /// </remarks>
        public static int GetRightBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            if (string.IsNullOrEmpty(prefix) || phrases.Count == 0)
                return right;

            while (left + 1 < right)
            {
                int middle = left + (right - left) / 2;
                if (string.Compare(prefix, phrases[middle], StringComparison.OrdinalIgnoreCase) > 0
                    || phrases[middle].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    left = middle + 1;
                else
                    right = middle;
            }

            if (left != phrases.Count
                && string.Compare(phrases[left], prefix, StringComparison.OrdinalIgnoreCase) > 0
                && !phrases[left].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return left;
            else
                return right;
        }
    }
}