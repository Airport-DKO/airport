using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services.Configuration;

using WebPassengersGenerator.ServiceCheckIn;
using WebPassengersGenerator.ServiceTicketSales;


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
        //WebServiceCheckIn CheckIn= new WebServiceCheckIn();
        //TicketSalesService.WebServiceTicketSales ticketSales = new WebServiceTicketSales();
        ServiceTicketSales.WebServiceTicketSalesSoapClient ticketSales = new WebServiceTicketSalesSoapClient();
        ServiceCheckIn.WebServiceCheckInSoapClient CheckIn = new WebServiceCheckInSoapClient();
        private static Random random = new Random();
        public List<Passenger> passengers = new List<Passenger>();   //база активных пассажиров (тех, которые уже созданы и ещё находятся в нашем аэропорту)
        private PassengersStatistic statistic = new PassengersStatistic();
        public int generateSleep = 0;                                //интервал при генерации

        /// <summary>
        /// генерирует рендомных пассажиров
        /// </summary>
        /// <param name="count">количество</param>
        public void GenerateRandomPassengers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                passengers.Add(new Passenger());
                statistic.Created++;
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
            var p = passengers.Where(s => s.State != PassengerState.Onboard).ToArray();
            foreach (var passenger in p)
            {
                int behavior = random.Next(0, 4);
                switch (behavior)
                {
                    case 0: //купиь билет
                        var ticket = ticketSales.BuyTicket(passenger.ID);
                        if (ticket != null)
                        {

                            //ТВОЮ Ж МАТЬ!!!!!
                            //passenger.Ticket = ticket;
                            //..................//TODO говорит, что не может кастить. вспомнить, как исправать

                            passenger.State = PassengerState.Buy;
                            statistic.Buy++;
                        }
                        break;
                    case 1: //вернуть билет
                        if (ticketSales.ReturnTicket(passenger.ID))
                        {
                            passenger.Ticket = null;
                            statistic.Return++;
                        }
                        break;
                    case 2: //зарегестрироваться
                        //TODO!!!!!опять несоответствие типов (ругается при передаче)
                        if (CheckIn.Registrate(passenger))
                        {
                            passenger.State = PassengerState.Registered;
                            statistic.Registred++;
                        }
                        break;
                    default:
                        break;
                }
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
    }
}