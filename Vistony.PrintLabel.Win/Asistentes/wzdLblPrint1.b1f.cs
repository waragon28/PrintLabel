using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;

using SAPbobsCOM;
using Forxap.Framework.UI;
using Vistony.PrintLabel.UI.Constans;
using Vistony.PrintLabel.DAL;
using Vistony.PrintLabel.BO;
using Vistony.PrintLabel.UI.Win;

using SAPbouiCOM;
using RestSharp;
using Newtonsoft.Json;

using System.Configuration;
using System.Threading;

namespace Vistony.PrintLabel.Win.Asistentes
{
    [FormAttribute("LabelPrint1", "Asistentes/wzdLblPrint1.b1f")]
    class wzdLblPrint1 : UserFormBase
    {

        private StaticText StaticText3;
        private StaticText StaticText4;
        private StaticText StaticText5;
        private EditText EditText4;
        private StaticText StaticText6;
        private StaticText StaticText7;
        private EditText EditText6;
        private EditText EditText7;
        private StaticText StaticText8;
        private EditText EditText8;
        private Button Button2;
        private OptionBtn OptionBtn0;
        private OptionBtn OptionBtn1;
        private StaticText StaticText11;
        private StaticText StaticText12;
        private StaticText StaticText13;
        private StaticText StaticText14;
        private ComboBox ComboBox0;
        private Grid Grid0;
        private CheckBox CheckBox2;
        private CheckBox CheckBox3;
        private CheckBox CheckBox4;
        private EditText EditText3;
        private EditText EditText5;
        private StaticText StaticText15;
        private StaticText StaticText16;
        private StaticText StaticText17;
        private Button Button6;
        private CheckBox CheckBox0;
        private StaticText StaticText22;
        private Button Button4;

        private Button Button0;
        private Button Button1;
        private StaticText StaticText1;
        private StaticText StaticText2;
        private StaticText StaticText9;
        private StaticText StaticText10;
        SAPbouiCOM.DataTable oDatatable;
        private EditText EditText1;
        private EditText EditText2;
        private StaticText StaticText18;
        private StaticText StaticText19;
        public SAPbouiCOM.Form oForm;
        private ComboBox ComboBox3;
        private StaticText StaticText21;
        public int PaneLevel { get; set; }
        // public int PaneMax { get; set; }
        public int PaneMax = 5;
        public string usuario = Sb1Globals.UserName;


        /*************************************************/
        private EditText EditTextItemCode, EditTextItemName;
        private EditText EditTextDateFab, EditTextLoteName;
        private SAPbobsCOM.Recordset recordset = null;
        /*************************************************/

        public wzdLblPrint1()
        {
        }


