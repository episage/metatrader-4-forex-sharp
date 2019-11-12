//==========================================================================
// Hollard Base Class Library
// Author: Mark A. Nicholson (mailto:mark.anthony.nicholson@gmail.com)
//==========================================================================
// © The Hollard Insurance Company.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
// FITNESS FOR A PARTICULAR PURPOSE.
//==========================================================================

using System;

namespace TradePlatform.Bcl
{
    public static class ByteArrayExtensionMethods
    {
        public static string ToHexString(this byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var c = new char[value.Length << 1];
            
            for (var i = 0; i < value.Length; i++)
            {
                int b = (value[i] >> 4);
                c[i << 1] = (char)(55 + b + (((b - 10) >> 31) & -7));
                b = (value[i] & 0xF);
                c[(i << 1) + 1] = (char)(55 + b + (((b - 10) >> 31) & -7));
            }

            return new string(c);
        }

        public static bool ValueEquals(this byte[] value, byte[] other)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (other == null)
            {
                return false;
            }

            if (value == other)
            {
                return true;
            }

            if (value.Length != other.Length)
            {
                return false;
            }

            if (Environment.Is64BitProcess)
            {
                return ValueEquals64(value, other, value.Length);
            }

            return ValueEquals32(value, other, value.Length);
        }

        public static int ComputeHashCode(this byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return ComputeHashCodeCore(value, value.Length);
        }

        public static int ComputeHashCode(this byte[] value, int length)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (length < 0 || length > value.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            return ComputeHashCodeCore(value, length);
        }

        private static unsafe int ComputeHashCodeCore(this byte[] value, int length)
        {
            // Co-prime numbers.
            const int initial = 17;
            const int multiplier = 23;

            int hash = initial;

            fixed (byte* p = value)
            {
                int* p1 = (int*)p, p2 = (p1 + (length >> 2)/*shift-divide by 4*/);

                unchecked
                {
                    while (p1 != p2)
                    {
                        hash = ((hash * multiplier) + *p1++);
                    }

                    byte* p3 = (byte*)p1, p4 = (p + length);

                    if (p3 != p4)
                    {
                        int last = *p3++;

                        if (p3 != p4)
                        {
                            last |= (*p3++ << 8);

                            if (p3 != p4)
                            {
                                last |= (*p3 << 16);
                            }
                        }

                        hash = ((hash * multiplier) + last);
                    }
                }
            }

            return hash;
        }

        private static unsafe bool ValueEquals32(byte[] a, byte[] b, int length)
        {
            int i = 0;
            int l = (length >> 2)/*shift-divide by 4*/;
            int n = (l << 2)/*shift-multiply by 4*/;

            fixed (byte* p1 = a, p2 = b)
            {
                int* p3 = (int*)p1, p4 = (int*)p2;

                for (; i < l; i++)
                {
                    if (*(p3 + i) != *(p4 + i))
                    {
                        return false;
                    }
                }

                for (i = n; i < length; i++)
                {
                    if (*(p1 + i) != *(p2 + i))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static unsafe bool ValueEquals64(byte[] a, byte[] b, int length)
        {
            int i = 0;
            int l = (length >> 3)/*shift-divide by 8*/;
            int n = (l << 3)/*shift-multiply by 8*/;

            fixed (byte* p1 = a, p2 = b)
            {
                long* p3 = (long*)p1, p4 = (long*)p2;

                for (; i < l; i++)
                {
                    if (*(p3 + i) != *(p4 + i))
                    {
                        return false;
                    }
                }

                for (i = n; i < length; i++)
                {
                    if (*(p1 + i) != *(p2 + i))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
