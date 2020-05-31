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
using System.Linq;
using System.ServiceProcess;

namespace TradePlatform.Bcl.ServiceProcess
{
    public class ServiceControlManager
    {
	   private Service[] _services;

	   public void Run(IEnumerable<Service> servicesToRun, string instrumentationKey = null)
	   {
		  _services = (servicesToRun as Service[] ?? servicesToRun.ToArray());

		  foreach (var service in _services)
		  {
			 service.SetManager(this, instrumentationKey);
		  }

		  OnRun(_services);
	   }

	   protected virtual void OnRun(ICollection<Service> servicesToRun)
	   {
		  ServiceBase.Run((Service[])servicesToRun);
	   }

	   protected ICollection<Service> Services => _services;

	   public virtual void LogMessage(Service service, string message, ServiceMessageType messageType)
	   {
		  if (service == null)
		  {
			 throw new ArgumentNullException(nameof(service));
		  }

		  if (message == null)
		  {
			 throw new ArgumentNullException(nameof(message));
		  }

		  if (!messageType.IsValid())
		  {
			 throw new ArgumentOutOfRangeException(nameof(messageType));
		  }

		  service.LogMessageCore(message, messageType);
	   }

	   public void LogMessageBroadcast(string message, ServiceMessageType messageType)
	   {
		  foreach (var service in _services)
		  {
			 service.LogMessage(message, messageType);
		  }
	   }
    }
}