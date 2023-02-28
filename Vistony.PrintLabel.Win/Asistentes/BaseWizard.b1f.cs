using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;

namespace Vistony.PrintLabel.UI.Win.Asistentes
{
    [FormAttribute("Forxap.Demo.UI.Win.Asistentes.BaseWizard", "Asistentes/BaseWizard.b1f")]
    class BaseWizard :  UserFormBase
    {

        public SAPbouiCOM.Form oForm;
        public SAPbouiCOM.Grid oGrid;
        public int panelevel = 1;
        public int paneMax = 3;
        public SAPbouiCOM.StaticText lblTitle;
        public SAPbouiCOM.StaticText lblPageNumber;
        public SAPbouiCOM.Button btnPrior;
        public SAPbouiCOM.Button btnNext;
        public SAPbouiCOM.Button btnCancel;
   
        /// <summary>
        /// 
        /// </summary>
        public int PaneLevel
        {
            get { return oForm.PaneLevel; }
            set { oForm.PaneLevel = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int PaneMax
        {
            get { return paneMax; }
            set { paneMax = value; }
        }
        

        public BaseWizard()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }


        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            throw new System.NotImplementedException();

        }

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.Freeze(true);

            oForm.ScreenCenter(); // centro la pantalla
            oForm.State = SAPbouiCOM.BoFormStateEnum.fs_Maximized;
        }
    }
}
