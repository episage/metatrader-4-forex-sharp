using TradePlatform.MT4.Core;
using TradePlatform.MT4.Core.Utils;

namespace TradePlatform.MT4.SDK.API
{
    using System;

    /// <summary>
    /// For each executable MQL4 program, a number of predefined variables is supported that reflect the state of the current price chart at the launching of a program: an expert, a script, or a custom indicator.
    /// </summary>
    public static class PredefinedVariables
    {
        /// <summary>
        /// The latest known seller's price (ask price) for the current symbol. The RefreshRates() function must be used to update.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double Ask(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("Ask", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Number of bars in the current chart.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int Bars(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("Bars", null);

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// The latest known buyer's price (offer price, bid price) of the current symbol. The RefreshRates() function must be used to update.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double Bid(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("Bid", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Series array that contains close prices for each bar of the current chart.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static double Close(this MqlHandler handler, int i)
        {
            string retrunValue = handler.CallMqlMethod("Close", i);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Series array that contains close prices for each bar of the current chart.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static double iClose(this MqlHandler handler, string symbol, int i,TIME_FRAME timeFrame)
        {
            string retrunValue = handler.CallMqlMethod("iClose", symbol, i, (int) timeFrame);

            return Convertor.ToDouble(retrunValue);
        }


        /// <summary>
        /// Number of digits after decimal point for the current symbol prices.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int Digits(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("Digits", null);

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// Series array that contains the highest prices of each bar of the current chart.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static double High(this MqlHandler handler, int i)
        {
            string retrunValue = handler.CallMqlMethod("High", i);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Series array that contains the lowest prices of each bar of the current chart.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static double Low(this MqlHandler handler, int i)
        {
            string retrunValue = handler.CallMqlMethod("Low", i);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Series array that contains open prices of each bar of the current chart.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static double Open(this MqlHandler handler, int i)
        {
            string retrunValue = handler.CallMqlMethod("Open", i);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// The current symbol point value in the quote currency.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double Point(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("Point", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Series array that contains open time of each bar of the current chart. Data like datetime represent time, in seconds, that has passed since 00:00 a.m. of 1 January, 1970.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static DateTime Time(this MqlHandler handler, int i)
        {
            string retrunValue = handler.CallMqlMethod("Time", i);

            return Convertor.ToDateTime(retrunValue);
        }

        /// <summary>
        /// Series array that contains tick volumes of each bar of the current chart.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double Volume(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("Volume", null);

            return Convertor.ToDouble(retrunValue);
        }

        public static int IndicatorCounted(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("IndicatorCounted", null);

            return Convertor.ToInt(retrunValue);
        }
    }
}
