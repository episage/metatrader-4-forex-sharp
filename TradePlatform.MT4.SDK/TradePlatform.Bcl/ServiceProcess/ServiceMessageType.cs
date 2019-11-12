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

namespace TradePlatform.Bcl.ServiceProcess
{
    /// <summary>
    /// Service message type.
    /// </summary>
    [Serializable]
    public enum ServiceMessageType
    {
        None = 0,
        /// <summary>
        /// Informational message.
        /// </summary>
        Information,
        /// <summary>
        /// Warning message.
        /// </summary>
        Warning,
        /// <summary>
        /// Error message.
        /// </summary>
        Error
    }

    internal static class ServiceThreadMessageTypeExtensionMethods
    {
        internal static bool IsValid(this ServiceMessageType value)
        {
            switch (value)
            {
                case ServiceMessageType.None:
                case ServiceMessageType.Information:
                case ServiceMessageType.Warning:
                case ServiceMessageType.Error:
                    return true;

                default:
                    return false;
            }
        }
    }
}