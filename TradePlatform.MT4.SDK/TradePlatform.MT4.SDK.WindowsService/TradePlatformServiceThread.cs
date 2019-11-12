using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TradePlatform.Bcl.ServiceProcess;
using MySql.Data.MySqlClient.Properties;
using TradePlatform.MT4.Core;

namespace TradePlatform.MT4.SDK.WindowsService
{
    internal sealed class TradePlatformServiceThread : ServiceThread
    {
	   #region Constructor

	   internal TradePlatformServiceThread() : base($"{nameof(TradePlatformServiceThread)}:{nameof(TradePlatformServiceThread)}",
			 5000,
			 5000)
	   {
	   }

	   #endregion // Cosntructor

	   #region Protected Methods

	   protected override void OnExecute(CancellationToken cancellationToken)
	   {
		   Bridge.InitializeHosts();
	   }

	   #endregion // Protected Methods
    }
}
