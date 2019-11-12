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
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace TradePlatform.Bcl.ServiceProcess
{
    /// <summary>
    /// A non-fatal exception that CAN be thrown by the
    /// <see cref="ServiceThread.OnExecute"/>
    /// method.
    /// </summary>
    /// <remarks>
    /// Throw this exception from the body of the 
    /// <see cref="ServiceThread.OnExecute"/>
    /// method to report an error condition that SHOULD be logged, but that
    /// the service SHOULD attempt to recover from.  Throwing any other
    /// exception will result in the service terminating.
    /// </remarks>
    [Serializable]
    public class ServiceThreadException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceThreadException"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor initializes the <see cref="ServiceThreadException.Message"/>
        /// property of the new instance to a system-supplied message that describes
        /// the error and takes into account the current system culture.  All the
        /// derived classes should provide this default constructor.
        /// </remarks>
        public ServiceThreadException()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceThreadException"/> class
        /// with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <remarks>
        /// This constructor initializes the <see cref="ServiceThreadException.Message"/>
        /// property of the new instance by using the <paramref name="message"/>
        /// parameter.  If the <paramref name="message"/> parameter is null (Nothing
        /// in Visual Basic), this is the same as calling the
        /// <see cref="ServiceThreadException()"/> constructor.
        /// </remarks>
        public ServiceThreadException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceThreadException"/> class
        /// with a specified error message and a reference to the inner exception
        /// that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the
        /// exception.</param>
        /// <param name="innerException">The exception that is the cause of the
        /// current exception, or a null reference (Nothing in Visual Basic) if no
        /// inner exception is specified.</param>
        /// <remarks>
        /// An exception that is thrown as a direct result of a previous exception
        /// SHOULD include a reference to the previous exception in the
        /// <see cref="ServiceThreadException.InnerException"/> property.  The
        /// <see cref="ServiceThreadException.InnerException"/> property returns the same
        /// value that is passed into the constructor, or a null reference (Nothing
        /// in Visual Basic) if the <paramref name="innerException"/> parameter does
        /// not supply the inner exception value to the constructor.
        /// </remarks>
        public ServiceThreadException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceThreadException"/> class
        /// with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the
        /// serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains
        /// contextual information about the source or destination.</param>
        /// <remarks>
        /// This constructor is called during deserialization to reconstitute the
        /// exception object transmitted over a stream.
        /// </remarks>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected ServiceThreadException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}