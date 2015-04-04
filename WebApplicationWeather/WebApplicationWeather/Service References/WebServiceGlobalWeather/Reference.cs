﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34209
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationWeather.WebServiceGlobalWeather {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.webserviceX.NET", ConfigurationName="WebServiceGlobalWeather.GlobalWeatherSoap")]
    public interface GlobalWeatherSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetWeather", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetWeather(string CityName, string CountryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetWeather", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetWeatherAsync(string CityName, string CountryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetCitiesByCountry", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetCitiesByCountry(string CountryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetCitiesByCountry", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetCitiesByCountryAsync(string CountryName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GlobalWeatherSoapChannel : WebApplicationWeather.WebServiceGlobalWeather.GlobalWeatherSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GlobalWeatherSoapClient : System.ServiceModel.ClientBase<WebApplicationWeather.WebServiceGlobalWeather.GlobalWeatherSoap>, WebApplicationWeather.WebServiceGlobalWeather.GlobalWeatherSoap {
        
        public GlobalWeatherSoapClient() {
        }
        
        public GlobalWeatherSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GlobalWeatherSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GlobalWeatherSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GlobalWeatherSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetWeather(string CityName, string CountryName) {
            return base.Channel.GetWeather(CityName, CountryName);
        }
        
        public System.Threading.Tasks.Task<string> GetWeatherAsync(string CityName, string CountryName) {
            return base.Channel.GetWeatherAsync(CityName, CountryName);
        }
        
        public string GetCitiesByCountry(string CountryName) {
            return base.Channel.GetCitiesByCountry(CountryName);
        }
        
        public System.Threading.Tasks.Task<string> GetCitiesByCountryAsync(string CountryName) {
            return base.Channel.GetCitiesByCountryAsync(CountryName);
        }
    }
}
