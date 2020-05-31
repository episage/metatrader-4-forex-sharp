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
using System.Diagnostics;
using System.IO;
using System.Text;

namespace TradePlatform.Bcl.Diagnostics
{
    /// <summary>
    /// Logs entries to the console.
    /// </summary>
    /// <remarks>
    /// This class is similar to the <see cref="EventLog"/> class, but writes
    /// entries to the console standard output and standard error streams instead.
    /// Note: Instances of this class are thread-safe and immutable.
    /// </remarks>
    public class ConsoleLog : IDisposable
    {
        private const int DefaultBufferSize = 256;

        /// <summary>
        /// A global lock across all instances of this class.
        /// This lock is used to synchronise access when setting and restoring the
        /// console colours.  The <see cref="Console"/> class itself is already
        /// thread-safe.
        /// </summary>
        private static readonly object consoleSyncRoot = new object();

        /// <summary>
        /// The default console log instance.
        /// </summary>
        /// This instance targets the console standard output stream and uses the
        /// current console's background and foreground colours.
        public static readonly ConsoleLog Default = new ConsoleLog();

        /// <summary>
        /// The console standard output or standard error stream writer.
        /// </summary>
        private readonly TextWriter writer;
        
        /// <summary>
        /// Settings used to control how the entries are displayed on the console,
        /// e.g., background and foreground colours and the message format string.
        /// </summary>
        private readonly ConsoleLogStyle defaultStyle;

        /// <summary>
        /// Initialize a new instance with default settings.
        /// </summary>
        public ConsoleLog()
            : this(ConsoleLogTarget.Out, Console.OutputEncoding, DefaultBufferSize, null)
        { }

        public ConsoleLog(ConsoleLogStyle defaultStyle)
            : this(ConsoleLogTarget.Out, Console.OutputEncoding, DefaultBufferSize, defaultStyle)
        { }
        
        public ConsoleLog(ConsoleLogTarget target)
            : this(target, Console.OutputEncoding, DefaultBufferSize, null)
        { }

        public ConsoleLog(ConsoleLogTarget target, ConsoleLogStyle defaultStyle)
            : this(target, Console.OutputEncoding, DefaultBufferSize, defaultStyle)
        { }

        public ConsoleLog(ConsoleLogTarget target, Encoding encoding)
            : this(target, encoding, DefaultBufferSize, null)
        { }

        public ConsoleLog(ConsoleLogTarget target, Encoding encoding, ConsoleLogStyle defaultStyle)
            : this(target, encoding, DefaultBufferSize, defaultStyle)
        { }

        public ConsoleLog(ConsoleLogTarget target, Encoding encoding, int bufferSize)
            : this(target, encoding, bufferSize, null)
        { } 

        public ConsoleLog(ConsoleLogTarget target, Encoding encoding, int bufferSize, ConsoleLogStyle defaultStyle)
        {
            if (!target.IsValid())
            {
                throw new ArgumentOutOfRangeException(nameof(target));
            }

            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            if (bufferSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize));
            }

            Stream tempStream = null;
            
            try
            {
                tempStream = OpenStandardStream(target, bufferSize);
                writer = new StreamWriter(tempStream, encoding, bufferSize);
                tempStream = null;
            }
            finally
            {
                tempStream?.Close();
            }

            this.defaultStyle = defaultStyle;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (consoleSyncRoot)
                {
                    writer.Close();
                }
            }
        }

        private static Stream OpenStandardStream(ConsoleLogTarget target, int bufferSize)
        {
            switch (target)
            {
                case ConsoleLogTarget.None:
                    return Stream.Null;

                case ConsoleLogTarget.Out:
                    return Console.OpenStandardOutput(bufferSize);

                case ConsoleLogTarget.Error:
                    return Console.OpenStandardError(bufferSize);

                default:
                    throw new ArgumentOutOfRangeException(nameof(target));
            }
        }

        /// <summary>
        /// Gets the <see cref="ConsoleLogStyle"/> for this instance.
        /// </summary>
        public virtual ConsoleLogStyle DefaultStyle => (defaultStyle ?? ConsoleLogStyle.Default);

        public void WriteEntry(ConsoleLogEntry entry)
        {
            WriteEntry(entry, null);
        }

        public void WriteEntry(ConsoleLogEntry entry, ConsoleLogEntryStyle style)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            WriteEntryCore(entry.Message, entry.Source, entry.EntryType, entry.CreatedTime, style);
        }

        /// <summary>
        /// Writes an entry to the console.
        /// </summary>
        public void WriteEntry(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            WriteEntryCore(message, null, ConsoleLogEntryType.Information, DateTimeOffset.Now, null);
        }

        /// <summary>
        /// Writes an entry to the console.
        /// </summary>
        public void WriteEntry(string message, string source)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));    
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            WriteEntryCore(message, source, ConsoleLogEntryType.Information, DateTimeOffset.Now, null);
        }

        /// <summary>
        /// Writes an entry to the console.
        /// </summary>
        public void WriteEntry(string message, string source, ConsoleLogEntryType type)
        {
            WriteEntry(message, source, type, DateTimeOffset.Now, null);
        }

        /// <summary>
        /// Writes an entry to the console.
        /// </summary>
        public virtual void WriteEntry(string message, string source, ConsoleLogEntryType type, DateTimeOffset createdTime)
        {
            WriteEntry(message, source, type, createdTime, null);
        }

        public void WriteEntry(string message, string source, ConsoleLogEntryType type, DateTimeOffset createdTime, ConsoleLogEntryStyle style)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (!type.IsValid())
            {
                throw new ArgumentOutOfRangeException(nameof(type));
            }

            WriteEntryCore(message, source, type, createdTime, style);
        }

        private void WriteEntryCore(string message, string source, ConsoleLogEntryType type, DateTimeOffset createdTime, ConsoleLogEntryStyle style)
        {
            if (style == null)
            {
                style = GetDefaultEntryStyle(type);
            }

            lock (consoleSyncRoot)
            {
                var originalBackgroundColor = Console.BackgroundColor;
                var originalForegroundColor = Console.ForegroundColor;

                try
                {
                    if (style.BackgroundColor != null)
                    {
                        Console.BackgroundColor = (ConsoleColor)style.BackgroundColor;
                    }

                    if (style.ForegroundColor != null)
                    {
                        Console.ForegroundColor = (ConsoleColor)style.ForegroundColor;
                    }

                    if (style.MessageFormat != null)
                    {
                        writer.WriteLine(style.MessageFormat, source, message, type, createdTime);
                    }
                    else
                    {
                        if (source != null)
                        {
                            writer.Write(source);
                            writer.Write(": ");
                        }

                        writer.WriteLine(message);
                    }

                    writer.Flush();
                }
                finally
                {
                    if (style.BackgroundColor != null)
                    {
                        Console.ForegroundColor = originalForegroundColor;
                    }

                    if (style.ForegroundColor != null)
                    {
                        Console.BackgroundColor = originalBackgroundColor;
                    }
                }
            }
        }

        private ConsoleLogEntryStyle GetDefaultEntryStyle(ConsoleLogEntryType type)
        {
            switch (type)
            {
                case ConsoleLogEntryType.Information:
                    return DefaultStyle.InformationStyle;

                case ConsoleLogEntryType.Warning:
                    return DefaultStyle.WarningStyle;

                case ConsoleLogEntryType.Error:
                    return DefaultStyle.ErrorStyle;
                    
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }
    }
}