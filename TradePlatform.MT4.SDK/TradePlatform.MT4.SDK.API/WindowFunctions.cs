using TradePlatform.MT4.Core;
using TradePlatform.MT4.Core.Utils;

namespace TradePlatform.MT4.SDK.API
{
    using System;

    /// <summary>
    /// A group of functions intended for working with the current chart window. 
    /// </summary>
    public static class WindowFunctions
    {
        /// <summary>
        /// The function sets a flag hiding indicators called by the Expert Advisor. 
        /// </summary>
        /// <param name="handler"> </param>
        /// <param name="hide"></param>
        public static void HideTestIndicators(this MqlHandler handler, bool hide)
        {
            string retrunValue = handler.CallMqlMethod("HideTestIndicators", hide ? 1 : 0);
        }

        /// <summary>
        /// Returns the amount of minutes determining the used period (chart timeframe). 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int Period(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("Period");

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// Refreshing of data in pre-defined variables and series arrays. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static bool RefreshRates(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("RefreshRates");

            return Convertor.ToBoolean(retrunValue);
        }

        /// <summary>
        /// Returns a text string with the name of the current financial instrument. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static string Symbol(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("Symbol");

            return retrunValue;
        }

        /// <summary>
        /// Function returns the amount of bars visible on the chart. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int WindowBarsPerChart(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("WindowBarsPerChart");

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// Returns name of the executed expert, script, custom indicator, or library, depending on the MQL4 program, from which this function has been called. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static string WindowExpertName(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("WindowExpertName");

            return retrunValue;
        }

        /// <summary>
        /// If indicator with name was found, the function returns the window index containing this specified indicator, otherwise it returns -1.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int WindowFind(this MqlHandler handler, string name)
        {
            string retrunValue = handler.CallMqlMethod("WindowFind", name);

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// The function returns the first visible bar number in the current chart window.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int WindowFirstVisibleBar(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("WindowFirstVisibleBar");

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// Returns the system window handler containing the given chart.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <returns></returns>
        public static int WindowHandle(this MqlHandler handler, string symbol, TIME_FRAME timeframe)
        {
            string retrunValue = handler.CallMqlMethod("WindowHandle", symbol, ((int)timeframe));

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// Returns TRUE if the chart subwindow is visible, otherwise returns FALSE.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool WindowIsVisible(this MqlHandler handler, int index)
        {
            string retrunValue = handler.CallMqlMethod("WindowIsVisible", index);

            return Convertor.ToBoolean(retrunValue);
        }

        /// <summary>
        /// Returns window index where expert, custom indicator or script was dropped. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int WindowOnDropped(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("WindowOnDropped");

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// Returns maximal value of the vertical scale of the specified subwindow of the current chart (0-main chart window, the indicators' subwindows are numbered starting from 1). 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static double WindowPriceMax(this MqlHandler handler, int index = 0)
        {
            string retrunValue = handler.CallMqlMethod("WindowPriceMax", index);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Returns minimal value of the vertical scale of the specified subwindow of the current chart (0-main chart window, the indicators' subwindows are numbered starting from 1).
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static double WindowPriceMin(this MqlHandler handler, int index = 0)
        {
            string retrunValue = handler.CallMqlMethod("WindowPriceMin", index);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Returns the price part of the chart point where expert or script was dropped.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static double WindowPriceOnDropped(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("WindowPriceOnDropped");

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Redraws the current chart forcedly. It is normally used after the objects properties have been changed. 
        /// </summary>
        /// <param name="handler"></param>
        public static void WindowRedraw(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("WindowRedraw");
        }

        /// <summary>
        /// Saves current chart screen shot as a GIF file. Returns FALSE if it fails. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="filename"></param>
        /// <param name="size_x"></param>
        /// <param name="size_y"></param>
        /// <param name="start_bar"></param>
        /// <param name="chart_scale"></param>
        /// <param name="chart_mode"></param>
        /// <returns></returns>
        public static bool WindowScreenShot(this MqlHandler handler, string filename, int size_x, int size_y, int start_bar = -1, int chart_scale = -1, int chart_mode = -1)
        {
            string retrunValue = handler.CallMqlMethod("WindowScreenShot", filename, size_x, size_y, start_bar, chart_scale, chart_mode);

            return Convertor.ToBoolean(retrunValue);
        }

        /// <summary>
        /// Returns the time part of the chart point where expert or script was dropped.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static DateTime WindowTimeOnDropped(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("WindowTimeOnDropped");

            return Convertor.ToDateTime(retrunValue);
        }

        /// <summary>
        /// Returns count of indicator windows on the chart (including main chart). 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int WindowsTotal(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("WindowsTotal");

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// Returns the value at X axis in pixels for the chart window client area point at which the expert or script was dropped. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int WindowXOnDropped(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("WindowXOnDropped");

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// Returns the value at Y axis in pixels for the chart window client area point at which the expert or script was dropped. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int WindowYOnDropped(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("WindowYOnDropped");

            return Convertor.ToInt(retrunValue);
        }
    }
}
