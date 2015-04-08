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

namespace Ground_Service_Control.BaggageTractor {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="BaggageTractorSoap", Namespace="http://tempuri.org/")]
    public partial class BaggageTractor : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback UnloadBaggageOperationCompleted;
        
        private System.Threading.SendOrPostCallback LoadBaggageOperationCompleted;
        
        private System.Threading.SendOrPostCallback ToPlainOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public BaggageTractor() {
            this.Url = global::Ground_Service_Control.Properties.Settings.Default.Ground_Service_Control_BaggageTractor_BaggageTractor;
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
        public event UnloadBaggageCompletedEventHandler UnloadBaggageCompleted;
        
        /// <remarks/>
        public event LoadBaggageCompletedEventHandler LoadBaggageCompleted;
        
        /// <remarks/>
        public event ToPlainCompletedEventHandler ToPlainCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UnloadBaggage", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool UnloadBaggage(MapObject serviseZone, int weightOfBaggage, ServiceTaskId taskId) {
            object[] results = this.Invoke("UnloadBaggage", new object[] {
                        serviseZone,
                        weightOfBaggage,
                        taskId});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void UnloadBaggageAsync(MapObject serviseZone, int weightOfBaggage, ServiceTaskId taskId) {
            this.UnloadBaggageAsync(serviseZone, weightOfBaggage, taskId, null);
        }
        
        /// <remarks/>
        public void UnloadBaggageAsync(MapObject serviseZone, int weightOfBaggage, ServiceTaskId taskId, object userState) {
            if ((this.UnloadBaggageOperationCompleted == null)) {
                this.UnloadBaggageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUnloadBaggageOperationCompleted);
            }
            this.InvokeAsync("UnloadBaggage", new object[] {
                        serviseZone,
                        weightOfBaggage,
                        taskId}, this.UnloadBaggageOperationCompleted, userState);
        }
        
        private void OnUnloadBaggageOperationCompleted(object arg) {
            if ((this.UnloadBaggageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UnloadBaggageCompleted(this, new UnloadBaggageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/LoadBaggage", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool LoadBaggage(MapObject serviseZone, System.Guid flightNumber, ServiceTaskId taskId) {
            object[] results = this.Invoke("LoadBaggage", new object[] {
                        serviseZone,
                        flightNumber,
                        taskId});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void LoadBaggageAsync(MapObject serviseZone, System.Guid flightNumber, ServiceTaskId taskId) {
            this.LoadBaggageAsync(serviseZone, flightNumber, taskId, null);
        }
        
        /// <remarks/>
        public void LoadBaggageAsync(MapObject serviseZone, System.Guid flightNumber, ServiceTaskId taskId, object userState) {
            if ((this.LoadBaggageOperationCompleted == null)) {
                this.LoadBaggageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLoadBaggageOperationCompleted);
            }
            this.InvokeAsync("LoadBaggage", new object[] {
                        serviseZone,
                        flightNumber,
                        taskId}, this.LoadBaggageOperationCompleted, userState);
        }
        
        private void OnLoadBaggageOperationCompleted(object arg) {
            if ((this.LoadBaggageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LoadBaggageCompleted(this, new LoadBaggageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ToPlain", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ToPlain(System.Guid flightNumber) {
            object[] results = this.Invoke("ToPlain", new object[] {
                        flightNumber});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ToPlainAsync(System.Guid flightNumber) {
            this.ToPlainAsync(flightNumber, null);
        }
        
        /// <remarks/>
        public void ToPlainAsync(System.Guid flightNumber, object userState) {
            if ((this.ToPlainOperationCompleted == null)) {
                this.ToPlainOperationCompleted = new System.Threading.SendOrPostCallback(this.OnToPlainOperationCompleted);
            }
            this.InvokeAsync("ToPlain", new object[] {
                        flightNumber}, this.ToPlainOperationCompleted, userState);
        }
        
        private void OnToPlainOperationCompleted(object arg) {
            if ((this.ToPlainCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ToPlainCompleted(this, new ToPlainCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void UnloadBaggageCompletedEventHandler(object sender, UnloadBaggageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UnloadBaggageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UnloadBaggageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void LoadBaggageCompletedEventHandler(object sender, LoadBaggageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LoadBaggageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LoadBaggageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void ToPlainCompletedEventHandler(object sender, ToPlainCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ToPlainCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ToPlainCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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