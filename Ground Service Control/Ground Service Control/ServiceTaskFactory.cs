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

        public ServiceTask createContainerLoader(ServiceTaskRole role)
        {
            return m_plane.baggage <= 0 && role == ServiceTaskRole.UnloadPlane
                ? (ServiceTask) new NoServiceTask(m_plane)
                : new ContainerLoaderServiceTask(m_plane, role);
        }

        public ServiceTask createBaggageTractor(ServiceTaskRole role)
        {
            return m_plane.baggage <= 0 && role == ServiceTaskRole.UnloadPlane
                ? new NoServiceTask(m_plane)
                : (ServiceTask)new BaggageTractorServiceTask(m_plane, role);
        }

        public ServiceTask createPassengerStairs(ServiceTaskRole role)
        {
            return !m_plane.ladder && role == ServiceTaskRole.UnloadPlane
                ? new NoServiceTask(m_plane)
                : (ServiceTask)new PassengerStairsServiceTask(m_plane, role);
        }

        public ServiceTask createVIPShuttle(ServiceTaskRole role)
        {
            return m_plane.VIPPassengers <= 0 && role == ServiceTaskRole.UnloadPlane
                ? new NoServiceTask(m_plane)
                : (ServiceTask) new VIPShuttleServiceTask(m_plane, role);
        }

        public ServiceTask createPassengerBus(ServiceTaskRole role)
        {
            return m_plane.economPassengers <= 0 && role == ServiceTaskRole.UnloadPlane
                ? new NoServiceTask(m_plane)
                : (ServiceTask) new PassengerBusServiceTask(m_plane, role);
        }

        public ServiceTask createCateringTruck()
        {
            return new CateringTruckServiceTask(m_plane);
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