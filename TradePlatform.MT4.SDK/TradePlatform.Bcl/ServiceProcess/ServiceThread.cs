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
using System.ServiceProcess;
using System.Threading;
using TradePlatform.Bcl.Properties;

namespace TradePlatform.Bcl.ServiceProcess
{
    /// <summary>
    /// Service thread abstract base class.
    /// </summary>
    /// <remarks>
    /// Implement this class once for each service.  Call the <see cref="Start"/>
    /// method from the <see cref="ServiceBase.OnStart"/> method.  Call the
    /// <see cref="Stop"/> method from the <see cref="ServiceBase.OnStop"/> method.
    /// Override the <see cref="OnExecute"/> method to provide the actual work that
    /// the service must perform on each polling iteration.  Call the
    /// <see cref="Dispose"/> method from the overridden
    /// <see cref="ServiceBase.Dispose(Boolean)"/> method.  Override the
    /// <see cref="Dispose(Boolean)"/> method, if you have any additional
    /// disposable objects.
    /// </remarks>
    public abstract class ServiceThread : IDisposable
    {
        private readonly int successMillisecondsInterval;
        private readonly int failureMillisecondsInterval;
        private readonly Thread thread;
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private Service service;
        private bool disposed;

        protected const int DefaultSuccessMillisecondsInterval = 0;
        protected const int DefaultFailureMillisecondsInterval = 60000;

        protected ServiceThread(string name)
            : this(name, DefaultSuccessMillisecondsInterval, DefaultFailureMillisecondsInterval)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceThread"/> class.
        /// </summary>
        /// <param name="service">The <see cref="ServiceBase"/> instance.</param>
        /// <param name="settings">The <see cref="ServiceThreadSettings"/> instance.</param>
        protected ServiceThread(string name, int successMillisecondsInterval, int failureMillisecondsInterval)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.successMillisecondsInterval = successMillisecondsInterval;
            this.failureMillisecondsInterval = failureMillisecondsInterval;

            // Create, but do not start, the thread.
            thread = new Thread(ThreadProc) { Name = name };
        }

