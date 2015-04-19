using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebInformationPanel
{
    public enum Cities
    {
        Tokyo,
        Kyiv,
        Whitecourt,
        Roma,
        Washington,
        Minsk,
        Almaty,
    };

    public class Flight
    {
        public Guid number { get; set; }                    //id рейса
        public Cities city { get; set; }                    //город назначения
        public DateTime arrivalTime { get; set; }           //время прилёта
        public DateTime takeoffTime { get; set; }           //время отправления

        public DateTime StartRegistrationTime { get; set; } //начало регистрации
        public DateTime EndRegistrationTime { get; set; }   //конец регистрации

        public int EconomPassengersCount { get; set; }      //количество обычных пассажиров
        public int VipPassengersCount { get; set; }         //количество vip-ов

        public Guid? BindPlaneID { get; set; }               //id самолёта, который полетит этим рейсом
        public bool IsReadyTakeOff { get; set; }            //готов ли самолёт вылетать
    }
}