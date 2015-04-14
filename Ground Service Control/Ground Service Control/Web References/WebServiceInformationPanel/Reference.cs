﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.34209.
// 
#pragma warning disable 1591

namespace Ground_Service_Control.WebServiceInformationPanel {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WebServiceInformationPanelSoap", Namespace="http://tempuri.org/")]
    public partial class WebServiceInformationPanel : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetFlightsForRegistrationOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetFlightsForSalesOperationCompleted;
        
        private System.Threading.SendOrPostCallback IsFlightSoonOperationCompleted;
        
        private System.Threading.SendOrPostCallback IsCheckInFinishedOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateFlightOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAvailableFlightsOperationCompleted;
        
        private System.Threading.SendOrPostCallback RegisterPlaneToFlightOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReadyToTakeOffOperationCompleted;
        
        private System.Threading.SendOrPostCallback ResetOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WebServiceInformationPanel() {
            this.Url = global::Ground_Service_Control.Properties.Settings.Default.Ground_Service_Control_WebServiceInformationPanel_WebServiceInformationPanel;
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
        public event GetFlightsForRegistrationCompletedEventHandler GetFlightsForRegistrationCompleted;
        
        /// <remarks/>
        public event GetFlightsForSalesCompletedEventHandler GetFlightsForSalesCompleted;
        
        /// <remarks/>
        public event IsFlightSoonCompletedEventHandler IsFlightSoonCompleted;
        
        /// <remarks/>
        public event IsCheckInFinishedCompletedEventHandler IsCheckInFinishedCompleted;
        
        /// <remarks/>
        public event CreateFlightCompletedEventHandler CreateFlightCompleted;
        
        /// <remarks/>
        public event GetAvailableFlightsCompletedEventHandler GetAvailableFlightsCompleted;
        
        /// <remarks/>
        public event RegisterPlaneToFlightCompletedEventHandler RegisterPlaneToFlightCompleted;
        
        /// <remarks/>
        public event ReadyToTakeOffCompletedEventHandler ReadyToTakeOffCompleted;
        
        /// <remarks/>
        public event ResetCompletedEventHandler ResetCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetFlightsForRegistration", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Flight[] GetFlightsForRegistration() {
            object[] results = this.Invoke("GetFlightsForRegistration", new object[0]);
            return ((Flight[])(results[0]));
        }
        
        /// <remarks/>
        public void GetFlightsForRegistrationAsync() {
            this.GetFlightsForRegistrationAsync(null);
        }
        
