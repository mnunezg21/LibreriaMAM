namespace LibreriaV6.Modelo {

    public class TLineaFactura {
        public string CodFactura { get; set; }
        public string VideoJuego { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }

        public TLineaFactura(string codFactura, string videojuego, string cantidad, string total) {
            CodFactura = codFactura;
            VideoJuego = videojuego;
            Cantidad = cantidad;
            Total = total;
        }

        public TLineaFactura() {
        }

        public float subTotal() {
            return float.Parse(Total);
        }

        public override string ToString() {
            return VideoJuego + " " + Cantidad + " " + Total;
        }

        public override bool Equals(object obj) {
            return ((TLineaFactura)obj).VideoJuego == VideoJuego;
        }
    }
}