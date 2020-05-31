using TradePlatform.Bcl.ServiceProcess;
using System;

namespace TradePlatform.MT4.SDK.WindowsService
{
    static class Program
    {
        static void Main(string[] args)
        {
		  //ServiceBase[] ServicesToRun;
		  //ServicesToRun = new ServiceBase[]
		  //{
			 //new TradePlatformExperts()
		  //};

		  //ServiceBase.Run(ServicesToRun);
		  ////ServicesToRun.LoadServices(); --use this line to debug service

		  var services = new Service[] { TradePlatformExperts.Create() };

		  if (Environment.UserInteractive)
		  {
			  ServiceApplication.Run(services, new ConsoleServiceControlManager(args, true));
		  }
		  else
		  {
			  ServiceApplication.Run(services);
		  }
	   }
    }
}
