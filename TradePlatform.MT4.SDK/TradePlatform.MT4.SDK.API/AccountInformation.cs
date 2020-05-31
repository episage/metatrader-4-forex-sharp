using TradePlatform.MT4.Core;
using TradePlatform.MT4.Core.Utils;

namespace TradePlatform.MT4.SDK.API
{
	/// <summary>
    /// A group of functions to access to the active account information. 
    /// </summary>
    public static class AccountInformation
    {
        /// <summary>
        /// Returns balance value of the current account (the amount of money on the account). 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double AccountBalance(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("AccountBalance", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Returns credit value of the current account. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double AccountCredit(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("AccountCredit", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Returns the brokerage company name where the current account was registered. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static string AccountCompany(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("AccountCompany", null);

            return retrunValue;
        }

        /// <summary>
        /// Returns currency name of the current account. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static string AccountCurrency(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("AccountCurrency", null);

            return retrunValue;
        }

        /// <summary>
        /// Returns equity value of the current account. Equity calculation depends on trading server settings. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double AccountEquity(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("AccountEquity", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Returns free margin value of the current account. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double AccountFreeMargin(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("AccountFreeMargin", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Returns free margin that remains after the specified position has been opened at the current price on the current account. If the free margin is insufficient, an error 134 (ERR_NOT_ENOUGH_MONEY) will be generated. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="cmd"></param>
        /// <param name="volume"></param>
        /// <returns></returns>
        public static double AccountFreeMarginCheck(this MqlHandler handler, string symbol, ORDER_TYPE cmd, double volume)
        {
            string retrunValue = handler.CallMqlMethod("AccountFreeMarginCheck", symbol, (int)cmd, volume);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculation mode of free margin allowed to open positions on the current account. The calculation mode can take the following values:
        /// 0 - floating profit/loss is not used for calculation;
        /// 1 - both floating profit and loss on open positions on the current account are used for free margin calculation;
        /// 2 - only profit value is used for calculation, the current loss on open positions is not considered;
        /// 3 - only loss value is used for calculation, the current loss on open positions is not considered. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double AccountFreeMarginMode(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("AccountFreeMarginMode", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Returns leverage of the current account. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int AccountLeverage(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("AccountLeverage", null);

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// Returns margin value of the current account. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double AccountMargin(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("AccountMargin", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Returns the current account name. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static string AccountName(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("AccountName", null);

            return retrunValue;
        }

        /// <summary>
        /// Returns the number of the current account. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int AccountNumber(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("AccountNumber", null);

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// Returns profit value of the current account. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double AccountProfit(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("AccountProfit", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Returns the connected server name. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static string AccountServer(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("AccountServer", null);

            return retrunValue;
        }

        /// <summary>
        /// Returns the value of the Stop Out level. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int AccountStopoutLevel(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("AccountStopoutLevel", null);

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// Returns the calculation mode for the Stop Out level. Calculation mode can take the following values:
        /// 0 - calculation of percentage ratio between margin and equity;
        /// 1 - comparison of the free margin level to the absolute value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int AccountStopoutMode(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("AccountStopoutMode", null);

            return Convertor.ToInt(retrunValue);
        }
    }
}
