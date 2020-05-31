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
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace TradePlatform.Bcl
{
    [Serializable]
    public sealed class Binary : IEquatable<Binary>
    {
        private readonly byte[] value;
        [NonSerialized] private int hashCode;

        public Binary(byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            
            this.value = new byte[value.Length];
            Buffer.BlockCopy(value, 0, this.value, 0, value.Length);
        }

        public Binary(byte[] value, int startIndex, int length)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            if ((startIndex + length) > value.Length)
            {
                throw new ArgumentException();
            }

            this.value = new byte[length];
            Buffer.BlockCopy(value, startIndex, this.value, 0, length);
        }

        public int Length => value.Length;

        public byte this[int index]
        {
            get
            {
                if (index < 0 || index > value.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return value[index];
            }
        }

        public byte[] ToByteArray()
        {
            var buffer = new byte[value.Length];
            Buffer.BlockCopy(value, 0, buffer, 0, value.Length);
            return buffer;
        }

        public byte[] ToByteArray(int startIndex, int length)
        {
            if (startIndex < 0 || startIndex >= value.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            if ((startIndex + length) > value.Length)
            {
                throw new ArgumentException();
            }

            var buffer = new byte[length];
            Buffer.BlockCopy(value, startIndex, buffer, 0, length);
            return buffer;
        }

        public Stream GetStream()
        {
            return new MemoryStream(value, 0, value.Length, false, false);    
        }

        public Stream GetStream(int startIndex, int length)
        {
            if (startIndex < 0 || startIndex >= value.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            if ((startIndex + length) > value.Length)
            {
                throw new ArgumentException();
            }

            return new MemoryStream(value, startIndex, length, false, false);
        }

        public bool Equals(Binary other)
        {
            if (hashCode != 0 && other.hashCode != 0 && hashCode != other.hashCode)
            {
                return false;
            }

            return value.ValueEquals(other.value);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Binary);
        }

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        public override int GetHashCode()
        {
            return (hashCode != 0 ? hashCode : (hashCode = value.ComputeHashCode(value.Length)));
        }

        public override string ToString()
        {
            return string.Concat("0x", value.ToHexString());
        }
    }
}