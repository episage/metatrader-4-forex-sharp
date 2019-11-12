using TradePlatform.MT4.Core;
using TradePlatform.MT4.Core.Utils;

namespace TradePlatform.MT4.SDK.API
{
	/// <summary>
    ///  A group of functions intended for calculation of standard and custom indicators.
    /// </summary>
    /// NOT IMPLEMENTED ARRAY INDICATORS AND iCustom
    public static class TechnicalIndicators
    {
        /// <summary>
        /// Calculates the Bill Williams' Accelerator/Decelerator oscillator. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iAC(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iAC", symbol, ((int)timeframe), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Accumulation/Distribution indicator and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iAD(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iAD", symbol, ((int)timeframe), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Bill Williams' Alligator and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="jaw_period"></param>
        /// <param name="jaw_shift"></param>
        /// <param name="teeth_period"></param>
        /// <param name="teeth_shift"></param>
        /// <param name="lips_period"></param>
        /// <param name="lips_shift"></param>
        /// <param name="ma_method"></param>
        /// <param name="appliedApplyPrice"></param>
        /// <param name="mode"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iAlligator(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int jaw_period, int jaw_shift, int teeth_period, int teeth_shift, int lips_period, int lips_shift, MA_METHOD ma_method, APPLY_PRICE appliedApplyPrice, GATOR_MODE mode, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iAlligator", symbol, ((int)timeframe), jaw_period, jaw_shift, teeth_period, teeth_shift, lips_period, lips_shift, ((int)ma_method), ((int)appliedApplyPrice), ((int)mode), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Movement directional index and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="period"></param>
        /// <param name="appliedApplyPrice"></param>
        /// <param name="mode"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iADX(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int period, APPLY_PRICE appliedApplyPrice, ADX_MODE mode, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iADX", symbol, ((int)timeframe), period, ((int)appliedApplyPrice), ((int)mode), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Indicator of the average true range and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="period"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iATR(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int period, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iATR", symbol, ((int)timeframe), period, shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Bill Williams' Awesome oscillator and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iAO(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iAO", symbol, ((int)timeframe), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Bears Power indicator and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="period"></param>
        /// <param name="appliedApplyPrice"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iBearsPower(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int period, APPLY_PRICE appliedApplyPrice, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iBearsPower", symbol, ((int)timeframe), period, shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Bollinger bands® indicator and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="period"></param>
        /// <param name="deviation"></param>
        /// <param name="bands_shift"></param>
        /// <param name="appliedApplyPrice"></param>
        /// <param name="mode"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iBands(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int period, int deviation, int bands_shift, APPLY_PRICE appliedApplyPrice, BAND_MODE mode, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iBands", symbol, ((int)timeframe), period, deviation, bands_shift, ((int)appliedApplyPrice), ((int)mode), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Bulls Power indicator and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="period"></param>
        /// <param name="appliedApplyPrice"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iBullsPower(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int period, APPLY_PRICE appliedApplyPrice, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iBullsPower", symbol, ((int)timeframe), period, ((int)appliedApplyPrice), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Commodity channel index and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="period"></param>
        /// <param name="appliedApplyPrice"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iCCI(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int period, APPLY_PRICE appliedApplyPrice, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iCCI", symbol, ((int)timeframe), period, ((int)appliedApplyPrice), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the DeMarker indicator and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="period"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iDeMarker(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int period, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iDeMarker", symbol, ((int)timeframe), period, shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Envelopes indicator and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="ma_period"></param>
        /// <param name="ma_method"></param>
        /// <param name="ma_shift"></param>
        /// <param name="appliedApplyPrice"></param>
        /// <param name="deviation"></param>
        /// <param name="mode"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iEnvelopes(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int ma_period, MA_METHOD ma_method, int ma_shift, APPLY_PRICE appliedApplyPrice, double deviation, BAND_MODE mode, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iEnvelopes", symbol, ((int)timeframe), ma_period, ((int)ma_method), ma_shift, ((int)appliedApplyPrice), deviation, ((int)mode), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Force index and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="period"></param>
        /// <param name="ma_method"></param>
        /// <param name="appliedApplyPrice"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iForce(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int period, MA_METHOD ma_method, APPLY_PRICE appliedApplyPrice, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iForce", symbol, ((int)timeframe), period, ((int)ma_method), ((int)appliedApplyPrice), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Fractals and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="mode"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iFractals(this MqlHandler handler, string symbol, TIME_FRAME timeframe, BAND_MODE mode, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iFractals", symbol, ((int)timeframe), ((int)mode), shift);

            return Convertor.ToDouble(retrunValue);
        }
        
