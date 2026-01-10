using LibreriaV6.Comun;

namespace LibreriaV6.Modelo {

    public class TLinea {
        public string CodFactura { get; set; }
        public string Libro { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }

        public TLinea(string codFactura, string libro, string cantidad, string total) {
            this.CodFactura = codFactura;
            this.Libro = libro;
            this.Cantidad = cantidad;
            this.Total = total;
        }

        public TLinea(string libro, string cantidad, string total) {
            this.CodFactura = Util.GenerarCodigo(this.GetType());
            this.Libro = libro;
            this.Cantidad = cantidad;
            this.Total = total;
        }

        public TLinea() {
        }

        public override string ToString() {
            return CodFactura + ": " + Libro.ToUpper();
        }
    }
}