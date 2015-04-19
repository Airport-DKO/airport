using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTicketSales.InformationPanelService;



namespace WebTicketSales
{
    public class TicketSales
    {
        WebServiceInformationPanel informationPanel = new WebServiceInformationPanel();
        MetrologService.MetrologService metrolog = new MetrologService.MetrologService();
        private Random random = new Random();
        private List<Ticket> ticketsBase = new List<Ticket>();
        private MqSender Logger = new MqSender("LoggerQueue");

        public TicketSales()
        {
            Logger.Connect();
        }

        /// <summary>
        /// покупка билетов
        /// </summary>
        /// <param name="passengerId"> id покупателя</param>
        /// <returns>купленный билет</returns>
        public Ticket BuyTicket(Guid passengerId)
        {
            //если пассажир уже купил белет, то ещё один мы ему не отдаём
            if (ticketsBase.FirstOrDefault(s => s.PassengerID == passengerId) != null)
                return null;
            List<Flight> Flights;
            //если не удалось достучаться до табло
            try
            {
                //получаем список рейсов от табло
                Flights = informationPanel.GetFlightsForSales().ToList();
                if (Flights.Count == 0)
                    return null;
                //выбираем рандомный рейс
                int k = random.Next(Flights.Count);
                var flight = Flights[k];

                //пассажир выбирает условия обслуживания
                var behaver = (Class)random.Next(0, 2);
                int count;
                Ticket t;
                switch (behaver)
                {
                    case Class.Econom: //пассажир выбрал эконом
                        // смотрим количество уже купленных билетов эконом-класса
                        count = ticketsBase.Count(s => s.FlightID == flight.number && s.TicketClass == Class.Econom);
                        //если все билеты раскупили - пассажир уходит грустный :(
                        if (count >= flight.EconomPassengersCount)
                            return null;
                        // ну а если билеты остались - оформляем билет, и отдаём его пассажиру
                        t = new Ticket() { FlightID = flight.number, PassengerID = passengerId, TicketClass = Class.Econom };
                        break;
                    case Class.Vip: //пассажир выбрал Vip (всё то же самое с точностью до класса)
                        count = ticketsBase.Count(s => s.FlightID == flight.number && s.TicketClass == Class.Vip);
                        if (count >= flight.VipPassengersCount)
                            return null;
                        t = new Ticket() { FlightID = flight.number, PassengerID = passengerId, TicketClass = Class.Vip };
                        break;
                    default:
                        return null;
                }
                ticketsBase.Add(t);
                var time = metrolog.GetCurrentTime();
                Logger.SendMsg(string.Format("{0}_{1}_1_TicketSales_Пассажир {2} купил билет на рейс {3} {4} класса",
                    time.Date, time.TimeOfDay, t.PassengerID, t.FlightID, t.TicketClass));
                return t;
            }
            catch (Exception ex)
            {
                var time = metrolog.GetCurrentTime();
                Logger.SendMsg(string.Format("{0}_{1}_0_TicketSales_Error {2}",
                    time.Date, time.TimeOfDay, ex.Message));
                return null;
            }
        }

        /// <summary>
        /// возврат билетоа
        /// </summary>
        /// <param name="passengerId">id пассажира</param>
        /// <returns>удалось ли вернуть билет</returns>
        public bool ReturnTicket(Guid passengerId)
        {
            try
            {
                var ticket = ticketsBase.FirstOrDefault(s => s.PassengerID == passengerId);
                if (ticket != null)
                {
                    if (informationPanel.CanReturnTicket(ticket.FlightID))
                    {
                        var time = metrolog.GetCurrentTime();
                        ticketsBase.Remove(ticket);
                        Logger.SendMsg(
                            string.Format("{0}_{1}_1_TicketSales_Пассажир {2} вернул билет на рейс {3} {4} класса",
                                time.Date, time.TimeOfDay, ticket.PassengerID, ticket.FlightID, ticket.TicketClass));
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                var time = metrolog.GetCurrentTime();
                Logger.SendMsg(string.Format("{0}_{1}_0_TicketSales_Error {2}",
                    time.Date, time.TimeOfDay, ex.Message));
                return false;
            }
            return false;
        }

        /// <summary>
        /// проверка из регистрации, что пассажир действительно купил этот билет, и не сдал его
        /// </summary>
        /// <param name="passengerid">id пассажира</param>
        /// <param name="fligthid">id рейса</param>
        /// <returns></returns>
        public bool CheckTicket(Guid passengerid, Guid fligthid)
        {
            return ticketsBase.FirstOrDefault(s => s.FlightID == fligthid && s.PassengerID == passengerid) != null;
        }

        public void Reset()
        {
            ticketsBase.Clear();
        }
    }
}