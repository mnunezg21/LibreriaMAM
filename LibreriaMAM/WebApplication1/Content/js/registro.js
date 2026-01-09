function Registro(user) {
    var uri = '/Inicio/Registro';
    $.ajax({
        url: uri,
        data: JSON.stringify(user),
        type: 'POST',
        success: exito,
        contentType: 'application/json'
    });
}

function cargarRegistro() {
    var user = {};
    user.Nick = $("#userRegisInput").val();
    user.Pass = $("#passRegisInput").val();
    var passConfirm = $("#passRegisConfInput").val();

    confirmarPassword();

    if (user.Pass == passConfirm) {
        Registro(user);
    } else {
        $("#passNoCoinciden").removeClass("d-none");
    }
}

window.onload = function () {
    $("#passRegisConfInput").keyup(function () {
        confirmarPassword();
    });
}

function confirmarPassword() {
    var pass = $("#passRegisInput").val();
    var passConfirm = $("#passRegisConfInput").val();

    if (pass == passConfirm) {
        $("#passNoCoinciden").addClass("d-none");
    } else {
        $("#passNoCoinciden").removeClass("d-none");
    }
}

function exito() {
    window.location.replace("/Inicio/Inicio");
}