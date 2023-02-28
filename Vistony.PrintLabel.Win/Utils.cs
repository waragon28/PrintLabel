using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Drawing;
using SAPbobsCOM;
using Forxap.Framework.Extensions;

using Vistony.PrintLabel.BLL;
using Vistony.PrintLabel.BO;

using Vistony.PrintLabel.Win;


namespace Vistony.PrintLabel.UI.Win
{
    public  class Utils
    {

        





        public static void LoadPrinters(ref SAPbouiCOM.ComboBox oComboBox)
        {
            Dictionary<string, string> listDictionary;
            if (oComboBox != null)
            {
                using (PrinterBLL impresoraBLL = new PrinterBLL() )
                {
                    listDictionary = impresoraBLL.GetList();
                }

                foreach (var item in listDictionary)
                {
                    oComboBox.ValidValues.Add(item.Key, item.Value);
                }

                oComboBox.Item.DisplayDesc = true;
            }

        }

        public static Printer LoadPrinter(string code)
        {
            Dictionary<string, string> listDictionary;
            Printer printer = new Printer();
            
                using (PrinterBLL impresoraBLL = new PrinterBLL())
                {
                    listDictionary = impresoraBLL.GetObject(code);
                }

                foreach (var item in listDictionary)
                {
                    printer.Code = code;
                    printer.IPAdress = item.Key;
                    printer.PortNumber = Convert.ToInt32(item.Value);

                }

            return printer;
        
        }

        /// <summary>
        /// Carga un combobox con los supervisores
        /// </summary>
        /// <param name="oComboBox"></param>
        public static void LoadUnidadNegocio(ref SAPbouiCOM.ComboBox oComboBox)
        {
            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                listObject = Forxap.Framework.DI.Sb1Users.GetListFromSQL("CALL SP_VIS_BUSINNES_UNIT() ");
                foreach (var item in listObject)
                {
                    oComboBox.ValidValues.Add(item.Key, item.Value);
                }

                oComboBox.Item.DisplayDesc = true;
            }

        }


        /// <summary>
        /// Carga un combobox con los valores validos
        /// </summary>
        /// <param name="oComboBox"></param>
        /// <param name="tableID"></param> 
        public static void LoadTipoPago(ref SAPbouiCOM.ComboBox oComboBox)
        {
            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                listObject = Forxap.Framework.DI.ValidValues.GetValidValues("@VIST_DEPOSITO1", "VIS_IncomeType");
                foreach (var item in listObject)
                {
                    oComboBox.ValidValues.Add(item.Key, item.Value);
                }

                oComboBox.Item.DisplayDesc = true;
            }

        }


        /// <summary>
        /// Carga un combobox con los valores validos
        /// </summary>
        /// <param name="oComboBox"></param>
        /// <param name="tableID"></param> 
        public static void LoadEstado(ref SAPbouiCOM.ComboBox oComboBox)
        {
            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                listObject = Forxap.Framework.DI.ValidValues.GetValidValues("@VIST_DEPOSITO1", "VIS_Status");
                foreach (var item in listObject)
                {
                    oComboBox.ValidValues.Add(item.Key, item.Value);
                }

                oComboBox.Item.DisplayDesc = true;
            }

        }
    



        

        


        /// <summary>
        /// Carga un combobox con los usuarios
        /// </summary>
        /// <param name="oComboBox"></param>
        public static void LoadUsers(ref  SAPbouiCOM.ComboBox oComboBox)
        {
            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                listObject = Forxap.Framework.DI.Sb1Users.GetListUser();
                foreach (var item in listObject)
                {
                    oComboBox.ValidValues.Add(item.Key,item.Value);
                }

                oComboBox.Item.DisplayDesc = true;
            }

        }

        /// <summary>
        /// Carga un combobox dentro de una grilla con los usuarios
        /// </summary>
        /// <param name="oComboBox"></param>
        public static void LoadUsers(ref  SAPbouiCOM.Column oColumn)
        {
            Dictionary<string, string> listObject;

            if (oColumn != null)
            {
                listObject = Forxap.Framework.DI.Sb1Users.GetListUser();

               
                foreach (var item in listObject)
                {
                    oColumn.ValidValues.Add(item.Key, item.Value);
                }

            }

        }

 

    }// fin de la clase

}// fin del namespace
