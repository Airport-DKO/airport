﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContainerLoader.GmcReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MapObject", Namespace="DKO-Airport-Ground-Movement-Control")]
    [System.SerializableAttribute()]
    public partial class MapObject : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private GmcReference.MapObjectType MapObjectTypeField;
        
        private int NumberField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public GmcReference.MapObjectType MapObjectType {
            get {
                return this.MapObjectTypeField;
            }
            set {
                if ((this.MapObjectTypeField.Equals(value) != true)) {
                    this.MapObjectTypeField = value;
                    this.RaisePropertyChanged("MapObjectType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Number {
            get {
                return this.NumberField;
            }
            set {
                if ((this.NumberField.Equals(value) != true)) {
                    this.NumberField = value;
                    this.RaisePropertyChanged("Number");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MapObjectType", Namespace="DKO-Airport-Ground-Movement-Control")]
    public enum MapObjectType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Runway = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Garage = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ServiceArea = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Airport = 3,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CoordinateTuple", Namespace="DKO-Airport-Ground-Movement-Control")]
    [System.SerializableAttribute()]
    public partial class CoordinateTuple : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int XField;
        
        private int YField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int X {
            get {
                return this.XField;
            }
            set {
                if ((this.XField.Equals(value) != true)) {
                    this.XField = value;
                    this.RaisePropertyChanged("X");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Y {
            get {
                return this.YField;
            }
            set {
                if ((this.YField.Equals(value) != true)) {
                    this.YField = value;
                    this.RaisePropertyChanged("Y");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MoveObjectType", Namespace="DKO-Airport-Ground-Movement-Control")]
    public enum MoveObjectType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        None = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Plane = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FollowMeVan = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ContainerLoader = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BaggageTractor = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CateringTruck = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Deicer = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PassengerStairs = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PassengerBus = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        VipShuttle = 9,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SnowRemovalVehicle = 10,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="DKO-Airport-Ground-Movement-Control", ConfigurationName="GmcReference.GMCSoap")]
    public interface GMCSoap {
        
        // CODEGEN: Generating message contract since element name from from namespace DKO-Airport-Ground-Movement-Control is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="DKO-Airport-Ground-Movement-Control/GetRoute", ReplyAction="*")]
        GmcReference.GetRouteResponse GetRoute(GmcReference.GetRouteRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="DKO-Airport-Ground-Movement-Control/GetRoute", ReplyAction="*")]
        System.Threading.Tasks.Task<GmcReference.GetRouteResponse> GetRouteAsync(GmcReference.GetRouteRequest request);
        
        // CODEGEN: Generating message contract since element name coordinate from namespace DKO-Airport-Ground-Movement-Control is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="DKO-Airport-Ground-Movement-Control/Step", ReplyAction="*")]
        GmcReference.StepResponse Step(GmcReference.StepRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="DKO-Airport-Ground-Movement-Control/Step", ReplyAction="*")]
        System.Threading.Tasks.Task<GmcReference.StepResponse> StepAsync(GmcReference.StepRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetRouteRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetRoute", Namespace="DKO-Airport-Ground-Movement-Control", Order=0)]
        public GmcReference.GetRouteRequestBody Body;
        
        public GetRouteRequest() {
        }
        
        public GetRouteRequest(GmcReference.GetRouteRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="DKO-Airport-Ground-Movement-Control")]
    public partial class GetRouteRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public GmcReference.MapObject from;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public GmcReference.MapObject to;
        
        public GetRouteRequestBody() {
        }
        
        public GetRouteRequestBody(GmcReference.MapObject from, GmcReference.MapObject to) {
            this.from = from;
            this.to = to;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetRouteResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetRouteResponse", Namespace="DKO-Airport-Ground-Movement-Control", Order=0)]
        public GmcReference.GetRouteResponseBody Body;
        
        public GetRouteResponse() {
        }
        
        public GetRouteResponse(GmcReference.GetRouteResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="DKO-Airport-Ground-Movement-Control")]
    public partial class GetRouteResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public GmcReference.CoordinateTuple[] GetRouteResult;
        
        public GetRouteResponseBody() {
        }
        
        public GetRouteResponseBody(GmcReference.CoordinateTuple[] GetRouteResult) {
            this.GetRouteResult = GetRouteResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class StepRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Step", Namespace="DKO-Airport-Ground-Movement-Control", Order=0)]
        public GmcReference.StepRequestBody Body;
        
        public StepRequest() {
        }
        
        public StepRequest(GmcReference.StepRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="DKO-Airport-Ground-Movement-Control")]
    public partial class StepRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public GmcReference.CoordinateTuple coordinate;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public GmcReference.MoveObjectType type;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public System.Guid id;
        
        public StepRequestBody() {
        }
        
        public StepRequestBody(GmcReference.CoordinateTuple coordinate, GmcReference.MoveObjectType type, System.Guid id) {
            this.coordinate = coordinate;
            this.type = type;
            this.id = id;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class StepResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="StepResponse", Namespace="DKO-Airport-Ground-Movement-Control", Order=0)]
        public GmcReference.StepResponseBody Body;
        
        public StepResponse() {
        }
        
        public StepResponse(GmcReference.StepResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="DKO-Airport-Ground-Movement-Control")]
    public partial class StepResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool StepResult;
        
        public StepResponseBody() {
        }
        
        public StepResponseBody(bool StepResult) {
            this.StepResult = StepResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GMCSoapChannel : GmcReference.GMCSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GMCSoapClient : System.ServiceModel.ClientBase<GmcReference.GMCSoap>, GmcReference.GMCSoap {
        
        public GMCSoapClient() {
        }
        
        public GMCSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GMCSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GMCSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GMCSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GmcReference.GetRouteResponse GmcReference.GMCSoap.GetRoute(GmcReference.GetRouteRequest request) {
            return base.Channel.GetRoute(request);
        }
        
        public GmcReference.CoordinateTuple[] GetRoute(GmcReference.MapObject from, GmcReference.MapObject to) {
            GmcReference.GetRouteRequest inValue = new GmcReference.GetRouteRequest();
            inValue.Body = new GmcReference.GetRouteRequestBody();
            inValue.Body.from = from;
            inValue.Body.to = to;
            GmcReference.GetRouteResponse retVal = ((GmcReference.GMCSoap)(this)).GetRoute(inValue);
            return retVal.Body.GetRouteResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GmcReference.GetRouteResponse> GmcReference.GMCSoap.GetRouteAsync(GmcReference.GetRouteRequest request) {
            return base.Channel.GetRouteAsync(request);
        }
        
        public System.Threading.Tasks.Task<GmcReference.GetRouteResponse> GetRouteAsync(GmcReference.MapObject from, GmcReference.MapObject to) {
            GmcReference.GetRouteRequest inValue = new GmcReference.GetRouteRequest();
            inValue.Body = new GmcReference.GetRouteRequestBody();
            inValue.Body.from = from;
            inValue.Body.to = to;
            return ((GmcReference.GMCSoap)(this)).GetRouteAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GmcReference.StepResponse GmcReference.GMCSoap.Step(GmcReference.StepRequest request) {
            return base.Channel.Step(request);
        }
        
        public bool Step(GmcReference.CoordinateTuple coordinate, GmcReference.MoveObjectType type, System.Guid id) {
            GmcReference.StepRequest inValue = new GmcReference.StepRequest();
            inValue.Body = new GmcReference.StepRequestBody();
            inValue.Body.coordinate = coordinate;
            inValue.Body.type = type;
            inValue.Body.id = id;
            GmcReference.StepResponse retVal = ((GmcReference.GMCSoap)(this)).Step(inValue);
            return retVal.Body.StepResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GmcReference.StepResponse> GmcReference.GMCSoap.StepAsync(GmcReference.StepRequest request) {
            return base.Channel.StepAsync(request);
        }
        
        public System.Threading.Tasks.Task<GmcReference.StepResponse> StepAsync(GmcReference.CoordinateTuple coordinate, GmcReference.MoveObjectType type, System.Guid id) {
            GmcReference.StepRequest inValue = new GmcReference.StepRequest();
            inValue.Body = new GmcReference.StepRequestBody();
            inValue.Body.coordinate = coordinate;
            inValue.Body.type = type;
            inValue.Body.id = id;
            return ((GmcReference.GMCSoap)(this)).StepAsync(inValue);
        }
    }
}
