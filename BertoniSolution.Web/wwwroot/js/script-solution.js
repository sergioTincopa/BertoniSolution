var solution = ((solution, undefined) => {

    //Function that capture Album change event
    solution.onAlbumButtonClick = () => {
        $("#btnGetPhotos").click((e) => {
            let album = document.getElementById('Album').value;
            let errorValidate = false;

            if (album != 0) {
                $.ajax({
                    type: 'get',
                    url: '/Solution/GetPhotos?id=' + album,
                    async: true,
                    dataType: "json",
                    contentType: 'application/json',
                    processData: true
                }).done((data) => {
                    //Validate data and data result to set or not list obtained to photos table
                    if (!$.isEmptyObject(data) && !$.isEmptyObject(data.result)) {
                        let tablePhotos = $('#tblPhotos').DataTable();
                        tablePhotos.clear();
                        tablePhotos.rows.add(data.result);
                        tablePhotos.draw();
                    } else {
                        alert('Connection with web service is closed!');
                    }
                });
            } else {
                alert('Por favor seleccionar un álbum');
            }
        });
    };

    //Function that load combo album
    solution.loadComboAlbum = () => {

        $.ajax({
            type: 'get',
            url: '/Solution/GetAlbums',
            async: true,
            dataType: "json",
            contentType: 'application/json',
            processData: true
        }).done((data) => {
            //Validate data and data result to set or not list obtained to album field
            if (!$.isEmptyObject(data) && !$.isEmptyObject(data.result)) {
                let select = document.getElementById('Album');
                let options = '<option value="">--Select--</option>';
                for (let item of data.result) {
                    options += `<option value="${item.id}">${item.title}</option>`;
                }
                select.innerHTML = options;
            } else {
                alert('Connection with web service is closed!');
            }
        });
    };

    solution.LoadTablePhotos = () => {

        $('#tblPhotos').DataTable({
            data: {},
            searching: false,
            ordering: false,
            paging: false,
            pageLength: [],
            responsive: true,
            deferRender: true,
            info: false,
            scroller: true,
            scrollY: "600px",
            columns: [
                { data: "id" },
                { data: "title" },
                { data: "url" },
                { data: "thumbnailUrl" },
                {
                    data: {},
                    className: "text-center",
                    render: function (row) {
                        let chk = "<button type='button' class='btn btn-primary btn-xs'>Ver Comentarios</button>";
                        return chk;
                    }
                },
            ]
        });

        $('#tblPhotos tbody').on('click', 'button', function () {
            let variable = $('#tblPhotos').DataTable()
                .row($(this).parents('tr'))
                .data();

            let objComments = document.getElementById('div_comments');
            objComments.style.display = 'block';

            $.ajax({
                type: 'get',
                url: '/Solution/GetComments?id=' + variable.id,
                async: true,
                dataType: "json",
                contentType: 'application/json',
                processData: true
            }).done((data) => {
                //Validate data and data result to set or not list obtained to photos table
                if (!$.isEmptyObject(data) && !$.isEmptyObject(data.result)) {
                    let tableComments = $('#tblComments').DataTable();
                    tableComments.clear();
                    tableComments.rows.add(data.result);
                    tableComments.draw();
                } else {
                    alert('Connection with web service is closed!');
                }
            });
        });
    };

    solution.LoadTableComments = () => {

        $('#tblComments').DataTable({
            data: {},
            searching: false,
            ordering: false,
            paging: false,
            pageLength: [],
            responsive: true,
            deferRender: true,
            info: false,
            scroller: true,
            scrollY: "200px",
            columns: [
                { data: "id" },
                { data: "name" },
                { data: "email" },
                { data: "body" }
            ]
        });
    };

    return solution;
})(solution || {});