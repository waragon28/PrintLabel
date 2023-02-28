using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Forxap.Framework.DI;
using Vistony.PrintLabel.BO;
using Forxap.Framework.UI;

namespace Vistony.PrintLabel.DAL
{
    public class WorkOrderDAL : IDisposable
    {
        public SAPbouiCOM.DataTable GetWorkOrderForPrintLabel(string startDate, string endDate, string statusWO, string statusPrint,ref SAPbouiCOM.DataTable oDataTable)
        {
            string strSQL = string.Empty;

            strSQL = string.Format( "CALL SP_GET_WORK_ORDER( '{0}', '{1}', '{2}' , '{3}')",startDate, endDate,statusWO,statusPrint );

            using (Sb1Data sb1Data = new Sb1Data())
            {
                 sb1Data.GetDataTableFromSQL(strSQL, ref oDataTable);
            }

            return oDataTable;

        }

        public SAPbouiCOM.DataTable GetWorkSCCForPrintLabel(string startDate, string endDate, string statusWO, string statusPrint, ref SAPbouiCOM.DataTable oDataTable)
        {
            string strSQL = string.Empty;

            strSQL = string.Format("CALL SP_GET_WORK_OSCC( '{0}', '{1}', '{2}' , '{3}')", startDate, endDate, statusWO, statusPrint);

            using (Sb1Data sb1Data = new Sb1Data())
            {
                sb1Data.GetDataTableFromSQL(strSQL, ref oDataTable);
            }

            return oDataTable;


        }

        public string  UpdateStatusPrinted(WorkOrder jsonBody, int? docEntry)
        {
            string ret = string.Empty;


            try
            {
                dynamic response;
                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic jsonData = JsonConvert.SerializeObject(jsonBody);
                response = methods.PATCH("ProductionOrders", docEntry, jsonData);
                dynamic m = JsonConvert.DeserializeObject(response.Content.ToString());
                string rpta = m.ToString();
                if (response.StatusCode.ToString() == "NoContent")
                {
                    return "Actualizado correctamente";
                }
                else
                {
                    return m["error"]["message"]["value"].ToString();
                }
            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.Message);
                return ex.Message;
            }

            return ret;
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
        ~WorkOrderDAL()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion

    }
}
