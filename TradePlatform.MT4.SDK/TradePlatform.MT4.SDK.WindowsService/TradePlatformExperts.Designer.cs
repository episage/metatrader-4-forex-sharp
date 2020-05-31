using System;
using System.Diagnostics;
using System.IO;
using log4net;

namespace TradePlatform.MT4.SDK.WindowsService
{
    partial class TradePlatformExperts
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.ServiceName = "TradePlatformExperts";
            this.EventLog.Source = "TradePlatformExperts";
            this.EventLog.Log = "TradePlatformExpertsLog";
        }

        #endregion
    }
}
