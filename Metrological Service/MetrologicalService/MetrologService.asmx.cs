using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Timers;

namespace MetrologicalService
{
    /// <summary>
    /// Сводное описание для MetrologService
    /// </summary>
    [WebService(Namespace = "Airport-Metrological-Service")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class MetrologService : System.Web.Services.WebService
    {

        [WebMethod]
        public DateTime GetCurrentTime()
        {
            return Core.Instance.timer;
        }

        [WebMethod]
        public void RefreshTick(double coeff)
        {
            Core.Instance.Rabb(coeff);
            Core.Instance.ModelingSpeed = coeff;
        }

        [WebMethod]
        public Double GetCurrentTick()
        {
            return Core.Instance.ModelingSpeed;
        }

        [WebMethod]
        public void Reset()
        {
            Core.Instance.ClearAllQueues();
            RefreshTick(1);
            Core.Instance.timer = DateTime.UtcNow.AddHours(3);
            Core.Instance.ModelingSpeed = 1;
        }
    }
}
