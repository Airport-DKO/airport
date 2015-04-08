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
        /// <summary>
        /// Перевозчик багажа
        /// </summary>
        BaggageTractor,
        /// <summary>
        /// Питание
        /// </summary>
        CateringTruck,
        /// <summary>
        /// Погрузчик багажа (типа трапа?)
        /// </summary>
        ContainerLoader,
        PassengerBus,
        /// <summary>
        /// Трап
        /// </summary>
        PassengerStairs,
        Refueler,
        VIPShuttle
    }
}
