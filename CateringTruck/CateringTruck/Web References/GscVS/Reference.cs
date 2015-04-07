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

namespace CateringTruck.GscVS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="GSCSoap", Namespace="DKO-Airport-Ground-Service-Control")]
    public partial class GSC : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetFreePlaceOperationCompleted;
        
        private System.Threading.SendOrPostCallback SetFreePlaceOperationCompleted;
        
        private System.Threading.SendOrPostCallback SetNeedsOperationCompleted;
        
        private System.Threading.SendOrPostCallback DoneOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public GSC() {
            this.Url = global::CateringTruck.Properties.Settings.Default.CateringTruck_GscVS_GSC;
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
        public event GetFreePlaceCompletedEventHandler GetFreePlaceCompleted;
        
        /// <remarks/>
        public event SetFreePlaceCompletedEventHandler SetFreePlaceCompleted;
        
        /// <remarks/>
        public event SetNeedsCompletedEventHandler SetNeedsCompleted;
        
        /// <remarks/>
        public event DoneCompletedEventHandler DoneCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("DKO-Airport-Ground-Service-Control/GetFreePlace", RequestNamespace="DKO-Airport-Ground-Service-Control", ResponseNamespace="DKO-Airport-Ground-Service-Control", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public MapObject GetFreePlace(System.Guid plane) {
            object[] results = this.Invoke("GetFreePlace", new object[] {
                        plane});
            return ((MapObject)(results[0]));
        }
        
        /// <remarks/>
        public void GetFreePlaceAsync(System.Guid plane) {
            this.GetFreePlaceAsync(plane, null);
        }
        
        /// <remarks/>
        public void GetFreePlaceAsync(System.Guid plane, object userState) {
            if ((this.GetFreePlaceOperationCompleted == null)) {
                this.GetFreePlaceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetFreePlaceOperationCompleted);
            }
            this.InvokeAsync("GetFreePlace", new object[] {
                        plane}, this.GetFreePlaceOperationCompleted, userState);
        }
        
        private void OnGetFreePlaceOperationCompleted(object arg) {
            if ((this.GetFreePlaceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetFreePlaceCompleted(this, new GetFreePlaceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("DKO-Airport-Ground-Service-Control/SetFreePlace", RequestNamespace="DKO-Airport-Ground-Service-Control", ResponseNamespace="DKO-Airport-Ground-Service-Control", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SetFreePlace(System.Guid plane) {
            object[] results = this.Invoke("SetFreePlace", new object[] {
                        plane});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SetFreePlaceAsync(System.Guid plane) {
            this.SetFreePlaceAsync(plane, null);
        }
        
        /// <remarks/>
        public void SetFreePlaceAsync(System.Guid plane, object userState) {
            if ((this.SetFreePlaceOperationCompleted == null)) {
                this.SetFreePlaceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetFreePlaceOperationCompleted);
            }
            this.InvokeAsync("SetFreePlace", new object[] {
                        plane}, this.SetFreePlaceOperationCompleted, userState);
        }
        
        private void OnSetFreePlaceOperationCompleted(object arg) {
            if ((this.SetFreePlaceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetFreePlaceCompleted(this, new SetFreePlaceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("DKO-Airport-Ground-Service-Control/SetNeeds", RequestNamespace="DKO-Airport-Ground-Service-Control", ResponseNamespace="DKO-Airport-Ground-Service-Control", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SetNeeds(System.Guid plane, Flight flight, bool ladder, int economPassengers, int VIPPassengers, int baggage, int fuelingNeeds) {
            object[] results = this.Invoke("SetNeeds", new object[] {
                        plane,
                        flight,
                        ladder,
                        economPassengers,
                        VIPPassengers,
                        baggage,
                        fuelingNeeds});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SetNeedsAsync(System.Guid plane, Flight flight, bool ladder, int economPassengers, int VIPPassengers, int baggage, int fuelingNeeds) {
            this.SetNeedsAsync(plane, flight, ladder, economPassengers, VIPPassengers, baggage, fuelingNeeds, null);
        }
        
        /// <remarks/>
        public void SetNeedsAsync(System.Guid plane, Flight flight, bool ladder, int economPassengers, int VIPPassengers, int baggage, int fuelingNeeds, object userState) {
            if ((this.SetNeedsOperationCompleted == null)) {
                this.SetNeedsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetNeedsOperationCompleted);
            }
            this.InvokeAsync("SetNeeds", new object[] {
                        plane,
                        flight,
                        ladder,
                        economPassengers,
                        VIPPassengers,
                        baggage,
                        fuelingNeeds}, this.SetNeedsOperationCompleted, userState);
        }
        
        private void OnSetNeedsOperationCompleted(object arg) {
            if ((this.SetNeedsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetNeedsCompleted(this, new SetNeedsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("DKO-Airport-Ground-Service-Control/Done", RequestNamespace="DKO-Airport-Ground-Service-Control", ResponseNamespace="DKO-Airport-Ground-Service-Control", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Done(ServiceTaskId TaskNumber) {
            object[] results = this.Invoke("Done", new object[] {
                        TaskNumber});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void DoneAsync(ServiceTaskId TaskNumber) {
            this.DoneAsync(TaskNumber, null);
        }
        
        /// <remarks/>
        public void DoneAsync(ServiceTaskId TaskNumber, object userState) {
            if ((this.DoneOperationCompleted == null)) {
                this.DoneOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDoneOperationCompleted);
            }
            this.InvokeAsync("Done", new object[] {
                        TaskNumber}, this.DoneOperationCompleted, userState);
        }
        
        private void OnDoneOperationCompleted(object arg) {
            if ((this.DoneCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DoneCompleted(this, new DoneCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="DKO-Airport-Ground-Movement-Control")]
    public partial class MapObject {
        
        private MapObjectType mapObjectTypeField;
        
        private int numberField;
        
        /// <remarks/>
        public MapObjectType MapObjectType {
            get {
                return this.mapObjectTypeField;
            }
            set {
                this.mapObjectTypeField = value;
            }
        }
        
        /// <remarks/>
        public int Number {
            get {
                return this.numberField;
            }
            set {
                this.numberField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="DKO-Airport-Ground-Movement-Control")]
    public enum MapObjectType {
        
        /// <remarks/>
        Runway,
        
        /// <remarks/>
        Garage,
        
        /// <remarks/>
        ServiceArea,
        
        /// <remarks/>
        Airport,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="DKO-Airport-Ground-Service-Control")]
    public partial class ServiceTaskId {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="DKO-Ariport-Aircraft-Generator")]
    public partial class Flight {
        
        private int flightNumberField;
        
        private City cityField;
        
        private System.DateTime arrivalTimeField;
        
        private System.DateTime departureTimeField;
        
        /// <remarks/>
        public int FlightNumber {
            get {
                return this.flightNumberField;
            }
            set {
                this.flightNumberField = value;
            }
        }
        
        /// <remarks/>
        public City City {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime ArrivalTime {
            get {
                return this.arrivalTimeField;
            }
            set {
                this.arrivalTimeField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime DepartureTime {
            get {
                return this.departureTimeField;
            }
            set {
                this.departureTimeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="DKO-Ariport-Aircraft-Generator")]
    public enum City {
        
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetFreePlaceCompletedEventHandler(object sender, GetFreePlaceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetFreePlaceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetFreePlaceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public MapObject Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((MapObject)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void SetFreePlaceCompletedEventHandler(object sender, SetFreePlaceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SetFreePlaceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SetFreePlaceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void SetNeedsCompletedEventHandler(object sender, SetNeedsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SetNeedsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SetNeedsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void DoneCompletedEventHandler(object sender, DoneCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DoneCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DoneCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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