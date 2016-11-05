using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabre_Hasher
{
    class BinHash
    {
        public static uint GetHash(string s)
        {
            s = s.ToLower();
            uint hash = 2166136261;
            for (int i = 0; i < s.Length; i++)
            {
                hash = hash ^ s[i];
                hash = hash * 16777619;
            }

            return hash;
        }
    }
}

