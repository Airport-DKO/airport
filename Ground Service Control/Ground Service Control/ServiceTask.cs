﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ground_Service_Control
{
    /// <summary>
    /// Одна конкретная задача для самолёта и список задач, зависящих от неё.
    /// </summary>
    internal abstract class ServiceTask
    {
        protected ServiceTask(Guid plane)
        {
            taskId.plane = plane;
        }

        public ServiceTaskId taskId = new ServiceTaskId();
        public List<ServiceTask> nextTasks = new List<ServiceTask>();

        /// <summary>
        /// Выполняет текущее задание
        /// </summary>
        public abstract void execute();
    };

    internal abstract class TransportationServiceTask : ServiceTask
    {
        protected TransportationServiceTask(Guid plane, bool load)
            : base(plane)
        {
            taskId.type = ServiceTaskType.VIPShuttle;
            m_load = load;
        }

        public bool needToLoad()
        {
            return m_load;
        }
        /// <summary>
        /// Показывает, должен ли самолёт быть загружен или разгружен.
        /// </summary>
        private readonly bool m_load;
    };

    internal class BaggageTractorServiceTask : TransportationServiceTask
    {
        public BaggageTractorServiceTask(Guid plane, bool load)
            : base(plane, load)
        {
            taskId.type = ServiceTaskType.BaggageTractor;
        }

        public override void execute()
        {
            //FIXME:
            return;
        }
    };

    internal class CateringTruckServiceTask : ServiceTask
    {
        public CateringTruckServiceTask(Guid plane)
            : base(plane)
        {
            taskId.type = ServiceTaskType.CateringTruck;
        }

        public override void execute()
        {
            //FIXME:
            return;
        }
    };

    internal class ContainerLoaderServiceTask : ServiceTask
    {
        public ContainerLoaderServiceTask(Guid plane)
            : base(plane)
        {
            taskId.type = ServiceTaskType.ContainerLoader;
        }

        public override void execute()
        {
            //FIXME:
            return;
        }
    };

    internal class DeicerServiceTask : ServiceTask
    {
        public DeicerServiceTask(Guid plane)
            : base(plane)
        {
            taskId.type = ServiceTaskType.Deicer;
        }

        public override void execute()
        {
            //FIXME:
            return;
        }
    };

    internal class PassengerBusServiceTask : TransportationServiceTask
    {
        public PassengerBusServiceTask(Guid plane, bool load)
            : base(plane, load)
        {
            taskId.type = ServiceTaskType.PassengerBus;
        }

        public override void execute()
        {
            //FIXME:
            return;
        }
    };

    internal class PassengerStairsServiceTask : ServiceTask
    {
        public PassengerStairsServiceTask(Guid plane)
            : base(plane)
        {
            taskId.type = ServiceTaskType.PassengerStairs;
        }

        public override void execute()
        {
            //FIXME:
            return;
        }
    };

    internal class RefuelerServiceTask : ServiceTask
    {
        public RefuelerServiceTask(Guid plane)
            : base(plane)
        {
            taskId.type = ServiceTaskType.Refueler;
        }

        public override void execute()
        {
            //FIXME:
            return;
        }
    };

    internal class VIPShuttleServiceTask : TransportationServiceTask
    {
        public VIPShuttleServiceTask(Guid plane, bool load)
            : base(plane, load)
        {
            taskId.type = ServiceTaskType.VIPShuttle;
        }

        public override void execute()
        {
            //FIXME:
            return;
        }
    };

    internal class NoServiceTask : ServiceTask
    {
        public NoServiceTask(Guid plane)
            : base(plane)
        {
            taskId.type = ServiceTaskType.VIPShuttle;
        }

        public override void execute()
        {
            //TODO: сообщить о завершении.
        }
    };
}
