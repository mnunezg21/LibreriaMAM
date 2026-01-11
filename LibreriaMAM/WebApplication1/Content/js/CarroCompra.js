let total = 0;
let $carrito = document.querySelector('#carrito');
let $total = document.querySelector('#total');
let $mensaje = document.querySelector('#mensaje');
let carrito;

if (localStorage.carrito !== undefined)
    carrito = JSON.parse(localStorage.carrito);
if (carrito === undefined) {
    carrito = []
} else {
    renderizarCarrito(carrito);
    calcularTotal(carrito);
}

function anyadirCarrito(dato) {
    var encontrado = false;
    if (carrito.length == 0) {
        dato[0].Cantidad = 1;
        carrito.push(dato);
    } else {
        var cantidad = 1;
        for (var i = 0; i < carrito.length; i++) {
            var codLibro = carrito[i][0].CodLibro;
            if (codLibro == dato[0].CodLibro && !encontrado) {
                carrito[i][0].Cantidad++;
                encontrado = true;
            }
        }
        if (!encontrado) {
            dato[0].Cantidad = cantidad;
            carrito.push(dato);
        }
    }
    calcularTotal(carrito);
    renderizarCarrito(carrito);
}

function renderizarCarrito(carrito) {
    $carrito.textContent = '';
    var indice = 0;
    for (let miItem of carrito) {
        let tr = document.createElement('tr');
        let td1 = document.createElement('td');
        let td2 = document.createElement('td');
        let td3 = document.createElement('td');
        let td4 = document.createElement('td');
        let td5 = document.createElement('td');
        td1.textContent = `${parseInt(miItem[0].Cantidad)}`;
        td2.textContent = `${miItem[0]['Titulo']}`;
        td3.textContent = `${miItem[0]['Autor']}`;
        td4.textContent = `${miItem[0]['Precio']}€`;
        let miBoton = document.createElement('button');
        miBoton.classList.add('btn', 'btn-danger', 'mx-5');
        miBoton.textContent = 'X';
        miBoton.setAttribute('posicion', indice);
        indice = indice + 1;
        miBoton.addEventListener('click', borrarItemCarrito);
        tr.appendChild(td1);
        tr.appendChild(td2);
        tr.appendChild(td3);
        tr.appendChild(td4);
        td5.appendChild(miBoton);
        tr.appendChild(td5);
        $carrito.appendChild(tr);
    }
}

function borrarItemCarrito() {
    let posicion = this.getAttribute('posicion');
    carrito.splice(posicion, 1);
    localStorage.removeItem("carrito");
    localStorage.carrito = JSON.stringify(carrito);
    renderizarCarrito(carrito);
    calcularTotal(carrito);
}

function calcularTotal(carrito) {
    total = 0;
    for (let miItem of carrito) {
        var a = parseInt(miItem[0].Cantidad);
        total = total + parseInt(miItem[0]['Precio'] * a);
    }
    let totalDosDecimales = total.toFixed(2);
    $total.textContent = totalDosDecimales;
}

function success(data) {
    anyadirCarrito(data);
    localStorage.carrito = JSON.stringify(carrito);
}

function comprar() {
    var uri = '/Libro/comprar';
    var lineas = lineasFactura(carrito);
    $.ajax({
        url: uri,
        data: JSON.stringify(lineas),
        type: 'POST',
        success: exito,
        contentType: 'application/json'
    });
}

function exito(data) {
    $mensaje.textContent = data;
    localStorage.removeItem("carrito");
    carrito = [];
    renderizarCarrito(carrito);
    calcularTotal(carrito);
}

function lineasFactura(carrito) {
    var lineas = [];
    var lf = {};
    for (let miItem of carrito) {
        lf = {};
        lf.CodFactura = "";
        lf.Libro = miItem[0].CodLibro;
        lf.Cantidad = miItem[0].Cantidad;
        lf.Total = miItem[0].Precio * lf.Cantidad;
        lineas.push(lf);
    }
    return lineas;
}