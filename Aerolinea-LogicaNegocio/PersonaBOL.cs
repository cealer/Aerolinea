using Aerolinea_AccesoDatos;
using Aerolinea_Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_LogicaNegocio
{
   public class PersonaBOL
    {
        private PersonaDAL _personaDal = new PersonaDAL();

        public void Registrar(EPersona aux)
        {
            _personaDal.Insertar(aux);
        }

        public void Modificar(EPersona aux)
        {
            _personaDal.Update(aux);
        }

        public DataTable ObtenerTodos(EPersona aux)
        {
            return _personaDal.SelectAll(aux);
        }

        public ArrayList LlenarCombo(EPersona aux)
        {
            return _personaDal.LlenarComboBusqueda(aux);
        }

        public DataTable ObtenerCondicion(EPersona aux, string campo, string valor)
        {
            return _personaDal.SelectAll(aux, campo, valor);
        }

        public int ObtenerIdPasajero() { 
        return _personaDal.ObtenerMaxId();
        }
    }
}
