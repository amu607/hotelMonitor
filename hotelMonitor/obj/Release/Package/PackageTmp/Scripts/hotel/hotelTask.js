if (!String.prototype.supplant) {
    String.prototype.supplant = function (o) {
        return this.replace(/{([^{}]*)}/g,
            function (a, b) {
                var r = o[b];
                return typeof r === 'string' || typeof r === 'number' ? r : a;
            }
        );
    };
}

$(function () {

    var hotelTask = $.connection.hotelTask, // the generated client-side hub proxy
        $taskTable = $('#taskTable'),
        $taskTableBody = $taskTable.find('tbody'),
        $taskMessage = $('#taskMessage');
        $taskMessageUl = $taskMessage.find('ul'),
        rowTemplate = '<tr><td>{TaskId}</td><td>{TaskName}</td><td>{WorkerName}</td><td>{RoomName}</td><td>{HotelTaskStatus}</td><td>{CreateDateTime}</td></tr>';

    function formatStock(task) {
        return $.extend(task, {
            TaskId: task.Id,
            TaskName: task.TaskName,
            WorkerName: task.WorkerName,
            RoomName: task.RoomName,
            HotelTaskStatus: task.HotelTaskStatus === 0 ? 'ToDo' : task.HotelTaskStatus == 1 ? 'Doing' : 'Done' ,
            CreateDateTime : task.CreateDateTime
        });
    }

    function init() {
        return hotelTask.server.getTasks().done(function (tasks) {
            $taskTableBody.empty();
            $.each(tasks, function () {
                var task = formatStock(this);
                $taskTableBody.append(rowTemplate.supplant(task));
            });
        });
    }

    function clearInput() {
        $('#taskId').val('');
        $('#taskName').val('');
        $('#workerName').val('');
        $('#roomName').val('');
    }

    // Add client-side hub methods that the server will call
    $.extend(hotelTask.client, {
        taskRefresh: function () {
            return init();
        },

        sendAllMessge: function(message) {
            $taskMessageUl.append("<li><span>" + message + "</span></li>");
        }
    });

    // Start the connection
    $.connection.hub.start()
        .then(init)
        .done(function () {

            // Wire up the buttons
            $("#add").click(function () {
                var taskName = $('#taskName').val();
                var workerName = $('#workerName').val();
                var roomName = $('#roomName').val();
                hotelTask.server.addTask(taskName, workerName, roomName);
                clearInput();
            });

            $("#close").click(function () {
                var taskId = $('#taskId').val();
                hotelTask.server.closeTask(taskId);
                clearInput();
            });

            $("#start").click(function () {
                var taskId = $('#taskId').val();
                hotelTask.server.startTask(taskId);
                clearInput();
            });

            $("#clear").click(function () {
                clearInput();
            });
        });
});