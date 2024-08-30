var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: '/HotelRoom/getall'
        },
        "columns": [

            { data: 'roomType', "width": "15%" },
            { data: 'priceonseason', "width": "15%" },
            { data: 'priceoffseason', "width": "15%" },
            { data: 'capacity', "width": "10%" },
            { data: 'extrachargeperperson', "width": "15%" },
            { data: 'inclusions', "width": "15%" },
            {
                data: 'hotel.name', "width": "10%"
            },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                             <a href="/HotelRoom/upsert?id=${data}" class="btn btn-primary mx-2">Edit</a>               
                             <a onClick="Delete('/HotelRoom/delete/${data}')" class="btn btn-danger mx-2">Delete</a>
                            </div>`;
                },
                "width": "25%"
            }
        ]
    });
}


function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}


