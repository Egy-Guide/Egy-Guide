var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "type": "GET",
            "url": "/TourGuide/GuideDashboardToursReservation/TourSells"
        },
        "columns": [
            { "data": "tripDetail.title", "width": "15%" },
            { "data": "applicationUser.firstName", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "bookingDate", "width": "15%" },
            { "data": "bookingStatus", "width": "40%" },

            
            
        ]
    });
}

