using System;
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

    internal class BaggageTractorServiceTask : ServiceTask
    {
        public BaggageTractorServiceTask(Guid plane)
            : base(plane)
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

    internal class PassengerBusServiceTask : ServiceTask
    {
        public PassengerBusServiceTask(Guid plane)
            : base(plane)
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

    internal class VIPShuttleServiceTask : ServiceTask
    {
        public VIPShuttleServiceTask(Guid plane)
            : base(plane)
        {
            taskId.type = ServiceTaskType.VIPShuttle;
        }

        public override void execute()
        {
            //FIXME:
            return;
        }
    };
}
