using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ground_Service_Control
{
    /// <summary>
    /// Номер задачи, которая назначается УНО обслуживающей службе.
    /// </summary>
    public class ServiceTaskId
    {
        internal Guid plane;
        internal ServiceTaskType type;
    };

    internal enum ServiceTaskType
    {
        None,

        BaggageTractor, //< Перевозчик багажа
        CateringTruck, //< Питание
        ContainerLoader, //< Погрузчик багажа (типа трапа?)
        Deicer,
        PassengerBus,
        PassengerStairs, //< Трап
        Refueler,  //< Топливо
        VIPShuttle
    }
}