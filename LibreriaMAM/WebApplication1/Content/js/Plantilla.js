let t = 0.0;
let $carro = document.querySelector('#carro');
let $t = document.querySelector('#t');
let $unids = document.querySelector('#unids')
let carro;

if (localStorage.carrito !== undefined)
    carro = JSON.parse(localStorage.carrito);
if (carro === undefined)
    carro = []
else {
    renderizarCarro(carro);
    calcularT(carro);
}

function calcularT(carro) {
    t = 0;
    u = 0;
    for (let miItem of carro) {
        t = t + parseFloat(miItem[0]['Precio'] * miItem[0]['Cantidad']);
        u++;
    }
    if (u > 0) {
        $unids.classList.add('alert', 'bg-primary', 'text-white', 'p-1');
        $unids.textContent = u;
    }
    $t.textContent = t.toFixed(2);
}

function renderizarCarro(carro) {
    $carro.textContent = '';
    var indice = 0;
    for (let miItem of carro) {
        let miNodo = document.createElement('li');
        miNodo.classList.add('list-group-item');

        let miNodoRow = document.createElement('div');
        miNodoRow.classList.add('row', 'justify-content-center');
        miNodo.appendChild(miNodoRow);

        let miNodoCol1 = document.createElement('div');
        miNodoCol1.classList.add('col-8', 'col-md-10', 'text-left');
        miNodoRow.appendChild(miNodoCol1);

        let miSpan = document.createElement('span');
        miSpan.textContent = `x${miItem[0]['Cantidad']} ${miItem[0]['Titulo']} - ${miItem[0]['Precio'] * miItem[0]['Cantidad']}€`;
        miSpan.classList.add('text-left');
        miNodoCol1.appendChild(miSpan);

        let miNodoCol2 = document.createElement('div');
        miNodoCol2.classList.add('col-4', 'col-md-2', 'text-right');
        miNodoRow.appendChild(miNodoCol2);

        let miBoton = document.createElement('button');
        miBoton.classList.add('btn', 'btn-danger');
        miBoton.textContent = 'X';
        miBoton.setAttribute('posicion', indice);
        indice = indice + 1;
        miBoton.addEventListener('click', borrarItemCarro);
        miNodoCol2.appendChild(miBoton);

        $carro.appendChild(miNodo);
    }
}

function borrarItemCarro() {
    carro.splice(this.getAttribute('posicion'), 1);
    localStorage.removeItem("carrito");
    localStorage.carrito = JSON.stringify(carro);
    renderizarCarro(carro);
    calcularT(carro);
}