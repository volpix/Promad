using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Producto/
        public ActionResult GetAll()
        {
            BL.Producto producto = new BL.Producto();
            BL.Result result = BL.Producto.GetAll();

            producto.Productos = result.Objects;
            return View(producto);
        }
        [HttpGet]
        public ActionResult Form()
        {
            BL.Producto producto = new BL.Producto();

            producto.Proovedor = new BL.Proovedor();
            BL.Result resultProovedor = BL.Proovedor.GetAll();

            producto.Proovedor.Proovedores = resultProovedor.Objects;

            return View(producto);
            
        }
        [HttpPost]
        public ActionResult Form(BL.Producto producto)
        {
            
            BL.Result result = new BL.Result();

                result = BL.Producto.Add(producto);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "El Producto se ha registrado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "El Producto no se ha registrado correctamente " + result.ErrorMessage;
                }

            return PartialView("Modal");
        }
	}
}