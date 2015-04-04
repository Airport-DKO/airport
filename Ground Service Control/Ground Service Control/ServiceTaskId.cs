using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ground_Service_Control
{
    /// <summary>
    /// Номер задачи, которая назначается УНО обслуживающей службе.
    /// </summary>
    public class ServiceTaskId
    {
        public Guid plane;
        public string data;
        public int id;
    };
}