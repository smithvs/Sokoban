using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Autocomplete
{
    /* internal class AutocompleteTask
     {
         /// <returns>
         /// Возвращает первую фразу словаря, начинающуюся с prefix.
         /// </returns>
         /// <remarks>
         /// Эта функция уже реализована, она заработает, 
         /// как только вы выполните задачу в файле LeftBorderTask
         /// </remarks>
         public static string FindFirstByPrefix(IReadOnlyList<string> phrases, string prefix)
         {
             var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
             if (index < phrases.Count && phrases[index].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                 return phrases[index];

             return null;
         }

         /// <returns>
         /// Возвращает первые в лексикографическом порядке count (или меньше, если их меньше count) 
         /// элементов словаря, начинающихся с prefix.
         /// </returns>
         /// <remarks>Эта функция должна работать за O(log(n) + count)</remarks>
         public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
         {
             // тут стоит использовать написанный ранее класс LeftBorderTask
             return null;
         }

         /// <returns>
         /// Возвращает количество фраз, начинающихся с заданного префикса
         /// </returns>
         public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
         {
             // тут стоит использовать написанные ранее классы LeftBorderTask и RightBorderTask
             return -1;
         }
     }

     */

    internal class AutocompleteTask
    {
        /// <returns>
        /// Возвращает первую фразу словаря, начинающуюся с prefix.
        /// </returns>
        /// <remarks>
        /// Эта функция уже реализована, она заработает, 
        /// как только вы выполните задачу в файле LeftBorderTask
        /// </remarks>
        public static string FindFirstByPrefix(IReadOnlyList<string> phrases, string prefix)
        {

            var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            if (index < phrases.Count && phrases[index].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return phrases[index];
            else
                return null;
        }

        /// <returns>
        /// Возвращает первые в лексикографическом порядке count (или меньше, если их меньше count) 
        /// элементов словаря, начинающихся с prefix.
        /// </returns>
        /// <remarks>Эта функция должна работать за O(log(n) + count)</remarks>
        public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
        {
            var begin = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            var end = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, phrases.Count) - 1;
            List<string> goodPhrases = new List<string>();
            for (int i = begin; i <= end && i < begin + count; i++)
            {
                goodPhrases.Add(phrases[i]);
            }
            return goodPhrases.ToArray();
        }

        /// <returns>
        /// Возвращает количество фраз, начинающихся с заданного префикса
        /// </returns>
        public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
        {

            return RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, phrases.Count)
                   - LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) - 1;
        }
    }

    [TestFixture]
    public class AutocompleteTests
    {
        [Test]
        public void TopByPrefix_IsEmpty_WhenNoPhrases()
        {
            var phrases = new List<string>() { "ab", "ab", "ab", "ab" };
            IReadOnlyList<string> read = phrases; 
            Assert.AreEqual(RightBorderTask.GetRightBorderIndex(read, "aa", -1, 4),2);
            //CollectionAssert.IsEmpty(actualTopWords);
        }

        // ...

        [Test]
        public void CountByPrefix_IsTotalCount_WhenEmptyPrefix()
        {
            // ...
            //Assert.AreEqual(expectedCount, actualCount);
        }

        // ...
    }
}
