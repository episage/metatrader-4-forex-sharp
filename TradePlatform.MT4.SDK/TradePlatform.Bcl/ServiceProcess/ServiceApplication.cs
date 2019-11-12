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
using TradePlatform.Bcl.Properties;

namespace TradePlatform.Bcl.ServiceProcess
{
    public static class ServiceApplication
    {
	   /// <summary>
	   /// Registers the executable for a Windows Service with the Windows Service
	   /// Control Manager (SCM).
	   /// </summary>
	   /// <param name="service">A <see cref="Service"/> which indicates a
	   /// service to start.</param>
	   /// <param name="instrumentationKey"></param>
	   /// <remarks>
	   /// This method supports starting a service in user-interactive mode
	   /// (console application).
	   /// </remarks>
	   public static void Run(Service service, string instrumentationKey = null)
	   {
		  Run(service, null, instrumentationKey);
	   }

	   /// <summary>
	   /// Registers the executable for a Windows Service with the Windows Service
	   /// Control Manager (SCM).
	   /// </summary>
	   /// <param name="service">A <see cref="Service"/> which indicates a
	   /// service to start.</param>
	   /// <param name="serviceControlManager"></param>
	   /// <param name="instrumentationKey"></param>
	   /// <remarks>
	   /// This method supports starting a service in user-interactive mode
	   /// (console application).
	   /// </remarks>
	   public static void Run(Service service, ServiceControlManager serviceControlManager, string instrumentationKey = null)
	   {
		  if (service == null)
		  {
			 throw new ArgumentNullException(nameof(service));
		  }

		  RunCore(new[] { service }, serviceControlManager, instrumentationKey);
	   }

	   /// <summary>
	   /// Registers the executable for a Windows Service with the Windows Service
	   /// Control Manager (SCM).
	   /// </summary>
	   /// <param name="services">An array of <see cref="Service"/> instances,
	   /// which indicates the services to start.</param>
	   /// <param name="instrumentationKey"></param> 
	   /// <remarks>
	   /// This method supports starting a service in user-interactive mode
	   /// (console application).
	   /// </remarks>
	   public static void Run(IEnumerable<Service> services, string instrumentationKey = null)
	   {
		  Run(services, null, instrumentationKey);
	   }

	   /// <summary>
	   /// Registers the executable for a Windows Service with the Windows Service
	   /// Control Manager (SCM).
	   /// </summary>
	   /// <param name="services">An array of <see cref="Service"/> instances,
	   /// which indicates the services to start.</param>
	   /// <param name="serviceControlManager"></param>
	   /// <param name="instrumentationKey"></param>
	   /// <remarks>
	   /// This method supports starting a service in user-interactive mode
	   /// (console application).
	   /// </remarks>
	   public static void Run(IEnumerable<Service> services, ServiceControlManager serviceControlManager, string instrumentationKey = null)
	   {
		  if (services == null)
		  {
			 throw new ArgumentNullException(nameof(services));
		  }

		  RunCore(services, serviceControlManager ?? new ServiceControlManager(), instrumentationKey);
	   }

	   private static void RunCore(IEnumerable<Service> services, ServiceControlManager serviceControlManager, string instrumentationKey = null)
	   {
		  AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
			 {
				try
				{
				    var exception = (e.ExceptionObject as Exception);
				    var message = new ServiceApplicationException(Resources.UnhandledServiceApplicationExceptionMessage, exception).ToString();
				    serviceControlManager.LogMessageBroadcast(message, ServiceMessageType.Error);
				}
				finally
				{
				    // Terminate the process.  This is required for a Windows Service to exit.
				    Environment.Exit(-1);
				}
			 };

		  serviceControlManager.Run(services, instrumentationKey);
	   }
    }
}