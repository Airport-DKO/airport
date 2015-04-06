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

namespace Tower_Control.GmcWs {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="GMCSoap", Namespace="Airport")]
    public partial class GMC : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetRouteOperationCompleted;
        
        private System.Threading.SendOrPostCallback StepOperationCompleted;
        
        private System.Threading.SendOrPostCallback CheckRunwayAwailabilityOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public GMC() {
            this.Url = global::Tower_Control.Properties.Settings.Default.Tower_Control_GmcWs_GMC;
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
        public event GetRouteCompletedEventHandler GetRouteCompleted;
        
        /// <remarks/>
        public event StepCompletedEventHandler StepCompleted;
        
        /// <remarks/>
        public event CheckRunwayAwailabilityCompletedEventHandler CheckRunwayAwailabilityCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Airport/GetRoute", RequestNamespace="Airport", ResponseNamespace="Airport", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public CoordinateTuple[] GetRoute(MapObject from, MapObject to) {
            object[] results = this.Invoke("GetRoute", new object[] {
                        from,
                        to});
            return ((CoordinateTuple[])(results[0]));
        }
        
        /// <remarks/>
        public void GetRouteAsync(MapObject from, MapObject to) {
            this.GetRouteAsync(from, to, null);
        }
        
        /// <remarks/>
        public void GetRouteAsync(MapObject from, MapObject to, object userState) {
            if ((this.GetRouteOperationCompleted == null)) {
                this.GetRouteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRouteOperationCompleted);
            }
            this.InvokeAsync("GetRoute", new object[] {
                        from,
                        to}, this.GetRouteOperationCompleted, userState);
        }
        
        private void OnGetRouteOperationCompleted(object arg) {
            if ((this.GetRouteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRouteCompleted(this, new GetRouteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Airport/Step", RequestNamespace="Airport", ResponseNamespace="Airport", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Step(CoordinateTuple coordinate, MoveObjectType type, System.Guid id) {
            object[] results = this.Invoke("Step", new object[] {
                        coordinate,
                        type,
                        id});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void StepAsync(CoordinateTuple coordinate, MoveObjectType type, System.Guid id) {
            this.StepAsync(coordinate, type, id, null);
        }
        
        /// <remarks/>
        public void StepAsync(CoordinateTuple coordinate, MoveObjectType type, System.Guid id, object userState) {
            if ((this.StepOperationCompleted == null)) {
                this.StepOperationCompleted = new System.Threading.SendOrPostCallback(this.OnStepOperationCompleted);
            }
            this.InvokeAsync("Step", new object[] {
                        coordinate,
                        type,
                        id}, this.StepOperationCompleted, userState);
        }
        
        private void OnStepOperationCompleted(object arg) {
            if ((this.StepCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.StepCompleted(this, new StepCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Airport/CheckRunwayAwailability", RequestNamespace="Airport", ResponseNamespace="Airport", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public MapObject CheckRunwayAwailability(System.Guid planeGuid) {
            object[] results = this.Invoke("CheckRunwayAwailability", new object[] {
                        planeGuid});
            return ((MapObject)(results[0]));
        }
        
        /// <remarks/>
        public void CheckRunwayAwailabilityAsync(System.Guid planeGuid) {
            this.CheckRunwayAwailabilityAsync(planeGuid, null);
        }
        
        /// <remarks/>
        public void CheckRunwayAwailabilityAsync(System.Guid planeGuid, object userState) {
            if ((this.CheckRunwayAwailabilityOperationCompleted == null)) {
                this.CheckRunwayAwailabilityOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheckRunwayAwailabilityOperationCompleted);
            }
            this.InvokeAsync("CheckRunwayAwailability", new object[] {
                        planeGuid}, this.CheckRunwayAwailabilityOperationCompleted, userState);
        }
        
        private void OnCheckRunwayAwailabilityOperationCompleted(object arg) {
            if ((this.CheckRunwayAwailabilityCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CheckRunwayAwailabilityCompleted(this, new CheckRunwayAwailabilityCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Airport")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Airport")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Airport")]
    public partial class CoordinateTuple {
        
        private int xField;
        
        private int yField;
        
        /// <remarks/>
        public int X {
            get {
                return this.xField;
            }
            set {
                this.xField = value;
            }
        }
        
        /// <remarks/>
        public int Y {
            get {
                return this.yField;
            }
            set {
                this.yField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Airport")]
    public enum MoveObjectType {
        
        /// <remarks/>
        None,
        
        /// <remarks/>
        Plane,
        
        /// <remarks/>
        FollowMeVan,
        
        /// <remarks/>
        ContainerLoader,
        
        /// <remarks/>
        BaggageTractor,
        
        /// <remarks/>
        CateringTruck,
        
        /// <remarks/>
        Deicer,
        
        /// <remarks/>
        PassengerStairs,
        
        /// <remarks/>
        PassengerBus,
        
        /// <remarks/>
        VipShuttle,
        
        /// <remarks/>
        SnowRemovalVehicle,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void GetRouteCompletedEventHandler(object sender, GetRouteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRouteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRouteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public CoordinateTuple[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((CoordinateTuple[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void StepCompletedEventHandler(object sender, StepCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class StepCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal StepCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void CheckRunwayAwailabilityCompletedEventHandler(object sender, CheckRunwayAwailabilityCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CheckRunwayAwailabilityCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CheckRunwayAwailabilityCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
}

#pragma warning restore 1591