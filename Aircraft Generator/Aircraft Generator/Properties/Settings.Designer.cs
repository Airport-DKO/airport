﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aircraft_Generator.Properties {
    
    
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
        [global::System.Configuration.DefaultSettingValueAttribute("http://airport-dko-gsc.azurewebsites.net/gsc.asmx")]
        public string Aircraft_Generator_GscWs_GSC {
            get {
                return ((string)(this["Aircraft_Generator_GscWs_GSC"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://airport-dko-gmc.azurewebsites.net/gmc.asmx")]
        public string Aircraft_Generator_GmcVs_GMC {
            get {
                return ((string)(this["Aircraft_Generator_GmcVs_GMC"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://airport-dko-gmc.azurewebsites.net/Tower.asmx")]
        public string Aircraft_Generator_TowerService_Tower {
            get {
                return ((string)(this["Aircraft_Generator_TowerService_Tower"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://airport-dko-gsc.azurewebsites.net/gsc.asmx")]
        public string Aircraft_Generator_GscWs2_GSC {
            get {
                return ((string)(this["Aircraft_Generator_GscWs2_GSC"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://airport-dko-passengers.azurewebsites.net/WebServiceInformationPanel.asmx")]
        public string Aircraft_Generator_InformationPanelWS_WebServiceInformationPanel {
            get {
                return ((string)(this["Aircraft_Generator_InformationPanelWS_WebServiceInformationPanel"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://airport-dko-metrological.azurewebsites.net/MetrologService.asmx")]
        public string Aircraft_Generator_MetrologicalService_MetrologService {
            get {
                return ((string)(this["Aircraft_Generator_MetrologicalService_MetrologService"]));
            }
        }
    }
}
