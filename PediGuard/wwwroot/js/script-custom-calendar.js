//var routeURL = location.protocol + "//" + location.host;
//$(document).ready(function () {
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