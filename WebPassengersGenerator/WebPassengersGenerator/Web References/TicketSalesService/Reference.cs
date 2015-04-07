﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.34014.
// 
#pragma warning disable 1591

namespace WebPassengersGenerator.TicketSalesService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WebServiceTicketSalesSoap", Namespace="http://tempuri.org/")]
    public partial class WebServiceTicketSales : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback BuyTicketOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReturnTicketOperationCompleted;
        
        private System.Threading.SendOrPostCallback CheckTicketOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WebServiceTicketSales() {
            this.Url = global::WebPassengersGenerator.Properties.Settings.Default.WebPassengersGenerator_TicketSalesService_WebServiceTicketSales;
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
        public event BuyTicketCompletedEventHandler BuyTicketCompleted;
        
        /// <remarks/>
        public event ReturnTicketCompletedEventHandler ReturnTicketCompleted;
        
        /// <remarks/>
        public event CheckTicketCompletedEventHandler CheckTicketCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/BuyTicket", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Ticket BuyTicket(System.Guid passengerId) {
            object[] results = this.Invoke("BuyTicket", new object[] {
                        passengerId});
            return ((Ticket)(results[0]));
        }
        
        /// <remarks/>
        public void BuyTicketAsync(System.Guid passengerId) {
            this.BuyTicketAsync(passengerId, null);
        }
        
        /// <remarks/>
        public void BuyTicketAsync(System.Guid passengerId, object userState) {
            if ((this.BuyTicketOperationCompleted == null)) {
                this.BuyTicketOperationCompleted = new System.Threading.SendOrPostCallback(this.OnBuyTicketOperationCompleted);
            }
            this.InvokeAsync("BuyTicket", new object[] {
                        passengerId}, this.BuyTicketOperationCompleted, userState);
        }
        
        private void OnBuyTicketOperationCompleted(object arg) {
            if ((this.BuyTicketCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.BuyTicketCompleted(this, new BuyTicketCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ReturnTicket", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ReturnTicket(System.Guid passengerId) {
            object[] results = this.Invoke("ReturnTicket", new object[] {
                        passengerId});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ReturnTicketAsync(System.Guid passengerId) {
            this.ReturnTicketAsync(passengerId, null);
        }
        
        /// <remarks/>
        public void ReturnTicketAsync(System.Guid passengerId, object userState) {
            if ((this.ReturnTicketOperationCompleted == null)) {
                this.ReturnTicketOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReturnTicketOperationCompleted);
            }
            this.InvokeAsync("ReturnTicket", new object[] {
                        passengerId}, this.ReturnTicketOperationCompleted, userState);
        }
        
        private void OnReturnTicketOperationCompleted(object arg) {
            if ((this.ReturnTicketCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReturnTicketCompleted(this, new ReturnTicketCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CheckTicket", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool CheckTicket(System.Guid passengerid, System.Guid fligthid) {
            object[] results = this.Invoke("CheckTicket", new object[] {
                        passengerid,
                        fligthid});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void CheckTicketAsync(System.Guid passengerid, System.Guid fligthid) {
            this.CheckTicketAsync(passengerid, fligthid, null);
        }
        
        /// <remarks/>
        public void CheckTicketAsync(System.Guid passengerid, System.Guid fligthid, object userState) {
            if ((this.CheckTicketOperationCompleted == null)) {
                this.CheckTicketOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheckTicketOperationCompleted);
            }
            this.InvokeAsync("CheckTicket", new object[] {
                        passengerid,
                        fligthid}, this.CheckTicketOperationCompleted, userState);
        }
        
        private void OnCheckTicketOperationCompleted(object arg) {
            if ((this.CheckTicketCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CheckTicketCompleted(this, new CheckTicketCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Ticket {
        
        private System.Guid passengerIDField;
        
        private System.Guid flightIDField;
        
        private Class ticketClassField;
        
        /// <remarks/>
        public System.Guid PassengerID {
            get {
                return this.passengerIDField;
            }
            set {
                this.passengerIDField = value;
            }
        }
        
        /// <remarks/>
        public System.Guid FlightID {
            get {
                return this.flightIDField;
            }
            set {
                this.flightIDField = value;
            }
        }
        
        /// <remarks/>
        public Class TicketClass {
            get {
                return this.ticketClassField;
            }
            set {
                this.ticketClassField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum Class {
        
        /// <remarks/>
        Vip,
        
        /// <remarks/>
        Econom,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void BuyTicketCompletedEventHandler(object sender, BuyTicketCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class BuyTicketCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal BuyTicketCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Ticket Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Ticket)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void ReturnTicketCompletedEventHandler(object sender, ReturnTicketCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReturnTicketCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReturnTicketCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void CheckTicketCompletedEventHandler(object sender, CheckTicketCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CheckTicketCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CheckTicketCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591