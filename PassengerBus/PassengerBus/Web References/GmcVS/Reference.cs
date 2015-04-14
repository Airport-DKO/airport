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

namespace PassengerBus.GmcVS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="GMCSoap", Namespace="Airport")]
    public partial class GMC : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetRouteOperationCompleted;
        
        private System.Threading.SendOrPostCallback StepOperationCompleted;
        
        private System.Threading.SendOrPostCallback CheckRunwayAwailabilityOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetPlaneServiceZoneOperationCompleted;
        
        private System.Threading.SendOrPostCallback RunwayReleaseOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRunwayOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetServiceZonesOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public GMC() {
            this.Url = global::PassengerBus.Properties.Settings.Default.PassengerBus_GmcVS_GMC;
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
        public event GetPlaneServiceZoneCompletedEventHandler GetPlaneServiceZoneCompleted;
        
        /// <remarks/>
        public event RunwayReleaseCompletedEventHandler RunwayReleaseCompleted;
        
        /// <remarks/>
        public event GetRunwayCompletedEventHandler GetRunwayCompleted;
        
        /// <remarks/>
        public event GetServiceZonesCompletedEventHandler GetServiceZonesCompleted;
        
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
        public bool CheckRunwayAwailability(System.Guid planeGuid) {
            object[] results = this.Invoke("CheckRunwayAwailability", new object[] {
                        planeGuid});
            return ((bool)(results[0]));
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
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Airport/GetPlaneServiceZone", RequestNamespace="Airport", ResponseNamespace="Airport", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public MapObject GetPlaneServiceZone(System.Guid planeGuid) {
            object[] results = this.Invoke("GetPlaneServiceZone", new object[] {
                        planeGuid});
            return ((MapObject)(results[0]));
        }
        
        /// <remarks/>
        public void GetPlaneServiceZoneAsync(System.Guid planeGuid) {
            this.GetPlaneServiceZoneAsync(planeGuid, null);
        }
        
        /// <remarks/>
        public void GetPlaneServiceZoneAsync(System.Guid planeGuid, object userState) {
            if ((this.GetPlaneServiceZoneOperationCompleted == null)) {
                this.GetPlaneServiceZoneOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetPlaneServiceZoneOperationCompleted);
            }
            this.InvokeAsync("GetPlaneServiceZone", new object[] {
                        planeGuid}, this.GetPlaneServiceZoneOperationCompleted, userState);
        }
        
        private void OnGetPlaneServiceZoneOperationCompleted(object arg) {
            if ((this.GetPlaneServiceZoneCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetPlaneServiceZoneCompleted(this, new GetPlaneServiceZoneCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Airport/RunwayRelease", RequestNamespace="Airport", ResponseNamespace="Airport", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void RunwayRelease() {
            this.Invoke("RunwayRelease", new object[0]);
        }
        
        /// <remarks/>
        public void RunwayReleaseAsync() {
            this.RunwayReleaseAsync(null);
        }
        
        /// <remarks/>
        public void RunwayReleaseAsync(object userState) {
            if ((this.RunwayReleaseOperationCompleted == null)) {
                this.RunwayReleaseOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRunwayReleaseOperationCompleted);
            }
            this.InvokeAsync("RunwayRelease", new object[0], this.RunwayReleaseOperationCompleted, userState);
        }
        
        private void OnRunwayReleaseOperationCompleted(object arg) {
            if ((this.RunwayReleaseCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RunwayReleaseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Airport/GetRunway", RequestNamespace="Airport", ResponseNamespace="Airport", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public MapObject GetRunway() {
            object[] results = this.Invoke("GetRunway", new object[0]);
            return ((MapObject)(results[0]));
        }
        
        /// <remarks/>
        public void GetRunwayAsync() {
            this.GetRunwayAsync(null);
        }
        
        /// <remarks/>
        public void GetRunwayAsync(object userState) {
            if ((this.GetRunwayOperationCompleted == null)) {
                this.GetRunwayOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRunwayOperationCompleted);
            }
            this.InvokeAsync("GetRunway", new object[0], this.GetRunwayOperationCompleted, userState);
        }
        
        private void OnGetRunwayOperationCompleted(object arg) {
            if ((this.GetRunwayCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRunwayCompleted(this, new GetRunwayCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Airport/GetServiceZones", RequestNamespace="Airport", ResponseNamespace="Airport", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public MapObject[] GetServiceZones() {
            object[] results = this.Invoke("GetServiceZones", new object[0]);
            return ((MapObject[])(results[0]));
        }
        
        /// <remarks/>
        public void GetServiceZonesAsync() {
            this.GetServiceZonesAsync(null);
        }
        
        /// <remarks/>
        public void GetServiceZonesAsync(object userState) {
            if ((this.GetServiceZonesOperationCompleted == null)) {
                this.GetServiceZonesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetServiceZonesOperationCompleted);
            }
            this.InvokeAsync("GetServiceZones", new object[0], this.GetServiceZonesOperationCompleted, userState);
        }
        
        private void OnGetServiceZonesOperationCompleted(object arg) {
            if ((this.GetServiceZonesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetServiceZonesCompleted(this, new GetServiceZonesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
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
        
        /// <remarks/>
        Refueler,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetRouteCompletedEventHandler(object sender, GetRouteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void StepCompletedEventHandler(object sender, StepCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void CheckRunwayAwailabilityCompletedEventHandler(object sender, CheckRunwayAwailabilityCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CheckRunwayAwailabilityCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CheckRunwayAwailabilityCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetPlaneServiceZoneCompletedEventHandler(object sender, GetPlaneServiceZoneCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetPlaneServiceZoneCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetPlaneServiceZoneCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void RunwayReleaseCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetRunwayCompletedEventHandler(object sender, GetRunwayCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRunwayCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRunwayCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetServiceZonesCompletedEventHandler(object sender, GetServiceZonesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetServiceZonesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetServiceZonesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public MapObject[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((MapObject[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591