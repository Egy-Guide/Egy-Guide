dataTable = $('#tblData').DataTable({
    "ajax": {
        "type": "GET",
        "url": "/Admin/Guide/GetGuides"
    },
    "order": [[1, "desc"]],
    "columns": [
        { "data": "guideName", "width": "5%" },
        { "data": "registrationDate", "width": "8%" },
        {
            "data": "status",
            "render": function (data) {
                if (data == "Pending") {
                    return `
                            <div class="text-center">
                                <a class="btn btn-secondary disabled" style="cursor: default">
                                    Pending
                                </a>
                            </div>
                           `
                }

                if (data == "Approved") {
                    return `
                            <div class="text-center">
                                <a class="btn btn-primary disabled" style="cursor: default">
                                    Approved
                                </a>
                            </div>
                           `
                }

                if (data == "Locked") {
                    return `
                            <div class="text-center">
                                <a class="btn btn-warning disabled" style="cursor: default">
                                    Lock
                                </a>
                            </div>
                           `
                }

            }, "width": "3%"
        },
        {
            "data": "id",
            "render": function (data) {
                return `
                                <div class="text-center">
                                    <a href="/admin/guide-details?id=${data}" class="btn btn-info" target="_blank" style="cursor: pointer">
                                        <i class="fa fa-eye" aria-hidden="true"></i> View
                                    </a>
                                </div>
                               `
            }, "width": "3%"
        },
        {
            "data": { "id": "id", "status": "status" },
            "render": function (data) {
                if (data.status == "Pending") {
                    return `
                                <div class="text-center">
                                    <a onclick=process("/Admin/Guide/Approved?id=${data.id}") class="btn btn-primary" style="cursor: pointer">
                                        <i class="fa fa-check" aria-hidden="true"></i> Approved
                                    </a>
                                    <a onclick=Delete(${data.id}) class="btn btn-danger" style="cursor: pointer">
                                        <i class="fa fa-trash-o" aria-hidden="true"></i> Delete
                                    </a>
                                </div>
                               `
                }

                if (data.status == "Approved") {
                    return `
                                <div class="text-center">
                                    <a onclick=process("/Admin/Guide/Locked?id=${data.id}") class="btn btn-warning" style="cursor: pointer">
                                        <i class="fa fa-lock" aria-hidden="true"></i> Lock
                                    </a>
                                    <a onclick=Delete(${data.id}) class="btn btn-danger" style="cursor: pointer">
                                        <i class="fa fa-trash-o" aria-hidden="true"></i> Delete
                                    </a>
                                </div>
                               `
                }

                if (data.status == "Locked") {
                    return `
                                <div class="text-center">
                                    <a onclick=process("/Admin/Guide/UnLocked?id=${data.id}") class="btn btn-success" style="cursor: pointer">
                                        <i class="fa fa-unlock" aria-hidden="true"></i> UnLock
                                    </a>
                                    <a onclick=Delete(${data.id}) class="btn btn-danger" style="cursor: pointer">
                                        <i class="fa fa-trash-o" aria-hidden="true"></i> Delete
                                    </a>
                                </div>
                               `
                }

            }, "width": "5%"
        }
    ]
});

function process(url) {
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

function Delete(id) {
    var isConfirmed = confirm("Are you sure to delete?")

    if (isConfirmed) {
        $.ajax({
            url: "/Admin/Guide/Delete?id=" + id,
            type: "DELETE",
            success: function (data) {
                if (data) {
                    alert("Deleted Done..")
                    window.location.replace("/admin/guide");
                }
                else
                    alert("OOH! Problem has occured")
            }
        })
    }

}