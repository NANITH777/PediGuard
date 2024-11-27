var routeURL = location.protocol + "//" + location.host;
$(document).ready(function () {
    InitializeCalendar();
});

var calendar;
function InitializeCalendar() {
    try {
        var calendarEl = document.getElementById('calendar');
        if (calendarEl != null) {
            var eventsUrl = '@Url.Action("GetAllNobet", "Nobet")';
            console.log("Events URL:", eventsUrl); // Log pour vérifier l'URL générée

            calendar = new FullCalendar.Calendar(calendarEl, {
                initialView: 'dayGridMonth',
                headerToolbar: {
                    left: 'prev,next,today',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay'
                },
                selectable: true,
                editable: false,
                eventDisplay: 'block',
                events: eventsUrl,
                eventClick: function (info) {
                    Swal.fire({
                        title: 'Shift Details',
                        html: `
                            <div class="text-start">
                                <p><strong>Title:</strong> ${info.event.title}</p>
                                <p><strong>Start:</strong> ${info.event.start ? info.event.start.toLocaleString() : 'N/A'}</p>
                                <p><strong>End:</strong> ${info.event.end ? info.event.end.toLocaleString() : 'N/A'}</p>
                            </div>
                        `,
                        icon: 'info'
                    });
                }
            });
            calendar.render();
        }
    }
    catch (e) {
        console.error("Calendar initialization error:", e);
    }
}



//var routeURL = location.protocol + "//" + location.host;
//$(document).ready(function () {
//    $("#appointmentDate").kendoDateTimePicker({
//        value: new Date(),
//        dateInput: false
//    });

//    InitializeCalendar();
//});
//var calendar;
//function InitializeCalendar() {
//    try {
//        var calendarEl = document.getElementById('calendar');
//        if (calendarEl != null) {
//            var eventsUrl = '@Url.Action("GetAllNobet", "Nobet")';
//            console.log("Events URL:", eventsUrl); // Log pour vérifier l'URL générée

//            calendar = new FullCalendar.Calendar(calendarEl, {
//                initialView: 'dayGridMonth',
//                headerToolbar: {
//                    left: 'prev,next,today',
//                    center: 'title',
//                    right: 'dayGridMonth,timeGridWeek,timeGridDay'
//                },
//                selectable: true,
//                editable: false,
//                select: function (event) {
//                    onShowModal(event, null);
//                },
//                eventDisplay: 'block',
//                events: eventsUrl,
//                eventClick: function (info) {
//                    Swal.fire({
//                        title: 'Shift Details',
//                        html: `
//                            <div class="text-start">
//                                <p><strong>Title:</strong> ${info.event.title}</p>
//                                <p><strong>Start:</strong> ${info.event.start ? info.event.start.toLocaleString() : 'N/A'}</p>
//                                <p><strong>End:</strong> ${info.event.end ? info.event.end.toLocaleString() : 'N/A'}</p>
//                            </div>
//                        `,
//                        icon: 'info'
//                    });
//                }
//            });
//            calendar.render();
//        }
//    }
//    catch (e) {
//        console.error("Calendar initialization error:", e);
//    }
//}

//function onShowModal(obj, isEventDetail) {
//    if (isEventDetail != null) {
//        $("#title").val(obj.title);
//        $("#description").val(obj.description);
//        $("#appointmentDate").val(obj.startDate);
//        $("#duration").val(obj.duration);
//        $("#patientId").val(obj.patientId);
//        $("#id").val(obj.id);
//        $("#lblPatientName").html(obj.patientName);
//        $("#lblDoctorName").html(obj.doctorName);
//        if (obj.isDoctorApproved) {
//            $("#lblStatus").html('Approved');
//            $("#btnConfirm").addClass("d-none");
//            $("#btnSubmit").addClass("d-none");
//        } else {
//            $("#lblStatus").html('Pending');
//            $("#btnConfirm").removeClass("d-none");
//            $("#btnSubmit").removeClass("d-none");
//        }
//        $("#btnDelete").removeClass("d-none");
//    } else {
//        $("#appointmentDate").val(obj.startStr + " " + new moment().format("hh:mm A"));
//        $("#id").val(0);
//        $("#btnDelete").addClass("d-none");
//        $("#btnSubmit").removeClass("d-none");
//    }
//    $("#appointmentInput").modal("show");
//}

//function onCloseModal() {
//    $("#apointmentForm")[0].reset();
//    $("#id").val(0);
//    $("#title").val('');
//    $("#description").val('');
//    $("#appointmentDate").val('');
//    $("#appointmentInput").modal("hide");
//}

//function onSubmitForm() {
//    if (checkValidation()) {
//        var requestData = {
//            Id: parseInt($("#id").val()),
//            Title: $("#title").val(),
//            Description: $("#description").val(),
//            StartDate: $("#appointmentDate").val(),
//            Duration: $("#duration").val(),
//            PatientId: $("#patientId").val(),
//        };

//        $.ajax({
//            url: routeURL + '/api/Appointment/SaveCalendarData',
//            type: 'POST',
//            data: JSON.stringify(requestData),
//            contentType: 'application/json',
//            success: function (response) {
//                if (response.status === 1 || response.status === 2) {
//                    calendar.refetchEvents();
//                    $.notify(response.message, "success");
//                    onCloseModal();
//                } else {
//                    $.notify(response.message, "error");
//                }
//            },
//            error: function (xhr) {
//                $.notify("Error", "error");
//            }
//        });
//    }
}

//function checkValidation() {
//    var isValid = true;
//    if ($("#title").val() === undefined || $("#title").val() === "") {
//        isValid = false;
//        $("#title").addClass('error');
//    } else {
//        $("#title").removeClass('error');
//    }

//    if ($("#appointmentDate").val() === undefined || $("#appointmentDate").val() === "") {
//        isValid = false;
//        $("#appointmentDate").addClass('error');
//    } else {
//        $("#appointmentDate").removeClass('error');
//    }

//    return isValid;
//}

//function getEventDetailsByEventId(info) {
//    $.ajax({
//        url: routeURL + '/api/Appointment/GetCalendarDataById/' + info.id,
//        type: 'GET',
//        dataType: 'JSON',
//        success: function (response) {
//            if (response.status === 1 && response.dataenum !== undefined) {
//                onShowModal(response.dataenum, true);
//            }
//        },
//        error: function (xhr) {
//            $.notify("Error", "error");
//        }
//    });
//}

//function onDoctorChange() {
//    calendar.refetchEvents();
//}

//function onDeleteAppointment() {
//    var id = parseInt($("#id").val());
//    $.ajax({
//        url: routeURL + '/api/Appointment/DeleteAppoinment/' + id,
//        type: 'GET',
//        dataType: 'JSON',
//        success: function (response) {
//            if (response.status === 1) {
//                $.notify(response.message, "success");
//                calendar.refetchEvents();
//                onCloseModal();
//            } else {
//                $.notify(response.message, "error");
//            }
//        },
//        error: function (xhr) {
//            $.notify("Error", "error");
//        }
//    });
//}

//function onConfirm() {
//    var id = parseInt($("#id").val());
//    $.ajax({
//        url: routeURL + '/api/Appointment/ConfirmEvent/' + id,
//        type: 'GET',
//        dataType: 'JSON',
//        success: function (response) {
//            if (response.status === 1) {
//                $.notify(response.message, "success");
//                calendar.refetchEvents();
//                onCloseModal();
//            } else {
//                $.notify(response.message, "error");
//            }
//        },
//        error: function (xhr) {
//            $.notify("Error", "error");
//        }
//    });
//}