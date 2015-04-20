using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Ground_Service_Control
{
    /// <summary>
    /// Список задач для самолёта
    /// </summary>
    internal class PlaneTask
    {
        public PlaneTask(PlaneNeeds _plane)
        {
            plane = _plane;
        }

        public PlaneNeeds plane;

        public void AddTask(ServiceTask task)
        {
            m_tasks.Add(task);
        }

        /// <summary>
        /// Начинает выполнение заданий
        /// </summary>
        public void StartExecution()
        {
            var tasks = new List<ServiceTask>(m_tasks);
            foreach (var task in tasks)
            {
                executeTasks(task);
            }
        }

        /// <summary>
        /// Выполняет задачи, которые м.б. выполненны на данной стадии
        /// </summary>
        /// <param name="previousTask">Предыдущее задание</param>
        /// <returns>true если задание поставленно на выполнение, false - нет заданий</returns>
        public bool nextTasks(ServiceTaskId previousTask)
        {
            Debug.Assert(m_tasks.Count > 0);

            var tasks = new List<ServiceTask>(m_tasks);
            foreach (var task in tasks.Where(task => task.taskId == previousTask))
            {
                executeTasks(task);

                return m_tasks.Count > 0;
            }

            Debug.Assert(false);
            return false;
        }

        private void executeTasks(ServiceTask finishedTask)
        {
            m_tasks.Remove(finishedTask);

            foreach (var task in finishedTask.nextTasks)
            {
                //Utils.self().log("Begin: " + task.taskId.type + " самолёт: " + task.taskId.plane);
                task.execute();
                m_tasks.Add(task);
            }
        }

        /// <summary>
        /// Задачи, которые выполняются
        /// </summary>
        private readonly List<ServiceTask> m_tasks = new List<ServiceTask>();
    };
}