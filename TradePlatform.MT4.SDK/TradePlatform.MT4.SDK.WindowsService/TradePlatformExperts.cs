using System.ServiceProcess;
using log4net;

using System;
using System.Collections.Generic;
using System.Linq;
using TradePlatform.Bcl.ServiceProcess;

namespace TradePlatform.MT4.SDK.WindowsService
{

    public partial class TradePlatformExperts : Service
    {
	    #region Constructors

	    public TradePlatformExperts()
	    {
		    InitializeComponent();
	    }

	    internal TradePlatformExperts(params ServiceThread[] threads)
		    : base(threads)
	    {
		    InitializeComponent();
	    }

	    #endregion // Constructors

	    #region Static Methods

	    internal static TradePlatformExperts Create()
	    {
		    TradePlatformExperts serviceInstance;
		    List<ServiceThread> threads = null;

		    try
		    {
			    threads = new List<ServiceThread>();
			    threads.Add(new TradePlatformServiceThread());
			    if (!threads.Any())
			    {
				    throw new ApplicationException("Cannot start service when no threads have been configured to run.");
			    }

			    serviceInstance = new TradePlatformExperts(threads.ToArray());

			    threads.Clear();
			    threads = null;
		    }
		    finally
		    {
			    threads?.ForEach(t => t.Dispose());
		    }

		    return serviceInstance;
	    }

	    #endregion // Static Methods
    }
}
