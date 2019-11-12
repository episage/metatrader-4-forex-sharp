using TradePlatform.MT4.Core;
using TradePlatform.MT4.Core.Utils;

namespace TradePlatform.MT4.SDK.API
{
    using System;

    /// <summary>
    /// A group of functions intended for trading management.
    /// </summary>
    public static class TradingFunctions
    {
        /// <summary>
        /// Closes opened order. If the function succeeds, the return value is true. If the function fails, the return value is false. To get the detailed error information, call GetLastError(). 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="ticket">Unique number of the order ticket.</param>
        /// <param name="lots">Number of lots.</param>
        /// <param name="price">Preferred closing price.</param>
        /// <param name="slippage">Value of the maximum price slippage in points.</param>
        /// <param name="color">Color of the closing arrow on the chart. If the parameter is missing or has CLR_NONE value closing arrow will not be drawn on the chart.</param>
        /// <returns></returns>
        public static bool OrderClose(this MqlHandler handler, int ticket, double lots, double price, int slippage, int color = 0)
        {
            string retrunValue = handler.CallMqlMethod("OrderClose", ticket, lots, price, slippage, color);

            return Convertor.ToBoolean(retrunValue);
        }

        /// <summary>
        /// Closes an opened order by another opposite opened order. If the function succeeds, the return value is true. If the function fails, the return value is false. To get the detailed error information, call GetLastError(). 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="ticket">Unique number of the order ticket.</param>
        /// <param name="opposite">Unique number of the opposite order ticket.</param>
        /// <param name="color">Color of the closing arrow on the chart. If the parameter is missing or has CLR_NONE value closing arrow will not be drawn on the chart.</param>
        /// <returns></returns>
        public static bool OrderCloseBy(this MqlHandler handler, int ticket, int opposite, int color = 0)
        {
            string retrunValue = handler.CallMqlMethod("OrderCloseBy", ticket, opposite, color);
            return Convertor.ToBoolean(retrunValue);
        }

        /// <summary>
        /// Returns close price for the currently selected order.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double OrderClosePrice(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("OrderClosePrice", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Returns close time for the currently selected order. If order close time is not 0 then the order selected and has been closed and retrieved from the account history. Open and pending orders close time is equal to 0.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static DateTime OrderCloseTime(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("OrderCloseTime", null);

            return Convertor.ToDateTime(retrunValue);
        }

        /// <summary>
        /// Returns comment for the selected order.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static string OrderComment(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("OrderComment", null);

