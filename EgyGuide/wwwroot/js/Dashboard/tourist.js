var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "type": "GET",
            "url": "/Tourist/TouristDashboardToursReservation/Reservations"
        },
        "columns": [
            { "data": "tripDetail.title", "width": "15%" },
            { "data": "bookingNo", "width": "15%" },
            { "data": "bookingStatus", "width": "15%" },
            { "data": "bookingDate", "width": "15%" },
            { "data": "bookingStatus", "width": "15%" },
            {
                "data": "tripDetail.tripId",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/offered-details?id=${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    View Trip 
                                </a>
                                <a href="" class="btn btn-success text-white" style="cursor:pointer">
                                    View Reservation 
                                </a>
                            </div>
                           `;
                }, "width": "40%"

            }
        ]
    });
}

