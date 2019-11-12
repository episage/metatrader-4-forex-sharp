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
using System.Collections;
using System.Collections.Generic;

namespace TradePlatform.Bcl.ServiceProcess
{
    internal sealed class ServiceThreadCollection : IEnumerable<ServiceThread>
    {
        private readonly List<ServiceThread> threads;
        
        internal ServiceThreadCollection(IEnumerable<ServiceThread> threads)
        {
            if (threads == null)
            {
                throw new ArgumentNullException(nameof(threads));
            }

            this.threads = new List<ServiceThread>(threads);
        }

        public void Start(string[] args)
        {
            foreach (var thread in threads)
            {
                thread.Start(args);
            }
        }

        public void Stop()
        {
            StopAsync();
            WaitForExit();
        }

        public void StopAsync()
        {
            foreach (var thread in threads)
            {
                thread.StopAsync();
            }
        }

        public void WaitForExit()
        {
            foreach (var thread in threads)
            {
                thread.WaitForExit();
            }
        }

        public IEnumerator<ServiceThread> GetEnumerator()
        {
            return threads.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}