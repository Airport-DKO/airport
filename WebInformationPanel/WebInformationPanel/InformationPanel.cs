using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace WebInformationPanel
{
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

            //проставляем время начала и окончания регистрации на рейс
            //допустим, что регистрация заканчивается за полчаса до вылета
            //и длится 2 часа
            //TODO (согласовать) возможно нужно больше времини, т.к. людей багаж и еду надо везди после окончания регистрации
            f.EndRegistrationTime = takeoffTime.AddMinutes(-30);
            f.StartRegistrationTime = f.EndRegistrationTime.AddHours(-2);
            //TODO (спросить) забыла, когда и кем записывается время прибытия
            FlightsBase.Add(f);
        }

        //TODO Кирилл, есть серьёзный разговор
        public Flight GetFlightForPlane()
        {
            //TODO МАША, не забудь переделать, а то я тебя знаю
            return FlightsBase[0];
        }

        /// <summary>
        /// получаем рейсы, доступные для регистрации
        /// </summary>
        /// <returns>список рейсов</returns>
        //TODO подумать над тем, чтобы в этом методе вернуть просто список айдишников
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
    }
}