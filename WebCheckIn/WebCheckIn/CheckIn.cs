using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCheckIn.TicketSalesService;
using WebTicketSales;


namespace WebCheckIn
{
    public class Catering
    {
        public int Diabetic { get; set; }
        public int Vegetarian { get; set; }
        public int Children { get; set; }
        public int LowCalorie { get; set; }
        public int Default { get; set; }
    }

    public class RegistrationWriting
    {
        public Guid FligthID { get; set; }
        public Passenger Passenger { get; set; }
    }

    class CheckIn
    {
        
        private WebServiceTicketSales ticketSales = new WebServiceTicketSales();
        private InformationPanelService.WebServiceInformationPanel informationPanel = new InformationPanelService.WebServiceInformationPanel();
        private List<RegistrationWriting> RegistrationBase = new List<RegistrationWriting>();
        private MqSender Logger = new MqSender("LoggerQueue");
        private MetrologService.MetrologService metrolog = new MetrologService.MetrologService();

        public CheckIn()
        {
            Logger.Connect();
        }
        /// <summary>
        /// возвращает суммарный вес багажа
        /// </summary>
        /// <param name="flightNumber">id рейса</param>
        /// <returns>вес</returns>
        public int GetBaggage(Guid flightNumber)
        {
            SendMsgToLogger(0, "Получен запрос на багаж. рейс" + flightNumber);
            return RegistrationBase.Where(s => s.FligthID == flightNumber).Sum(s =>s.Passenger.WeightBaggage);
        }

        /// <summary>
        /// возвращает количество коробок с едой каждого типа
        /// </summary>
        /// <param name="flightNumber">id рейса</param>
        /// <returns></returns>
        public Catering GetCatering(Guid flightNumber)
        {
            SendMsgToLogger(0, "Получен запрос на питание. рейс " + flightNumber);
            //получаем всех пассажиров, которые зарегестрированы на рейс
            var fligths = RegistrationBase.Where(s => s.FligthID == flightNumber).ToList();
            //считаем количество необходимых кантейнеров по каждому типу
            var c = new Catering()
            {
                Children = fligths.Count(s => s.Passenger.PreferFood == Food.Children),
                Default = fligths.Count(s => s.Passenger.PreferFood == Food.Default),
                Diabetic = fligths.Count(s => s.Passenger.PreferFood == Food.Diabetic),
                LowCalorie = fligths.Count(s => s.Passenger.PreferFood == Food.LowCalorie),
                Vegetarian = fligths.Count(s => s.Passenger.PreferFood == Food.Vegetarian)
            };
            return c;
        }

        /// <summary>
        /// возвращает список пассажиров эконом-класса
        /// </summary>
        /// <param name="flightNumber">номер рейса</param>
        /// <returns>список пассажиров</returns>
        public List<Guid> GetSimplePassengers(Guid flightNumber)
        {
            SendMsgToLogger(0,"Получен запрос на обычных пассажиров "+ flightNumber);
            //получаем всех пассажиров, которые зарегестрированы на рейс
            var fligths = RegistrationBase.Where(s => s.FligthID == flightNumber).ToList();
            //возвращаем айдишники пассажиров эконома
            return fligths.Where(s => s.Passenger.Ticket.TicketClass == Class.Econom).Select(s => s.Passenger.ID).ToList();
        }

        /// <summary>
        /// возвращает список vip-ов
        /// </summary>
        /// <param name="flightNumber">id рейса</param>
        /// <returns></returns>
        public List<Guid> GetVips(Guid flightNumber)
        {
            SendMsgToLogger(0, "Получен запрос на vip пассажиров " + flightNumber);
            //получаем всех пассажиров, которые зарегестрированы на рейс
            var fligths = RegistrationBase.Where(s => s.FligthID == flightNumber).ToList();
            //возвращаем айдишники пассажиров випа
            return fligths.Where(s => s.Passenger.Ticket.TicketClass == Class.Vip).Select(s => s.Passenger.ID).ToList();
        }

        /// <summary>
        /// метод регистрации пассажиров
        /// </summary>
        /// <param name="passenger">пассажир</param>
        /// <returns>удалось ли зарегестрироваться</returns>
        public bool Registrate(Passenger passenger)
        {
            //если у пассажира небыло билета - выгоняем его с регистрации
            if (passenger.Ticket == null)
                return false;
            try
            {
                //если касса говорит, что такой пассажир билет на этот рейс не покупал - на самолёт ему, собственно, нельзя
                if (!ticketSales.CheckTicket(passenger.ID, passenger.Ticket.FlightID))
                    return false;

                var fligths = informationPanel.GetFlightsForRegistration();
                var fligth = fligths.FirstOrDefault(s => s.number == passenger.Ticket.FlightID);
                //если в списке рейсов с открытой регистрацией нет рейса, на который хотел бы зарегестрироваться пассажир - или он опаздал, или рано пришёл. пусть погуляет
                if (fligth == null)
                    return false;
                //и вот, если пассажир прошёл через все проверки, то он может зарегестрироваться(но улетит ли он - большой вопрос)
                RegistrationBase.Add(new RegistrationWriting() { FligthID = fligth.number, Passenger = passenger });
                SendMsgToLogger(1, string.Format("пассажир {0} зарегистрирован на рейс{1}",passenger.ID,fligth.number));

                return true;

            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public void Reset()
        {
            RegistrationBase.Clear();
        }

        private void SendMsgToLogger(int status, string text)
        {
            try
            {
                DateTime t = metrolog.GetCurrentTime();
                Logger.SendMsg(string.Format("{0}_{1}_{2}_CheckIn_{3}",
                    t.ToString("dd.MM.yyyy"), t.ToString("HH:mm:ss"), status, text));
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}
