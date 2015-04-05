using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCheckIn.ServiceReferenceTicketSales;

namespace WebTicketSales
{
    /// <summary>
    /// возможные состояния пассажиров
    /// </summary>
    public enum PassengerState
    {
        Created,        //создан, но ленив
        Buy,            //купил билет
        Registered,     //зарегестрирован
        Onboard         //на борту
    }

    /// <summary>
    /// предпочтения в питании
    /// </summary>
    public enum Food
    {
        Diabetic,
        Vegetarian,
        Children,
        LowCalorie,
        Default
    };

    /// <summary>
    /// Пассажир
    /// </summary>
    public class Passenger
    {
        public Guid ID { get; private set; }            //id-шник (спасибо капитан)
        private static Random random = new Random();
        public PassengerState State { get; set; }       //состояние пассажира
        public Food PreferFood { get; set; }    //любимая еда 
        public int WeightBaggage { get; set; }  //багаж, который взял с собой 
        public Ticket Ticket { get; set; }

        public Passenger()
        {
            State = PassengerState.Created;
            PreferFood = (Food)random.Next(0, 5);
            WeightBaggage = random.Next(0, 50);
            ID = Guid.NewGuid();
        }

        public Passenger(Food food, int baggage)
        {
            State = PassengerState.Created;
            PreferFood = food;
            WeightBaggage = baggage;
            ID = Guid.NewGuid();
        }
    }
}