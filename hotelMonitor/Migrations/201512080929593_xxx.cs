namespace hotelMonitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xxx : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.HotelTasks", "RoomName", c => c.String(maxLength: 10));
            AlterColumn("dbo.HotelTasks", "TaskName", c => c.String(maxLength: 50));
            AlterColumn("dbo.HotelTasks", "WorkerName", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HotelTasks", "WorkerName", c => c.String());
            AlterColumn("dbo.HotelTasks", "TaskName", c => c.String());
            DropColumn("dbo.HotelTasks", "RoomName");
        }
    }
}
