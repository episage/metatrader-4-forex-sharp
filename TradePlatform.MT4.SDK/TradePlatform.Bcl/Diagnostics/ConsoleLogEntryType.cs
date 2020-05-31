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

namespace TradePlatform.Bcl.Diagnostics
{
    /// <summary>
    /// Specifies the entry type for a <see cref="ConsoleLog"/> entry.
    /// </summary>
    [Serializable]
    public enum ConsoleLogEntryType
    {
        None = 0,

        /// <summary>
        /// An information entry.  This indicates a significant, successful
        /// operation.
        /// </summary>
        Information,

        /// <summary>
        /// A warning entry.  This indicates a problem that is not immediately
        /// significant, but that may signify conditions that could cause future
        /// problems.
        /// </summary>
        Warning,

        /// <summary>
        /// An error entry.  This indicates a significant problem the user should
        /// know about; usually a loss of functionality or data.
        /// </summary>
        Error
    }

    /// <summary>
    /// Extension methods for <see cref="ConsoleLogEntryType"/>.
    /// </summary>
    public static class ConsoleLogEntryTypeExtensionMethods
    {
        /// <summary>
        /// Determines if a <see cref="ConsoleLogEntryType"/> value is valid.
        /// </summary>
        /// <param name="value">The <see cref="ConsoleLogEntryType"/> value to test.</param>
        /// <returns>true if the <see cref="ConsoleLogEntryType"/> value is valid;
        /// otherwise false.</returns>
        public static bool IsValid(this ConsoleLogEntryType value)
        {
            switch (value)
            {
                case ConsoleLogEntryType.None:
                case ConsoleLogEntryType.Information:
                case ConsoleLogEntryType.Warning:
                case ConsoleLogEntryType.Error:
                    return true;

                default:
                    return false;
            }
        }
    }
}