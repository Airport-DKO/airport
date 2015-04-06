using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace WebInformationPanel
{
    //TODO написать логику переноса времени вылета!!!!!
    class InformationPanel
    {
        List<Flight> FlightsBase = new List<Flight>();   //собственно, рейсы уже привязанные к самолёту
        private static Random random;

        /// <summary>
        /// создаёт рейс, и кладёт его в список
        /// </summary>
        /// <param name="takeoffTime">время вылета</param>
        /// <param name="city">направление</param>
        /// <param name="economPassengers">количество обычных пассажиров</param>
        /// <param name="vipPassengers">количество випов</param>
        public void CreateFlight(DateTime takeoffTime, Cities city, int economPassengers, int vipPassengers)
        {
            Flight f = new Flight();
            f.number = Guid.NewGuid();
            f.takeoffTime = takeoffTime;
            f.city = city;
            f.EconomPassengersCount = economPassengers;
            f.VipPassengersCount = vipPassengers;
            f.IsReadyTakeOff = false;
            //проставляем время начала и окончания регистрации на рейс
            //допустим, что регистрация заканчивается за полчаса до вылета
            //и длится 2 часа
            //TODO (согласовать) возможно нужно больше времини, т.к. людей багаж и еду надо везди после окончания регистрации
            f.EndRegistrationTime = takeoffTime.AddMinutes(-30);
            f.StartRegistrationTime = f.EndRegistrationTime.AddHours(-2);
            //TODO (спросить) забыла, когда и кем записывается время прибытия
            FlightsBase.Add(f);
        }

        /// <summary>
        /// получение списка свободных рейсов для гс
        /// </summary>
        /// <returns></returns>
        public List< Flight> GetAvailableFlights()
        {
            return FlightsBase.Where(s => s.BindPlaneID == null).ToList();
        }

        public bool ReadyToTakeOff(Guid fligthID)
        {
            var f = FlightsBase.FirstOrDefault(s => s.number == fligthID);
            if (f != null)
            {
                f.IsReadyTakeOff = true;
                return true;
            }
            return false;
        }

        //TODO нет класса Pline, поэтому пока принимаем тольео id (возможны исправления) 
        //в принципе, можно с помощью этого метода предусмотреть функционал создания рейса специально под самолёт, но это если скучно будет
        /// <summary>
        /// привязка рейса к самолёту
        /// </summary>
        /// <param name="planeid">id самолёта</param>
        /// <param name="FlightId">id рейса</param>
        /// <returns></returns>
        public bool RegisterPlaneToFlight(Guid planeid, Guid FlightId)
        {
            var f = FlightsBase.FirstOrDefault(s => s.number == FlightId);
            if (f == null) return false;
            f.BindPlaneID = planeid;
            return true;
        }

        /// <summary>
        /// получаем рейсы, доступные для регистрации
        /// </summary>
        /// <returns>список рейсов</returns>
        public List<Flight> GetFlightsForRegistration()
        {
            try
            {
                //TODO получаем точное время от мс
                DateTime time = DateTime.Now;
                var t = FlightsBase.Where(s =>
                    time >= s.StartRegistrationTime && time <= s.EndRegistrationTime                //отбираем рейсы, регистрация на которые уже началась, но ещё не закончилась
                    && (s.VipPassengersCount > 0 || s.EconomPassengersCount > 0)).ToList();         //и на которых есть хоть какие-то места
                return t;
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// получение списка рейсов для кассы
        /// </summary>
        /// <returns>список рейсов, на которые можно купить билеты</returns>
        public List<Flight> GetFlightsForSales()
        {
            try
            {
                //TODO получаем точное время от мс
                DateTime time = DateTime.Now;
                var t = FlightsBase.Where(s => time <= s.EndRegistrationTime                     //допустим, что мы можем продовать билеты до окончания регистрации
                    && (s.VipPassengersCount > 0 || s.EconomPassengersCount > 0)).ToList();         //и на которых есть хоть какие-то места
                return t;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Табло отвечает, закончилась ли регистрация на рейс
        /// </summary>
        /// <param name="flightNumber">id рейса</param>
        /// <returns>конец регистрации</returns>
        public bool IsCheckInFinished(Guid flightNumber) //Табло отвечает, закончилась ли регистрация на рейс
        {
            //TODO получаем время от мс
            DateTime time = DateTime.Now;
            var f = FlightsBase.FirstOrDefault(s => s.number == flightNumber);
            if (f==null)//это будет очень странно            
                return false;
            return time >= f.EndRegistrationTime;
        }

        /// <summary>
        /// Табло отвечает, в ближайшие ли 5 минут вылет рейса
        /// </summary>
        /// <param name="flightNumber"> id рейса</param>
        /// <returns></returns>
        public bool IsFlightSoon(Guid flightNumber) 
        {
            //TODO получаем время от мс
            DateTime time = DateTime.Now;
            var f = FlightsBase.FirstOrDefault(s => s.number == flightNumber);
            if (f == null)//это будет очень странно            
                return false;
            return time >= f.takeoffTime.AddMinutes(-5);
        }

        public void Reset()
        {
            FlightsBase.Clear();
        }
    }
}