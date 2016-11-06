using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Sabre_Hasher
{
    class BinHash
    {
        public static char[] alpha = "abcdefghijklmnopqrstuvwxyz-_0123456789".ToCharArray();
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
        public static string Bruteforce(uint hash, uint length = 0)
        {
            string brute = "";
            uint brutedHash = 0;
            List<string> brutesTried = new List<string>();
            for (int a = 0; a < alpha.Length; a++)
            {
                brute = alpha[a].ToString();
                brutedHash = GetHash(brute);
                if (brutedHash == hash)
                {
                    return brute;
                }
                else
                {
                    for(int b = 0; b < alpha.Length; b++)
                    {
                        for(int c = 0; c < alpha.Length; c++)
                        {
                            brute = alpha[b].ToString() + alpha[c].ToString();
                            brutedHash = GetHash(brute);
                            if (brutedHash == hash)
                            {
                                return brute;
                            }
                            else
                            {
                                for (int d = 0; d < alpha.Length; d++)
                                {
                                    for (int e = 0; e < alpha.Length; e++)
                                    {
                                        for(int f = 0; f < alpha.Length; f++)
                                        {
                                            brute = alpha[d].ToString() + alpha[e].ToString() + alpha[f].ToString();
                                            brutedHash = GetHash(brute);
                                            if (brutedHash == hash)
                                            {
                                                return brute;
                                            }
                                            else
                                            {
                                                for (int g = 0; g < alpha.Length; g++)
                                                {
                                                    for (int h = 0; h < alpha.Length; h++)
                                                    {
                                                        for (int i = 0; i < alpha.Length; i++)
                                                        {
                                                            for(int j = 0; j < alpha.Length; j++)
                                                            {
                                                                brute = alpha[g].ToString() + alpha[h].ToString() + alpha[i].ToString() + alpha[j].ToString();
                                                                brutedHash = GetHash(brute);
                                                                if (brutedHash == hash)
                                                                {
                                                                    return brute;
                                                                }
                                                                else
                                                                {
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return brute;
        }
    }
}

