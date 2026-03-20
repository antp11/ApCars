using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Interfaces;
using UTN.WinForms.ApCars.Layers.DAL;
using UTN.WinForms.ApCars.Layers.Entities;

namespace UTN.WinForms.ApCars.Layers.BLL
{
    internal class BLLUsuario : IBLLUsuario
    {
        private bool IsValidPassword(string pPassword, ref string pMensaje)
        {
            if (pPassword.Trim().Length <= 6)
            {
                pMensaje = "El password debe ser mayor o igual a 6 caracteres";
                return false;
            }

            if (pPassword.Trim().Length > 10)
            {
                pMensaje = "El password debe ser mayor o igual a 6 caracteres y menor  o igual que 10";
                return false;
            }

            return true;
        }

        public bool Delete(string pLogin)
        {
            IDALUsuario dalUsuario = new DALUsuario();
            return dalUsuario.Delete(pLogin);
        }

        public IEnumerable<Usuario> GetAll()
        {
            IDALUsuario dalUsuario = new DALUsuario();

            return dalUsuario.GetAll();


        }

        public Usuario GetById(string pLogin)
        {
            IDALUsuario dalUsuario = new DALUsuario();

            return dalUsuario.GetById(pLogin);
        }

        public Usuario Login(string pLogin, string pPassword)
        {
            IDALUsuario dalUsuario = new DALUsuario();
            // Encriptar el password
            string crytpPasswd = Cryptography.EncrypthAES(pPassword);

            return dalUsuario.Login(pLogin, crytpPasswd);
        }


        public Usuario Save(Usuario pUsuario)
        {
            IDALUsuario dalUsuario = new DALUsuario();
            string mensaje = "";
            Usuario oUsuario = null;

            if (!IsValidPassword(pUsuario.Contrasenna, ref mensaje))
            {
                throw new Exception(mensaje);
            }

            // Encriptar la contraseña.
            pUsuario.Contrasenna = Cryptography.EncrypthAES(pUsuario.Contrasenna);

            if (dalUsuario.GetById(pUsuario.IdUsuario) != null)
                oUsuario = dalUsuario.Update(pUsuario);
            else
                oUsuario = dalUsuario.Save(pUsuario);
            return oUsuario;


        }
    }
}
