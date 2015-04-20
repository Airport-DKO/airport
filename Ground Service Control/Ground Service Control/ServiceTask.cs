﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Ground_Service_Control
{
    internal enum ServiceTaskRole
    {
        LoadPlane,
        UnloadPlane,
        MoveToGarage
    };

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
        protected TransportationServiceTask(PlaneNeeds plane, ServiceTaskRole _role)
            : base(plane)
        {
            taskId.type = ServiceTaskType.VIPShuttle;
            role = _role;
        }

        /// <summary>
        /// Показывает, должен ли самолёт быть загружен или разгружен.
        /// </summary>
        public ServiceTaskRole role { set; get; }
    };

    internal class BaggageTractorServiceTask : TransportationServiceTask
    {
        public BaggageTractorServiceTask(PlaneNeeds plane, ServiceTaskRole role)
            : base(plane, role)
        {
            taskId.type = ServiceTaskType.BaggageTractor;
        }

        public override void execute()
        {
            var t = new Task(() =>
            {
                var bt = new BaggageTractor.BaggageTractor();

                if (role == ServiceTaskRole.LoadPlane)
                {
                    bt.LoadBaggage(context.serviceZone, context.flight.number, taskId);
                    return;
                }

                bt.UnloadBaggage(context.serviceZone, context.baggage, taskId);
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
                Utils.self().waitTillCheckInFinished(context.flight.number);

                var ct = new CateringTruck.CateringTruck();
                ct.LoadFood(context.serviceZone, context.flight.number, taskId);
            });

            t.Start();
        }
    };

    internal class ContainerLoaderServiceTask : TransportationServiceTask
    {
        public ContainerLoaderServiceTask(PlaneNeeds plane, ServiceTaskRole role)
            : base(plane, role)
        {
            taskId.type = ServiceTaskType.ContainerLoader;
        }

        public override void execute()
        {
            var t = new Task(() =>
            {
                Utils.self().sleep(5000);

                var cl = new ContainerLoader.ContainerLoader();
                if(role == ServiceTaskRole.MoveToGarage){
                    cl.ToGarage(context.serviceZone);
                    GSC_impl.self().Done(taskId);
                    return;
                } else if (role == ServiceTaskRole.UnloadPlane){
                    cl.ToServiceZone(context.serviceZone, context.flight.number, taskId);
                    return;
                }

                Utils.self().waitTillCheckInFinished(context.flight.number);

                var baggage = new BaggageTractor.BaggageTractor();

                if(baggage.ToPlain(context.flight.number)){
                    if (context.baggage <= 0)
                    {
                        cl.ToServiceZone(context.serviceZone, context.flight.number, taskId);
                    }
                    else
                    {
                        GSC_impl.self().Done(taskId);
                    }
                } else {
                    cl.ToGarage(context.serviceZone);
                    GSC_impl.self().Done(taskId);
                }
            });

            t.Start();
            return;
        }
    };

    internal class PassengerBusServiceTask : TransportationServiceTask
    {
        public PassengerBusServiceTask(PlaneNeeds plane, ServiceTaskRole role)
            : base(plane, role)
        {
            taskId.type = ServiceTaskType.PassengerBus;
        }

        public override void execute()
        {
            var t = new Task(() =>
            {
                var pb = new PassengerBus.PassengerBus();

                if (role == ServiceTaskRole.LoadPlane)
                {
                    Utils.self().waitTillCheckInFinished(context.flight.number);
                    pb.LoadPassengers(context.serviceZone, context.flight.number, taskId);
                    return;
                }

                Utils.self().sleep(5000);
                pb.UnloadPassengers(context.serviceZone, context.economPassengers, taskId);
            });

            t.Start();
            return;
        }
    };

    internal class PassengerStairsServiceTask : TransportationServiceTask
    {
        public PassengerStairsServiceTask(PlaneNeeds plane, ServiceTaskRole role)
            : base(plane, role)
        {
            taskId.type = ServiceTaskType.PassengerStairs;
        }

        public override void execute()
        {
            var t = new Task(() =>
            {
                var ps = new PassengerStairs.PassengerStairs();

                if (role == ServiceTaskRole.MoveToGarage)
                {
                    ps.ToGarage(context.serviceZone);
                    GSC_impl.self().Done(taskId);
                    return;
                }
                else if (role == ServiceTaskRole.UnloadPlane)
                {
                    ps.ToServiceZone(context.serviceZone, context.flight.number, taskId);
                    return;
                }

                Utils.self().waitTillCheckInFinished(context.flight.number);

                var vip = new VIPShuttle.VIPShuttle();
                var bus = new PassengerBus.PassengerBus();

                var needTrap = vip.ToPlain(context.flight.number) || bus.ToPlain(context.flight.number);
                if (needTrap)
                {
                    if (context.economPassengers + context.VIPPassengers <= 0 && !context.ladder)
                    {
                        ps.ToServiceZone(context.serviceZone, context.flight.number, taskId);
                    }
                    else
                    {
                        GSC_impl.self().Done(taskId);
                    }
                } else {
                    ps.ToGarage(context.serviceZone);
                    GSC_impl.self().Done(taskId);
                }
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
                var rf = new Refueler.Refueler();
                rf.Fill(context.serviceZone, context.fuelingNeeds, taskId);
            });

            t.Start();
        }
    };

    internal class VIPShuttleServiceTask : TransportationServiceTask
    {
        public VIPShuttleServiceTask(PlaneNeeds plane, ServiceTaskRole role)
            : base(plane, role)
        {
            taskId.type = ServiceTaskType.VIPShuttle;
        }

        public override void execute()
        {
            var t = new Task(() =>
            {
                var vip = new VIPShuttle.VIPShuttle();
                if (role == ServiceTaskRole.LoadPlane)
                {
                    Utils.self().waitTillCheckInFinished(context.flight.number);
                    vip.LoadPassengers(context.serviceZone, context.flight.number, taskId);
                    return;
                }
                vip.UnloadPassengers(context.serviceZone, context.VIPPassengers, taskId);
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
