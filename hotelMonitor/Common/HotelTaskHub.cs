using System;
using System.Collections.Generic;
using hotelMonitor.Models;
using Microsoft.AspNet.SignalR;
using hotelMonitor.Models.Entity;
using Microsoft.AspNet.SignalR.Hubs;

namespace hotelMonitor.Common
{
    [HubName("hotelTask")]
    public class HotelTaskHub : Hub
    {
        private readonly HotelTask _hotelTask;

        public HotelTaskHub() : this(HotelTask.Instance)
        {

        }

        public HotelTaskHub(HotelTask hotelTask)
        {
            _hotelTask = hotelTask;
        }

        public IEnumerable<HotelTaskViewModel> GetTasks()
        {
            return _hotelTask.GetTasks();
        }

        public void AddTask(string taskName, string workerName, string roomName)
        {
           _hotelTask.AddTask(taskName,workerName,roomName);
        }

        public void CloseTask(Guid taskId)
        {
            _hotelTask.UpdateTask(taskId, HotelTaskStatus.Done);
        }

        public void StartTask(Guid taskId)
        {
            _hotelTask.UpdateTask(taskId, HotelTaskStatus.Doing);
        }

    }
}