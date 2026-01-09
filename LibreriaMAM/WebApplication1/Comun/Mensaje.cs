using System;

namespace LibreriaV6.Comun {

    public class Mensaje {

        public static string mostrarmensaje(String mensaje, String pagina) {
            return "<div id = openModal class = modalDialog>" +
                   "<div>" +
                   "<a href= " + pagina + " title = Close class = 'close'>X</a>" +
                   "<h2> Mensaje </h2>" +
                   "<p>" + mensaje + "</p>" +
                   "</div>" +
                   "</div>";
        }
    }
}