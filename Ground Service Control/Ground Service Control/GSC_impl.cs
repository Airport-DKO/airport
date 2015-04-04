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
        public MapObject zone = null;
    };

 
    public class GSC_impl
    {
        public static GSC_impl self()
        {
            return m_self;
        }

        public MapObject GetFreePlace(Guid plane)
        {
            lock (m_lock)
            {
                Debug.Assert(m_serviceZones != null);

                //FIXME: Как узнать, что площадка освободилась.
                foreach (var zone in m_serviceZones)
                {
                    if (!zone.free) continue;

                    zone.free = false;

                    Debug.Assert(!m_planes.Contains(plane));
                    m_planes.Add(plane);
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
                Debug.Assert(m_planes.Contains(plane));


                //FIXME: Отправить все службы на обслуживание самолёта.
                return true;
            }
        }

        public bool Done(ServiceTaskId TaskNumber)
        {
            lock (m_lock)
            {
                //FIXME:
                return true;
            }
        }

        private GSC_impl()
        {
            lock (m_lock)
            {
                m_gmc = new GMC.GMC();

                //FIXME:
                return;
                List<MapObject> zones = null;
                //zones = m_gmc.GetServiceZones(); 
                foreach (var zone in zones)
                {
                    m_serviceZones.Add(new ServiceZone {zone = zone, free = true});
                }

            }
        }

        private readonly Object m_lock = new object();

        private GMC.GMC m_gmc = null;

        /// <summary>
        /// Список площадок под обслуживание самолётов.
        /// </summary>
        private List<ServiceZone> m_serviceZones = null;

        /// <summary>
        /// Список самолётов, которые обслуживаются или заходят на посадку
        /// </summary>
        private readonly List<Guid> m_planes = new List<Guid>();

        /// <summary>
        /// Список служб, которые выполняются в данный момент
        /// </summary>
        private List<int> m_task = new List<int>(); 

        private static readonly GSC_impl m_self = new GSC_impl();
    }
}