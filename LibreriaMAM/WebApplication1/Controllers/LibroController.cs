using LibreriaV6.Comun;
using LibreriaV6.Modelo;
using LibreriaV6.Negocio;
using LibreriaV6.Persistencia;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{

    public class LibroController : Controller
    {
        private ControlAccesoDAO<TLibro> control = new ControlAccesoDAO<TLibro>();

        public ActionResult Consultar()
        {
            object[] modelos = new object[2];
            List<TLibro> list = new List<TLibro>();
            foreach (var item in control.Obtener(new TLibro().GetType()))
            {
                list.Add((TLibro)item);
            }

            modelos[0] = list;
            modelos[1] = control.Obtener(new TGenero().GetType());

            return View(modelos);
        }

        public ActionResult ConsultarFiltro(String genero)
        {
            object[] modelos = new object[2];

            List<TLibro> list = new List<TLibro>();
            foreach (TLibro item in control.Obtener(new TLibro().GetType()))
            {
                if (item.Genero.Equals(genero))
                {
                    list.Add(item);
                }
            }

            modelos[0] = list;
            modelos[1] = control.Obtener(new TGenero().GetType());

            return View(modelos);
        }

        public ActionResult VerGeneros()
        {
            return View();
        }

        public ActionResult CarroCompra()
        {
            List<TLibro> list = new List<TLibro>();

            foreach (var item in control.Obtener(new TLibro().GetType()))
            {
                list.Add((TLibro)item);
            }

            return View(list);
        }

        public PartialViewResult borrarLibro(string CodLibro)
        {
            control.BorradoVirtual((TLibro)control.Buscar(new TLibro().GetType(), CodLibro));
            object[] modelos = new object[1];
            modelos[0] = control.Obtener(new TLibro().GetType());
            return PartialView("_BorrarLibro", modelos);
        }

        public ActionResult verLibro(string CodLibro)
        {
            return PartialView("_verLibro", (TLibro)control.Buscar(new TLibro().GetType(), CodLibro));
        }

        public ActionResult addLibro()
        {
            return View(control.Obtener(new TGenero().GetType()));
        }

        [HttpPost]
        public ActionResult addLibro(TLibro libro)
        {
            try
            {
                List<object> libros = new List<object>();
                libro.Precio = libro.Precio.Replace(",", ".");
                libro.CodLibro = Util.GenerarCodigo(libro.GetType());
                libro.Borrado = "0";
                libro.Formatouno = libro.Formatouno == null ? "N/A" : libro.Formatouno;
                libro.Formatodos = libro.Formatodos == null ? "N/A" : libro.Formatodos;
                libro.Formatotres = libro.Formatotres == null ? "N/A" : libro.Formatotres;
                libros.Add((TLibro)libro);
                if (control.Insertar(libros))
                {
                    return Json("Libro insertado correctamente");
                }
            }
            catch (Exception e)
            {
                return Json(Errores.ControlErrores(e));
            }
            return RedirectToAction("Inicio");
        }

        public ActionResult modificarLibro(string CodLibro)
        {
            object[] modelos = new object[2];
            modelos[0] = control.Buscar(new TLibro().GetType(), CodLibro);
            modelos[1] = control.Obtener(new TGenero().GetType());
            return View(modelos);
        }

        [HttpPost]
        public ActionResult modificarLibro(TLibro libro)
        {
            try
            {
                libro.Precio = libro.Precio.Replace(",", ".");
                libro.Borrado = "0";
                libro.Formatotres = libro.Formatotres == null ? "N/A" : libro.Formatotres;
                libro.Formatodos = libro.Formatodos == null ? "N/A" : libro.Formatodos;
                libro.Formatotres = libro.Formatotres == null ? "N/A" : libro.Formatotres;
                control.Modificar(libro.CodLibro, libro);
                return RedirectToAction("Consultar");
            }
            catch (Exception e)
            {
                return Content(Mensaje.mostrarmensaje(Errores.ControlErrores(e), "modificarLibro"));
            }
        }

        [HttpPost]
        public ActionResult obtenerLibros(string CodLibro)
        {
            object[] modelos = new object[1];
            modelos[0] = control.Buscar(new TLibro().GetType(), CodLibro);
            return Json(modelos);
        }

        public ActionResult Buscar(String buscar)
        {
            object modelos = new object[2];
            List<TLibro> list = new List<TLibro>();
            foreach (var item in control.BuscarLike(new TLibro().GetType(), "Titulo", buscar))
            {
                list.Add((TLibro)item);
            }

            modelos = list;

            return View(modelos);
        }

        [HttpPost]
        public ActionResult comprar(List<TLinea> data)
        {
            TFactura factura = new TFactura("", ((TUsuario)Session["usuario"]).Nick, DateTime.Now.ToShortDateString());
            factura.CodFactura = Util.GenerarCodigo(factura.GetType());
            List<object> listaFacturaTemp = new List<object>();
            listaFacturaTemp.Add(factura);
            List<object> listaLineasFactura = new List<object>();

            foreach (TLinea linea in data)
            {
                TLineaFactura lineaTemp = new TLineaFactura(factura.CodFactura, linea.Libro, linea.Cantidad.ToString(), linea.Total.ToString());
                listaLineasFactura.Add(lineaTemp);
            }

            control.Insertar(listaLineasFactura);
            control.Insertar(listaFacturaTemp);
            return Json("Factura guardada correctamente");
        }
    }
}