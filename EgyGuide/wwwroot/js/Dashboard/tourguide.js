﻿dataTable = $('#tblData').DataTable({
    "ajax": {
        "type": "GET",
        "url": "/TourGuide/GuideDashboardToursReservation/TourSells"
    },
    "columns": [
        { "data": "tripTitle", "width": "30%" },
        { "data": "userFirstName", "width": "15%" },
        { "data": "email", "width": "15%" },
        { "data": "phoneNumber", "width": "5%" },
        { "data": "bookingDate", "width": "15%" },
        { "data": "bookingStatus", "width": "20%" },
        {
            "data": { "bookingId": "bookingId", "bookingStatus": "bookingStatus" },
            "render": function (data) {
                if (data.bookingStatus == "Confirmation") {
                    return `
                                <div class="text-center">
                                    <a onclick=tripCompleted("/TourGuide/GuideDashboardToursReservation/TripCompleted?bookingId=${data.bookingId}") class="btn btn-primary" style="cursor: pointer">
                                        <i class="fa fa-clock-o" aria-hidden="true"></i> Completed
                                    </a>
                                </div>
                               `
                }

                if (data.bookingStatus == "Completed") {
                    return `
                                <div class="text-center">
                                    <a class="btn btn-success">
                                        <i class="fa fa-check" aria-hidden="true"></i> Completed
                                    </a>
                                </div>
                               `
                } else {
                    return `
                                <div class="text-center">
                                    -
                                </div>
                               `
                }


            }, "width": "5%"
        }
    ]
});

function tripCompleted(url) {
    $.ajax({
        type: "POST",
        url: url,
        success: function (data) {
            if (data.success) {
                dataTable.ajax.reload();
            }

            else
                alert(data.message);
        }
    })
}