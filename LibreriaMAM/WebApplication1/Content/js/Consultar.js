function borrar(a) {
    var list = document.getElementById(a);
    if (list.hasChildNodes()) {
        list.parentNode.removeChild(list);
    }
}