using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradePlatform.MT4.Core;
using TradePlatform.MT4.Core.Utils;

namespace TradePlatform.MT4.SDK.API
{
	/// <summary>
    /// General-purpose functions not included into any specialized groups. 
    /// </summary>
    public static class CommonFunctions
    {
        /// <summary>
        /// Displays a dialog box containing the user-defined data. Parameters can be of any type.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="message"> </param>
        public static void Alert(this MqlHandler handler, string message)
        {
            string retrunValue = handler.CallMqlMethod("Alert", message);
        }

        /// <summary>
        /// The function outputs the comment defined by the user in the left top corner of the chart. Parameters can be of any type.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="message"> </param>
        public static void Comment(this MqlHandler handler, string message)
        {
            string retrunValue = handler.CallMqlMethod("Comment", message);
        }

        /// <summary>
        /// The GetTickCount() function retrieves the number of milliseconds that have elapsed since the system was started. It is limited to the resolution of the system timer. 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static int GetTickCount(this MqlHandler handler)
        {
            string retrunValue = handler.CallMqlMethod("GetTickCount", null);

            return Convertor.ToInt(retrunValue);
        }

        /// <summary>
        /// Returns various data about securities listed in the Market Watch window. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static double MarketInfo(this MqlHandler handler, string symbol, MARKER_INFO_MODE mode)
        {
            string retrunValue = handler.CallMqlMethod("MarketInfo", symbol, (int)mode);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Function plays a sound file. The file must be located in the terminal_dir\sounds directory or in its subdirectory. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="filename"></param>
        public static void PlaySound(this MqlHandler handler, string filename)
        {
            string retrunValue = handler.CallMqlMethod("PlaySound", filename);
        }

        /// <summary>
        /// Prints a message to the experts log. Parameters can be of any type.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="message"> </param>
        public static void Print(this MqlHandler handler, string message)
        {
            string retrunValue = handler.CallMqlMethod("Print", message);
        }

        /// <summary>
        /// Sends Push notification to mobile terminals whose MetaQuotes IDs are specified on the "Notifications" tab in options window. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="notification"></param>
        /// <returns></returns>
        public static bool SendNotification(this MqlHandler handler, string notification)
        {
            string retrunValue = handler.CallMqlMethod("SendNotification", notification);

            return Convertor.ToBoolean(retrunValue);
        }
    }
}
