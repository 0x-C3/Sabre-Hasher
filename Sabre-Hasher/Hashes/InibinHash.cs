using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabre_Hasher
{
    class InibinHash
    {
        public static UInt32 GetHash(string section, string name)
            {
                UInt32 hash = 0;

                foreach (var c in section.ToLower())
                {
                    hash = c + 65599 * hash;
                }

                hash = (65599 * hash + 42);

                foreach (var c in name.ToLower())
                {
                    hash = c + 65599 * hash;
                }

                return hash;
            }
    }
}