            return retrunValue;
        }

        /// <summary>
        /// Returns calculated commission for the currently selected order.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double OrderCommission(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("OrderCommission", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Deletes previously opened pending order. If the function succeeds, the return value is true. If the function fails, the return value is false. To get the detailed error information, call GetLastError(). 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="ticket">Unique number of the order ticket.</param>
        /// <param name="color">Color of the arrow on the chart. If the parameter is missing or has CLR_NONE value arrow will not be drawn on the chart.</param>
        /// <returns></returns>
        public static bool OrderDelete(this MqlHandler handler, int ticket, int color = 0)
        {
            string retrunValue = handler.CallMqlMethod("OrderDelete", ticket, color);

            return Convertor.ToBoolean(retrunValue);
        }

        /// <summary>
        /// Returns expiration date for the selected pending order.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static DateTime OrderExpiration(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("OrderExpiration", null);

            return Convertor.ToDateTime(retrunValue);
        }

        /// <summary>
        /// Returns amount of lots for the selected order.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double OrderLots(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("OrderLots", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Returns an identifying (magic) number for the currently selected order.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int OrderMagicNumber(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("OrderMagicNumber", null);

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// Modification of characteristics for the previously opened position or pending orders. If the function succeeds, the returned value will be TRUE. If the function fails, the returned value will be FALSE. To get the detailed error information, call GetLastError() function.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="ticket">Unique number of the order ticket.</param>
        /// <param name="price">New open price of the pending order.</param>
        /// <param name="stoploss">New StopLoss level.</param>
        /// <param name="takeprofit">New TakeProfit level.</param>
        /// <param name="expiration">Pending order expiration time.</param>
        /// <param name="arrow_color">Arrow color for StopLoss/TakeProfit modifications in the chart. If the parameter is missing or has CLR_NONE value, the arrows will not be shown in the chart.</param>
        /// <returns></returns>
        public static bool OrderModify(this MqlHandler handler, int ticket, double price, double stoploss, double takeprofit, DateTime expiration=default(DateTime), int arrow_color=0)
        {
            string retrunValue = handler.CallMqlMethod("OrderModify", ticket, price, stoploss, takeprofit, expiration, arrow_color);

            return Convertor.ToBoolean(retrunValue);
        }

        /// <summary>
        /// Returns open price for the currently selected order.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double OrderOpenPrice(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("OrderOpenPrice", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Returns open time for the currently selected order.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static DateTime OrderOpenTime(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("OrderOpenTime", null);

            return Convertor.ToDateTime(retrunValue);
        }

        /// <summary>
        /// Prints information about the selected order in the log in the following format:
        /// </summary>
        /// <param name="handler"></param>
        public static void OrderPrint(this MqlHandler handler)
        {
            handler.CallMqlMethod("OrderPrint", null);
        }

        /// <summary>
        /// Returns the net profit value (without swaps or commissions) for the selected order. For open positions, it is the current unrealized profit. For closed orders, it is the fixed profit. Returns profit for the currently selected order.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double OrderProfit(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("OrderProfit", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// The function selects an order for further processing. It returns TRUE if the function succeeds. It returns FALSE if the function fails. To get the error information, one has to call the GetLastError() function.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="index">Order index or order ticket depending on the second parameter.</param>
        /// <param name="select">Selecting flags. It can be any of the following values:
        ///SELECT_BY_POS - index in the order pool,
        ///SELECT_BY_TICKET - index is order ticket.</param>
        /// <param name="pool">	Optional order pool index. Used when the selected parameter is SELECT_BY_POS. It can be any of the following values:
        ///MODE_TRADES (default)- order selected from trading pool(opened and pending orders),
        ///MODE_HISTORY - order selected from history pool (closed and canceled order).</param>
        /// <returns></returns>
        public static bool OrderSelect(this MqlHandler handler, int index, SELECT_BY select, POOL_MODES pool = POOL_MODES.MODE_TRADES)
        {
            string retrunValue = handler.CallMqlMethod("OrderSelect", index, (int)select, (int)pool);

            return Convertor.ToBoolean(retrunValue);
        }

        /// <summary>
        /// The main function used to open a position or place a pending order.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol">SYMBOL for trading.</param>
        /// <param name="cmd">Operation type. It can be any of the Trade operation enumeration.</param>
        /// <param name="volume">Number of lots.</param>
        /// <param name="price">Preferred price of the trade.</param>
        /// <param name="slippage">Maximum price slippage for buy or sell orders.</param>
        /// <param name="stoploss">Stop loss level.</param>
        /// <param name="takeprofit">Take profit level.</param>
        /// <param name="comment">Order comment text. Last part of the comment may be changed by server.</param>
        /// <param name="magic">Order magic number. May be used as user defined identifier.</param>
        /// <param name="expiration">Order expiration time (for pending orders only).</param>
        /// <param name="arrow_color">Color of the opening arrow on the chart. If parameter is missing or has CLR_NONE value opening arrow is not drawn on the chart.</param>
        /// <returns></returns>
        public static int OrderSend(this MqlHandler handler, string symbol, ORDER_TYPE cmd, double volume, double price, int slippage, double stoploss, double takeprofit, string comment = "", int magic = 0, DateTime expiration = default(DateTime), int arrow_color = 0)
        {
            string retrunValue = handler.CallMqlMethod("OrderSend", symbol, (int)cmd, volume, price, slippage, stoploss, takeprofit, comment, magic, expiration, arrow_color);

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// Returns the number of closed orders in the account history loaded into the terminal. The history list size depends on the current settings of the "Account history" tab of the terminal. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int HistoryTotal(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("HistoryTotal", null);

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// Returns stop loss value for the currently selected order.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double OrderStopLoss(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("OrderStopLoss", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Returns market and pending orders count.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int OrdersTotal(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("OrdersTotal", null);

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// Returns swap value for the currently selected order.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double OrderSwap(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("OrderSwap", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Returns the order symbol value for selected order.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static string OrderSymbol(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("OrderSymbol", null);

            return retrunValue;
        }

        /// <summary>
        /// Returns take profit value for the currently selected order.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double OrderTakeProfit(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("OrderTakeProfit", null);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Returns ticket number for the currently selected order.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int OrderTicket(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("OrderTicket", null);

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// Returns order operation type for the currently selected order.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static ORDER_TYPE OrderType(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("OrderType", null);

            return (ORDER_TYPE)Enum.Parse(typeof(ORDER_TYPE), retrunValue);
        }
    }
}