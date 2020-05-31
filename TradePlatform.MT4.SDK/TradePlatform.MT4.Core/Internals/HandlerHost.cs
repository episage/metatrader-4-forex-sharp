using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TradePlatform.MT4.Core.Config;
using TradePlatform.MT4.Core.Exceptions;
using TradePlatform.MT4.Core.Utils;
using TradePlatform.MT4.Engine.Log;

namespace TradePlatform.MT4.Core.Internals
{
  internal sealed class HandlerHost
  {
    private readonly Thread _listenThread;
    private readonly string _name;
    private readonly bool _isBackground;
    private readonly TcpListener _tcpListener;

    public HostElement HostConfiguration
    {
      get
      {
        return ((BridgeConfiguration) ConfigurationManager.GetSection("BridgeConfiguration")).Hosts[this._name];
      }
    }

    public HandlerHost(string name, IPAddress ip, int port, bool isBackground)
    {
      this._name = name;
      this._isBackground = isBackground;
      this._tcpListener = new TcpListener(ip, port);
      this._listenThread = new Thread(new ThreadStart(this.ListenForClients))
      {
        IsBackground = this._isBackground
      };
    }

    public void Run()
    {
      this._listenThread.Start();
    }

    private void HandleClientComm(object client)
    {
      lock (client)
      {
        var local_0 = (TcpClient) client;
        Trace.Write( new LogInfo(LogType.Initializations, null, "Connection opened"));
        HandlerProvider handlerProvider = (HandlerProvider) null;
        try
        {
          var local_1 = local_0.GetStream();
          var local_2 = this.GetMessage(local_1);
          if (local_2.Length < 3)
            throw new MessageException(local_2, 3, "discriminator|applicationName|methodName|param1|param2|param3");
          var local_3 = new MethodCallInfo(local_2[2], Enumerable.Skip<string>((IEnumerable<string>) local_2, 3));
          var expertInfo = new ExpertInfo(local_2[0] + local_2[1], local_2[1], local_3);
          handlerProvider = HandlerProvider.GetOrCreate(expertInfo, HostConfiguration);
          lock (handlerProvider.Locker)
          {
            handlerProvider.BeginTime = DateTime.Now;
            handlerProvider.ServerMethod = local_3;
            handlerProvider.ClientMethod = null;
            var local_4 = new Thread((ParameterizedThreadStart) (x =>
            {
              try
              {
                ((HandlerProvider) x).ProceedServerMethod();
              }
              catch (Exception exception_1)
              {
                var local_5 = new HandlerExecutionException(expertInfo, exception_1);
                handlerProvider.ServerMethod.ErrorMessage = local_5.Message;
                Trace.Write( new LogInfo(LogType.HandlerExecutionError, local_5, ""));
              }
              finally
              {
                handlerProvider.ClientCallSemaphore.Set();
              }
            }))
            {
              IsBackground = this._isBackground
            };
            local_4.CurrentCulture = new CultureInfo("en-US");
            local_4.Name = local_0.Client.RemoteEndPoint + " > " + this._tcpListener.Server.LocalEndPoint;
            local_4.Start(handlerProvider);
            handlerProvider.ClientCallSemaphore.WaitOne();
            while (handlerProvider.ClientMethod != null)
            {
              var local_5 = new string[2 + Enumerable.Count<string>((IEnumerable<string>) handlerProvider.ClientMethod.Parameters)];
              local_5[0] = "###MQL###";
              local_5[1] = handlerProvider.ClientMethod.MethodName;
              for (int local_6 = 2; local_6 < local_5.Length; ++local_6)
                local_5[local_6] = handlerProvider.ClientMethod.Parameters[local_6 - 2];
              this.WriteMessage(local_1, local_5);
              string[] local_7 = this.GetMessage(local_1);
              if (local_7.Length < 2)
                throw new MessageException(local_7, 2, "lastError|returnValue");
              handlerProvider.ClientMethod.ErrorMessage = local_7[0] == "0:no error" ? null : local_7[0];
              handlerProvider.ClientMethod.ReturnValue = local_7[1] == "###EMPTY###" ? string.Empty : local_7[1];
              handlerProvider.ServerCallSemaphore.Set();
              handlerProvider.ClientCallSemaphore.WaitOne();
            }
            if (handlerProvider.ServerMethod.ErrorMessage != null)
              this.WriteMessage(local_1, "###ERR###", handlerProvider.ServerMethod.ErrorMessage);
            if (handlerProvider.ServerMethod.ReturnValue != null)
              this.WriteMessage(local_1, new string[1]
              {
                handlerProvider.ServerMethod.ReturnValue
              });
          }
        }
        catch (Exception exception_0)
        {
          Trace.Write(new LogInfo(LogType.Execption, exception_0, ""));
        }
        finally
        {
          if (handlerProvider != null)
          {
            handlerProvider.EndTime = DateTime.Now;
            Trace.Write(new LogInfo(LogType.Notifications, null, "Method execution time: " + (handlerProvider.EndTime - handlerProvider.BeginTime).TotalMilliseconds + " ms."));
          }
          local_0.Close();
        }
        Trace.Write( new LogInfo(LogType.Initializations, null, "Connection closed\n"));
      }
    }

