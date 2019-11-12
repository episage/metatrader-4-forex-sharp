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
using System.IO;

namespace TradePlatform.Bcl.Diagnostics
{
    /// <summary>
    /// Specifies the output destination for a <see cref="ConsoleLog"/>.
    /// </summary>
    /// <remarks>
    /// Specifies wheather to use the <see cref="Console.Out"/> (standard output
    /// stream), the <see cref="Console.Error"/> (standard error stream), or the
    /// <see cref="TextWriter.Null"/> (a null stream) when writing entries.
    /// </remarks>
    [Serializable]
    public enum ConsoleLogTarget
    {
        /// <summary>
        /// None.  Defaults to <see cref="TextWriter.Null"/>.
        /// </summary>
        None = 0,

        /// <summary>
        /// Standard output stream.  Defaults to <see cref="Console.Out"/>.
        /// </summary>
        Out,

        /// <summary>
        /// Standard error stream.  Defaults to <see cref="Console.Error"/>.
        /// </summary>
        Error
    }

    /// <summary>
    /// Extension methods for <see cref="ConsoleLogTarget"/>.
    /// </summary>
    public static class ConsoleStreamTypeExtensionMethods
    {
        /// <summary>
        /// Determines if a <see cref="ConsoleLogTarget"/> value is valid.
        /// </summary>
        /// <param name="value">The <see cref="ConsoleLogTarget"/> value to test.</param>
        /// <returns>true if the <see cref="ConsoleLogTarget"/> value is valid;
        /// otherwise false.</returns>
        public static bool IsValid(this ConsoleLogTarget value)
        {
            switch (value)
            {
                case ConsoleLogTarget.None:
                case ConsoleLogTarget.Out:
                case ConsoleLogTarget.Error:
                    return true;

                default:
                    return false;
            }
        }
    }
}