namespace LibreriaV6.Modelo {

    public class TGenero {
        public string Genero { get; set; }
        public string Imagen { get; set; }

        public TGenero() {
        }

        public TGenero(string genero, string imagen) {
            this.Genero = genero;
            this.Imagen = imagen;
        }
    }
}