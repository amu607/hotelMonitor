using System;
using System.Collections.Generic;
using hotelMonitor.Models;
using hotelMonitor.Models.Entity;

namespace hotelMonitor.Services.Interface
{
    public interface IHotelService
    {
        /// <summary>
        /// Get Hotel Tasks
        /// </summary>
        /// <param name="index"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        HotelTaskListViewModel GetTasks(int index, int rowCount);

        /// <summary>
        /// Add Task
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="workerName"></param>
        /// <param name="roomName"></param>
        void AddTask(string taskName, string workerName, string roomName);

        /// <summary>
        /// Update Hotel Task Status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="taskStatus"></param>
        void UpdateTaskStatus(Guid id, HotelTaskStatus taskStatus );
    }


}