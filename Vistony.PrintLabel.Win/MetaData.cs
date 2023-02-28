using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vistony.PrintLabel.UI.Constans;
using Forxap.Framework.UI;
using Forxap.Framework.Utils;


namespace Vistony.PrintLabel.UI.Win
{
   public  class Sb1MetaData
    {

       /// <summary>
       /// 
       /// </summary>
       public static void AddMenus()
       {
           try
           {
               Sb1Messages.ShowSuccess(string.Format(AddonMessageInfo.Message001), SAPbouiCOM.BoMessageTime.bmt_Short);
               Sb1XmlFile.LoadAddonMenu(AddonUserFiles.UserMenus);
           }
           catch (Exception ex)
           {
               Sb1Messages.ShowError(AddonMessageInfo.Message003, SAPbouiCOM.BoMessageTime.bmt_Medium);
           }
       }


    }// fin de la clase


}//fin del namespace


