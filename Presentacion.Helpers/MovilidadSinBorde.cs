namespace Presentacion.Helpers
{
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public static class MovilidadSinBorde
    {
        //Importar las Dll de user32 de Windows que contiene los métodos para mover ventanas
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public static void Movilidad(Form formulario)
        {
            ReleaseCapture();
            SendMessage(formulario.Handle, 0x112, 0xf012, 0);
        }
    }
}
