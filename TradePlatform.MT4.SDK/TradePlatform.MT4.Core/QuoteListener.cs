using System;
using TradePlatform.MT4.Core.Exceptions;

namespace TradePlatform.MT4.Core
{
  public class QuoteListener : ExpertAdvisor
  {
    public QuoteListener()
    {
      QuoteListener quoteListener = this;
      Action<MqlErrorException> action = quoteListener.MqlError + new Action<MqlErrorException>(this.OnMqlError);
      quoteListener.MqlError = action;
    }

    private void OnMqlError(MqlErrorException mqlErrorException)
    {
      MetaTrader4.For(QuoterExtensions.AccountNumber(this), QuoterExtensions.Symbol(this)).OnMqlError(mqlErrorException);
    }

    protected override int Init()
    {
      return 0;
    }

    protected override int Start()
    {
      MetaTrader4.For(QuoterExtensions.AccountNumber(this), QuoterExtensions.Symbol(this)).OnQuote(this);
      return 1;
    }

    protected override int DeInit()
    {
      return 0;
    }
  }
}