        private void EjecucionSegundoPlano()
        {

            // Display the name of the
            // current working thread
            Console.WriteLine("In progress thread is: {0}", Thread.CurrentThread.Name);


            WorkOrder workOrder = new WorkOrder();

            /*PROCESO SEGUNDO PLANO*/
            //throw new System.NotImplementedException();
            Printer printer = null;

            if (ComboBox1.Value.Length == 0)
            {
                Sb1Messages.ShowError("LabelPrint:: Es necesario selecionar una impresora.");
                return;
            }

            //  02: obtengo los datos de la impresora donde desean imprimir
            printer = Utils.LoadPrinter(ComboBox1.GetSelectedValue());




            if (EditText9.Value.Length > 0)
            {
                if (1 == 1/*EditText4.Value.Length > 0*/)
                {
                    try
                    {
                        decimal number = Convert.ToDecimal(EditText11.Value);
                        recordset = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        if (number > 0)
                        {
                            LineData lineData = new LineData();

                            //string url = string.Format("/b1s/v1/Items('{0}')?$select= ItemCode, ItemName, Properties8", EditText0.Value);
                            

                            lineData.ItemCode = EditText0.Value;
                            lineData.ItemName = EditText9.Value;
                            lineData.numero = Convert.ToInt32(number);
                            lineData.lote = EditText12.Value;
                            lineData.fecha = EditText13.Value;
                            lineData.unidadMedida = EditText10.Value;
                            lineData.ipAddress = printer.IPAdress;
                            lineData.portNumber = printer.PortNumber;

                            string endPointService = ConfigurationManager.AppSettings["Zebra.Api"].ToString();

                            RestClient client = new RestClient(endPointService);
                            RestRequest request = new RestRequest(Method.POST);
                            string JsonObtenerCabezera = JsonConvert.SerializeObject(lineData);
                            string dataReq = JsonObtenerCabezera;
                            IRestResponse result = client.Execute(request.AddJsonBody(dataReq));

                            if (result.StatusDescription == "OK")
                            {
                                Sb1Messages.ShowMessage("LabelPrint:: Comandos enviados a la impresora exitosamente.");
                            }
                            else
                            {
                                Sb1Messages.ShowError("LabelPrint:: Ocurrio un error al imprimir.");
                            }
                        }
                        else
                        {
                            Sb1Messages.ShowError("LabelPrint:: La cantidad de rotulos a imprimir debe ser mayor a '0'.");
                        }

                    }
                    catch
                    {
                        Sb1Messages.ShowError("LabelPrint:: Ocurrio un error de conversión en la cantidad.");
                    }



                }
                else
                {
                    Sb1Messages.ShowError("LabelPrint:: Es necesario ingresar el número de rotulos a imprimir.");
                }

            }
            else
            {
                Sb1Messages.ShowError("LabelPrint:: Es necesario selecionar un artículo.");
            }




            Console.WriteLine("Completed thread is: {0}", Thread.CurrentThread.Name);
        }
        /*FLAG DE MIGRACION PRODUCTO*/
        /*
          public bool ValidarIMEI(string IMEI, Recordset recordset, EditText ID_Empleado, EditText Nombre_OHEM)
        {
            bool Rspt = false;
           // recordset = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string StrHANA = string.Format("CALL P_VIST_VALIDAR_IMEI('{0}')", IMEI);
            recordset.DoQuery(StrHANA);
            string EmpID = recordset.Fields.Item("empID").Value.ToString();
            if (EmpID != "0")
            {
                Rspt= true;
                ID_Empleado.Value = recordset.Fields.Item("empID").Value.ToString();
                Nombre_OHEM.Value = recordset.Fields.Item("lastName").Value.ToString() + " " +
                                    recordset.Fields.Item("firstName").Value.ToString() + " " +
                                   recordset.Fields.Item("middleName").Value.ToString();
            }
            else
            {
               
            }
            return Rspt;
        }
             */
        /*FIN FALG DE MIGRACION*/

