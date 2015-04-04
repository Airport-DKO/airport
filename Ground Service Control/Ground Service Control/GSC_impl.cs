using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ground_Service_Control.AircraftGenerator;
using Ground_Service_Control.GMC;

namespace Ground_Service_Control
{
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
                //FIXME:
                return null;
            }
        }

        public bool SetNeeds(Guid plane, Flight flight, bool ladder, int economPassengers, int VIPPassengers,
           int baggage, int fuelingNeeds)
        {
            lock (m_lock)
            {
                //FIXME:
                return true;
            }
        }

        public bool Done(int TaskNumber)
        {
            lock (m_lock)
            {
                //FIXME:
                return true;
            }
        }

        private GSC_impl()
        {
        }

        private readonly Object m_lock = new object();

        private static readonly GSC_impl m_self = new GSC_impl();
    }
}