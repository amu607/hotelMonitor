using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using hotelMonitor.Models;
using hotelMonitor.Models.Entity;
using hotelMonitor.Services;
using hotelMonitor.Services.Interface;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using WebGrease.Css.Extensions;

namespace hotelMonitor.Common
{
    public class HotelTask
    {
        private IHotelService _hotelService;

        private readonly static Lazy<HotelTask> _instance = new Lazy<HotelTask>(
               () => new HotelTask(GlobalHost.ConnectionManager.GetHubContext<HotelTaskHub>().Clients));

        private IHubConnectionContext<dynamic> Clients { get; set; }

        public static HotelTask Instance { get { return _instance.Value; }}

        private HotelTask(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            _hotelService = new HotelService();
            LoadTasks();
        }

        private readonly ConcurrentDictionary<string, HotelTaskViewModel> _tasks = 
            new ConcurrentDictionary<string, HotelTaskViewModel>();

        private void LoadTasks()
        {
            _tasks.Clear();

            var result = _hotelService.GetTasks(0, 5);
            var tasks = result.Tasks;

            tasks.ForEach(stock => _tasks.TryAdd(stock.TaskName, stock));
        }

        public IEnumerable<HotelTaskViewModel> GetTasks()
        {
            var result = _hotelService.GetTasks(0, 5);
            return result.Tasks;
        }

        public void AddTask(string taskName, string workerName, string roomName)
        {
            Clients.All.sendAllMessge("add task, task name:" + taskName + ",worker name:" + workerName);
            _hotelService.AddTask(taskName,workerName, roomName);
            Refresh();
        }

        public void UpdateTask(Guid taskId, HotelTaskStatus status)
        {
            Clients.All.sendAllMessge("update task, taskId:" + taskId + ", to new status:" + status);
            _hotelService.UpdateTaskStatus(taskId,status);
            Refresh();
        }

        private void Refresh()
        {
            Clients.All.taskRefresh();
        }
    }
}