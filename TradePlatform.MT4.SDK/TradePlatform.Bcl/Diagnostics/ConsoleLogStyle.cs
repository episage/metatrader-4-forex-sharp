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
    /// Specifies settings for the <see cref="ConsoleLog"/> class.
    /// </summary>
    /// <remarks>
    /// Note: Instances of this class are thread-safe and immutable.
    /// </remarks>
    [Serializable]
    public class ConsoleLogStyle
    {
        public static readonly ConsoleLogStyle Default = new ConsoleLogStyle();

        private readonly ConsoleLogEntryStyle informationStyle;
        private readonly ConsoleLogEntryStyle warningStyle;
        private readonly ConsoleLogEntryStyle errorStyle;

        private ConsoleLogStyle()
        { }

        public ConsoleLogStyle(ConsoleLogEntryStyle entryStyle)
        {
            informationStyle = entryStyle;
            warningStyle = entryStyle;
            errorStyle = entryStyle;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ConsoleLogStyle"/> class,
        /// for the specified settings.
        /// </summary>
        public ConsoleLogStyle(
            ConsoleLogEntryStyle informationStyle,
            ConsoleLogEntryStyle warningStyle,
            ConsoleLogEntryStyle errorStyle)
        {
            this.informationStyle = informationStyle;
            this.warningStyle = warningStyle;
            this.errorStyle = errorStyle;
        }
        
        /// <summary>
        /// The <see cref="ConsoleLogTarget"/> to use for
        /// <see cref="ConsoleLogEntryType.Information"/>.
        /// </summary>
        /// <remarks>
        /// By default, <see cref="ConsoleLogEntryType.Information"/> entries are
        /// written to <see cref="Console.Out"/> (standard target stream).
        /// </remarks>
        public ConsoleLogEntryStyle InformationStyle => (informationStyle ?? ConsoleLogEntryStyle.Default);

        /// <summary>
        /// The <see cref="ConsoleLogTarget"/> to use for
        /// <see cref="ConsoleLogEntryType.Warning"/>.
        /// </summary>
        /// <remarks>
        /// By default, <see cref="ConsoleLogEntryType.Warning"/> entries are
        /// written to <see cref="Console.Error"/> (standard error stream).
        /// </remarks>
        public ConsoleLogEntryStyle WarningStyle => (warningStyle ?? ConsoleLogEntryStyle.Default);

        /// <summary>
        /// The <see cref="ConsoleLogTarget"/> to use for
        /// <see cref="ConsoleLogEntryType.Error"/>.
        /// </summary>
        /// <remarks>
        /// By default, <see cref="ConsoleLogEntryType.Error"/> entries are
        /// written to <see cref="Console.Error"/> (standard error stream).
        /// </remarks>
        public ConsoleLogEntryStyle ErrorStyle => (errorStyle ?? ConsoleLogEntryStyle.Default);
    }
}