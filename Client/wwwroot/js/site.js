// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//ready function --> fungsi yang dijalankan jika browser selesai ter-load
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

$(document).ready(function () {
    $('#tabelBarKeluar').DataTable({
    ajax: {
        url: "/api/BarKeluar",
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

