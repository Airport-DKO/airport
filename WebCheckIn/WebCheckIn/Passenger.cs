using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCheckIn.TicketSalesService;

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
        public Guid ID { get; set; }            //id-шник (спасибо капитан)
        public PassengerState State { get; set; }       //состояние пассажира
        public Food PreferFood { get; set; }    //любимая еда 
        public int WeightBaggage { get; set; }  //багаж, который взял с собой 
        public Ticket Ticket { get; set; }
    }
}