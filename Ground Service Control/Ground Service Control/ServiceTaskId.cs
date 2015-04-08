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
            //FIXME:
            return new BaggageTractor.ServiceTaskId();
        }

        public static implicit operator ContainerLoader.ServiceTaskId(ServiceTaskId d)
        {
            //FIXME:
            return new ContainerLoader.ServiceTaskId();
        }

        public static implicit operator PassengerStairs.ServiceTaskId(ServiceTaskId d)
        {
            //FIXME:
            return new PassengerStairs.ServiceTaskId();
        }

        public static implicit operator CateringTruck.ServiceTaskId(ServiceTaskId d)
        {
            //FIXME:
            return new CateringTruck.ServiceTaskId();
        }

        public static implicit operator PassengerBus.ServiceTaskId(ServiceTaskId d)
        {
            //FIXME:
            return new PassengerBus.ServiceTaskId();
        }

        public static implicit operator Refueler.ServiceTaskId(ServiceTaskId d)
        {
            //FIXME:
            return new Refueler.ServiceTaskId();
        }

        public static implicit operator VIPShuttle.ServiceTaskId(ServiceTaskId d)
        {
            //FIXME:
            return new VIPShuttle.ServiceTaskId();
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