    public static IEnumerable<string> GetSplit(string s, char c)
    {
      int l = s.Length;
      int i = 0;
      int j = s.IndexOf(c, 0, l);
      if (j == -1)
      {
        yield return s;
      }
      else
      {
        for (; j != -1; j = s.IndexOf(c, i, l - i))
        {
          if (j - i > 0)
            yield return s.Substring(i, j - i);
          i = j + 1;
        }
        if (i < l)
          yield return s.Substring(i, l - i);
      }
    }

    private string[] GetMessage(NetworkStream stream)
    {
      byte[] numArray = new byte[4096];
      int count = stream.Read(numArray, 0, 4096);
      string str = new ASCIIEncoding().GetString(numArray, 0, count).Trim(new char[1]);
      Trace.Write(new LogInfo(LogType.Workflow, null, " --> " + str));
      return str.Split(new char[1]
      {
        '|'
      }, StringSplitOptions.None);
    }

    private void WriteMessage(NetworkStream stream, params string[] message)
    {
      ASCIIEncoding asciiEncoding = new ASCIIEncoding();
      string result = "";  
      message.ToList().ForEach((string x) => result = string.Concat(result, x, "|"));  
/*
      Enumerable.ToList<string>((IEnumerable<string>) message).ForEach((Action<string>) (x =>
      {
        // ISSUE: variable of a compiler-generated type         
        HandlerHost.\u003C\u003Ec__DisplayClass11 temp_37 = this;  //TODO fixfix
        // ISSUE: reference to a compiler-generated field
          string temp_41 = x + "|";
         string temp_41 = temp_37.result + x + "|";
        // ISSUE: reference to a compiler-generated field
        temp_37.result = temp_41;
      }));
      result = result.Trim(new char[1]
      {
        '|'
      });*/
      byte[] bytes = asciiEncoding.GetBytes(result);
      Trace.Write(new LogInfo(LogType.Workflow, null, " <-- " + result));
      stream.Write(bytes, 0, bytes.Length);
      stream.Flush();
    }

    private void ListenForClients()
    {
      this._tcpListener.Start();
      Trace.Write(new LogInfo(LogType.Initializations, null, "TCP listening for MT4 at " + HostConfiguration.IPAddress + ":" + this.HostConfiguration.Port + "\n"));
      while (true)
      {
        TcpClient tcpClient = this._tcpListener.AcceptTcpClient();
        Thread thread = new Thread(new ParameterizedThreadStart(this.HandleClientComm))
        {
          IsBackground = this._isBackground
        };
        thread.Name = tcpClient.Client.RemoteEndPoint + " > " + _tcpListener.Server.LocalEndPoint;
        thread.Start(tcpClient);
      }
    }
  }
}
