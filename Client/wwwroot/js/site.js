// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//ready function --> fungsi yang dijalankan jika browser selesai ter-load
$(document).ready(function () {
    $('#tabelUser').DataTable({
    ajax: {
        url: "/api/User",
        dataSrc: "",
    },
    columns: [{data:"UserNIP"},
              {data:"Username"},
              {data:"FullName"},
              {data:"Email"},
              {data:"PhoneNumbe},
             ]
    });
});

$(document).ready(function () {
    $('#tabelSupplier').DataTable({
    ajax: {
        url: "/api/Supplier",
        dataSrc: "",
    },
    columns: [{data:"Id"},
              {data:"Name"},
              {data:"NoTelp"},
             ]
    });
});

$(document).ready(function () {
    $('#tabelBarMasuk').DataTable({
    ajax: {
        url: "/api/BarMasuk",
        dataSrc: "",
    },
    columns: [{data:"Id"},
              {data:""},
              {data:""},
              {data:""},
              {data:""},
              {data:""},
              {data:""},
             ]
    });
});

