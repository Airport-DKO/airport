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
        public Guid plane;
        public ServiceTaskType type;

        public static implicit operator BaggageTractor.ServiceTaskId(ServiceTaskId d)
        {
            return new BaggageTractor.ServiceTaskId() { plane = d.plane, type = (BaggageTractor.ServiceTaskType)d.type };
        }

        public static implicit operator ContainerLoader.ServiceTaskId(ServiceTaskId d)
        {
            return new ContainerLoader.ServiceTaskId() { plane = d.plane, type = (ContainerLoader.ServiceTaskType)d.type };
        }

        public static implicit operator PassengerStairs.ServiceTaskId(ServiceTaskId d)
        {
            return new PassengerStairs.ServiceTaskId() { plane = d.plane, type = (PassengerStairs.ServiceTaskType)d.type };
        }

        public static implicit operator CateringTruck.ServiceTaskId(ServiceTaskId d)
        {
            return new CateringTruck.ServiceTaskId() { plane = d.plane, type = (CateringTruck.ServiceTaskType)d.type };
        }

        public static implicit operator PassengerBus.ServiceTaskId(ServiceTaskId d)
        {
            return new PassengerBus.ServiceTaskId() { plane = d.plane, type = (PassengerBus.ServiceTaskType)d.type };
        }

        public static implicit operator Refueler.ServiceTaskId(ServiceTaskId d)
        {
            return new Refueler.ServiceTaskId() { plane = d.plane, type = (Refueler.ServiceTaskType)d.type };
        }

        public static implicit operator VIPShuttle.ServiceTaskId(ServiceTaskId d)
        {
            return new VIPShuttle.ServiceTaskId() { plane = d.plane, type = (VIPShuttle.ServiceTaskType)d.type };
        }
    };

    public enum ServiceTaskType
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
