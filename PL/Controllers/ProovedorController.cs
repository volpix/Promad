using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProovedorController : Controller
    {
        //
        // GET: /Proovedor/
        public ActionResult GetAll()
        {
            BL.Proovedor proovedor = new BL.Proovedor();
            BL.Result result = BL.Proovedor.GetAll();

            proovedor.Proovedores = result.Objects;
            return View(proovedor);
        }
        [HttpGet]
        public ActionResult Form(int? IdProovedor)
        {
            BL.Proovedor proovedor = new BL.Proovedor();

            if (IdProovedor == null)
            {
                return View(proovedor);
            }
            else
            {
                BL.Result result = new BL.Result();

                result = BL.Proovedor.GetById(IdProovedor.Value);
                if (result.Correct)
                {
                    proovedor = ((BL.Proovedor)result.Object);
                    return View(proovedor);
                }
                else
                {

                }
            }

            return View();
        }
        [HttpPost]
        public ActionResult Form(BL.Proovedor proovedor)
        {
            BL.Result result = new BL.Result();
                if (proovedor.IdProovedor == 0)
                {
                    result = BL.Proovedor.Add(proovedor);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "El Proovedor se ha registrado correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "El Proovedor no se ha registrado correctamente " + result.ErrorMessage;
                    }
                }
                else
                {
                    result = BL.Proovedor.Update(proovedor);

                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "El Proovedor se ha actualizado correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "El Proovedor no se ha actualizado correctamente " + result.ErrorMessage;
                    }
                }
            
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(int IdProovedor)
        {
            BL.Proovedor proovedor = new BL.Proovedor();
            proovedor.IdProovedor = IdProovedor;
                BL.Result result = BL.Proovedor.Delete(proovedor);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "El Proovedor se ha eliminado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "El Proovedor no se ha eliminado correctamente " + result.ErrorMessage;
                }
            return PartialView("Modal");
        }
	}
}