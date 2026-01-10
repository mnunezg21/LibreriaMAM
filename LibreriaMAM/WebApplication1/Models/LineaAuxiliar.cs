namespace LibreriaV6.Modelo {

    public class LineaAuxiliar {
        public string CodFactura { get; set; }
        public TLibro Libro { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }

        public LineaAuxiliar(string codFactura, TLibro libro, string cantidad, string total) {
            CodFactura = codFactura;
            Libro = libro;
            Cantidad = cantidad;
            Total = total;
        }

        public LineaAuxiliar() {
        }

        public double subTotal() {
            return double.Parse(Total.Replace(',', '.'));
        }
    }
}