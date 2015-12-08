using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hotelMonitor.Models;
using hotelMonitor.Models.Entity;
using hotelMonitor.Services.Interface;

namespace hotelMonitor.Services
{
    public class HotelService : IHotelService
    {
        public HotelTaskListViewModel GetTasks(int index,int rowCount)
        {
            var model = new HotelTaskListViewModel();

            using (var db = new HotelDB())
            {
                var list = db.HotelTasks
                    .OrderByDescending(a=> a.UpdateDatetime)
                    .Take(rowCount)
                    .Skip(index*rowCount)
                    .Select(a => new 
                    {
                        a.Id,
                        a.TaskName,
                        RoomeName = a.RoomName,
                        a.HotelTaskStatus,
                        a.WorkerName,
                        a.CreateDatetime,
                    })
                    .ToList()
                    .Select(a=> new HotelTaskViewModel()
                    {
                        Id = a.Id,
                        TaskName = a.TaskName,
                        RoomName = a.RoomeName,
                        HotelTaskStatus = a.HotelTaskStatus,
                        WorkerName = a.WorkerName,
                        CreateDateTime = a.CreateDatetime.ToString("yyyy-MM-dd HH:mm:ss"),
                    })
                    .ToList();
                model.Tasks = list;
            }

            return model;
        }

        public void AddTask(string taskName, string workerName, string roomName)
        {
            using (var db = new HotelDB())
            {
                var entity = new HotelTask()
                {
                    Id = Guid.NewGuid(),
                    TaskName = taskName,
                    HotelTaskStatus = HotelTaskStatus.ToDo,
                    WorkerName = workerName,
                    RoomName = roomName,
                    CreateDatetime = DateTime.UtcNow,
                    UpdateDatetime = DateTime.UtcNow,
                };

                db.HotelTasks.Add(entity);
                db.SaveChanges();
            }
        }

        public void UpdateTaskStatus(Guid id, HotelTaskStatus taskStatus)
        {
            using (var db = new HotelDB())
            {
                var task = db.HotelTasks.FirstOrDefault(a => a.Id == id);

                if (task == null)
                {
                    return;
                }

                task.UpdateDatetime = DateTime.UtcNow;
                task.HotelTaskStatus = taskStatus;
                db.SaveChanges();
            }
        }
    }
}