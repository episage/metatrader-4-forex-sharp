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
    public class ConsoleLogEntry
    {
        public ConsoleLogEntry(string source, string message)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            Source = source;
            Message = message;
            EntryType = ConsoleLogEntryType.Information;
            CreatedTime = DateTimeOffset.Now;
        }

        public ConsoleLogEntry(string source, string message, ConsoleLogEntryType entryType)
            : this(source, message, entryType, DateTimeOffset.Now)
        { }

        public ConsoleLogEntry(string source, string message, ConsoleLogEntryType entryType, DateTimeOffset createdTime)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (!entryType.IsValid())
            {
                throw new ArgumentOutOfRangeException(nameof(entryType));
            }

            Source = source;
            Message = message;
            EntryType = entryType;
            CreatedTime = createdTime;
        }

        public string Source { get; }

        public string Message { get; }

        public ConsoleLogEntryType EntryType { get; }

        public DateTimeOffset CreatedTime { get; }
    }
}