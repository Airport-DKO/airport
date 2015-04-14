﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.18444.
// 
#pragma warning disable 1591

namespace VIPShuttle.MetrologServiceVS {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MetrologServiceSoap", Namespace="Airport-Metrological-Service")]
    public partial class MetrologService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetCurrentTimeOperationCompleted;
        
        private System.Threading.SendOrPostCallback RefreshTickOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCurrentTickOperationCompleted;
        
        private System.Threading.SendOrPostCallback ResetOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MetrologService() {
            this.Url = global::VIPShuttle.Properties.Settings.Default.VIPShuttle_MetrologServiceVS_MetrologService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetCurrentTimeCompletedEventHandler GetCurrentTimeCompleted;
        
        /// <remarks/>
        public event RefreshTickCompletedEventHandler RefreshTickCompleted;
        
        /// <remarks/>
        public event GetCurrentTickCompletedEventHandler GetCurrentTickCompleted;
        
        /// <remarks/>
        public event ResetCompletedEventHandler ResetCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Airport-Metrological-Service/GetCurrentTime", RequestNamespace="Airport-Metrological-Service", ResponseNamespace="Airport-Metrological-Service", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.DateTime GetCurrentTime() {
            object[] results = this.Invoke("GetCurrentTime", new object[0]);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        public void GetCurrentTimeAsync() {
            this.GetCurrentTimeAsync(null);
        }
        
        /// <remarks/>
        public void GetCurrentTimeAsync(object userState) {
            if ((this.GetCurrentTimeOperationCompleted == null)) {
                this.GetCurrentTimeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCurrentTimeOperationCompleted);
            }
            this.InvokeAsync("GetCurrentTime", new object[0], this.GetCurrentTimeOperationCompleted, userState);
        }
        
        private void OnGetCurrentTimeOperationCompleted(object arg) {
            if ((this.GetCurrentTimeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCurrentTimeCompleted(this, new GetCurrentTimeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Airport-Metrological-Service/RefreshTick", RequestNamespace="Airport-Metrological-Service", ResponseNamespace="Airport-Metrological-Service", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void RefreshTick(double coeff) {
            this.Invoke("RefreshTick", new object[] {
                        coeff});
        }
        
        /// <remarks/>
        public void RefreshTickAsync(double coeff) {
            this.RefreshTickAsync(coeff, null);
        }
        
        /// <remarks/>
        public void RefreshTickAsync(double coeff, object userState) {
            if ((this.RefreshTickOperationCompleted == null)) {
                this.RefreshTickOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRefreshTickOperationCompleted);
            }
            this.InvokeAsync("RefreshTick", new object[] {
                        coeff}, this.RefreshTickOperationCompleted, userState);
        }
        
        private void OnRefreshTickOperationCompleted(object arg) {
            if ((this.RefreshTickCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RefreshTickCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Airport-Metrological-Service/GetCurrentTick", RequestNamespace="Airport-Metrological-Service", ResponseNamespace="Airport-Metrological-Service", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public double GetCurrentTick() {
            object[] results = this.Invoke("GetCurrentTick", new object[0]);
            return ((double)(results[0]));
        }
        
        /// <remarks/>
        public void GetCurrentTickAsync() {
            this.GetCurrentTickAsync(null);
        }
        
        /// <remarks/>
        public void GetCurrentTickAsync(object userState) {
            if ((this.GetCurrentTickOperationCompleted == null)) {
                this.GetCurrentTickOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCurrentTickOperationCompleted);
            }
            this.InvokeAsync("GetCurrentTick", new object[0], this.GetCurrentTickOperationCompleted, userState);
        }
        
        private void OnGetCurrentTickOperationCompleted(object arg) {
            if ((this.GetCurrentTickCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCurrentTickCompleted(this, new GetCurrentTickCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Airport-Metrological-Service/Reset", RequestNamespace="Airport-Metrological-Service", ResponseNamespace="Airport-Metrological-Service", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Reset() {
            this.Invoke("Reset", new object[0]);
        }
        
        /// <remarks/>
        public void ResetAsync() {
            this.ResetAsync(null);
        }
        
        /// <remarks/>
        public void ResetAsync(object userState) {
            if ((this.ResetOperationCompleted == null)) {
                this.ResetOperationCompleted = new System.Threading.SendOrPostCallback(this.OnResetOperationCompleted);
            }
            this.InvokeAsync("Reset", new object[0], this.ResetOperationCompleted, userState);
        }
        
        private void OnResetOperationCompleted(object arg) {
            if ((this.ResetCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ResetCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetCurrentTimeCompletedEventHandler(object sender, GetCurrentTimeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCurrentTimeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCurrentTimeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.DateTime Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.DateTime)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void RefreshTickCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetCurrentTickCompletedEventHandler(object sender, GetCurrentTickCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCurrentTickCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCurrentTickCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public double Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void ResetCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591