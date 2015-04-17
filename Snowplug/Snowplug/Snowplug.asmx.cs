using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using Snowplug.GMC;

namespace Snowplug
{

    internal class TaskToken{
        public Task task;
        public System.Threading.CancellationTokenSource token;
    }

    /// <summary>
    /// Summary description for Snowplug
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Snowplug : System.Web.Services.WebService
    {
        /// <summary>
        /// УНД командует Снегоочистке убрать снег с карты
        /// </summary>
        /// <param name="coordinates">Путь, от гаража до гаража, проходяший по всей карте</param>
        /// <returns></returns>
        [WebMethod]
        public bool Clean(List<CoordinateTuple> coordinates)
        {
            var tmp = new List<TaskToken>(tasks);
            foreach(var task in tmp){
                if(task.task.IsCompleted){
                    tasks.Remove(task);
                }
            }

            System.Threading.CancellationTokenSource source = new System.Threading.CancellationTokenSource();
            var t = new Task(() => SnowplugTask.Clean(coordinates, source.Token));
            t.Start();
            tasks.Add(new TaskToken{task = t, token = source});

            return true;
        }

        [WebMethod]
        public void Reset() {
            foreach(var task in tasks){
                if(!task.task.IsCompleted){
                    task.token.Cancel();
                }
            }

            tasks.Clear();
        }

        static List<TaskToken> tasks = new List<TaskToken>();
    }
}
