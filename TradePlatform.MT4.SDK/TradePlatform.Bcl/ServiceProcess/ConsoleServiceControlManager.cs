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
using System.Collections.Generic;
using System.Diagnostics;
using TradePlatform.Bcl.Diagnostics;
using TradePlatform.Bcl.Properties;

namespace TradePlatform.Bcl.ServiceProcess
{
    public class ConsoleServiceControlManager : ServiceControlManager
    {
        private static ConsoleLog defaultLog;

        private readonly string[] args;
        private readonly bool redirectLog;
        private readonly ConsoleLog log;

        public ConsoleServiceControlManager()
            : this(null, false, (ConsoleLog)null)
        { }

        public ConsoleServiceControlManager(string[] args)
            : this(args, false, (ConsoleLog)null)
        { }

        public ConsoleServiceControlManager(string[] args, bool redirectLog)
            : this(args, redirectLog, (ConsoleLog)null)
        { }

        public ConsoleServiceControlManager(string[] args, bool redirectLog, ConsoleLog log)
        {
            this.args = args;
            this.redirectLog = redirectLog;

            if (redirectLog)
            {
                this.log = (log ?? DefaultLog);
            }
        }

        public ConsoleServiceControlManager(string[] args, bool redirectLog, ConsoleLogStyle style)
        {
            this.args = args;
            this.redirectLog = redirectLog;

            if (redirectLog)
            {
                log = new ConsoleLog(ConsoleLogTarget.Out, style);
            }
        }

        protected override void OnRun(ICollection<Service> servicesToRun)
        {
            if (servicesToRun == null)
            {
                throw new ArgumentNullException(nameof(servicesToRun));
            }

            var sw = new Stopwatch();
            Console.WriteLine(Resources.ServiceControlManagerMessageStarting);
            sw.Start();

            foreach (var service in servicesToRun)
            {
                service.ManualStart(args);
            }

            sw.Stop();
            Console.WriteLine(Resources.ServiceControlManagerMessageStarted, sw.Elapsed.TotalSeconds);
            Console.WriteLine(Resources.ServiceControlManagerMessageStop);
            Console.ReadKey(true);
            Console.WriteLine(Resources.ServiceControlManagerMessageStopping);
            sw.Reset();
            sw.Start();

            foreach (var service in servicesToRun)
            {
                service.ManualStop();
            }

            sw.Stop();
            Console.WriteLine(Resources.ServiceControlManagerMessageStopped, sw.Elapsed.TotalSeconds);
            Console.WriteLine(Resources.ServiceControlManagerMessageExit);
            Console.ReadKey(true);
        }

        public override void LogMessage(Service service, string message, ServiceMessageType messageType)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            if (redirectLog)
            {
                log.WriteEntry(message, service.ServiceName, GetMessageType(messageType));
            }
            else
            {
                base.LogMessage(service, message, messageType);
            }
        }

        private static ConsoleLog DefaultLog
        {
            get 
            { 
                return (defaultLog ?? (defaultLog = new ConsoleLog(
                    ConsoleLogTarget.Error,
                    new ConsoleLogStyle(
                        new ConsoleLogEntryStyle(
                            ConsoleColor.Black,
                            ConsoleColor.Green,
                            ConsoleLogEntryStyle.DefaultMessageFormat),
                        new ConsoleLogEntryStyle(
                            ConsoleColor.Black,
                            ConsoleColor.Yellow,
                            ConsoleLogEntryStyle.DefaultMessageFormat),
                        new ConsoleLogEntryStyle(
                            ConsoleColor.Black,
                            ConsoleColor.Red,
                            ConsoleLogEntryStyle.DefaultMessageFormat)))));
            }
        }

        private static ConsoleLogEntryType GetMessageType(ServiceMessageType value)
        {
            switch (value)
            {
                case ServiceMessageType.None:
                case ServiceMessageType.Information:
                    return ConsoleLogEntryType.Information;
                    
                case ServiceMessageType.Warning:
                    return ConsoleLogEntryType.Warning;
                    
                case ServiceMessageType.Error:
                    return ConsoleLogEntryType.Error;

                default:
                    throw new ArgumentOutOfRangeException(nameof(value));
            }
        }
    }
}