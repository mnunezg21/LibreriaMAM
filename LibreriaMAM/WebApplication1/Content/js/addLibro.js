let $mensaje = document.querySelector('#mensaje');

function Enviar() {
    var uri = '/Libro/addLibro';
    var libro = {};
    libro = cargarLibro(libro);
    $.ajax({
        url: uri,
        data: JSON.stringify(libro),
        type: 'POST',
        success: exito,
        contentType: 'application/json'
    });
}

function cargarLibro(libro) {
    libro.Titulo = document.getElementById("titulo").value;
    libro.Desarrollador = document.getElementById("desarrollador").value;
    libro.Genero = document.getElementById("genero").value;
    libro.FechaLanzamiento = document.getElementById("fechalanzamiento").value;
    libro.Precio = document.getElementById("precio").value;
    libro.Imagen = document.getElementById("imagen").value;
    if (document.getElementById('multijugador').checked)
        libro.Formatouno = document.getElementById("multijugador").value;
    if (document.getElementById('cooperativo').checked)
        libro.Formatodos = document.getElementById("cooperativo").value;
    if (document.getElementById('micropagos').checked)
        libro.Formatotres = document.getElementById("micropagos").value;
    if (document.getElementById("nuevo").checked)
        libro.Estado = document.getElementById("nuevo").value;
    else if (document.getElementById("remaster").checked)
        libro.Estado = document.getElementById("remaster").value;
    return libro;
}

function exito(data) {
    $mensaje.textContent = data;
}