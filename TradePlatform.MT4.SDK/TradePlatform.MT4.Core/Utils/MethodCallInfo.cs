using System;
using System.Collections.Generic;
using System.Linq;

namespace TradePlatform.MT4.Core.Utils
{
  public sealed class MethodCallInfo
  {
    public readonly string MethodName;
    public readonly List<string> Parameters;

    public string ReturnValue { get; set; }

    public string ErrorMessage { get; set; }

    public MethodCallInfo(string methodName, IEnumerable<string> parameters)
    {
      this.MethodName = methodName;
      this.Parameters = new List<string>(parameters ?? (IEnumerable<string>) new string[0]);
      this.ReturnValue = (string) null;
      this.ErrorMessage = (string) null;
    }

    public override string ToString()
    {
      return Enumerable.Aggregate<string, string>((IEnumerable<string>) this.Parameters, this.MethodName + "(", (Func<string, string, string>) ((current, prm) => current + prm + ", ")).TrimEnd(',', ' ') + ")";
    }
  }
}
