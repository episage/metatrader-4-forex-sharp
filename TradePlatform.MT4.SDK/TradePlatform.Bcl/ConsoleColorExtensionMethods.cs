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
    /// <summary>
    /// Extension methods for <see cref="ConsoleColor"/>.
    /// </summary>
    internal static class ConsoleColorExtensionMethods
    {
        /// <summary>
        /// Determine if a value is a valid <see cref="ConsoleColor"/>.
        /// </summary>
        /// <param name="value">The <see cref="ConsoleColor"/> value to test.</param>
        /// <returns>true if <paramref name="value"/> is a valid
        /// <see cref="ConsoleColor"/>; otherwise false.</returns>
        internal static bool IsValid(this ConsoleColor value)
        {
            switch (value)
            {
                case ConsoleColor.Black:
                case ConsoleColor.Blue:
                case ConsoleColor.Cyan:
                case ConsoleColor.DarkBlue:
                case ConsoleColor.DarkCyan:
                case ConsoleColor.DarkGray:
                case ConsoleColor.DarkGreen:
                case ConsoleColor.DarkMagenta:
                case ConsoleColor.DarkRed:
                case ConsoleColor.DarkYellow:
                case ConsoleColor.Gray:
                case ConsoleColor.Green:
                case ConsoleColor.Magenta:
                case ConsoleColor.Red:
                case ConsoleColor.White:
                case ConsoleColor.Yellow:
                    return true;

                default:
                    return false;
            }
        }
    }
}