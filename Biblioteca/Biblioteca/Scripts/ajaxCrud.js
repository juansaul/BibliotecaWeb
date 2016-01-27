
function ajaxMethod(Entidad, Accion, Tipo,NombreA, Valor) {
    Dato = {
        id: Valor
    }
    var urlcreada =  "/"+Entidad+"/"+Accion+""
        $.ajax({
            //se establece la ruta en la cual se ejecutara la accion
            url: urlcreada, //Accion a ejecutar en el server
            contentType: "application/html; charset=utf-8",//tipo de contenido que se enviara
            type: Tipo,//tipo de transaccion
            dataType: "html",//tipo de archivo
            data:Dato  //Dato enviado al server
        }).success(function (result) {//si todo sale bien en la transaccion ajax entra aki
            return result;
        }).error(function (xhr, status) {//si sale algun error en la transaccion ajax entra aki
            return status;
        })
    }
