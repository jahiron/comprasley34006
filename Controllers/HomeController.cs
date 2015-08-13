using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agenda_Personal.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(string NombreApellido)
        {
            Models.Contacto contact = new Models.Contacto();

            if (!string.IsNullOrEmpty(NombreApellido))
                contact.Contacto_Nombres = NombreApellido;
            
            return View(contact.Contacto_Consulta(contact));
        }

        public ActionResult InsertarContacto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertarContacto(Models.Contacto contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    contact.Contacto_Inserta(contact);
                }
                catch (Exception)
                { }    
            }

            return RedirectToAction("Index");
        }

        public ActionResult ModificarContacto(int Contacto_Id)
        {
            Models.Contacto contact = new Models.Contacto();
            contact.Contacto_Id = Contacto_Id;

            try
            {
                contact = contact.Contacto_Consulta(contact).FirstOrDefault();
            }
            catch (Exception)
            { }

            return View(contact);
        }

        [HttpPost]
        public ActionResult ModificarContacto(Models.Contacto contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    contact.Contacto_Modifica(contact);
                }
                catch (Exception)
                { }
            }

            return RedirectToAction("Index");
        }

        public ActionResult DetallesContacto(int Contacto_Id)
        {
            Models.Contacto contact = new Models.Contacto();
            contact.Contacto_Id = Contacto_Id;

            try
            {
                contact = contact.Contacto_Consulta(contact).FirstOrDefault();
            }
            catch (Exception)
            { }

            return View(contact);
        }

        public ActionResult BorrarContacto(int Contacto_Id)
        {
            Models.Contacto contact = new Models.Contacto();
            contact.Contacto_Id = Contacto_Id;

            try
            {
                contact.Contacto_Borrar(Contacto_Id);
            }
            catch (Exception)
            { }

            return RedirectToAction("Index");
        }

        public ActionResult AcercaDe()
        {
            return View();
        }
    }
}
