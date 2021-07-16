dataTable = $('#tblData').DataTable({
    "ajax": {
        "type": "GET",
        "url": "/Tourist/TouristDashboardToursReservation/Reservations"
    },
    "columns": [
        { "data": "tripDetail.title", "width": "15%" },
        { "data": "bookingNo", "width": "15%" },
        { "data": "bookingDate", "width": "15%" },
        { "data": "bookingStatus", "width": "15%" },
        {
            "data": "tripDetail.tripId",
            "render": function (data) {
                return `
                            <div class="text-center">
                                <a href="/offered-details?id=${data}" class="btn btn-info text-white" style="cursor:pointer">
                                    View 
                                </a>
                               
                            </div>
                           `;
            }, "width": "5%"
        },
        {
            "data": { "bookingId":"bookingId", "bookingStatus":"bookingStatus"},
            "render": function (data) {

                if ((data.bookingStatus == "Confirmation")) {
                    return `
                            <div class="text-center">
                                <a target="_blank" href="/booking-confirmation?bookingId=${data.bookingId}" class="btn btn-success text-white" style="cursor:pointer">
                                    Show  
                                </a>
                                <a onclick=tripCanceled(${data.bookingId}) class="btn btn-danger" style="cursor: pointer">
                                    <i class="fa fa-trash" aria-hidden="true"></i> Cancel
                                </a>
                            </div>
                           `;
                } else {
                    return `
                            <div class="text-center">
                                <a target="_blank" href="/booking-confirmation?bookingId=${data.bookingId}" class="btn btn-success text-white" style="cursor:pointer">
                                    Show  
                                </a>
                            </div>
                           `;
                }

            }, "width": "13%"
        }

    ]
});

function tripCanceled(id) {
    var isConfirmed = confirm("Are you sure to cancel?")

    if (isConfirmed) {
        $.ajax({
            url: "/Tourist/TouristDashboardToursReservation/TripCanceled?id=" + id,
            type: "POST",
            success: function (data) {
                if (data) {
                    dataTable.ajax.reload();
                }
                else
                    alert("OOH! Problem has occured")
            }
        })
    }

}