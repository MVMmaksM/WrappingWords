using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordWrapping.Core
{
    /// <summary>
    /// согласные
    /// </summary>
    public static class Consonants
    {
        private static readonly HashSet<int> _consonants = new HashSet<int>
        {
            1041, 1042, 1043, 1044, 1046, 1047, 1049, 1050, 1051, 1052, 1053, 1055, 1056, 1057, 1058, 1060, 1061, 1062, 1063, 1064, 1065,
            1073, 1074, 1075, 1076, 1078, 1079, 1081, 1082, 1083, 1084, 1085, 1087, 1088, 1089, 1090, 1092, 1093, 1094, 1095, 1096, 1097
        };

        public static HashSet<int> GetConsonants()=>_consonants;
    }
}
