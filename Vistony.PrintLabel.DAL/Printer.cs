using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forxap.Framework.DI;

namespace Vistony.PrintLabel.DAL
{
   public class PrinterDAL : IDisposable
    {

        /// <summary>
        /// Obtiene un listado de impresoras
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetList()
        {

            using( Sb1Data sb1Data = new Sb1Data() )
            {
               return sb1Data.GetListFromSQL("CALL SP_GET_PRINTER('')");
            }
        }


        /// <summary>
        /// Obtiene una impresora a traves de su codigo
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetObject(string code )
        {

            using (Sb1Data sb1Data = new Sb1Data())
            {
                return sb1Data.GetObjectFromSQL( string.Format(" CALL SP_GET_PRINTER('{0}')",code));
            }
        }




        #region Disposable




        private bool disposing = false;
        /// <summary>
        /// Método de IDisposable para desechar la clase.
        /// </summary>
        public void Dispose()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        /// <summary>
        /// Método sobrecargado de Dispose que será el que
        /// libera los recursos, controla que solo se ejecute
        /// dicha lógica una vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name=”b”></param>
        protected virtual void Dispose(bool b)
        {
            // Si no se esta destruyendo ya…
            {
                if (!disposing)

                    // La marco como desechada ó desechandose,
                    // de forma que no se puede ejecutar este código
                    // dos veces.
                    disposing = true;
                // Indico al GC que no llame al destructor
                // de esta clase al recolectarla.
                GC.SuppressFinalize(this);
                // … libero los recursos… 
            }
        }




        /// <summary>
        /// Destructor de clase.
        /// En caso de que se nos olvide “desechar” la clase,
        /// el GC llamará al destructor, que tambén ejecuta la lógica
        /// anterior para liberar los recursos.
        /// </summary>
        ~PrinterDAL()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion


    }

}
