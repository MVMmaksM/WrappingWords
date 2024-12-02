using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordWrapping.Core
{
    /// <summary>
    /// гласные
    /// </summary>
    public static class Vowels
    {
        private static readonly HashSet<int> _vowels = new HashSet<int>
            {
               1072, 1091, 1086, 1080, 1101, 1099, 1103, 1102, 1077, 1105, 1040, 1059,  1054, 1048, 1069, 1067, 1071, 1070, 1045, 1025
            };

        public static HashSet<int> GetVowels() => _vowels;
    }
}
