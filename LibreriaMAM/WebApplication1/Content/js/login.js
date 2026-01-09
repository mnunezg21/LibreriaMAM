function Login() {
    var uri = '/Inicio/Login';
    var sesion = {};
    sesion = cargarSesion(sesion);
    $.ajax({
        url: uri,
        data: JSON.stringify(sesion),
        type: 'POST',
        success: exito,
        contentType: 'application/json'
    });
}

function cargarSesion(user) {
    user.Nick = document.getElementById("userLoginInput").value;
    user.Pass = document.getElementById("passLoginInput").value;
    return user;
}

function exito() {
    window.location.replace("/Inicio/Inicio");
}