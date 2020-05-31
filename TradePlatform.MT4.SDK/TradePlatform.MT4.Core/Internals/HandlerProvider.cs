using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using TradePlatform.MT4.Core.Config;
using TradePlatform.MT4.Core.Exceptions;
using TradePlatform.MT4.Core.Utils;
using TradePlatform.MT4.Engine.Log;

namespace TradePlatform.MT4.Core.Internals
{
  internal sealed class HandlerProvider
  {
    private static readonly Dictionary<string, HandlerProvider> _storage = new Dictionary<string, HandlerProvider>();
    private static readonly object _storageLocker = new object();
    internal readonly AutoResetEvent ClientCallSemaphore = new AutoResetEvent(false);
    internal readonly object Locker = new object();
    internal readonly AutoResetEvent ServerCallSemaphore = new AutoResetEvent(false);
    private readonly MqlHandler _mqlHandler;
    internal MethodCallInfo ClientMethod;
    internal MethodCallInfo ServerMethod;
    internal DateTime BeginTime;
    internal DateTime EndTime;

    internal HandlerElement HandlerConfiguration { get; set; }

    internal ExpertInfo ExpertInfo { get; set; }

    static HandlerProvider()
    {
    }

    private HandlerProvider(MqlHandler mqlHandler, HandlerElement handlerElement, ExpertInfo expertInfo)
    {
      this._mqlHandler = mqlHandler;
      this._mqlHandler.CallMqlInternal = new Func<string, IEnumerable<string>, string>(this.OnCallMqlMethod);
      this.HandlerConfiguration = handlerElement;
      this.ExpertInfo = expertInfo;
    }

    private string OnCallMqlMethod(string methodName, IEnumerable<string> parameters)
    {
      string str = "";
      try
      {
        this.ClientMethod = new MethodCallInfo(methodName, parameters);
        this.ClientCallSemaphore.Set();
        this.ServerCallSemaphore.WaitOne();
        str = this.ClientMethod.ReturnValue;
        if (!string.IsNullOrEmpty(this.ClientMethod.ErrorMessage))
        {
          if (this._mqlHandler.MqlError != null)
          {
            MqlErrorException mqlErrorException = new MqlErrorException(this.ExpertInfo, this.ClientMethod);
            this._mqlHandler.MqlError(mqlErrorException);
            Trace.Write((object) new LogInfo(LogType.MqlError, (Exception) mqlErrorException, ""));
          }
        }
      }
      catch (Exception ex)
      {
        Trace.Write((object) new LogInfo(LogType.Execption, ex, ""));
      }
      finally
      {
        this.ClientMethod = (MethodCallInfo) null;
      }
      return str;
    }

    internal void ProceedServerMethod()
    {
      this.ServerMethod.ReturnValue = this._mqlHandler.ResolveMethod(this.ServerMethod.MethodName, this.ServerMethod.Parameters) ?? "";
    }

    internal static HandlerProvider GetOrCreate(ExpertInfo expertInfo, HostElement hostElement)
    {
      lock (HandlerProvider._storageLocker)
      {
        if (HandlerProvider._storage.ContainsKey(expertInfo.Discriminator))
          return HandlerProvider._storage[expertInfo.Discriminator];
        if (!hostElement.Handlers.ContainsKey(expertInfo.HandlerName))
          throw new HandlerLoadException(expertInfo, "Requested application not found in configuration", (Exception) null);
        HandlerElement local_0 = hostElement.Handlers[expertInfo.HandlerName];
        Assembly local_1;
        try
        {
          local_1 = Assembly.LoadFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + local_0.AssemblyName + ".dll");
        }
        catch (Exception exception_3)
        {
          throw new HandlerLoadException(expertInfo, "Requested assembly not found", exception_3);
        }
        Type local_3;
        try
        {
          local_3 = local_1.GetType(local_0.TypeName);
        }
        catch (Exception exception_2)
        {
          throw new HandlerLoadException(expertInfo, "Requested type not found in assembly.", exception_2);
        }
        MqlHandler local_5;
        try
        {
          local_5 = (MqlHandler) Activator.CreateInstance(local_3);
        }
        catch (Exception exception_1)
        {
          throw new HandlerLoadException(expertInfo, "Can't create intance of expert.", exception_1);
        }
        try
        {
          foreach (ParameterElement item_0 in (ConfigurationElementCollection) local_0.InputParameters)
          {
            PropertyInfo local_8 = local_5.GetType().GetProperty(item_0.PropertyName);
            Type local_9 = local_8.PropertyType;
            object local_10 = Convert.ChangeType((object) item_0.PropertyValue, local_9);
            local_8.SetValue((object) local_5, local_10);
          }
        }
        catch (Exception exception_0)
        {
          throw new HandlerLoadException(expertInfo, "Can't set input parameters for expert", exception_0);
        }
        local_5.Discriminator = expertInfo.Discriminator;
        HandlerProvider local_12 = new HandlerProvider(local_5, local_0, expertInfo);
        HandlerProvider._storage.Add(expertInfo.Discriminator, local_12);
        return local_12;
      }
    }
  }
}
