using System;
using System.Collections.Generic;
using System.Linq;

namespace TradePlatform.MT4.Core.Exceptions
{
  internal class MessageException : Exception
  {
    public MessageException(string[] message, int minLenght, string formatSample)
      : base(string.Format("Wrong message length. Expected minimum lenght: {0}, but actual lenght: {1}. Message was: '{2}', expected format: '{3}'", (object) minLenght, (object) message.Length, (object) MessageException.ComputeArray((IEnumerable<string>) message), (object) formatSample))
    {
    }

    private static string ComputeArray(IEnumerable<string> message)
    {
      string result = "";
      message.ToList().ForEach((string x) => result = string.Concat(result, x, "|"));
      /*     Enumerable.ToList<string>(message).ForEach((Action<string>) (x => //TODO //TODO fixfix
           {
             // ISSUE: variable of a compiler-generated type
             MessageException.\u003C\u003Ec__DisplayClass1 temp_10 = this;
             // ISSUE: reference to a compiler-generated field
             string temp_14 = temp_10.result + x + "|";
             // ISSUE: reference to a compiler-generated field
             temp_10.result = temp_14;
           }));*/
      return result;
    }
  }
}
