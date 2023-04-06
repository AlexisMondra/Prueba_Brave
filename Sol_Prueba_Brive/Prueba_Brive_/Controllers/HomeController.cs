using Buss_Brive;
using Entity_Brive;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba_Brive_.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        BBrive Buss = new BBrive();


        public ActionResult Index()
        {
            try
            {
                List<EBrive> list = Buss.Obtener();
                return View(list);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(new List<EBrive>());
            }
        }

        public ActionResult Agregar()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Agregar(EBrive us)
        {
            try
            {
                Buss.Agregar(us);
                TempData["mensaje"] = $"Se agrego el producto {us.Nombre_Prod}";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                EBrive ec = Buss.ObtenerId(id);
                return View(ec);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");

                throw;
            }
        }

        public ActionResult EditarPost(EBrive eb)
        {
            try
            {
                Buss.Editar(eb);
                TempData["Mensaje"] = $"El producto {eb.Nombre_Prod} se edito correctamente";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Editar", eb);
                throw;
            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                EBrive eb = Buss.ObtenerId(id);
                TempData["Mensaje"] = $"El producto se elimino  correctamente";

                Buss.Eliminar(eb);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
                throw;
            }
        }

        public ActionResult Buscar(string Valor)
        {
            try
            {
                List<EBrive> list = Buss.Buscar(Valor);
                return View("Index", list);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Index", new List<EBrive>());
            }
        }



    }
}