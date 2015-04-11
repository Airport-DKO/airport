using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Ground_Service_Control.AircraftGenerator;
using Ground_Service_Control.GMC;

namespace Ground_Service_Control
{
    internal class ServiceZone
    {
        public bool free = true;
        public GMC.MapObject zone = null;
        /// <summary>
        /// Самолёт, который обслуживаются или заходят на посадку
        /// </summary>
        public Guid plane;
    };

    public class GSC_impl
    {
        public static GSC_impl self()
        {
            return m_self;
        }

        public bool SetFreePlace(Guid plane)
        {
            lock (m_lock)
            {
                foreach (var zone in m_serviceZones.Where(zone => zone.plane == plane))
                {
                    Debug.Assert(!zone.free);

                    zone.free = true;
                    zone.plane = Guid.Empty;

                    return true;
                }

                Debug.Assert(false);

                return true;
            }
        }

        public GMC.MapObject GetFreePlace(Guid plane)
        {
            lock (m_lock)
            {
                Debug.Assert(m_serviceZones != null);

                foreach (var zone in m_serviceZones.Where(zone => zone.free))
                {
                    zone.free = false;
                    zone.plane = plane;

                    return zone.zone;
                }

                return null;
            }
        }

        public bool SetNeeds(Guid plane, Flight flight, bool ladder, int economPassengers, int VIPPassengers,
           int baggage, int fuelingNeeds)
        {
            lock (m_lock)
            {
                var tmp = m_serviceZones.Where(z => z.plane == plane).ToList();

                Debug.Assert(tmp.Count() == 1);

                var zone = tmp.First();

                Debug.Assert(!zone.free);

                m_taskScheduler.servicePlane(new PlaneNeeds{ plane = plane, flight = flight, baggage = baggage, economPassengers = economPassengers, fuelingNeeds = fuelingNeeds, ladder = ladder, VIPPassengers = VIPPassengers, serviceZone =  zone.zone});

                return true;
            }
        }

        public bool Done(ServiceTaskId TaskNumber)
        {
            lock (m_lock)
            {
                if (!m_taskScheduler.nextTask(TaskNumber))
                {
                    //FIXME: сообщить, что готов к взлёту.
                }

                return true;
            }
        }

        private GSC_impl()
        {
            lock (m_lock)
            {
                m_gmc = new GMC.GMC();

                //FIXME:
                var zones=m_gmc.GetServiceZones();
                foreach (var mapObject in zones)
                {
                    m_serviceZones.Add(new ServiceZone() {zone = mapObject});
                }
                
            }
        }

        private readonly Object m_lock = new object();

        private GMC.GMC m_gmc = null;

        /// <summary>
        /// Список площадок под обслуживание самолётов.
        /// </summary>
        private readonly List<ServiceZone> m_serviceZones = new List<ServiceZone>();

        private readonly ServiceTaskScheduler m_taskScheduler = new ServiceTaskScheduler();

        private static readonly GSC_impl m_self = new GSC_impl();
    }
}