using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace Agenda_Personal.Models
{
    public class Contacto
    {
        [Display(Name="Id Contacto")]
        public int? Contacto_Id { get; set; }
        [Display(Name = "Nombre(s)"), Required(ErrorMessage="El nombre es requerido.")]
        public string Contacto_Nombres { get; set; }
        [Display(Name = "Apellido(s)"), Required(ErrorMessage = "El apellido es requerido.")]
        public string Contacto_Apellidos { get; set; }
        [Display(Name = "Telefono"), Required(ErrorMessage = "El teléfono es requerido.")]
        public string Contacto_Telefono { get; set; }
        [Display(Name = "Correo")]
        public string Contacto_Email { get; set; }

        public void Contacto_Inserta(Contacto contacto)
        {
            DataAccess.DataAccess data = new DataAccess.DataAccess();

            try
            {
                data.SetDataCommand("Contacto_Inserta", contacto);
            }
            catch (Exception)
            { }
        }

        public void Contacto_Modifica(Contacto contacto)
        {
            DataAccess.DataAccess data = new DataAccess.DataAccess();

            try
            {
                data.SetDataCommand("Contacto_Modifica", contacto);
            }
            catch (Exception)
            { }
        }

        public List<Contacto> Contacto_Consulta(Contacto contacto)
        {
            DataAccess.DataAccess data = new DataAccess.DataAccess();
            DataTable dt = new DataTable();
            List<Contacto> contactos = new List<Contacto>();
            string procedure = "";

            if (contacto.Contacto_Id == null)
                procedure = "Contacto_Consulta";
            else
                procedure = "Contacto_Consulta_Id";

            try
            {
                dt = data.GetDataTable(procedure, contacto);

                if (dt.Rows.Count > 0)
                {
                    contactos = (from list in dt.AsEnumerable()
                                 select new Contacto
                                 {
                                     Contacto_Id = list["Contacto_ID"] as int?,
                                     Contacto_Nombres = list["Contacto_Nombres"] as string,
                                     Contacto_Apellidos = list["Contacto_Apellidos"] as string,
                                     Contacto_Telefono = list["Contacto_Telefono"] as string,
                                     Contacto_Email = list["Contacto_Email"] as string
                                 }).ToList();
                }
            }
            catch (Exception)
            { }

            return contactos;
        }


        public void Contacto_Borrar(int Contacto_Id)
        {
            DataAccess.DataAccess data = new DataAccess.DataAccess();

            try
            {
                data.SetDataCommand("Contacto_Elimina", Contacto_Id, null);
            }
            catch (Exception)
            { }
        }
    }
}