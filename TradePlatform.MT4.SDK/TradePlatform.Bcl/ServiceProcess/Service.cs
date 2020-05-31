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
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using TradePlatform.Bcl.Properties;

namespace TradePlatform.Bcl.ServiceProcess
{
    /// <summary>
    /// Provides a base class for a Windows Service.
    /// </summary>
    /// <remarks>
    /// Set the <see cref="Service.EventLogName"/>,
    /// <see cref="Service.EventLogSource"/> and <see cref="Service.ServiceName"/>
    /// properties via the designer of a derived class.  This class extends the
    /// <see cref="ServiceBase"/> class to implement the
    /// <see cref="ServiceBase.OnStart"/> method asynchronously (as required by the
    /// Windows Service Control Manager).  This class implements a customisable
    /// event log name and source on the local machine and ties this to the auto log
    /// feature (set <see cref="Service.AutoLog"/> property to true).  By default,
    /// the class logs to the Windows 'Application' event log on the local machine,
    /// using the <see cref="Service.ServiceName"/> property value as the source.
    /// This class supports running one or more services in user-interactive mode
    /// (as a console application).  This is useful for debugging.  In user-
    /// interactive mode, information messages are written to the standard output
    /// console stream (<see cref="Console.Out"/>) and warning and error messages
    /// are written to the standard error console stream (see
    /// <see cref="Console.Error"/>).  This class replaces the
    /// <see cref="ServiceBase.Run(ServiceBase)"/> and
    /// <see cref="ServiceBase.Run(ServiceBase[])"/> methods, with overloads that
    /// allow the service to be run in user-interactive mode (as a console
    /// application) and that trap, log and correctly terminate the service
    /// process on unhandled exceptions.  The class automatically detects if it is
    /// running in user-interactive mode.  No event logging occurs in user-
    /// interactive mode -- all messages are output to the console standard output
    /// and error streams.
    /// </remarks>
    public class Service : ServiceBase
    {
	   private readonly List<ServiceThread> _threads;
	   private ServiceControlManager _manager;
	   private string _instrumentationKey;
	   private readonly TelemetryClient _telemetryClient = new TelemetryClient();
	   private bool _disposed;

	   protected Service()
	   { }

	   protected Service(ServiceThread thread)
	   {
		  thread.Service = this;
		  _threads = new List<ServiceThread>(1) { thread };
	   }

	   /// <summary>
	   /// Creates a new instance of the <see cref="Service"/> class.
	   /// </summary>
	   /// <param name="threads"></param>
	   protected Service(IEnumerable<ServiceThread> threads)
	   {
		  this._threads = new List<ServiceThread>(threads);

		  foreach (var thread in this._threads)
		  {
			 thread.Service = this;
		  }
	   }

	   /// <summary>
	   /// Clean up any resources being used.
	   /// </summary>
	   /// <param name="disposing">true if managed resources should be disposed;
	   /// otherwise, false.</param>
	   protected override void Dispose(bool disposing)
	   {
		  if (!_disposed)
		  {
			 try
			 {
				if (disposing)
				{
				    if (_threads != null)
				    {
					   foreach (var thread in _threads)
					   {
						  thread.Dispose();
					   }
				    }
				}
			 }
			 finally
			 {
				base.Dispose(disposing);
			 }

			 _disposed = true;
		  }
	   }

	   /// <summary>
	   /// Gets or sets the log name to use when writing to the event log.
	   /// </summary>
	   /// <remarks>
	   /// The default is the Windows 'Application' event log.
	   /// </remarks>
	   [Browsable(true)]
	   [Description("The log name to use when writing to the event log.")]
	   public string EventLogName
	   {
		  get { return EventLog.Log; }
		  set { EventLog.Log = value; }
	   }

	   /// <summary>
	   /// Gets or sets the source to use when writing to the event log.
	   /// </summary>
	   /// <remarks>
	   /// The default is the <see cref="Service.ServiceName"/> property value.
	   /// </remarks>
	   [Browsable(true)]
	   [Description("The source to use when writing to the event log.")]
	   public string EventLogSource
	   {
		  get { return EventLog.Source; }
		  set { EventLog.Source = value; }
	   }

	   protected override void OnStart(string[] args)
	   {
		  StartThreads(args);
	   }

	   public void ManualStart(string[] args)
	   {
		  var autoLog = AutoLog;

		  if (autoLog)
		  {
			 LogMessage(Resources.ServiceMessageStarting, ServiceMessageType.Information);
		  }

		  StartThreads(args);

		  if (autoLog)
		  {
			 LogMessage(Resources.ServiceMessageStarted, ServiceMessageType.Information);
		  }
	   }

	   protected void StartThreads(string[] args)
	   {
		  if (_disposed)
		  {
			 throw new ObjectDisposedException(GetType().FullName);
		  }

		  var autoLog = AutoLog;

		  foreach (var thread in _threads)
		  {
			 if (autoLog)
			 {
				LogMessage(string.Format(CultureInfo.CurrentCulture, "Starting service thread ({0})...", thread.Name), ServiceMessageType.Information);
			 }

			 thread.Start(args);

			 if (autoLog)
			 {
				LogMessage(string.Format(CultureInfo.CurrentCulture, "Service thread ({0}) started successfully.", thread.Name), ServiceMessageType.Information);
			 }
		  }
	   }

