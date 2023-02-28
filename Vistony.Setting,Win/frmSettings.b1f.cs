using System;
using System.Collections.Generic;
using System.Xml;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;


namespace Vistony.Setting_Win
{
    [FormAttribute("Vistony.Setting_Win.Form1", "frmSettings.b1f")]
    class Form1 : UserFormBase
    {
        public static SAPbouiCOM.Form oForm { get; set; }

        public Form1()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_3").Specific));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_4").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("5").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.Button Button0;

        private void OnCustomInitialize()
        {
            Folder0.Select();
            // oForm = SAPbouiCOM.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);

            // inicializo la tabla de parametrizaciones
            // ahora debo posicionar la  pantalla con el UDO con el code "CONFIG"

            oForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
            // ahora busco el Code = CONFIG
            oForm.SetEditText("5", "CONFIG");
            // ahora le doy click al boton  Buscar 
            oForm.Items.Item("1").Click();

        }

        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.EditText EditText0;
    }
}