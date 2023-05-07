function mostrarProductosActualizar(codigo) {
    const url1 = productosUrl + '?codigo=' + codigo;
    $.get(url1, function (data) {

        // Convertir la cadena JSON en una lista
        const prod = JSON.parse(data);

        $('#input-hidden-id').val(prod.idProducto);
        $('#Input-1').val(prod.nombreProducto);
        $('#Input-2').val(prod.precioProducto);
        $('#Textarea-1').val(prod.descripcionProducto);
        $('#marcaProducto').val(prod.marca);
        $('#superProducto').val(prod.supermercado);

        // Mostrar el modal
        $('#Modal3').modal('show');

        // Controlador de eventos click para el botón de actualización
        $('.btn-actualizar').on('click', function () {
            const id = $('#input-hidden-id').val();
            const nombre_producto = $('#Input-1').val();
            const precio_producto = $('#Input-2').val();
            const descripcion_producto = $('#Textarea-1').val();
            const marca_producto = $('#marcaProducto').val();
            const super_producto = $('#superProducto').val();
            const url2 = actualizarUrl;

            const data = {
                IdProducto: id,
                NombreProducto: nombre_producto,
                PrecioProducto: precio_producto,
                DescripcionProducto: descripcion_producto,
                Marca: marca_producto,
                Supermercado: super_producto,
            };

            $.post(url2, data, function (response) {
                // respuesta del servidor
            });

            $('#Modal3').modal('hide');

            $('#Modal3').on('hidden.bs.modal', function () {
                location.reload();
            });
        });
    });
}


/*------------------------------------------------------------------------------------------------------------------------------------------------------------*/

function mostrarMarcasActualizar(codigo) {
    const url1_m = marcasUrl + '?codigo=' + codigo;
    $.get(url1_m, function (data) {

        // Convertir la cadena JSON en una lista
        const prod = JSON.parse(data);

        $('#nMarca').val(prod.nombreMarca);
        $('#dMarca').val(prod.descripcionMarca);

        // Mostrar el modal
        $('#Modal5').modal('show');

        // Controlador de eventos click para el botón de actualización
        $('.btn-actualizar_m').on('click', function () {

            const nombre_marca = $('#nMarca').val();
            const descripcion_marca = $('#dMarca').val();
            const url2_m = actualizarUrl;

            const data = {
                nMarca: nombre_marca,
                dMarca: descripcion_marca,
            };

            $.post(url2_m, data, function (response) {
                // respuesta del servidor
            });

            $('#Modal5').modal('hide');

            $('#Modal5').on('hidden.bs.modal', function () {
                location.reload();
            });
        });
    });
}

/*------------------------------------------------------------------------------------------------------------------------------------------------------------*/

function mostrarSupermercadoActualizar(codigo) {
    const url1_S = supermercadosUrl + '?codigo=' + codigo;
    $.get(url1_S, function (data) {

        // Convertir la cadena JSON en una lista
        const prod = JSON.parse(data);
        console.log(prod)
        $('#nSuperm').val(prod.nombreSupermercado);
        $('#desSuperm').val(prod.descripcionSupermercado);
        $('#dirSuperm').val(prod.direccionSupermercado);

        // Mostrar el modal
        $('#Modal7').modal('show');

        // Controlador de eventos click para el botón de actualización
        $('.btn-actualizar_s').on('click', function () {
            const nombre_supermercado = $('#nSuperm').val();
            const descripcion_supermercado = $('#desSuperm').val();
            const direccion_supermercado = $('#dirSuperm').val();
            const url2_S = actualizarUrl;

            const data = {
                nSuperm: nombre_supermercado,
                dirSuperm: descripcion_supermercado,
                desSuperm: direccion_supermercado
            };

            $.post(url2_S, data, function (response) {
                // respuesta del servidor
            });

            $('#Modal7').modal('hide');

            $('#Modal7').on('hidden.bs.modal', function () {
                location.reload();
            });
        });
    });
}


