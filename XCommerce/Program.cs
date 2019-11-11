using System;
using System.Windows.Forms;
using Presentacion.Core.Delivery;
using Presentacion.Core.FormaPago;
using Presentacion.Seguridad;
using XCommerce.Servicio.Seguridad.Seguridad;
using XCommerce.Servicio.Seguridad.Usuario;

namespace XCommerce
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Lanzo el formulario de Login del Sistema
            var fLogin = new Login(new AccesoSistema(), new UsuarioServicio());
            fLogin.ShowDialog(); // Abrir el formulario
            
            // verifico si puede o no acceder
            if (fLogin.PuedeAccederSistema)
            {
                Application.Run(new Principal());
            }
            else
            {
                Application.Exit(); // Cierra la Aplicacion Completa
            }
        }
    }
}
