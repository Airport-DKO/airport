﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Ground_Service_Control
{
    /// <summary>
    /// Одна конкретная задача для самолёта и список задач, зависящих от неё.
    /// </summary>
    internal abstract class ServiceTask
    {
        protected ServiceTask(PlaneNeeds plane)
        {
            taskId.plane = plane.plane;
            context = plane;
        }

        public ServiceTaskId taskId = new ServiceTaskId();
        public List<ServiceTask> nextTasks = new List<ServiceTask>();
        public PlaneNeeds context = null;
        /// <summary>
        /// Выполняет текущее задание
        /// </summary>
        public abstract void execute();
    };

    internal abstract class TransportationServiceTask : ServiceTask
    {
        protected TransportationServiceTask(PlaneNeeds plane, bool load)
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
        public BaggageTractorServiceTask(PlaneNeeds plane, bool load)
            : base(plane, load)
        {
            taskId.type = ServiceTaskType.BaggageTractor;
        }

        public override void execute()
        {
            var t = new Task(() =>
            {
                //FIXME:
            });

            t.Start();
        }
    };

    internal class CateringTruckServiceTask : ServiceTask
    {
        public CateringTruckServiceTask(PlaneNeeds plane)
            : base(plane)
        {
            taskId.type = ServiceTaskType.CateringTruck;
        }

        public override void execute()
        {
            var t = new Task(() =>
            {
                //FIXME:
            });

            t.Start();
        }
    };

    internal class ContainerLoaderServiceTask : ServiceTask
    {
        public ContainerLoaderServiceTask(PlaneNeeds plane)
            : base(plane)
        {
            taskId.type = ServiceTaskType.ContainerLoader;
        }

        public override void execute()
        {
            var t = new Task(() =>
            {
                Thread.Sleep(Utils.self().systemTime(5000));

                //FIXME:
            });

            t.Start();
            return;
        }
    };

    internal class PassengerBusServiceTask : TransportationServiceTask
    {
        public PassengerBusServiceTask(PlaneNeeds plane, bool load)
            : base(plane, load)
        {
            taskId.type = ServiceTaskType.PassengerBus;
        }

        public override void execute()
        {
            var t = new Task(() =>
            {
                Thread.Sleep(Utils.self().systemTime(5000));

                //FIXME:
            });

            t.Start();
            return;
        }
    };

    internal class PassengerStairsServiceTask : ServiceTask
    {
        public PassengerStairsServiceTask(PlaneNeeds plane)
            : base(plane)
        {
            taskId.type = ServiceTaskType.PassengerStairs;
        }

        public override void execute()
        {
            var t = new Task(() =>
            {
                //FIXME:
            });

            t.Start();
        }
    };

    internal class RefuelerServiceTask : ServiceTask
    {
        public RefuelerServiceTask(PlaneNeeds plane)
            : base(plane)
        {
            taskId.type = ServiceTaskType.Refueler;
        }

        public override void execute()
        {
            var t = new Task(() =>
            {
                //FIXME:
            });

            t.Start();
        }
    };

    internal class VIPShuttleServiceTask : TransportationServiceTask
    {
        public VIPShuttleServiceTask(PlaneNeeds plane, bool load)
            : base(plane, load)
        {
            taskId.type = ServiceTaskType.VIPShuttle;
        }

        public override void execute()
        {
            var t = new Task(() =>
            {
                //FIXME:
            });

            t.Start();
        }
    };

    internal class NoServiceTask : ServiceTask
    {
        public NoServiceTask(PlaneNeeds plane)
            : base(plane)
        {
            taskId.type = ServiceTaskType.VIPShuttle;
        }

        public override void execute()
        {
            var t = new Task(() => GSC_impl.self().Done(taskId));
            t.Start();
        }
    };
}
