using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Ground_Service_Control.AircraftGenerator;

namespace Ground_Service_Control
{
    /// <summary>
    /// Самолёт и вся необходимая информация о нём
    /// </summary>
    internal class PlaneNeeds
    {
        public Guid plane;
        public Flight flight;
        public bool ladder;
        public int economPassengers;
        public int VIPPassengers;
        public int baggage;
        public int fuelingNeeds;
        public GMC.MapObject serviceZone;
    };

    internal class TasksGenerator
    {
        //Приблизительный порядок наземного обслуживания:
        //http://www.atmseminar.org/seminarContent/seminar8/papers/p_153_AO.pdf
        //http://www.boeing.com/commercial/aeromagazine/aero_01/textonly/t01txt.html
        //1. Багажный трап.
        //  2. Выгрузить багаж.
        //    3. Загрузить багаж
        //1. Трап.
        //  2. Выгрузить пассажиров (VIP, обычные)
        //    3. Обслуживание кабины (еда)
        //    3. Заправка.
        //       4. Принять пассажиров.
        //5. Все операции завершены:
        //    взлёт.
        static public PlaneTask generateListOfTasksForPlane(PlaneNeeds plane)
        {
            var factory = new ServiceTaskFactory(plane);

            var task = new PlaneTask(plane);

            var luggageTrap = factory.createContainerLoader();
            var luggageUnload = factory.createBaggageTractor(false);
            var luggageLoad = factory.createBaggageTractor(true);

            luggageUnload.nextTasks.Add(luggageLoad);
            luggageTrap.nextTasks.Add(luggageUnload);

            var trap = factory.createPassengerStairs();
            var vipPassangersOut = factory.createVIPShuttle(false);
            var passangersOut = factory.createPassengerBus(false);
            var food = factory.createCateringTruck();
            var fuel = factory.createRefueler();
            var vipPassangersIn = factory.createVIPShuttle(true);
            var passangersIn = factory.createPassengerBus(true);

            fuel.nextTasks.Add(vipPassangersIn);
            fuel.nextTasks.Add(passangersIn);

            passangersOut.nextTasks.Add(food);
            passangersOut.nextTasks.Add(fuel);

            trap.nextTasks.Add(vipPassangersOut);
            trap.nextTasks.Add(passangersOut);

            task.AddTask(luggageTrap);
            task.AddTask(trap);

            return task;
        }
    };
     
    internal class ServiceTaskScheduler
    {
        /// <summary>
        /// Призвести обслуживание самолёта.
        /// </summary>
        public void servicePlane(PlaneNeeds needs)
        {
            foreach (var need in m_tasks)
            {
                Debug.Assert(need.plane.plane != needs.plane);
            }

            var planeTasks = TasksGenerator.generateListOfTasksForPlane(needs);
            m_tasks.Add(planeTasks);
            planeTasks.StartExecution();
        }

        /// <summary>
        /// Проверяет, есть ли следуещее задание для самолёта, если есть асинхронно выполняет его (с необходимой задержкой)
        /// </summary>
        /// <param name="previousTask">Выполненное задание</param>
        /// <returns>Если новое задание добавленно - true, false - заданий нет, можно взлетать</returns>
        public bool nextTask(ServiceTaskId previousTask)
        {
            foreach (var task in m_tasks.Where(task => task.plane.plane == previousTask.plane))
            {
                if (!task.nextTasks(previousTask))
                {
                    m_tasks.Remove(task);
                    return false;
                }

                return true;
            }

            Debug.Assert(false);
            return false;
        }

        /// <summary>
        /// Список задач для каждого самолёта.
        /// </summary>
        private readonly List<PlaneTask> m_tasks = new List<PlaneTask>();
    };
}