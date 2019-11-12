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
    [Serializable]
    public class ConsoleLogEntryStyle
    {
        public static readonly ConsoleLogEntryStyle Default = new ConsoleLogEntryStyle();

        /// <summary>
        /// The default message format to use.
        /// </summary>
        /// <remarks>
        /// '{0}' represents the source.
        /// '{1}' represents the message.
        /// '{2}' represents the <see cref="ConsoleLogEntryType"/>.
        /// '{3}' represents the current local date/time.
        /// </remarks>
        public const string DefaultMessageFormat = "[{3:G}|{0}]\r\n{1}";

        private ConsoleLogEntryStyle()
        { }

        public ConsoleLogEntryStyle(ConsoleColor? backgroundColor, ConsoleColor? foregroundColor, string messageFormat)
        {
            if (backgroundColor != null && !((ConsoleColor)backgroundColor).IsValid())
            {
                throw new ArgumentOutOfRangeException(nameof(backgroundColor));
            }

            if (foregroundColor != null && !((ConsoleColor)foregroundColor).IsValid())
            {
                throw new ArgumentOutOfRangeException(nameof(foregroundColor));
            }

            BackgroundColor = backgroundColor;
            ForegroundColor = foregroundColor;
            MessageFormat = messageFormat;
        }

        public ConsoleColor? BackgroundColor { get; }

        public ConsoleColor? ForegroundColor { get; }

        public string MessageFormat { get; }
    }
}