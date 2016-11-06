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
        public static char[] alpha = "abcdefghijklmnopqrstuvwxyz-_0123456789/".ToCharArray();
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
        public static uint GetHash2(char[] s)
        {
            uint hash = 2166136261;
            for (int i = 0; i < s.Length; i++)
            {
                hash = hash ^ s[i];
                hash = hash * 16777619;
            }

            return hash;
        }
        public static string BruteforceLength(uint hashToBrute, int length)
        {
            char[] brute = new char[length];
            string bruteString = "";
            if(length == 1)
            {
                for(int a = 0; a < alpha.Length; a++)
                {
                    brute[0] = alpha[a];
                    if(GetHash2(brute) == hashToBrute)
                    {
                        foreach(char c in brute)
                        {
                            bruteString += c;
                        }
                        break;
                    }
                }
            }
            else if(length == 2)
            {
                for (int a = 0; a < alpha.Length; a++)
                {
                    for (int b = 0; b < alpha.Length; b++)
                    {
                        brute[0] = alpha[a];
                        brute[1] = alpha[b];
                        if (GetHash2(brute) == hashToBrute)
                        {
                            foreach (char c in brute)
                            {
                                bruteString += c;
                            }
                            break;
                        }
                    }
                }
            }
            else if (length == 3)
            {
                for (int a = 0; a < alpha.Length; a++)
                {
                    for (int b = 0; b < alpha.Length; b++)
                    {
                        for (int c = 0; c < alpha.Length; c++)
                        {
                            brute[0] = alpha[a];
                            brute[1] = alpha[b];
                            brute[2] = alpha[c];
                            if(GetHash2(brute) == hashToBrute)
                            {
                                foreach (char charr in brute)
                                {
                                    bruteString += charr;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            else if (length == 4)
            {
                for (int a = 0; a < alpha.Length; a++)
                {
                    for (int b = 0; b < alpha.Length; b++)
                    {
                        for (int c = 0; c < alpha.Length; c++)
                        {
                            for (int d = 0; d < alpha.Length; d++)
                            {
                                brute[0] = alpha[a];
                                brute[1] = alpha[b];
                                brute[2] = alpha[c];
                                brute[3] = alpha[d];
                                if (GetHash2(brute) == hashToBrute)
                                {
                                    foreach (char charr in brute)
                                    {
                                        bruteString += charr;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return bruteString;
        }
    }
}

