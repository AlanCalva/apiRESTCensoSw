using apiRESTCenso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace apiRESTCenso.Controllers
{
    public class CensoController : ApiController
    {
        // Definicion del arreglo de objetos
        public static clsCenso[] objCenso = null;

        // Constructor del controlador para inicializar
        // GET: api/Censo
        public IEnumerable<clsCenso> Get()
        {
            return objCenso;
        }

        // GET: api/Censo/5
        public clsCenso Get(int id)
        {
            // Elemento de uso para lectura
            clsCenso elemento = new clsCenso();
            for (int i = 0; i < objCenso.Length; i++)
            {
                if (objCenso[i].id == id)
                {
                    elemento = objCenso[i];
                    break;
                }
            }
            return elemento;
        }

        // POST: api/Censo
        public string Post(int posicion, [FromBody] clsCenso modelo)
        {
            string ban = "";

            if (objCenso == null)
            {
                objCenso = new clsCenso[5];
                objCenso[0] = new clsCenso();
                objCenso[1] = new clsCenso();
                objCenso[2] = new clsCenso();
                objCenso[3] = new clsCenso();
                objCenso[4] = new clsCenso();
               
            }

            if (posicion >= 0 && posicion <= 4)
            {
                objCenso[posicion].id = modelo.id;
                objCenso[posicion].curp = modelo.curp;
                objCenso[posicion].nombre = modelo.nombre;
                objCenso[posicion].apellidoPaterno = modelo.apellidoPaterno;
                objCenso[posicion].apellidoMaterno = modelo.apellidoMaterno;
                objCenso[posicion].direccion = modelo.direccion;
                objCenso[posicion].actividadEconomica = modelo.actividadEconomica;
                ban = "1"; // Success
            }
            else
            {
                ban = "0"; // Failure
            }

            return ban;
        }

        // PUT: api/Censo/5
        public string Put(int posicion, [FromBody] clsCenso modelo)
        {
            string ban;

            if (objCenso != null)
            {
                if (posicion >= 0 && posicion <= 4)
                {
                    objCenso[posicion].id = modelo.id;
                    objCenso[posicion].curp = modelo.curp;
                    objCenso[posicion].nombre = modelo.nombre;
                    objCenso[posicion].apellidoPaterno = modelo.apellidoPaterno;
                    objCenso[posicion].apellidoMaterno = modelo.apellidoMaterno;
                    objCenso[posicion].direccion = modelo.direccion;
                    objCenso[posicion].actividadEconomica = modelo.actividadEconomica;
                    ban = "1"; // Success
                }
                else
                {
                    ban = "0"; // Failure
                }
            }
            else
            {
                ban = "0"; // Failure
            }

            return ban;
        }

        // DELETE: api/Censo/5
        public string Delete(int posicion)
        {
            string ban;
            if (objCenso != null)
            {
                if (posicion >= 0 && posicion <= 4)
                {
                    objCenso[posicion].id = 0;
                    objCenso[posicion].curp = null;
                    objCenso[posicion].nombre = null;
                    objCenso[posicion].apellidoPaterno = null;
                    objCenso[posicion].apellidoMaterno = null;
                    objCenso[posicion].direccion = null; // Corrected here
                    objCenso[posicion].actividadEconomica = null;
                    ban = "1"; // Success
                }
                else
                {
                    ban = "0"; // Failure
                }
            }
            else
            {
                ban = "-1"; // Failure
            }
            return ban;

          

        }
         
    }
}
