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
        public int generateSleep = 300;                                //интервал при генерации
        private MqSender Logger = new MqSender("LoggerQueue");

        public PassengersGenerator()
        {
            Logger.Connect();
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
        }

        /// <summary>
        /// иммитация поведения пассажиров(одна итеррация)
        /// </summary>
        public void PassengerBehavior()
        {
            var p = passengers.Where(s => s.State != PassengerState.Onboard&&s.State != PassengerState.Registered).ToArray();
            foreach (var passenger in p)
            {
                int behavior = random.Next(0, 3);
                switch (behavior)
                {
                    case 0: //купиь билет
                        var ticket = ticketSales.BuyTicket(passenger.ID);
                        if (ticket != null)
                        {
                            passenger.Ticket = ticket;

                            passenger.State = PassengerState.Buy;
                            statistic.Buy++;
                        }
                        break;
                    case 1: //вернуть билет
                        if (ticketSales.ReturnTicket(passenger.ID))
                        {
                            passenger.Ticket = null;
                            passenger.State = PassengerState.Created;
                            statistic.Return++;
                        }
                        break;
                    case 2: //зарегестрироваться
                        if (CheckIn.Registrate(passenger))
                        {
                            passenger.State = PassengerState.Registered;
                            statistic.Registred++;
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
                return true;
            }
            return false;
        }

        /// <summary>
        /// получение информации для дашборда
        /// </summary>
        /// <returns>статистика генератора </returns>
        public PassengersStatistic GetPassengersInfo()
        {
            return statistic;
        }

        public List<Passenger> GetPassengersList()
        {
            return passengers;
        }

        public void Reset()
        {
            passengers.Clear();
        }
    }
}