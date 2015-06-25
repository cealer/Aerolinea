﻿using Aerolinea_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_AccesoDatos
{
    public class UsuarioDAL : Operaciones
    {

        public void Insertar(EUsuario aux)
        {
            Insert(aux);
        }
        public DataTable ObtenerTodos(EDestino aux)
        {
            return SelectAll(aux);
        }

        public void Eliminar(EDestino aux, int id)
        {
            Delete(aux, id);
        }

        public void Modificar(EDestino aux)
        {
            Update(aux);
        }

        public string getPassword(string password)
        {
            return Hashing.HashPassword(password);
        }

        public bool validarPassword(string password, string hash)
        {
            return Hashing.ValidaPassword(password, hash);
        }

        public DataTable BuscarUsuario(EUsuario aux, string usuario)
        {

            return SelectAll(aux, "Usuario", usuario);

        }

    }
}
