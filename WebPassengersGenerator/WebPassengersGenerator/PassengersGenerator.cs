using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        public List<Passenger> passengers = new List<Passenger>();          //база пассажиров 
        private PassengersStatistic statistic = new PassengersStatistic();
        public int generateSleep = 50;                                      //интервал при генерации
        private MetrologService.MetrologService metrolog = new MetrologService.MetrologService();


        public PassengersGenerator()
        {

        }

        /// <summary>
        /// генерирует рендомных пассажиров
        /// </summary>
        /// <param name="count">количество</param>
        public void GenerateRandomPassengers(int count)
        {
            new Task(()=>AsyncGenerateRandomPassengers(count)).Start();
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
                int behavior = random.Next(0,3);
                switch (behavior)
                {
                    case 0: //купиь билет
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
                            sendCateringStatistic(passenger.PreferFood);
                        }
                        break;
                    default:
                        break;
                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// проставляет пассажиру состояние "на борту"
        /// </summary>
        /// <param name="passengerId">id пассажира</param>
        /// <returns>папал ли пассажир на борт</returns>
        public bool onPlane(List<Guid> passengersidGuids)
        {
            foreach (var passengersidGuid in passengersidGuids)
            {
                var passenger = passengers.FirstOrDefault(s => s.ID == passengersidGuid);
                if (passenger != null)
                {
                    passenger.State = PassengerState.Onboard;
                    statistic.OnBoard++;
                    SendMsgToLogger(0, string.Format("Пассажир {0} на борту", passenger.ID));
                }
            }
            SendInformation(5, statistic.OnBoard);
            return true;
        }

        public List<Passenger> GetPassengersList()
        {
            return passengers;
        }

        public void Reset()
        {
            passengers.Clear();
            statistic = new PassengersStatistic();
        }

        private void SendMsgToLogger(int status, string text)
        {
            try
            {
                DateTime t = metrolog.GetCurrentTime();
                Logger.SendMessage(text);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// отправка сообщения на дашборд
        /// </summary>
        /// <param name="status">тип сообщения</param>
        /// <param name="newCount"> количество</param>
        private void SendInformation(int status, int newCount)
        {
            try
            {
                Dashboard.SendMessage(string.Format("PS_{0}_{1}",status,newCount)); 
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// отправляет статистику о питании на дашборт
        /// </summary>
        /// <param name="f">тип еды</param>
        private void sendCateringStatistic(Food f)
        {
            try
            {
                int y = 0, z = 0; //y - тип сообщения. z - количество
                var p = passengers.Where(s => s.State == PassengerState.Registered || s.State == PassengerState.Onboard);
                switch (f)
                {
                    case Food.Children:
                        z = p.Count(s => s.PreferFood == Food.Children);
                        y = 5;
                        break;
                    case Food.Default:
                        z = p.Count(s => s.PreferFood == Food.Default);
                        y = 2;
                        break;
                    case Food.Diabetic:
                        z = p.Count(s => s.PreferFood == Food.Diabetic);
                        y = 3;
                        break;
                    case Food.LowCalorie:
                        z = p.Count(s => s.PreferFood == Food.LowCalorie);
                        y = 6;
                        break;
                    case Food.Vegetarian:
                        z = p.Count(s => s.PreferFood == Food.Vegetarian);
                        y = 4;
                        break;
                }
                Dashboard.SendMessage(string.Format("FD_{0}_{1}", 1, p.Count()));
                Dashboard.SendMessage(string.Format("FD_{0}_{1}", y, z));
            }
            catch (Exception)
            {
            }
        }

        private void AsyncGenerateRandomPassengers(int count)
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
                SendInformation(1, statistic.Created);
                SendMsgToLogger(0, "Создан пассажир " + passengers.Last().ID);
                Thread.Sleep(generateSleep);
            }
        }
    }
}