        /// <summary>
        /// Releases all resources used by the <see cref="ServiceThread"/> instance.
        /// </summary>
        /// <remarks>
        /// Call the <see cref="Dispose"/> method when you are finished using the
        /// <see cref="ServiceThread"/> instance.  The <see cref="Dispose"/> method
        /// leaves the instance in an unusable state.  After calling the
        /// <see cref="Dispose"/> method, you must release all references to the
        /// instance so the garbage collector can reclaim the memory that the
        /// instance was occupying.
        /// </remarks>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="ServiceThread"/>
        /// and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged
        /// resources; false to release only unmanaged resources.</param>
        /// <remarks>
        /// This method is called by the public <see cref="Dispose"/> method.  The
        /// public <see cref="Dispose"/> method invokes the protected
        /// <see cref="Dispose(Boolean)"/> method with the
        /// <paramref name="disposing"/> parameter set to true.  When the
        /// <paramref name="disposing"/> parameter is true, this method releases all
        /// resources held by any managed objects that this instance references.
        /// This method invokes the <see cref="IDisposable.Dispose"/> method of each
        /// referenced object.
        /// Notes to Inheritors:
        /// The <see cref="Dispose"/> method can be called multiple times by other
        /// objects.  When overriding the <see cref="Dispose(Boolean)"/> method, be
        /// careful not to reference objects that have been previously disposed of
        /// in an earlier call to the <see cref="Dispose"/> method.
        /// </remarks>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    cancellationTokenSource.Dispose();
                }

                disposed = true;
            }
        }

        public string Name
        {
            get { return thread.Name; }
        }

        /// <summary>
        /// Start the service thread.
        /// </summary>
        /// <remarks>
        /// Call this method from the <see cref="ServiceBase.OnStart"/> method.
        /// </remarks>
        public void Start(string[] args)
        {
            if (disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }

            OnStart(args);
            // Start the thread.
            thread.Start();
        }

        protected virtual void OnStart(string[] args)
        { }

        protected virtual void OnStop()
        { }

        /// <summary>
        /// Stop the service thread.
        /// </summary>
        /// <remarks>
        /// Call this method from the <see cref="ServiceBase.OnStop"/> method.
        /// </remarks>
        public void Stop()
        {
            StopAsync();
            WaitForExit();
        }

        public void StopAsync()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }

            OnStop();

            // Request cancellation.
            cancellationTokenSource.Cancel();
        }
        
        public void WaitForExit()
        {
            // Wait for the thread to exit.
            thread.Join();
        }

        /// <summary>
        /// The service.
        /// </summary>
        protected internal Service Service
        {
            get { return service; }
            set
            {
                if (service != null)
                {
                    throw new InvalidOperationException();
                }

                service = value;
            }
        }

        /// <summary>
        /// The service thread worker method.
        /// </summary>
        /// <remarks>
        /// Override this method to implement your service's core work.
        /// </remarks>
        /// <param name="cancellationToken">Cancellation token to cancel work.</param>
        /// <remarks>
        /// This method is called repeatedly in a polling fashion as long as the
        /// service is running.  You MUST implement this method to honour a request
        /// for cancellation.  Check the
        /// <see cref="CancellationToken.IsCancellationRequested"/> property before
        /// performing work, and return from the method if the property is true.
        /// Under normal conditions, this method will be called repeatedly for the
        /// polling interval specified by the
        /// <see cref="ServiceThreadSettings.SuccessPollingInterval"/> property value.
        /// You CAN throw a <see cref="ServiceThreadException"/> exception from this
        /// method to indicate a recoverable error condition.  By default, the
        /// <see cref="ServiceThread"/> will log the error (as a warning) to the
        /// event log associated with the service and pause for the interval
        /// specified by the
        /// <see ServiceThreadSettingsttings.FailurePollingInterval"/> property
        /// value.  In user-interactive mode, by default, the error will be output
        /// to the console standard error stream instead.  The default behaviour CAN
        /// be overriden in a derived class, by overridding the
        /// <see cref="HandleException"/> method.  If an implementation of the
        /// <see cref="OnExecute"/> method throws an unhandled exception (other than
        /// <see cref="ServiceThreadException"/>), by default, the error will be logged to
        /// the event log associated with the service and the service will be
        /// terminated.  A process SHOULD terminate on an unhandled exception, as it
        /// is impossible to predict what negative side-effects the state corruption
        /// MAY cause.  Recovery of the terminated Windows Service CAN be handled by
        /// the Windows Service Host recovery configuration in Windows itself.
        /// </remarks>
        protected abstract void OnExecute(CancellationToken cancellationToken);

        /// <summary>
        /// Handles a recoverable error.
        /// </summary>
        /// <param name="exception">The recoverable error.</param>
        /// <returns>true if the exception was handled; otherwise false.</returns>
        /// <remarks>
        /// By default, this method logs the error (as a warning) to the event log
        /// associated with the service and returns true, which means that the
        /// service will pause for the interval specified by the
        /// <see ServiceThreadSettingsttings.FailurePollingInterval"/> before resuming.
        /// In user-interactive mode, the error will be output to the console
        /// standard error stream.  If an implementation of this method returns
        /// false, the error will be escalated to a fatal error, logged in the event
        /// log associated with the service, and the service will terminate.
        /// </remarks>
        protected virtual bool HandleException(Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            if (exception is ServiceThreadException)
            {
                // Log the exception message, inner exception messages
                // and the stack trace as a warning.
                service.LogMessage(exception.ToString(), ServiceMessageType.Error);
                return true;
            }

            return false;
        }

        private void ThreadProc()
        {
            var cancellationToken = cancellationTokenSource.Token;

            using (var waitHandle = cancellationToken.WaitHandle)
            {
                bool success;

                do
                {
                    try
                    {
                        OnExecute(cancellationToken);
                        success = true;
                    }
                    catch (OperationCanceledException)
                    {
                        success = true;
                    }
                    catch (Exception exception)
                    {
                        // Attempt to handle the exception.
                        if (!HandleException(exception))
                        {
                            service.LogMessage(exception.ToString(), ServiceMessageType.Error);
                            throw new ServiceThreadException(Resources.UnhandledServiceThreadExceptionMessage, exception);
                        }

                        // The exception was handled and is treated as a recoverable error.
                        // The service will not terminate, but will wait (usually longer than usual)
                        // before retrying.
                        success = false;
                    }
                } while (!waitHandle.WaitOne(success ? successMillisecondsInterval : failureMillisecondsInterval));
            }
        }
    }
}
