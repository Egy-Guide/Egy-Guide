dataTable = $('#tblData').DataTable({
    "ajax": {
        "type": "GET",
        "url": "/Admin/Trip/GetTrips"
    },
    "columns": [
        { "data": "title", "width": "5%" },
        { "data": "tourGuide", "width": "5%" },
        {
            "data": "id",
            "render": function (data) {
                return `
                        <div class="text-center">
                            <a href="/offered-details?id=${data}" class="btn btn-info" target="_blank" style="cursor: pointer">
                                <i class="fa fa-eye" aria-hidden="true"></i> View
                            </a>
                        </div>
                       `
            }, "width": "3%"
        },
        {
            "data": "id",
            "render": function (data) {

                return `
                        <div class="text-center">
                            <a onclick=Delete(${data}) class="btn btn-danger" style="cursor: pointer">
                                <i class="fa fa-trash-o" aria-hidden="true"></i> Delete
                            </a>
                        </div>
                       `

            }, "width": "5%"
        }
    ]
});

function Delete(id) {
    var isConfirmed = confirm("Are you sure to delete?")

    if (isConfirmed) {
        $.ajax({
            url: "/Admin/Trip/Delete?id=" + id,
            type: "DELETE",
            success: function (data) {
                if (data) {
                    alert("Deleted Done..")
                    window.location.replace("/admin/trip");
                }
                else
                    alert("OOH! Problem has occured")
            }
        })
    }

}