        public void SegundoPlano()
        {
            // Creating and initializing thread
            Thread mythr = new Thread(EjecucionSegundoPlano);

            // Name of the thread is Geek thread
            mythr.Name = "Geek thread";
            mythr.Start();

            // IsBackground is the property
            // of Thread which allows thread
            // to run in the background
            mythr.IsBackground = true;

            Console.WriteLine("Main Thread Ends!!");

            ///////////////////////////////
        }


        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.StaticText0.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText0_ClickAfter);
            this.StaticText20 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_21").Specific));
            this.StaticText20.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText20_ClickAfter);
            this.StaticText23 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_26").Specific));
            this.StaticText23.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText23_ClickAfter);
            this.StaticText24 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_27").Specific));
            this.StaticText24.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText24_ClickAfter);
            this.Button7 = ((SAPbouiCOM.Button)(this.GetItem("Item_4").Specific));
            this.Button7.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button7_ClickAfter);
            this.Button8 = ((SAPbouiCOM.Button)(this.GetItem("Item_20").Specific));
            this.Button8.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button8_ClickAfter);
            this.StaticText25 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_23").Specific));
            this.StaticText25.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText25_ClickAfter);
            this.OptionBtn2 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_8").Specific));
            this.OptionBtn2.ClickAfter += new SAPbouiCOM._IOptionBtnEvents_ClickAfterEventHandler(this.OptionBtn2_ClickAfter);
            this.OptionBtn3 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_12").Specific));
            this.OptionBtn3.ClickAfter += new SAPbouiCOM._IOptionBtnEvents_ClickAfterEventHandler(this.OptionBtn3_ClickAfter);
            this.StaticText26 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.StaticText26.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText26_ClickAfter);
            this.StaticText27 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.StaticText27.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText27_ClickAfter);
            this.StaticText28 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.StaticText28.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText28_ClickAfter);
            this.StaticText29 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.StaticText29.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText29_ClickAfter);
            this.StaticText30 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.StaticText30.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText30_ClickAfter);
            this.StaticText31 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.StaticText31.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText31_ClickAfter);
            this.StaticText32 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.StaticText32.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText32_ClickAfter);
            this.StaticText33 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_28").Specific));
            this.StaticText33.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText33_ClickAfter);
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_2").Specific));
            this.EditText0.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText0_ChooseFromListAfter);
            this.EditText0.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText0_ClickAfter);
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("Item_0").Specific));
            this.EditText9.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText9_ClickAfter);
            this.EditText10 = ((SAPbouiCOM.EditText)(this.GetItem("Item_22").Specific));
            this.EditText10.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText10_ClickAfter);
            this.EditText11 = ((SAPbouiCOM.EditText)(this.GetItem("Item_11").Specific));
            this.EditText11.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText11_ClickAfter);
            this.EditText12 = ((SAPbouiCOM.EditText)(this.GetItem("Item_16").Specific));
            this.EditText12.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText12_ClickAfter);
            this.Button9 = ((SAPbouiCOM.Button)(this.GetItem("Item_7").Specific));
            this.Button9.ChooseFromListAfter += new SAPbouiCOM._IButtonEvents_ChooseFromListAfterEventHandler(this.Button9_ChooseFromListAfter);
            this.Button9.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button9_ClickAfter);
            this.EditText13 = ((SAPbouiCOM.EditText)(this.GetItem("Item_15").Specific));
            this.EditText13.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText13_ClickAfter);
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_29").Specific));
            this.ComboBox1.ClickAfter += new SAPbouiCOM._IComboBoxEvents_ClickAfterEventHandler(this.ComboBox1_ClickAfter);
            this.Button10 = ((SAPbouiCOM.Button)(this.GetItem("Item_18").Specific));
            this.Button10.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button10_ClickAfter);
            this.OnCustomInitialize();

        }

        private void PriorPane()
        {
            Button0.Item.Enabled = true;
            //si estan en uno de los paneles de impresion cuando retroceda el boton debe decir Siguiente >
            if (oForm.PaneLevel == 3 || oForm.PaneLevel == 4 || oForm.PaneLevel == 5)
            {
                oForm.PaneLevel = 2;
                Button0.Item.Enabled = true;
                Button0.Caption = "Siguiente >";
            }



            else if (oForm.PaneLevel == 2)
            {
                oForm.PaneLevel -= 1;
                Button7.Item.Enabled = false;
            }


        }
        private void NextPane()
        {
            Button7.Caption = AddonLayoutForms.Label000;

            if (oForm.PaneLevel == 2)
            {


                // aqui debo verificar que tipo de impresión desean hacer
                // Logistica, Producción, Ubicaciones

                if (OptionBtn2.Selected)
                {
                    // te lleva al pane de impresión logistica
                    oForm.PaneLevel = 3;
                }

                else if (OptionBtn3.Selected)
                {
                    // te lleva al pane de impresión producción
                    oForm.PaneLevel = 4;
                }


                ///seteo el caption a finalizar
                Button7.Caption = AddonLayoutForms.Label001;

                //if (oForm.PaneLevel == 3)
                //{
                //    Button1.Item.Enabled = true;
                //    Button0.Item.Enabled = true;
                //    oForm.PaneLevel += 1;
                //}

                goto salgo;
            }
            if (PaneLevel < PaneMax)
            {
                oForm.PaneLevel += 1;
            }
            if (oForm.PaneLevel == 1)
            {
                oForm.PaneLevel = 1;
            }

        salgo:;

            // si entran al pane 2 debo activar el radio button por defecto
            if (oForm.PaneLevel == 2)
            {
                // verifico si ningundo uno de los radiobutron esta selecciona
                // entonces selecciono 1 por defecto
                if (OptionBtn2.Selected != true && OptionBtn3.Selected != true)
                    OptionBtn2.Selected = true;
            }

            //cuando llegan al útlimo pane desactivo el boton siguiente
            if (oForm.PaneLevel == 5)
            {
                Button7.Item.Enabled = true;

                //                oForm.PaneLevel = 2;
            }

            // si llegan al pane 1 desactivo el boton atras
            if (oForm.PaneLevel == 1)
            {
                Button7.Item.Enabled = false;
            }
            else
            {
                Button7.Item.Enabled = true;
            }


        }

        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);
        }

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {

        }

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            
           /* try
            {
                string strHANA = "";
                strHANA = string.Format("SELECT \"U_VIS_DESC_GAST\" as \"Tipo Gasto\",00000.00 as \"Monto Gasto\", '                  ' \"N° Comprobante\"  FROM \"@VIS_TIP_GAST\" T0 WHERE \"U_VIS_STATUS\"='Y'");
                oDatatable = oForm.DataSources.DataTables.Item("DT_0");
                oDatatable.ExecuteQuery(strHANA);
                Grid0.AutoResizeColumns();
                for (int i = 0; i <= 0; i++)
                {
                    Grid0.Columns.Item(i).Editable = false;
                }

            }
            catch (Exception EX)
            {
                Sb1Messages.ShowError(string.Format(EX.ToString()));
            }*/

            oForm.ScreenCenter();
            StaticText0.SetBold();
            StaticText0.SetSize(15);
            StaticText0.Item.Height =20;
            StaticText0.Item.Width =1000;
            StaticText0.SetSize(11);
            //StaticText13.SetBold();
            //StaticText13.SetSize(15);
            //StaticText13.Item.Height = 20;

            //StaticText14.SetSize(11);
            //StaticText15.SetSize(11);
           // StaticText0.SetBold(); // titulo del panel de logistica
            StaticText0.SetBold(); // titulo del panel de produccion
            StaticText25.SetBold(); // titulo del panel de ubicaciones

            OptionBtn2.GroupWith("Item_12");

            Utils.LoadPrinters(ref ComboBox1);

            //Grid1.AutoResizeColumns();

            StaticText25.SetBold();
        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

        }
        
        
        private void ComboBox0_ComboSelectAfter(object sboObject, SBOItemEventArg pVal)
        {

        }

        private void Button4_ClickBefore(object sboObject, SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
        }

        private void EditText5_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {
            recordset = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {
                
                if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                {
                    //EditTextLote.Value = chooseFromListEvent.SelectedObjects.GetValue("AbsEntry", 0).ToString();
                    EditTextLoteName.Value = chooseFromListEvent.SelectedObjects.GetValue("DistNumber", 0).ToString();
                    
                    string fechaFabricacion = chooseFromListEvent.SelectedObjects.GetValue("MnfDate", 0).ToString();

                    DateTime dateTime = DateTime.Parse(fechaFabricacion);

                    EditTextDateFab.Value = dateTime.ToString("MM/yyyy");

                }
            }
            catch (Exception e)
            {

            }
                

        }

        private void StaticText0_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private void Button2_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {


        }

        private void StaticText20_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private StaticText StaticText0;

        private void StaticText23_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private StaticText StaticText20;

        private void StaticText24_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private StaticText StaticText23;

        private void Button3_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private StaticText StaticText24;

        private void Button7_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            if (Button7.Item.Enabled == true)
            {
                NextPane();
            }
        }

        private Button Button3;

        private void Button8_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            PriorPane();
        }

        private Button Button7;

        private void StaticText25_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private Button Button8;

        private void OptionBtn2_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private StaticText StaticText25;

        private void OptionBtn3_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private OptionBtn OptionBtn2;

        private void StaticText26_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private OptionBtn OptionBtn3;

        private void StaticText27_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private StaticText StaticText26;

        private void StaticText28_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private StaticText StaticText27;

        private void StaticText29_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private StaticText StaticText28;

        private void StaticText30_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private StaticText StaticText29;

        private void StaticText31_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private StaticText StaticText30;

        private void StaticText32_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private StaticText StaticText31;

        private void StaticText33_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private StaticText StaticText32;

        private void EditText0_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private StaticText StaticText33;

        private void EditText9_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private EditText EditText0;

        private void EditText10_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private EditText EditText9;

        private void EditText11_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private EditText EditText10;

        private void EditText12_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private EditText EditText11;

        private void Button9_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private EditText EditText12;

        private void EditText13_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private Button Button9;

        private void ComboBox1_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private EditText EditText13;

        private void Button10_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            SegundoPlano();
        }

        private void EditText0_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            recordset = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {
                if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                {
                    EditText0.Value = chooseFromListEvent.SelectedObjects.GetValue("ItemCode", 0).ToString();
                    EditText9.Value = chooseFromListEvent.SelectedObjects.GetValue("ItemName", 0).ToString();
                    EditText10.Value = chooseFromListEvent.SelectedObjects.GetValue("BuyUnitMsr", 0).ToString();
                    
                }
            }
            catch (Exception e)
            {

            }
        }

        private void Button9_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {
            // throw new System.NotImplementedException();
            recordset = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {

                if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                {
                    //EditTextLote.Value = chooseFromListEvent.SelectedObjects.GetValue("AbsEntry", 0).ToString();
                    EditText12.Value = chooseFromListEvent.SelectedObjects.GetValue("DistNumber", 0).ToString();

                    string fechaFabricacion = chooseFromListEvent.SelectedObjects.GetValue("MnfDate", 0).ToString();

                    DateTime dateTime = DateTime.Parse(fechaFabricacion);

                    EditText13.Value = dateTime.ToString("MM/yyyy");

                }
            }
            catch (Exception e)
            {

            }
        }

        private ComboBox ComboBox1;
        private Button Button10;
    }
}