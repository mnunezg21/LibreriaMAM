namespace LibreriaV6.Modelo {

    public class LineaAuxiliar {
        public string CodFactura { get; set; }
        public TLibro VideoJuego { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }

        public LineaAuxiliar(string codFactura, TLibro videojuego, string cantidad, string total) {
            CodFactura = codFactura;
            VideoJuego = videojuego;
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