	   public void ManualStop()
	   {
		  var autoLog = AutoLog;

		  if (autoLog)
		  {
			 LogMessage(Resources.ServiceMessageStopping, ServiceMessageType.Information);
		  }

		  StopThreads();

		  if (autoLog)
		  {
			 LogMessage(Resources.ServiceMessageStopped, ServiceMessageType.Information);
		  }
	   }

	   protected void StopThreads()
	   {
		  if (_disposed)
		  {
			 throw new ObjectDisposedException(GetType().FullName);
		  }

		  if (_threads != null)
		  {
			 var autoLog = AutoLog;

			 foreach (var thread in _threads)
			 {
				if (autoLog)
				{
				    LogMessage(string.Format(CultureInfo.CurrentCulture, "Stopping service thread ({0})...", thread.Name), ServiceMessageType.Information);
				}

				thread.StopAsync();
			 }

			 var tasks = new Task[_threads.Count];

			 try
			 {
				for (var i = 0; i < tasks.Length; i++)
				{
				    var t = _threads[i];

				    tasks[i] = Task.Run(() =>
					   {
						  t.WaitForExit();

						  if (autoLog)
						  {
							 LogMessage(string.Format(CultureInfo.CurrentCulture, "Service thread ({0}) stopped successfully.", t.Name), ServiceMessageType.Information);
						  }
					   });
				}

				Task.WaitAll(tasks);
			 }
			 finally
			 {
				foreach (var task in tasks.Where(task => task != null))
				{
				    task.Dispose();
				}
			 }
		  }
	   }

	   protected override void OnStop()
	   {
		  StopThreads();
	   }

	   protected internal void SetManager(ServiceControlManager serviceControlManager, string instrumentationKey = null)
	   {
		  if (_manager != null)
		  {
			 throw new InvalidOperationException();
		  }

		  _manager = serviceControlManager ?? throw new ArgumentNullException(nameof(serviceControlManager));
		  _instrumentationKey = instrumentationKey;
	   }

	   /// <summary>
	   /// Logs an information message to the event log associated with the
	   /// service.
	   /// </summary>
	   /// <param name="message">The message to log.</param>
	   /// <remarks>
	   /// In user-interactive mode messages are written to the console standard
	   /// output stream.
	   /// </remarks>
	   public void LogMessage(string message)
	   {
		  LogMessage(message, ServiceMessageType.None);
	   }

	   /// <summary>
	   /// Logs a message to the event log associated with the service.
	   /// </summary>
	   /// <param name="message">The message to log.</param>
	   /// <param name="messageType">The message type to log.</param>
	   /// <remarks>
	   /// In user-interactive mode, <see cref="ServiceMessageType.Information"/>
	   /// message types are written to the console standard output stream, while
	   /// <see cref="ServiceMessageType.Warning"/> and
	   /// <see cref="ServiceMessageType.Error"/> message types are written to the
	   /// console standard error stream.
	   /// </remarks>
	   public virtual void LogMessage(string message, ServiceMessageType messageType)
	   {
		  if (_manager != null)
		  {
			 _manager.LogMessage(this, message, messageType);
		  }
		  else
		  {
			 if (message == null)
			 {
				throw new ArgumentNullException(nameof(message));
			 }

			 if (!messageType.IsValid())
			 {
				throw new ArgumentOutOfRangeException(nameof(messageType));
			 }

			 LogMessageCore(message, messageType);
		  }
	   }

	   internal void LogMessageCore(string message, ServiceMessageType messageType)
	   {
		  if (!string.IsNullOrWhiteSpace(_instrumentationKey))
		  {
			 _telemetryClient.InstrumentationKey = _instrumentationKey;
			 _telemetryClient.TrackTrace(message, GetSeverityLevel(messageType));
		  }
		  EventLog.WriteEntry(message, GetEventLogEntryType(messageType));
	   }

	   internal static SeverityLevel GetSeverityLevel(ServiceMessageType messageType)
	   {
		  switch (messageType)
		  {
			 case ServiceMessageType.None:
			 case ServiceMessageType.Information:
				return SeverityLevel.Information;

			 case ServiceMessageType.Warning:
				return SeverityLevel.Warning;

			 case ServiceMessageType.Error:
				return SeverityLevel.Error;

			 default:
				throw new ArgumentOutOfRangeException(nameof(messageType));
		  }
	   }

	   internal static EventLogEntryType GetEventLogEntryType(ServiceMessageType messageType)
	   {
		  switch (messageType)
		  {
			 case ServiceMessageType.None:
			 case ServiceMessageType.Information:
				return EventLogEntryType.Information;

			 case ServiceMessageType.Warning:
				return EventLogEntryType.Warning;

			 case ServiceMessageType.Error:
				return EventLogEntryType.Error;

			 default:
				throw new ArgumentOutOfRangeException(nameof(messageType));
		  }
	   }
    }
}
