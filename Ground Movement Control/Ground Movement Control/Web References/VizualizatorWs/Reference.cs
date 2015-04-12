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

namespace Ground_Movement_Control.VizualizatorWs {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="visualisatorSoap", Namespace="http://airport-dko-1.cloudapp.net/")]
    public partial class visualisator : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetMapOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetMapObjectsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRoutesOperationCompleted;
        
        private System.Threading.SendOrPostCallback MoveObjectOperationCompleted;
        
        private System.Threading.SendOrPostCallback LetItSnowOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public visualisator() {
            this.Url = global::Ground_Movement_Control.Properties.Settings.Default.Ground_Movement_Control_VizualizatorWs_visualisator;
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
        public event GetMapCompletedEventHandler GetMapCompleted;
        
        /// <remarks/>
        public event GetMapObjectsCompletedEventHandler GetMapObjectsCompleted;
        
        /// <remarks/>
        public event GetRoutesCompletedEventHandler GetRoutesCompleted;
        
        /// <remarks/>
        public event MoveObjectCompletedEventHandler MoveObjectCompleted;
        
        /// <remarks/>
        public event LetItSnowCompletedEventHandler LetItSnowCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://airport-dko-1.cloudapp.net/GetMap", RequestNamespace="http://airport-dko-1.cloudapp.net/", ResponseNamespace="http://airport-dko-1.cloudapp.net/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public CoordinateTuple[] GetMap() {
            object[] results = this.Invoke("GetMap", new object[0]);
            return ((CoordinateTuple[])(results[0]));
        }
        
        /// <remarks/>
        public void GetMapAsync() {
            this.GetMapAsync(null);
        }
        
        /// <remarks/>
        public void GetMapAsync(object userState) {
            if ((this.GetMapOperationCompleted == null)) {
                this.GetMapOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMapOperationCompleted);
            }
            this.InvokeAsync("GetMap", new object[0], this.GetMapOperationCompleted, userState);
        }
        
        private void OnGetMapOperationCompleted(object arg) {
            if ((this.GetMapCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetMapCompleted(this, new GetMapCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://airport-dko-1.cloudapp.net/GetMapObjects", RequestNamespace="http://airport-dko-1.cloudapp.net/", ResponseNamespace="http://airport-dko-1.cloudapp.net/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Location[] GetMapObjects() {
            object[] results = this.Invoke("GetMapObjects", new object[0]);
            return ((Location[])(results[0]));
        }
        
        /// <remarks/>
        public void GetMapObjectsAsync() {
            this.GetMapObjectsAsync(null);
        }
        
        /// <remarks/>
        public void GetMapObjectsAsync(object userState) {
            if ((this.GetMapObjectsOperationCompleted == null)) {
                this.GetMapObjectsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMapObjectsOperationCompleted);
            }
            this.InvokeAsync("GetMapObjects", new object[0], this.GetMapObjectsOperationCompleted, userState);
        }
        
        private void OnGetMapObjectsOperationCompleted(object arg) {
            if ((this.GetMapObjectsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetMapObjectsCompleted(this, new GetMapObjectsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://airport-dko-1.cloudapp.net/GetRoutes", RequestNamespace="http://airport-dko-1.cloudapp.net/", ResponseNamespace="http://airport-dko-1.cloudapp.net/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Route[] GetRoutes() {
            object[] results = this.Invoke("GetRoutes", new object[0]);
            return ((Route[])(results[0]));
        }
        
        /// <remarks/>
        public void GetRoutesAsync() {
            this.GetRoutesAsync(null);
        }
        
        /// <remarks/>
        public void GetRoutesAsync(object userState) {
            if ((this.GetRoutesOperationCompleted == null)) {
                this.GetRoutesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRoutesOperationCompleted);
            }
            this.InvokeAsync("GetRoutes", new object[0], this.GetRoutesOperationCompleted, userState);
        }
        
        private void OnGetRoutesOperationCompleted(object arg) {
            if ((this.GetRoutesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRoutesCompleted(this, new GetRoutesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://airport-dko-1.cloudapp.net/MoveObject", RequestNamespace="http://airport-dko-1.cloudapp.net/", ResponseNamespace="http://airport-dko-1.cloudapp.net/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void MoveObject(MoveObjectType type, System.Guid objectID, CoordinateTuple newPosition, int speed) {
            this.Invoke("MoveObject", new object[] {
                        type,
                        objectID,
                        newPosition,
                        speed});
        }
        
        /// <remarks/>
        public void MoveObjectAsync(MoveObjectType type, System.Guid objectID, CoordinateTuple newPosition, int speed) {
            this.MoveObjectAsync(type, objectID, newPosition, speed, null);
        }
        
        /// <remarks/>
        public void MoveObjectAsync(MoveObjectType type, System.Guid objectID, CoordinateTuple newPosition, int speed, object userState) {
            if ((this.MoveObjectOperationCompleted == null)) {
                this.MoveObjectOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMoveObjectOperationCompleted);
            }
            this.InvokeAsync("MoveObject", new object[] {
                        type,
                        objectID,
                        newPosition,
                        speed}, this.MoveObjectOperationCompleted, userState);
        }
        
        private void OnMoveObjectOperationCompleted(object arg) {
            if ((this.MoveObjectCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MoveObjectCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://airport-dko-1.cloudapp.net/LetItSnow", RequestNamespace="http://airport-dko-1.cloudapp.net/", ResponseNamespace="http://airport-dko-1.cloudapp.net/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void LetItSnow() {
            this.Invoke("LetItSnow", new object[0]);
        }
        
        /// <remarks/>
        public void LetItSnowAsync() {
            this.LetItSnowAsync(null);
        }
        
        /// <remarks/>
        public void LetItSnowAsync(object userState) {
            if ((this.LetItSnowOperationCompleted == null)) {
                this.LetItSnowOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLetItSnowOperationCompleted);
            }
            this.InvokeAsync("LetItSnow", new object[0], this.LetItSnowOperationCompleted, userState);
        }
        
        private void OnLetItSnowOperationCompleted(object arg) {
            if ((this.LetItSnowCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LetItSnowCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://airport-dko-1.cloudapp.net/")]
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
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://airport-dko-1.cloudapp.net/")]
    public partial class Route {
        
        private Location fromField;
        
        private Location toField;
        
        private CoordinateTuple[] pointsField;
        
        /// <remarks/>
        public Location From {
            get {
                return this.fromField;
            }
            set {
                this.fromField = value;
            }
        }
        
        /// <remarks/>
        public Location To {
            get {
                return this.toField;
            }
            set {
                this.toField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Points")]
        public CoordinateTuple[] Points {
            get {
                return this.pointsField;
            }
            set {
                this.pointsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://airport-dko-1.cloudapp.net/")]
    public partial class Location {
        
        private CoordinateTuple positionField;
        
        private MapObject mapObjField;
        
        /// <remarks/>
        public CoordinateTuple Position {
            get {
                return this.positionField;
            }
            set {
                this.positionField = value;
            }
        }
        
        /// <remarks/>
        public MapObject MapObj {
            get {
                return this.mapObjField;
            }
            set {
                this.mapObjField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://airport-dko-1.cloudapp.net/")]
    public partial class MapObject {
        
        private MapObjectType typeField;
        
        private int numberField;
        
        /// <remarks/>
        public MapObjectType Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        public int number {
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://airport-dko-1.cloudapp.net/")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://airport-dko-1.cloudapp.net/")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void GetMapCompletedEventHandler(object sender, GetMapCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetMapCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetMapCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void GetMapObjectsCompletedEventHandler(object sender, GetMapObjectsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetMapObjectsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetMapObjectsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Location[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Location[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void GetRoutesCompletedEventHandler(object sender, GetRoutesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRoutesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRoutesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Route[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Route[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void MoveObjectCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void LetItSnowCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591