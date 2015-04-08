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

        public ServiceTask createContainerLoader(bool load)
        {
            return m_plane.baggage <= 0
                ? (ServiceTask) new NoServiceTask(m_plane)
                : new ContainerLoaderServiceTask(m_plane, load);
        }

        public ServiceTask createBaggageTractor(bool load)
        {
            return m_plane.baggage <= 0
                ? new NoServiceTask(m_plane)
                : (ServiceTask)new BaggageTractorServiceTask(m_plane, load);
        }

        public ServiceTask createPassengerStairs(bool load)
        {
            return !m_plane.ladder
                ? new NoServiceTask(m_plane)
                : (ServiceTask)new PassengerStairsServiceTask(m_plane, load);
        }

        public ServiceTask createVIPShuttle(bool load)
        {
            return m_plane.VIPPassengers <= 0
                ? new NoServiceTask(m_plane)
                : (ServiceTask) new VIPShuttleServiceTask(m_plane, load);
        }

        public ServiceTask createPassengerBus(bool load)
        {
            return m_plane.economPassengers <= 0
                ? new NoServiceTask(m_plane)
                : (ServiceTask) new PassengerBusServiceTask(m_plane, load);
        }

        public ServiceTask createCateringTruck()
        {
            return m_plane.economPassengers + m_plane.VIPPassengers <= 0
                ? new NoServiceTask(m_plane)
                : (ServiceTask) new CateringTruckServiceTask(m_plane);
        }

        public ServiceTask createRefueler()
        {
            return m_plane.fuelingNeeds <= 0
                ? new NoServiceTask(m_plane)
                : (ServiceTask) new RefuelerServiceTask(m_plane);
        }

        private readonly PlaneNeeds m_plane;
    }
}