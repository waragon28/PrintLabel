﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vistony.PrintLabel.BO;
using Vistony.PrintLabel.DAL;


namespace Vistony.PrintLabel.BLL
{
    public class WorkOrderBLL : IDisposable
    {

        public SAPbouiCOM.DataTable GetWorkOrderForPrintLabel (string startDate, string endDate, string statusWO, string statusPrint, ref SAPbouiCOM.DataTable oDataTable )
        {
            using (WorkOrderDAL workOrderDAL = new WorkOrderDAL() )
            {
                return workOrderDAL.GetWorkOrderForPrintLabel(startDate, endDate, statusWO,statusPrint, ref oDataTable);
            }
        }

        public SAPbouiCOM.DataTable GetWorkSCCForPrintLabel(string startDate, string endDate, string statusWO, string statusPrint, ref SAPbouiCOM.DataTable oDataTable)
        {
            using (WorkOrderDAL workOrderDAL = new WorkOrderDAL())
            {
                return workOrderDAL.GetWorkSCCForPrintLabel(startDate, endDate, statusWO, statusPrint, ref oDataTable);
            }
        }
        
        public string UpdateStatusPrinted(WorkOrder jsonBody, int? docEntry)
        {

            using (WorkOrderDAL workOrderDAL = new WorkOrderDAL())
            {
                return workOrderDAL.UpdateStatusPrinted(jsonBody, docEntry);
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
        ~WorkOrderBLL()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion


    }// fin de la clase

}// fin del namespace
