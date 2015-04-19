using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services.Configuration;
using WebPassengersGenerator.CheckInService;
using WebPassengersGenerator.TicketSalesService;


namespace WebPassengersGenerator
{
    /// <summary>
    /// класс, собирает статистику о пассажирах
    /// </summary>
    public class PassengersStatistic
    {
        public int Created { get; set; }
        public int Buy { get; set; }
        public int Return { get; set; }
        public int Registred { get; set; }
        public int OnBoard { get; set; }
    }

    class PassengersGenerator
    {
        WebServiceCheckIn CheckIn= new WebServiceCheckIn();
        TicketSalesService.WebServiceTicketSales ticketSales = new WebServiceTicketSales();
        private static Random random = new Random();
        public List<Passenger> passengers = new List<Passenger>();   //база активных пассажиров (тех, которые уже созданы и ещё находятся в нашем аэропорту)
        private PassengersStatistic statistic = new PassengersStatistic();
        public int generateSleep = 50;                                //интервал при генерации
        private MqSender Logger = new MqSender("LoggerQueue");
        private MqSender DashBoard = new MqSender("StatusQueue");
        private MetrologService.MetrologService metrolog = new MetrologService.MetrologService();
        private Catering cateringStatistic = new Catering();



        public PassengersGenerator()
        {
            Logger.Connect();
            DashBoard.Connect();
        }

        /// <summary>
        /// генерирует рендомных пассажиров
        /// </summary>
        /// <param name="count">количество</param>
        public void GenerateRandomPassengers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                passengers.Add(new Passenger()
                {
                    ID = Guid.NewGuid(),
                    PreferFood = (Food)random.Next(0, 5),
                    WeightBaggage = random.Next(0, 50),
                    State = PassengerState.Created
                });
                statistic.Created++;
                SendInformation(1,statistic.Created);
                SendMsgToLogger(0,"Создан пассажир "+passengers.Last().ID);

                Thread.Sleep(generateSleep);
            }
        }

        /// <summary>
        /// генерация пассажира с параметрами (для графического интерфейса)
        /// </summary>
        /// <param name="food">предпочтение в еде</param>
        /// <param name="baggage">вес багажа</param>
        public void GeneratePassenger(Food food, int baggage)
        {
            passengers.Add(new Passenger()
            {
                ID = Guid.NewGuid(),
                PreferFood = food,
                State =PassengerState.Created,
                Ticket = null,
                WeightBaggage = baggage});
            statistic.Created++;
            SendInformation(1, statistic.Created);
            SendMsgToLogger(0, "Создан пассажир " + passengers.Last().ID);
        }

        /// <summary>
        /// иммитация поведения пассажиров(одна итеррация)
        /// </summary>
        public void PassengerBehavior()
        {
            var p = passengers.Where(s => s.State != PassengerState.Onboard&&s.State != PassengerState.Registered).ToArray();
            foreach (var passenger in p)
            {
                int behavior = random.Next(0,0);
                switch (behavior)
                {
                    case 0: //купиь билет
                        SendMsgToLogger(1, string.Format("Пассажир {0} хочет купить билет на рейс{1}", passenger.ID));
                        var ticket = ticketSales.BuyTicket(passenger.ID);
                        if (ticket != null)
                        {
                            passenger.Ticket = ticket;

                            passenger.State = PassengerState.Buy;
                            statistic.Buy++;
                            SendInformation(2, statistic.Buy);
                            SendMsgToLogger(0, string.Format("Пассажир {0} купил билет на рейс{1}", passenger.ID,ticket.FlightID));
                        }
                        break;
                    case 1: //вернуть билет
                        if (ticketSales.ReturnTicket(passenger.ID))
                        {
                            passenger.Ticket = null;
                            passenger.State = PassengerState.Created;
                            statistic.Return++;
                            SendInformation(4, statistic.Return);
                            SendMsgToLogger(0, string.Format("Пассажир {0} вернул билет", passenger.ID));
                        }
                        break;
                    case 2: //зарегестрироваться
                        if (CheckIn.Registrate(passenger))
                        {
                            passenger.State = PassengerState.Registered;
                            statistic.Registred++;
                            SendInformation(3, statistic.Registred);
                            SendMsgToLogger(0, string.Format("Пассажир {0} зарегистрировался", passenger.ID));

                        }
                        break;
                    default:
                        break;
                }
                Thread.Sleep(generateSleep);
            }
        }

        /// <summary>
        /// проставляет пассажиру состояние "на борту"
        /// </summary>
        /// <param name="passengerId">id пассажира</param>
        /// <returns>папал ли пассажир на борт</returns>
        public bool onPlane(Guid passengerId)
        {
            var passenger = passengers.FirstOrDefault(s => s.ID == passengerId);
            if (passenger != null)
            {
                passenger.State = PassengerState.Onboard;
                statistic.OnBoard++;
                SendInformation(5, statistic.OnBoard);
                SendMsgToLogger(0, string.Format("Пассажир {0} на борту", passenger.ID));
                return true;
            }
            return false;
        }

        

        public List<Passenger> GetPassengersList()
        {
            return passengers;
        }

        public void Reset()
        {
            passengers.Clear();
        }

        private void SendMsgToLogger(int status, string text)
        {
            try
            {
                DateTime t = metrolog.GetCurrentTime();
                Logger.SendMsg(string.Format("{0}_{1}_{2}_PassengersGenerator_{3}",
                    t.ToString("dd.MM.yyyy"), t.ToString("HH:mm:ss"), status, text));
            }
            catch (Exception ex)
            {

            }
        }

        private void SendInformation(int status, int newCount)
        {
            try
            {
                DashBoard.SendMsg(string.Format("PS_{0}_{1}",status,newCount)); 
            }
            catch (Exception ex)
            {

            }
        }

        //private void sendCateringStatistic(Food f)
        //{
        //    int y = 0;
        //    switch (f)
        //    {
        //        case Food.Children:
        //            cateringStatistic.Children++;
        //            y = 5;
        //            break;
        //        case Food.Default:
        //            cateringStatistic.Default++;
        //            y = 2;
        //            break;
        //        case Food.Diabetic:
        //            cateringStatistic.Diabetic++;
        //            y = 3;
        //            break;
        //        case Food.LowCalorie:
        //            cateringStatistic.LowCalorie++;
        //            y = 6;
        //            break;
        //        case Food.Vegetarian:
        //            cateringStatistic.Vegetarian++;
        //            y = 4;
        //            break;       
        //    }


        //    DashBoard.SendMsg(string.Format("FD_{0}_{1}", y, newCount));
        //}
    }
}