$().ready(function () {

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
                    "<td>" + libro.isbn + "</td>" + //nombre
                    "<td>" + libro.autor + "</td>" + //apellidoP
                    "<td>" + libro.descripcion + "</td>" + //apellidoM
                    "<td>" + libro.año + "</td>" + //fechaNac
                    "<td>" +
                     "<td>" + libro.noEjemplares + "</td>" + //fechaNac
                    "<td>" +
                    "<a id='enlaceDetalles' data-toggle='modal' data-target='#modalDetalles' nomatricula='" + libro.libroId + "'>Detalles</a> |" +
                    "<a id='enlaceBorrar' data-toggle='modal' data-target='#modalBorrar' nomatricula='" + libro.libroId + "'>Borrar</a> |" +
                    "<a id='enlaceEditar' data-toggle='modal' data-target='#modalEditar' nomatricula='" + libro.libroId + "'>Editar</a> |" +
                    "</td>" +
                    "</tr>")
            }

        }).error(function (xhr, status) {

        })
    }

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
        

    


})