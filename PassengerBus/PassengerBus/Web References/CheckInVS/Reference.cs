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

namespace PassengerBus.CheckInVS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="WebServiceCheckInSoap", Namespace="http://tempuri.org/")]
    public partial class WebServiceCheckIn : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback RegistrateOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetVipsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetSimplePassengersOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCateringOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetBaggageOperationCompleted;
        
        private System.Threading.SendOrPostCallback ResetOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WebServiceCheckIn() {
            this.Url = global::PassengerBus.Properties.Settings.Default.PassengerBus_CheckInVS_WebServiceCheckIn;
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
        public event RegistrateCompletedEventHandler RegistrateCompleted;
        
        /// <remarks/>
        public event GetVipsCompletedEventHandler GetVipsCompleted;
        
        /// <remarks/>
        public event GetSimplePassengersCompletedEventHandler GetSimplePassengersCompleted;
        
        /// <remarks/>
        public event GetCateringCompletedEventHandler GetCateringCompleted;
        
        /// <remarks/>
        public event GetBaggageCompletedEventHandler GetBaggageCompleted;
        
        /// <remarks/>
        public event ResetCompletedEventHandler ResetCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Registrate", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Registrate(Passenger passenger) {
            object[] results = this.Invoke("Registrate", new object[] {
                        passenger});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void RegistrateAsync(Passenger passenger) {
            this.RegistrateAsync(passenger, null);
        }
        
        /// <remarks/>
        public void RegistrateAsync(Passenger passenger, object userState) {
            if ((this.RegistrateOperationCompleted == null)) {
                this.RegistrateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRegistrateOperationCompleted);
            }
            this.InvokeAsync("Registrate", new object[] {
                        passenger}, this.RegistrateOperationCompleted, userState);
        }
        
        private void OnRegistrateOperationCompleted(object arg) {
            if ((this.RegistrateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RegistrateCompleted(this, new RegistrateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetVips", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Guid[] GetVips(System.Guid flightNumber) {
            object[] results = this.Invoke("GetVips", new object[] {
                        flightNumber});
            return ((System.Guid[])(results[0]));
        }
        
        /// <remarks/>
        public void GetVipsAsync(System.Guid flightNumber) {
            this.GetVipsAsync(flightNumber, null);
        }
        
        /// <remarks/>
        public void GetVipsAsync(System.Guid flightNumber, object userState) {
            if ((this.GetVipsOperationCompleted == null)) {
                this.GetVipsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetVipsOperationCompleted);
            }
            this.InvokeAsync("GetVips", new object[] {
                        flightNumber}, this.GetVipsOperationCompleted, userState);
        }
        
        private void OnGetVipsOperationCompleted(object arg) {
            if ((this.GetVipsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetVipsCompleted(this, new GetVipsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetSimplePassengers", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Guid[] GetSimplePassengers(System.Guid flightNumber) {
            object[] results = this.Invoke("GetSimplePassengers", new object[] {
                        flightNumber});
            return ((System.Guid[])(results[0]));
        }
        
        /// <remarks/>
        public void GetSimplePassengersAsync(System.Guid flightNumber) {
            this.GetSimplePassengersAsync(flightNumber, null);
        }
        
        /// <remarks/>
        public void GetSimplePassengersAsync(System.Guid flightNumber, object userState) {
            if ((this.GetSimplePassengersOperationCompleted == null)) {
                this.GetSimplePassengersOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSimplePassengersOperationCompleted);
            }
            this.InvokeAsync("GetSimplePassengers", new object[] {
                        flightNumber}, this.GetSimplePassengersOperationCompleted, userState);
        }
        
        private void OnGetSimplePassengersOperationCompleted(object arg) {
            if ((this.GetSimplePassengersCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSimplePassengersCompleted(this, new GetSimplePassengersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetCatering", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Catering GetCatering(System.Guid flightNumber) {
            object[] results = this.Invoke("GetCatering", new object[] {
                        flightNumber});
            return ((Catering)(results[0]));
        }
        
        /// <remarks/>
        public void GetCateringAsync(System.Guid flightNumber) {
            this.GetCateringAsync(flightNumber, null);
        }
        
        /// <remarks/>
        public void GetCateringAsync(System.Guid flightNumber, object userState) {
            if ((this.GetCateringOperationCompleted == null)) {
                this.GetCateringOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCateringOperationCompleted);
            }
            this.InvokeAsync("GetCatering", new object[] {
                        flightNumber}, this.GetCateringOperationCompleted, userState);
        }
        
        private void OnGetCateringOperationCompleted(object arg) {
            if ((this.GetCateringCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCateringCompleted(this, new GetCateringCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetBaggage", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int GetBaggage(System.Guid flightNumber) {
            object[] results = this.Invoke("GetBaggage", new object[] {
                        flightNumber});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void GetBaggageAsync(System.Guid flightNumber) {
            this.GetBaggageAsync(flightNumber, null);
        }
        
        /// <remarks/>
        public void GetBaggageAsync(System.Guid flightNumber, object userState) {
            if ((this.GetBaggageOperationCompleted == null)) {
                this.GetBaggageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBaggageOperationCompleted);
            }
            this.InvokeAsync("GetBaggage", new object[] {
                        flightNumber}, this.GetBaggageOperationCompleted, userState);
        }
        
        private void OnGetBaggageOperationCompleted(object arg) {
            if ((this.GetBaggageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetBaggageCompleted(this, new GetBaggageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Reset", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Passenger {
        
        private System.Guid idField;
        
        private PassengerState stateField;
        
        private Food preferFoodField;
        
        private int weightBaggageField;
        
        private Ticket ticketField;
        
        /// <remarks/>
        public System.Guid ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public PassengerState State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
        
        /// <remarks/>
        public Food PreferFood {
            get {
                return this.preferFoodField;
            }
            set {
                this.preferFoodField = value;
            }
        }
        
        /// <remarks/>
        public int WeightBaggage {
            get {
                return this.weightBaggageField;
            }
            set {
                this.weightBaggageField = value;
            }
        }
        
        /// <remarks/>
        public Ticket Ticket {
            get {
                return this.ticketField;
            }
            set {
                this.ticketField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum PassengerState {
        
        /// <remarks/>
        Created,
        
        /// <remarks/>
        Buy,
        
        /// <remarks/>
        Registered,
        
        /// <remarks/>
        Onboard,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum Food {
        
        /// <remarks/>
        Diabetic,
        
        /// <remarks/>
        Vegetarian,
        
        /// <remarks/>
        Children,
        
        /// <remarks/>
        LowCalorie,
        
        /// <remarks/>
        Default,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum Class {
        
        /// <remarks/>
        Vip,
        
        /// <remarks/>
        Econom,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Catering {
        
        private int diabeticField;
        
        private int vegetarianField;
        
        private int childrenField;
        
        private int lowCalorieField;
        
        private int defaultField;
        
        /// <remarks/>
        public int Diabetic {
            get {
                return this.diabeticField;
            }
            set {
                this.diabeticField = value;
            }
        }
        
        /// <remarks/>
        public int Vegetarian {
            get {
                return this.vegetarianField;
            }
            set {
                this.vegetarianField = value;
            }
        }
        
        /// <remarks/>
        public int Children {
            get {
                return this.childrenField;
            }
            set {
                this.childrenField = value;
            }
        }
        
        /// <remarks/>
        public int LowCalorie {
            get {
                return this.lowCalorieField;
            }
            set {
                this.lowCalorieField = value;
            }
        }
        
        /// <remarks/>
        public int Default {
            get {
                return this.defaultField;
            }
            set {
                this.defaultField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void RegistrateCompletedEventHandler(object sender, RegistrateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RegistrateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RegistrateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetVipsCompletedEventHandler(object sender, GetVipsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetVipsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetVipsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Guid[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Guid[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetSimplePassengersCompletedEventHandler(object sender, GetSimplePassengersCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSimplePassengersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSimplePassengersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Guid[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Guid[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetCateringCompletedEventHandler(object sender, GetCateringCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCateringCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCateringCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Catering Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Catering)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetBaggageCompletedEventHandler(object sender, GetBaggageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetBaggageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetBaggageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void ResetCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591