using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace WebInformationPanel
{
    //TODO дабить логгирование
    class InformationPanel
    {
        List<Flight> FlightsBase = new List<Flight>();   //собственно, рейсы уже привязанные к самолёту
        private static Random random;
        private MetrologService.MetrologService metrolog = new MetrologService.MetrologService();
        private Thread thread;
        private MqSender Logger = new MqSender("LoggerQueue");

        public InformationPanel()
        {
            thread = new Thread(makeFligthLater);
            thread.Start();
            Logger.Connect();
        }

        /// <summary>
        /// создаёт рейс, и кладёт его в список
        /// </summary>
        /// <param name="takeoffTime">время вылета</param>
        /// <param name="city">направление</param>
        /// <param name="economPassengers">количество обычных пассажиров</param>
        /// <param name="vipPassengers">количество випов</param>
        public void CreateFlight(DateTime arrivalTime, DateTime takeoffTime, Cities city, int economPassengers, int vipPassengers)
        {
            Flight f = new Flight();
            f.number = Guid.NewGuid();
            f.takeoffTime = takeoffTime;
            f.city = city;
            f.EconomPassengersCount = economPassengers;
            f.VipPassengersCount = vipPassengers;
            f.IsReadyTakeOff = false;
            f.arrivalTime = arrivalTime;
            //проставляем время начала и окончания регистрации на рейс
            //допустим, что регистрация заканчивается за полчаса до вылета
            //и длится 2 часа
            //TODO (согласовать) возможно нужно больше времини, т.к. людей багаж и еду надо везди после окончания регистрации
            f.EndRegistrationTime = takeoffTime.AddMinutes(-30);
            f.StartRegistrationTime = f.EndRegistrationTime.AddHours(-2);
            FlightsBase.Add(f);
            SendMsgToLogger(1, "Cоздан рейс " + f.number);

        }

        /// <summary>
        /// получение списка свободных рейсов для гс
        /// </summary>
        /// <returns></returns>
        public List< Flight> GetAvailableFlights()
        {
            return FlightsBase.Where(s => s.BindPlaneID == null).ToList();
        }

        /// <summary>
        /// гс сообщает, что самолёт полностью готов к вылету
        /// </summary>
        /// <param name="fligthID">номер рейса</param>
        /// <returns></returns>
        public bool ReadyToTakeOff(Guid fligthID)
        {
            var f = FlightsBase.FirstOrDefault(s => s.number == fligthID);
            if (f != null)
            {
                return f.IsReadyTakeOff = true;
                SendMsgToLogger(1, "рейс готов к вылету " + f.number);
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
        public Flight RegisterPlaneToFlight(Guid planeid, Guid FlightId)
        {
            var f = FlightsBase.FirstOrDefault(s => s.number == FlightId);
            if (f != null)
            {
                f.BindPlaneID = planeid;
                SendMsgToLogger(0, string.Format("Рейс {0} привязан к самолёту {1}",f.number,planeid));
            }
            return f;
        }

        /// <summary>
        /// получаем рейсы, доступные для регистрации
        /// </summary> 
        /// <returns>список рейсов</returns>
        public List<Flight> GetFlightsForRegistration()
        {
            try
            {
                var time = metrolog.GetCurrentTime();
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
                var time = metrolog.GetCurrentTime();
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
        public bool IsCheckInFinished(Guid flightNumber) 
        {
            try
            {
                var time = metrolog.GetCurrentTime();
                var f = FlightsBase.FirstOrDefault(s => s.number == flightNumber);
                if (f == null) //это будет очень странно            
                    return false;
                if (time >= f.EndRegistrationTime)
                {
                    SendMsgToLogger(1, "Регистрация завершена. рейс"+flightNumber);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Табло отвечает, в ближайшие ли 5 минут вылет рейса
        /// </summary>
        /// <param name="flightNumber"> id рейса</param>
        /// <returns></returns>
        public bool IsFlightSoon(Guid flightNumber)
        {
            try
            {
                var time = metrolog.GetCurrentTime();
                var f = FlightsBase.FirstOrDefault(s => s.number == flightNumber);
                if (f == null) //это будет очень странно            
                    return false;
                return time >= f.takeoffTime.AddMinutes(-5);
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool IsFlightRightNow(Guid flightNumber)
        {
            try
            {
                var time = metrolog.GetCurrentTime();
                var f = FlightsBase.FirstOrDefault(s => s.number == flightNumber);
                if (f == null) //это будет очень странно            
                    return false;
                if (time >= f.takeoffTime)
                {
                    SendMsgToLogger(1,"рейс готов к вылету "+flightNumber );
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// отвечает кассе, можно ли вернвть билет на этот рейс
        /// </summary>
        /// <param name="flightNumber">номер рейса</param>
        /// <returns></returns>
        public bool CanReturnTicket(Guid flightNumber)
        {
            try
            {
                var time = metrolog.GetCurrentTime();
                var f = FlightsBase.FirstOrDefault(s => s.number == flightNumber);
                if (f == null) //это будет очень странно            
                    return false;
                return time <= f.StartRegistrationTime;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// сброс "системы"
        /// </summary>
        public void Reset()
        {
            FlightsBase.Clear();
        }

        /// <summary>
        /// Возвращает в GUI статус рейса
        /// </summary>
        /// <param name="flightNumber">id рейса</param>
        /// <returns>статус</returns>
        public string GetStatus(Guid flightNumber)
        {
            try
            {
                var time = metrolog.GetCurrentTime();
                var f = FlightsBase.FirstOrDefault(s => s.number == flightNumber);
                if (f == null) //это будет очень странно            
                    return string.Empty;

                //TODO спросить о правильных статусах (например, какой статус у рейса, самолёт для которого ещё не сгенерился, а регистрация уже началсь)
                if (time < f.arrivalTime)
                    return "Ожидается";
                if (time >= f.arrivalTime && f.BindPlaneID == null)
                    return "Задерживается";
                if (time >= f.StartRegistrationTime && time <= f.EndRegistrationTime)
                    return "Идёт регистрация";
                if (time >= f.EndRegistrationTime && time <= f.takeoffTime)
                    return "Идёт пасадка";
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
            return string.Empty;
        }

        /// <summary>
        /// поулчаем список всех рейсов для интерфейса
        /// </summary>
        /// <returns>список рейсов</returns>
        public List<Flight> GetFlightsList()
        {
            return FlightsBase;
        }

        /// <summary>
        /// функция потока, который будет переносить время вылета, если самолёт не готов улететь
        /// </summary>
        private void makeFligthLater()
        {
            //пока читерство. поток будет спать фиксированное время
            while (true)
            {
                var time = metrolog.GetCurrentTime();
                var flights = FlightsBase.Where(s => time >= s.takeoffTime && s.IsReadyTakeOff == false);
                foreach (var flight in flights)
                {
                    flight.takeoffTime = time.AddMinutes(20);
                    SendMsgToLogger(1, "Вылет рейса перенесён " + flight.number);
                }
                Thread.Sleep(100);
            }
        }


        private void SendMsgToLogger(int status, string text)
        {
            try
            {
                DateTime t = metrolog.GetCurrentTime();
                Logger.SendMsg(string.Format("{0}_{1}_{2}_InformationPanel_{3}",
                    t.ToString("dd.MM.yyyy"), t.ToString("HH:mm:ss"), status, text));
            }
            catch (Exception ex)
            {

            }
        }
    }
}