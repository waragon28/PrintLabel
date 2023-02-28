using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.PrintLabel.UI.Constans
{
    public class AddonMessageInfo
    {

        public const string AddonName = "Addon Print Label ";

        public const string SAPNotRunning = AddonName + "SAP Business One, no se encuentra corriendo ";
        
        public const string StartLoading = AddonName + "Iniciando Carga ..." ;
        public const string FinishLoading = AddonName + "Carga Finalizada ...";

        public const string Message001 = AddonName + "Usuario no configurado para el " + AddonName;
        public const string Message003 = "No cuenta con Registros ";
        public const string Message004 = "No se configuro la Unidad de Negocio para '{0}'";
        public const string Message005 = "No se configuro el Gerente o Supervidor para '{0}'";
        public const string Message006 = "Campo código de Vendedor no puede ser vacio '{0}'";

        public const string Message007 = AddonName + " Es necesario selecionar una impresora.";

        public const string Message008 = AddonName + " Ocurrio un error al imprimir";

        public const string Message009 = AddonName + " Comandos enviados a la impresora exitosamente.";
        public const string Message010 = AddonName + " Se imprimió la orden de fabricación N° {0}.";


    }// fin de la clase


}// fin del namespace