        /// <summary>
        /// Gator oscillator calculation. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="jaw_period"></param>
        /// <param name="jaw_shift"></param>
        /// <param name="teeth_period"></param>
        /// <param name="teeth_shift"></param>
        /// <param name="lips_period"></param>
        /// <param name="lips_shift"></param>
        /// <param name="ma_method"></param>
        /// <param name="appliedApplyPrice"></param>
        /// <param name="mode"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iGator(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int jaw_period, int jaw_shift, int teeth_period, int teeth_shift, int lips_period, int lips_shift, MA_METHOD ma_method, APPLY_PRICE appliedApplyPrice, BAND_MODE mode, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iGator", symbol, ((int)timeframe), jaw_period, jaw_shift, teeth_period, teeth_shift, lips_period, lips_shift, ((int)ma_method), ((int)appliedApplyPrice), ((int)mode), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Ichimoku Kinko Hyo and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="tenkan_sen"></param>
        /// <param name="kijun_sen"></param>
        /// <param name="senkou_span_b"></param>
        /// <param name="mode"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iIchimoku(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int tenkan_sen, int kijun_sen, int senkou_span_b, ICHIMOKU_MODE mode, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iIchimoku", symbol, ((int)timeframe), tenkan_sen, kijun_sen, senkou_span_b, ((int)mode), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Bill Williams Market Facilitation index and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iBWMFI(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iBWMFI", symbol, ((int)timeframe), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Momentum indicator and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="period"></param>
        /// <param name="appliedApplyPrice"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iMomentum(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int period, APPLY_PRICE appliedApplyPrice, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iMomentum", symbol, ((int)timeframe), period, ((int)appliedApplyPrice), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Money flow index and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="period"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iMFI(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int period, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iMFI", symbol, ((int)timeframe), period, shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Moving average indicator and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="period"></param>
        /// <param name="ma_shift"></param>
        /// <param name="ma_method"></param>
        /// <param name="appliedApplyPrice"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iMA(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int period, int ma_shift, MA_METHOD ma_method, APPLY_PRICE appliedApplyPrice, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iMA", symbol, ((int)timeframe), period, ma_shift, ((int)ma_method), ((int)appliedApplyPrice), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Moving Average of Oscillator and returns its value. Sometimes called MACD Histogram in some systems. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="fast_ema_period"></param>
        /// <param name="slow_ema_period"></param>
        /// <param name="signal_period"></param>
        /// <param name="appliedApplyPrice"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iOsMA(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int fast_ema_period, int slow_ema_period, int signal_period, APPLY_PRICE appliedApplyPrice, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iOsMA", symbol, ((int)timeframe), fast_ema_period, slow_ema_period, signal_period, ((int)appliedApplyPrice), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Moving averages convergence/divergence and returns its value.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="fast_ema_period"></param>
        /// <param name="slow_ema_period"></param>
        /// <param name="signal_period"></param>
        /// <param name="appliedApplyPrice"></param>
        /// <param name="mode"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iMACD(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int fast_ema_period, int slow_ema_period, int signal_period, APPLY_PRICE appliedApplyPrice, MACD_MODE mode, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iMACD", symbol, ((int)timeframe), fast_ema_period, slow_ema_period, signal_period, ((int)appliedApplyPrice), ((int)mode), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the On Balance Volume indicator and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="appliedApplyPrice"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iOBV(this MqlHandler handler, string symbol, TIME_FRAME timeframe, APPLY_PRICE appliedApplyPrice, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iOBV", symbol, ((int)timeframe), ((int)appliedApplyPrice), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Parabolic Stop and Reverse system and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="step"></param>
        /// <param name="maximum"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iSAR(this MqlHandler handler, string symbol, TIME_FRAME timeframe, double step, double maximum, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iSAR", symbol, ((int)timeframe), step, maximum, shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Relative strength index and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="period"></param>
        /// <param name="appliedApplyPrice"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iRSI(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int period, APPLY_PRICE appliedApplyPrice, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iRSI", symbol, ((int)timeframe), period, ((int)appliedApplyPrice), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Relative Vigor index and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="period"></param>
        /// <param name="mode"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iRVI(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int period, MACD_MODE mode, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iRVI", symbol, ((int)timeframe), period, ((int)mode), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Standard Deviation indicator and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="ma_period"></param>
        /// <param name="ma_shift"></param>
        /// <param name="ma_method"></param>
        /// <param name="appliedApplyPrice"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iStdDev(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int ma_period, int ma_shift, MA_METHOD ma_method, APPLY_PRICE appliedApplyPrice, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iStdDev", symbol, ((int)timeframe), ma_period, ma_shift, ((int)ma_method), ((int)appliedApplyPrice), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Stochastic oscillator and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="Kperiod"></param>
        /// <param name="Dperiod"></param>
        /// <param name="slowing"></param>
        /// <param name="method"></param>
        /// <param name="applyPriceField"></param>
        /// <param name="mode"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iStochastic(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int Kperiod, int Dperiod, int slowing, MA_METHOD method, APPLY_PRICE applyPriceField, MACD_MODE mode, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iStochastic", symbol, ((int)timeframe), Kperiod, Dperiod, slowing, ((int)method), applyPriceField, ((int)mode), shift);

            return Convertor.ToDouble(retrunValue);
        }

        /// <summary>
        /// Calculates the Larry William's percent range indicator and returns its value. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="symbol"></param>
        /// <param name="timeframe"></param>
        /// <param name="period"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static double iWPR(this MqlHandler handler, string symbol, TIME_FRAME timeframe, int period, int shift)
        {
            string retrunValue = handler.CallMqlMethod("iWPR", symbol, ((int)timeframe), period, shift);

            return Convertor.ToDouble(retrunValue);
        }
    }
}
