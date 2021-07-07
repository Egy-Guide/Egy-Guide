dataTable = $('#tblData').DataTable({
    "ajax": {
        "type": "GET",
        "url": "/Admin/Blog/GetBlogs"
    },
    "order": [[1, "desc"]],
    "columns": [
        { "data": "title", "width": "5%" },
        { "data": "date", "width": "5%" },
        { "data": "createdBy", "width": "5%" },
        { "data": "views", "width": "1%" },
        {
            "data": "status",
            "render": function (data) {
                if (data == "active") {
                    return `
                            <div class="text-center">
                                <a id="hoverStatus" class="btn btn-success disabled" style="cursor: default">
                                    <i class="fa fa-toggle-on" aria-hidden="true"></i> Active
                                </a>
                            </div>
                           `
                }

                if (data == "unactive") {
                    return `
                            <div class="text-center">
                                <a id="hoverStatus" class="btn btn-warning disabled" style="cursor: default">
                                    <i class="fa fa-toggle-off" aria-hidden="true"></i> Unactive
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
                                    <a href="/blog-single?id=${data}" class="btn btn-info" target="_blank" style="cursor: pointer">
                                        <i class="fa fa-eye" aria-hidden="true"></i> View
                                    </a>
                                </div>
                               `
            }, "width": "3%"
        },
        {
            "data": { "id": "id", "status": "status" },
            "render": function (data) {

                if (data.status == "active") {
                    return `
                                <div class="text-center">
                                    <a onclick=process("/Admin/Blog/Unactive?id=${data.id}") class="btn btn-warning" style="cursor: pointer">
                                        <i class="fa fa-toggle-off" aria-hidden="true"></i> Unactive
                                    </a>
                                    <a onclick=Delete(${data.id}) class="btn btn-danger" style="cursor: pointer">
                                        <i class="fa fa-trash-o" aria-hidden="true"></i> Delete
                                    </a>
                                </div>
                               `
                }

                if (data.status == "unactive") {
                    return `
                                <div class="text-center">
                                    <a onclick=process("/Admin/Blog/Active?id=${data.id}") class="btn btn-success" style="cursor: pointer">
                                        <i class="fa fa-toggle-on" aria-hidden="true"></i></i> Active
                                    </a>
                                    <a onclick=Delete(${data.id}) class="btn btn-danger" style="cursor: pointer">
                                        <i class="fa fa-trash-o" aria-hidden="true"></i> Delete
                                    </a>
                                </div>
                               `
                }
                
            }, "width": "5%"
        }
    ],
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
            url: "/Admin/Blog/Delete?id=" + id,
            type: "DELETE",
            success: function (data) {
                if (data) {
                    alert("Deleted Done..")
                    window.location.replace("/admin/blog");
                }
                else
                    alert("OOH! Problem has occured")
            }
        })
    }

}