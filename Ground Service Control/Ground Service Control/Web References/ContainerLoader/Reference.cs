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

namespace Ground_Service_Control.ContainerLoader {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="ContainerLoaderSoap", Namespace="Airport-DKO-Container-Loader")]
    public partial class ContainerLoader : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ToServiceZoneOperationCompleted;
        
        private System.Threading.SendOrPostCallback ToGarageOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ContainerLoader() {
            this.Url = global::Ground_Service_Control.Properties.Settings.Default.Ground_Service_Control_ContainerLoader_ContainerLoader;
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
        public event ToServiceZoneCompletedEventHandler ToServiceZoneCompleted;
        
        /// <remarks/>
        public event ToGarageCompletedEventHandler ToGarageCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Airport-DKO-Container-Loader/ToServiceZone", RequestNamespace="Airport-DKO-Container-Loader", ResponseNamespace="Airport-DKO-Container-Loader", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ToServiceZone(MapObject serviceZone, System.Guid flightNumber, ServiceTaskId taskId) {
            object[] results = this.Invoke("ToServiceZone", new object[] {
                        serviceZone,
                        flightNumber,
                        taskId});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ToServiceZoneAsync(MapObject serviceZone, System.Guid flightNumber, ServiceTaskId taskId) {
            this.ToServiceZoneAsync(serviceZone, flightNumber, taskId, null);
        }
        
        /// <remarks/>
        public void ToServiceZoneAsync(MapObject serviceZone, System.Guid flightNumber, ServiceTaskId taskId, object userState) {
            if ((this.ToServiceZoneOperationCompleted == null)) {
                this.ToServiceZoneOperationCompleted = new System.Threading.SendOrPostCallback(this.OnToServiceZoneOperationCompleted);
            }
            this.InvokeAsync("ToServiceZone", new object[] {
                        serviceZone,
                        flightNumber,
                        taskId}, this.ToServiceZoneOperationCompleted, userState);
        }
        
        private void OnToServiceZoneOperationCompleted(object arg) {
            if ((this.ToServiceZoneCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ToServiceZoneCompleted(this, new ToServiceZoneCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Airport-DKO-Container-Loader/ToGarage", RequestNamespace="Airport-DKO-Container-Loader", ResponseNamespace="Airport-DKO-Container-Loader", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ToGarage(MapObject serviceZone) {
            object[] results = this.Invoke("ToGarage", new object[] {
                        serviceZone});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ToGarageAsync(MapObject serviceZone) {
            this.ToGarageAsync(serviceZone, null);
        }
        
        /// <remarks/>
        public void ToGarageAsync(MapObject serviceZone, object userState) {
            if ((this.ToGarageOperationCompleted == null)) {
                this.ToGarageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnToGarageOperationCompleted);
            }
            this.InvokeAsync("ToGarage", new object[] {
                        serviceZone}, this.ToGarageOperationCompleted, userState);
        }
        
        private void OnToGarageOperationCompleted(object arg) {
            if ((this.ToGarageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ToGarageCompleted(this, new ToGarageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34209")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34209")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="DKO-Airport-Ground-Service-Control")]
    public partial class ServiceTaskId {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void ToServiceZoneCompletedEventHandler(object sender, ToServiceZoneCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ToServiceZoneCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ToServiceZoneCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void ToGarageCompletedEventHandler(object sender, ToGarageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ToGarageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ToGarageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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