using LibreriaV6.Comun;

namespace LibreriaV6.Modelo {

    public class TLinea {
        public string CodFactura { get; set; }
        public string VideoJuego { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }

        public TLinea(string codFactura, string videojuego, string cantidad, string total) {
            this.CodFactura = codFactura;
            this.VideoJuego = VideoJuego;
            this.Cantidad = cantidad;
            this.Total = total;
        }

        public TLinea(string videojuego, string cantidad, string total) {
            this.CodFactura = Util.GenerarCodigo(this.GetType());
            this.VideoJuego = videojuego;
            this.Cantidad = cantidad;
            this.Total = total;
        }

        public TLinea() {
        }

        public override string ToString() {
            return CodFactura + ": " + VideoJuego.ToUpper();
        }
    }
}