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

namespace TradePlatform.Bcl.ServiceProcess
{
    public sealed class ServiceInitializeEventArgs<TServiceThread> : EventArgs
    {
        private readonly string[] arguments;

        internal ServiceInitializeEventArgs(string[] arguments)
        {
            this.arguments = arguments;
        }

        public IEnumerable<string> Arguments => arguments;

        public IEnumerable<TServiceThread> Threads { get; set; }
    }
}