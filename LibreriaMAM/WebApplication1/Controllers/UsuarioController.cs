using LibreriaV6.Modelo;
using LibreriaV6.Negocio;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LibreriaV6.Controllers {

    public class UsuarioController : Controller {
        private ControlAccesoDAO<TUsuario> control = new ControlAccesoDAO<TUsuario>();

        public ActionResult verFacturas() {
            return View(control.Buscar(new TFactura().GetType(), "Cliente", (Session["usuario"] as TUsuario).Nick));
        }

        public ActionResult detalleFactura(string CodFactura) {
            List<LineaAuxiliar> listaVentas = new List<LineaAuxiliar>();
            foreach (TLineaFactura lineaFactura in control.Buscar(new TLineaFactura().GetType(), "CodFactura", CodFactura)) {
                listaVentas.Add(new LineaAuxiliar(lineaFactura.CodFactura, (control.Buscar(new TLibro().GetType(), lineaFactura.Libro) as TLibro), lineaFactura.Cantidad, lineaFactura.Total));
            }

            return View(listaVentas);
        }
    }
}