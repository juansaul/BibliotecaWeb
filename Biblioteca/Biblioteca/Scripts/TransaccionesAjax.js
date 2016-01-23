$().ready(function () {
    var LibroId = 0
    //rellena la tabla de index
    function rellenarIndexLibros() {
        var strBuscado = $("input[name='strBuscado']").val();
        $.ajax({
            url: "/Libro/AjaxIndex", //Accion a ejecutar en el server
            contentType: "application/html; charset=utf-8",
            type: "GET",
            dataType: "html",
            data: { strBuscado: strBuscado } //Dato enviado al server
        }).success(function (result) {
            var tablaLibros = $("#tablaLibros tbody");
            tablaLibros.html("");
            var conjutoLibros = JSON.parse(result);

            for (var indice in conjutoLibros) {
                var libro = conjutoLibros[indice];
                tablaLibros.append("<tr>" +
                    "<td>" + libro.nombre + "</td>" + //Nombre grupo
                    "<td>" +" "+ libro.isbn + "</td>" + //nombre
                    "<td>" + libro.autor + "</td>" + //apellidoP
                    "<td>" + libro.descripcion + "</td>" + //apellidoM
                    "<td>" + libro.año + "</td>" + //fechaNac
                    "<td>" +
                     "<td>" + libro.noEjemplares + "</td>" + //fechaNac
                    "<td>" +
                    "<button id='enlaceDetalles' class='btn btn-info' data-toggle='modal' data-target='#modalDetalles' libroId='" + libro.libroId + "'>Detalles</button>"
                    +
                    "<button id='enlaceBorrar' class='btn btn-danger' data-toggle='modal' data-target='#modalBorrar' libroId='" + libro.libroId + "' style='margin-left:auto'>Borrar</button>" +
                    "<button id='enlaceEditar' class='btn btn-success' data-toggle='modal' data-target='#modalEditar' libroId='" + libro.libroId + "'>Editar</button>" +
                    "</td>" +
                    "</tr>")
            }

        }).error(function (xhr, status) {

        })
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////7

    //Selecciona el id del libro para rellenar los campos en la forma de modificar
    $("button#enlaceEditar").click(function () {
        var enlaceClickeado = $(this)
        var noID = enlaceClickeado.attr("libroId")
        $.ajax({
            url: "/Libro/AjaxEdit", //Accion a ejecutar en el server
            contentType: "application/html; charset=utf-8",
            type: "GET",
            dataType: "html",
            data: { libroId: noID } //Dato enviado al server
        }).success(function (result) { //result = {mensaje, status}
            //Se obtiene la respuesta del server en forma de objeto
            var libro = JSON.parse(result);

            //Con la información recibida, se rellena el formulario
            $("#modalEditar #libroId").val(libro.libroId);
            $("#modalEditar #nombre").val(libro.nombre);
            $("#modalEditar #isbn").val(libro.isbn);
            $("#modalEditar #autor").val(libro.autor);
            $("#modalEditar #editorial").val(libro.editorial);
            $("#modalEditar #descripcion").val(libro.descripcion);
            $("#modalEditar input[name='año']").val(libro.año);
            $("#modalEditar #noEjemplares").val(libro.noEjemplares);
  
    

        }).error(function (xhr, status) {
            /*Notificar al usuario de un error de comunicacion
            con el server*/
            $("#mensaje").removeClass('alert-danger alert-info');
            $("#mensaje").html("Ha ocurrido un error: " + status).addClass('alert-danger');
            $("#mensaje").fadeIn(500).delay(2000).fadeOut(500);
        })
    })
    //una vez rellenado el formulario modificado se manda a la base de datos para aguardarlo
    $("#btnEditar").click(function () {
        libroModificado = {
            libroId: $("#modalEditar #libroId").val(),
            nombre: $("#modalEditar #nombre").val(),
            isbn: $("#modalEditar #isbn").val(),
            autor: $("#modalEditar #autor").val(),
            editorial: $("#modalEditar #editorial").val(),
            descripcion: $("#modalEditar #descripcion").val(),
            año: $("#modalEditar input[name='año']").val(),
            noEjemplares: $("#modalEditar #noEjemplares").val(),

        };

        $.ajax({
            url: '/Libro/AjaxEdit',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(libroModificado),
            type: 'post',
        }).success(function (result) {
            rellenarIndexLibros();
        }).error(function (xhr, status) {
            alert("No se encontro el servidor," +
                " verifique si se encuentra conectado a internet.");

        })
        $("#modalEditar").modal("toggle");
    })
    $("button#enlaceBorrar").click(function () {
        LibroId = $(this).attr("libroId")
    })
    //elimina un registro
    $("button#btnBorrar").click(function () {
        $.ajax({
            url: '/Libro/DeleteConfirmed',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: {libroId: LibroId }, //Dato enviado al server
            type: 'get',
        }).success(function (result) {
            rellenarIndexLibros();
        }).error(function (xhr, status) {
            alert("No se encontro el servidor," +
                " verifique si se encuentra conectado a internet.");

        })


    })
    $("#btnCrear").click(function () {
        nuevoLibro = {
            nombre: $("#modalAlta #nombre").val(),
            isbn: $("#modalAlta #isbn").val(),
            autor: $("#modalAlta #autor").val(),
            editorial: $("#modalAlta #editorial").val(),
            descripcion: $("#modalAlta #descripcion").val(),
            año: $("#modalAlta input[name='año']").val(),
            noEjemplares: $("#modalAlta #noEjemplares").val()
        };

        $.ajax({
            url: '/Libro/Create',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(nuevoLibro),
            type: 'post',
        }).success(function (result) {
            rellenarIndexLibros();
        }).error(function (xhr, status) {
            alert("No se encontro el servidor," +
                " verifique si se encuentra conectado a internet.");

        })
        $("#modalAlta").modal("toggle");
    })

    $("button#enlaceDetalles").click(function () {
        var enlaceClickeado = $(this)
        var noID = enlaceClickeado.attr("libroId")
        $.ajax({
            url: "/Libro/details", //Accion a ejecutar en el server
            contentType: "application/html; charset=utf-8",
            type: "GET",
            dataType: "html",
            data: { id: noID } //Dato enviado al server
        }).success(function (result) { //result = {mensaje, status}
            var libro = JSON.parse(result);
            var detalles = $("#detalleslibros");
            detalles.html("");
            //Con la información recibida, se rellena el formulario
           detalles.append(
            "<p>"+ "Nombre: "+ libro.nombre+"</p>"+
            "<p>" + "ISBN: " + libro.isbn + "</p>" +
            "<p>" + "Autor: " + libro.autor + "</p>" +
           "<p>" + "Editorial: " + libro.editorial + "</p>" +
            "<p>" + "Descripcion: " + libro.descripcion + "</p>" +
            "<p >" + "Año: " + libro.año + "</p>" +
          "<p>" + "No.Ejemplares: " + libro.noEjemplares + "</p>")

        }).error(function (xhr, status) {
            /*Notificar al usuario de un error de comunicacion
            con el server*/
            $("#mensaje").removeClass('alert-danger alert-info');
            $("#mensaje").html("Ha ocurrido un error: " + status).addClass('alert-danger');
            $("#mensaje").fadeIn(500).delay(2000).fadeOut(500);
        })
    })


})