        /// <remarks/>
        public void GetFlightsForRegistrationAsync(object userState) {
            if ((this.GetFlightsForRegistrationOperationCompleted == null)) {
                this.GetFlightsForRegistrationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetFlightsForRegistrationOperationCompleted);
            }
            this.InvokeAsync("GetFlightsForRegistration", new object[0], this.GetFlightsForRegistrationOperationCompleted, userState);
        }
        
        private void OnGetFlightsForRegistrationOperationCompleted(object arg) {
            if ((this.GetFlightsForRegistrationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetFlightsForRegistrationCompleted(this, new GetFlightsForRegistrationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetFlightsForSales", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Flight[] GetFlightsForSales() {
            object[] results = this.Invoke("GetFlightsForSales", new object[0]);
            return ((Flight[])(results[0]));
        }
        
        /// <remarks/>
        public void GetFlightsForSalesAsync() {
            this.GetFlightsForSalesAsync(null);
        }
        
        /// <remarks/>
        public void GetFlightsForSalesAsync(object userState) {
            if ((this.GetFlightsForSalesOperationCompleted == null)) {
                this.GetFlightsForSalesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetFlightsForSalesOperationCompleted);
            }
            this.InvokeAsync("GetFlightsForSales", new object[0], this.GetFlightsForSalesOperationCompleted, userState);
        }
        
        private void OnGetFlightsForSalesOperationCompleted(object arg) {
            if ((this.GetFlightsForSalesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetFlightsForSalesCompleted(this, new GetFlightsForSalesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IsFlightSoon", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool IsFlightSoon(System.Guid flightNumber) {
            object[] results = this.Invoke("IsFlightSoon", new object[] {
                        flightNumber});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void IsFlightSoonAsync(System.Guid flightNumber) {
            this.IsFlightSoonAsync(flightNumber, null);
        }
        
        /// <remarks/>
        public void IsFlightSoonAsync(System.Guid flightNumber, object userState) {
            if ((this.IsFlightSoonOperationCompleted == null)) {
                this.IsFlightSoonOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsFlightSoonOperationCompleted);
            }
            this.InvokeAsync("IsFlightSoon", new object[] {
                        flightNumber}, this.IsFlightSoonOperationCompleted, userState);
        }
        
        private void OnIsFlightSoonOperationCompleted(object arg) {
            if ((this.IsFlightSoonCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsFlightSoonCompleted(this, new IsFlightSoonCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IsCheckInFinished", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool IsCheckInFinished(System.Guid flightNumber) {
            object[] results = this.Invoke("IsCheckInFinished", new object[] {
                        flightNumber});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void IsCheckInFinishedAsync(System.Guid flightNumber) {
            this.IsCheckInFinishedAsync(flightNumber, null);
        }
        
        /// <remarks/>
        public void IsCheckInFinishedAsync(System.Guid flightNumber, object userState) {
            if ((this.IsCheckInFinishedOperationCompleted == null)) {
                this.IsCheckInFinishedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsCheckInFinishedOperationCompleted);
            }
            this.InvokeAsync("IsCheckInFinished", new object[] {
                        flightNumber}, this.IsCheckInFinishedOperationCompleted, userState);
        }
        
        private void OnIsCheckInFinishedOperationCompleted(object arg) {
            if ((this.IsCheckInFinishedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsCheckInFinishedCompleted(this, new IsCheckInFinishedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CreateFlight", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void CreateFlight(System.DateTime takeoffTime, Cities city, int economPassengers, int vipPassengers) {
            this.Invoke("CreateFlight", new object[] {
                        takeoffTime,
                        city,
                        economPassengers,
                        vipPassengers});
        }
        
        /// <remarks/>
        public void CreateFlightAsync(System.DateTime takeoffTime, Cities city, int economPassengers, int vipPassengers) {
            this.CreateFlightAsync(takeoffTime, city, economPassengers, vipPassengers, null);
        }
        
        /// <remarks/>
        public void CreateFlightAsync(System.DateTime takeoffTime, Cities city, int economPassengers, int vipPassengers, object userState) {
            if ((this.CreateFlightOperationCompleted == null)) {
                this.CreateFlightOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateFlightOperationCompleted);
            }
            this.InvokeAsync("CreateFlight", new object[] {
                        takeoffTime,
                        city,
                        economPassengers,
                        vipPassengers}, this.CreateFlightOperationCompleted, userState);
        }
        
        private void OnCreateFlightOperationCompleted(object arg) {
            if ((this.CreateFlightCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateFlightCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAvailableFlights", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Flight[] GetAvailableFlights() {
            object[] results = this.Invoke("GetAvailableFlights", new object[0]);
            return ((Flight[])(results[0]));
        }
        
        /// <remarks/>
        public void GetAvailableFlightsAsync() {
            this.GetAvailableFlightsAsync(null);
        }
        
        /// <remarks/>
        public void GetAvailableFlightsAsync(object userState) {
            if ((this.GetAvailableFlightsOperationCompleted == null)) {
                this.GetAvailableFlightsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAvailableFlightsOperationCompleted);
            }
            this.InvokeAsync("GetAvailableFlights", new object[0], this.GetAvailableFlightsOperationCompleted, userState);
        }
        
        private void OnGetAvailableFlightsOperationCompleted(object arg) {
            if ((this.GetAvailableFlightsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAvailableFlightsCompleted(this, new GetAvailableFlightsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RegisterPlaneToFlight", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool RegisterPlaneToFlight(System.Guid planeid, System.Guid FlightId) {
            object[] results = this.Invoke("RegisterPlaneToFlight", new object[] {
                        planeid,
                        FlightId});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void RegisterPlaneToFlightAsync(System.Guid planeid, System.Guid FlightId) {
            this.RegisterPlaneToFlightAsync(planeid, FlightId, null);
        }
        
        /// <remarks/>
        public void RegisterPlaneToFlightAsync(System.Guid planeid, System.Guid FlightId, object userState) {
            if ((this.RegisterPlaneToFlightOperationCompleted == null)) {
                this.RegisterPlaneToFlightOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRegisterPlaneToFlightOperationCompleted);
            }
            this.InvokeAsync("RegisterPlaneToFlight", new object[] {
                        planeid,
                        FlightId}, this.RegisterPlaneToFlightOperationCompleted, userState);
        }
        
        private void OnRegisterPlaneToFlightOperationCompleted(object arg) {
            if ((this.RegisterPlaneToFlightCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RegisterPlaneToFlightCompleted(this, new RegisterPlaneToFlightCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ReadyToTakeOff", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ReadyToTakeOff(System.Guid fligthID) {
            object[] results = this.Invoke("ReadyToTakeOff", new object[] {
                        fligthID});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ReadyToTakeOffAsync(System.Guid fligthID) {
            this.ReadyToTakeOffAsync(fligthID, null);
        }
        
        /// <remarks/>
        public void ReadyToTakeOffAsync(System.Guid fligthID, object userState) {
            if ((this.ReadyToTakeOffOperationCompleted == null)) {
                this.ReadyToTakeOffOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReadyToTakeOffOperationCompleted);
            }
            this.InvokeAsync("ReadyToTakeOff", new object[] {
                        fligthID}, this.ReadyToTakeOffOperationCompleted, userState);
        }
        
        private void OnReadyToTakeOffOperationCompleted(object arg) {
            if ((this.ReadyToTakeOffCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReadyToTakeOffCompleted(this, new ReadyToTakeOffCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34209")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Flight {
        
        private System.Guid numberField;
        
        private Cities cityField;
        
        private System.DateTime arrivalTimeField;
        
        private System.DateTime takeoffTimeField;
        
        private System.DateTime startRegistrationTimeField;
        
        private System.DateTime endRegistrationTimeField;
        
        private int economPassengersCountField;
        
        private int vipPassengersCountField;
        
        private System.Nullable<System.Guid> bindPlaneIDField;
        
        private bool isReadyTakeOffField;
        
        /// <remarks/>
        public System.Guid number {
            get {
                return this.numberField;
            }
            set {
                this.numberField = value;
            }
        }
        
        /// <remarks/>
        public Cities city {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime arrivalTime {
            get {
                return this.arrivalTimeField;
            }
            set {
                this.arrivalTimeField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime takeoffTime {
            get {
                return this.takeoffTimeField;
            }
            set {
                this.takeoffTimeField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime StartRegistrationTime {
            get {
                return this.startRegistrationTimeField;
            }
            set {
                this.startRegistrationTimeField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime EndRegistrationTime {
            get {
                return this.endRegistrationTimeField;
            }
            set {
                this.endRegistrationTimeField = value;
            }
        }
        
        /// <remarks/>
        public int EconomPassengersCount {
            get {
                return this.economPassengersCountField;
            }
            set {
                this.economPassengersCountField = value;
            }
        }
        
        /// <remarks/>
        public int VipPassengersCount {
            get {
                return this.vipPassengersCountField;
            }
            set {
                this.vipPassengersCountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.Guid> BindPlaneID {
            get {
                return this.bindPlaneIDField;
            }
            set {
                this.bindPlaneIDField = value;
            }
        }
        
        /// <remarks/>
        public bool IsReadyTakeOff {
            get {
                return this.isReadyTakeOffField;
            }
            set {
                this.isReadyTakeOffField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34209")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum Cities {
        
        /// <remarks/>
        Tokyo,
        
        /// <remarks/>
        Paris,
        
        /// <remarks/>
        Rome,
        
        /// <remarks/>
        NewYork,
        
        /// <remarks/>
        Sydney,
        
        /// <remarks/>
        Brasilia,
        
        /// <remarks/>
        Antananarivo,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void GetFlightsForRegistrationCompletedEventHandler(object sender, GetFlightsForRegistrationCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetFlightsForRegistrationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetFlightsForRegistrationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Flight[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Flight[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void GetFlightsForSalesCompletedEventHandler(object sender, GetFlightsForSalesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetFlightsForSalesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetFlightsForSalesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Flight[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Flight[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void IsFlightSoonCompletedEventHandler(object sender, IsFlightSoonCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsFlightSoonCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsFlightSoonCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void IsCheckInFinishedCompletedEventHandler(object sender, IsCheckInFinishedCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsCheckInFinishedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsCheckInFinishedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void CreateFlightCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void GetAvailableFlightsCompletedEventHandler(object sender, GetAvailableFlightsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAvailableFlightsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAvailableFlightsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Flight[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Flight[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void RegisterPlaneToFlightCompletedEventHandler(object sender, RegisterPlaneToFlightCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RegisterPlaneToFlightCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RegisterPlaneToFlightCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void ReadyToTakeOffCompletedEventHandler(object sender, ReadyToTakeOffCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReadyToTakeOffCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReadyToTakeOffCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void ResetCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591