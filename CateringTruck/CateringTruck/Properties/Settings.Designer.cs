﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CateringTruck.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://airport-dko-gmc.azurewebsites.net/gmc.asmx")]
        public string CateringTruck_GmcVS_GMC {
            get {
                return ((string)(this["CateringTruck_GmcVS_GMC"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://airport-dko-gsc.azurewebsites.net/gsc.asmx")]
        public string CateringTruck_GscVS_GSC {
            get {
                return ((string)(this["CateringTruck_GscVS_GSC"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://airport-dko-aircraft-generator.azurewebsites.net/AircraftGenerator.asmx")]
        public string CateringTruck_AircraftGeneratorVS_AircraftGenerator {
            get {
                return ((string)(this["CateringTruck_AircraftGeneratorVS_AircraftGenerator"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://airport-dko-passengers.azurewebsites.net/WebServiceCheckIn.asmx")]
        public string CateringTruck_ChechinVS_WebServiceCheckIn {
            get {
                return ((string)(this["CateringTruck_ChechinVS_WebServiceCheckIn"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://airport-dko-metrological.azurewebsites.net/MetrologService.asmx")]
        public string CateringTruck_MetrologServiceVS_MetrologService {
            get {
                return ((string)(this["CateringTruck_MetrologServiceVS_MetrologService"]));
            }
        }
    }
}
