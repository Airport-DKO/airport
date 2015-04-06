using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ground_Service_Control
{
    /// <summary>
    /// Фабрика по созданию заданий. 
    /// Автоматически проверяет, нужно ли выполнить задание, если нет возвращает NoServiceTask объект.
    /// </summary>
    internal class ServiceTaskFactory
    {
        public ServiceTaskFactory(PlaneNeeds plane)
        {
            m_plane = plane;
        }

        public ServiceTask createContainerLoader()
        {
            return m_plane.baggage <= 0
                ? (ServiceTask) new NoServiceTask(m_plane.plane)
                : new ContainerLoaderServiceTask(m_plane.plane);
        }

        public ServiceTask createBaggageTractor(bool load)
        {
            return m_plane.baggage <= 0
                ? new NoServiceTask(m_plane.plane)
                : (ServiceTask)new BaggageTractorServiceTask(m_plane.plane, load);
        }

        public ServiceTask createPassengerStairs()
        {
            return !m_plane.ladder
                ? new NoServiceTask(m_plane.plane)
                : (ServiceTask)new PassengerStairsServiceTask(m_plane.plane);
        }

        public ServiceTask createVIPShuttle(bool load)
        {
            return m_plane.VIPPassengers <= 0
                ? new NoServiceTask(m_plane.plane)
                : (ServiceTask) new VIPShuttleServiceTask(m_plane.plane, load);
        }

        public ServiceTask createPassengerBus(bool load)
        {
            return m_plane.economPassengers <= 0
                ? new NoServiceTask(m_plane.plane)
                : (ServiceTask) new PassengerBusServiceTask(m_plane.plane, load);
        }

        public ServiceTask createCateringTruck()
        {
            return m_plane.economPassengers + m_plane.VIPPassengers <= 0
                ? new NoServiceTask(m_plane.plane)
                : (ServiceTask) new CateringTruckServiceTask(m_plane.plane);
        }

        public ServiceTask createRefueler()
        {
            return m_plane.fuelingNeeds <= 0
                ? new NoServiceTask(m_plane.plane)
                : (ServiceTask) new RefuelerServiceTask(m_plane.plane);
        }

        public ServiceTask createDeicer()
        {
            return Utils.self().temperature() > 4
                ? new NoServiceTask(m_plane.plane)
                : (ServiceTask) new DeicerServiceTask(m_plane.plane);
        }

        private readonly PlaneNeeds m_plane;
    }
}