using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

using Forxap.Framework.Extensions;
using Vistony.PrintLabel.UI.Constans;

using Vistony.PrintLabel.Win;

using Vistony.PrintLabel.BO;
using Vistony.PrintLabel.BLL;
using Vistony.PrintLabel.Win;
using Forxap.Framework.UI;

using SAPbouiCOM;
using RestSharp;
using Newtonsoft.Json;

using System.Configuration;
using Vistony.PrintLabel.UI.Win;
using System.Threading;

namespace Vistony.PrintLabel.Win.Asistentes
{
    [FormAttribute("LabelPrint2", "Asistentes/wzdLblPrint2.b1f")]
    class wzdLblPrint2 : UserFormBase
    {
        public SAPbouiCOM.Form oForm;
        private int PaneMax = 5;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        string ModSelect = "";
        public int PaneLevel { get; set; }
        public wzdLblPrint2()
        {
        }
        private void EjecucionSegundoPlano()
        {

            // Display the name of the
            // current working thread
            Console.WriteLine("In progress thread is: {0}", Thread.CurrentThread.Name);


            WorkOrder workOrder = new WorkOrder();


            try
            {
                PrintWOSelecteds();
            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(AddonMessageInfo.AddonName + ex.Message.ToString());
            }

            Console.WriteLine("Completed thread is: {0}", Thread.CurrentThread.Name);
        }
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

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_0").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_1").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.OptionBtn0 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_4").Specific));
            this.OptionBtn0.ClickAfter += new SAPbouiCOM._IOptionBtnEvents_ClickAfterEventHandler(this.OptionBtn0_ClickAfter);
            this.OptionBtn1 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_5").Specific));
            this.OptionBtn1.ClickAfter += new SAPbouiCOM._IOptionBtnEvents_ClickAfterEventHandler(this.OptionBtn1_ClickAfter);
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_6").Specific));
            this.Grid0.LinkPressedBefore += new SAPbouiCOM._IGridEvents_LinkPressedBeforeEventHandler(this.Grid0_LinkPressedBefore);
            this.Grid0.LinkPressedAfter += new SAPbouiCOM._IGridEvents_LinkPressedAfterEventHandler(this.Grid0_LinkPressedAfter);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_7").Specific));
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_9").Specific));
            this.CheckBox0 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_10").Specific));
            this.CheckBox1 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_11").Specific));
            this.CheckBox2 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_12").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.CheckBox3 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_14").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_18").Specific));
            this.Button3.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button3_ClickAfter);
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_20").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_21").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_22").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_24").Specific));
            this.LinkedButton1 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_77").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_23").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_25").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);

            StaticText0.SetBold();
            StaticText4.SetBold();
            OptionBtn1.GroupWith("Item_4");
            EditText3.Value = "2";
            oForm.ScreenCenter();
            EditText0.SetNow();
            EditText1.SetNow();
            ModSelect = "OF";
            Utils.LoadPrinters(ref ComboBox0);
            StaticText0.SetSize(15);
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
                Button1.Item.Enabled = false;
            }


        }

        private void NextPane()
        {
            Button0.Caption = AddonLayoutForms.Label000;

            if (oForm.PaneLevel == 2)
            {


                // aqui debo verificar que tipo de impresión desean hacer
                // Logistica, Producción, Ubicaciones

                if (OptionBtn0.Selected)
                {
                    // te lleva al panel de ordenes de producción
                    oForm.PaneLevel = 3;
                    StaticText4.Caption = "Imprima etiquetas según las ordenes de fabricación";
                }

                else if (OptionBtn1.Selected)
                {
                    // te lleva al panel de impresión de SSCC
                    oForm.PaneLevel = 3;
                    StaticText4.Caption = "Imprima etiquetas según las SSCC";

                }



                ///seteo el caption a finalizar
                Button0.Caption = AddonLayoutForms.Label001;

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
                if (OptionBtn0.Selected != true && OptionBtn1.Selected != true)
                    OptionBtn0.Selected = true;

                CheckBox3.Checked = true;

            }

            if (oForm.PaneLevel == 3)
            {

                CheckBox3.Checked = true;
            }
            //cuando llegan al útlimo pane desactivo el boton siguiente
            if (oForm.PaneLevel == 4)
            {
                Button1.Item.Enabled = true;

                //                oForm.PaneLevel = 2;
            }

            // si llegan al pane 1 desactivo el boton atras
            if (oForm.PaneLevel == 1)
            {
                Button1.Item.Enabled = false;
            }
            else
            {
                Button1.Item.Enabled = true;
            }



            // si esta con el caption finalizar cierro la ventana

            //            if (Button0.Caption == AddonLayoutForms.Label001)
            //                oForm.Close();

        }

        private SAPbouiCOM.OptionBtn OptionBtn0;
        private SAPbouiCOM.OptionBtn OptionBtn1;


        private string GetStartDate()
        {
            string ret = string.Empty;

            ret = EditText0.Value;
            return ret;
        }

        private string GetEndDate()
        {
            string ret = string.Empty;

            ret = EditText1.GetDate();

            return ret;
        }

        private string GetStatusWO()
        {
            string ret = string.Empty;

            if (CheckBox0.Checked)

                ret += "P,";

            if (CheckBox1.Checked)
                ret += "R,";

            if (CheckBox2.Checked)
                ret += "L,";

            return ret;
        }

        private string GetStatusPrint()
        {
            string ret = string.Empty;

            if (CheckBox3.Checked)
                ret = "N";


            return ret;
        }


        private void Find()
        {
            oForm.Freeze(true);
            using (WorkOrderBLL workOrderBLL = new WorkOrderBLL())
            {
                SAPbouiCOM.DataTable oDT = null;
                    oDT=oForm.GetDataTable("DT_0");
                if (OptionBtn0.Selected)
                {
                    workOrderBLL.GetWorkOrderForPrintLabel(GetStartDate(), GetEndDate(), GetStatusWO(), GetStatusPrint(), ref oDT);

                    SetFormatGrid();
                }

                else if (OptionBtn1.Selected)
                {
                    workOrderBLL.GetWorkSCCForPrintLabel(GetStartDate(), GetEndDate(), GetStatusWO(), GetStatusPrint(), ref oDT);
                    SetFormatGridsscc();
                }

                Grid0.ReadOnlyColumnsEx();

            }
            // debo desactivar las columnas de la grilla y solo dejar para que hagam el Check



            oForm.Freeze(false);
        }

        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.CheckBox CheckBox0;
        private SAPbouiCOM.CheckBox CheckBox1;
        private SAPbouiCOM.CheckBox CheckBox2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.CheckBox CheckBox3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.Button Button3;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;

        private void Button3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            Find();
        }

        private void SetFormatGrid()
        {
            Grid0.AssignLineNro();
            Grid0.Columns.Item(0).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
            Grid0.Columns.Item("DocEntry").Visible = false;
            Grid0.Columns.Item("DocEntryMezcla").Visible = false;
            Grid0.Columns.Item("DocNum").LinkedObjectType(Grid0, "DocNum", "202"); // muestro la orden de fabricacion
            Grid0.Columns.Item("Producto").LinkedObjectType(Grid0, "Producto", "4"); // muestro la ventana de productos
            Grid0.Columns.Item("NumeroMezcla").LinkedObjectType(Grid0, "NumeroMezcla", "202"); // muestro la ventana de productos
            
            Grid0.Columns.Item("Producto").TitleObject.Caption = "Código Producto";
            Grid0.Columns.Item("Producto").Editable = false;

            Grid0.Columns.Item("DocNum").TitleObject.Caption = "Número OP";
            Grid0.Columns.Item("CantidadPlanificada").TitleObject.Caption = "Cantidad planificada";
            Grid0.Columns.Item("CantidadCompletada").TitleObject.Caption = "Cantidad completada";
            Grid0.Columns.Item("Impreso").TitleObject.Caption = "Imprimir";
            Grid0.Columns.Item("FechaOF").TitleObject.Caption = "Fecha Orden Fabricación";
            Grid0.Columns.Item("UMD").TitleObject.Caption = "Unidad de medida";

            Grid0.Columns.Item("NumeroMezcla").TitleObject.Caption = "Número OP Mezcla";
            Grid0.Columns.Item(0).TitleObject.Caption = "Marcar";
            Grid0.ReadOnlyColumns();
            Grid0.Columns.Item(0).Editable = true;
            Grid0.AutoResizeColumns();


        }

        private void SetFormatGridsscc()
        {
            Grid0.AssignLineNro();
            Grid0.Columns.Item(0).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
            Grid0.Columns.Item("DocNum").LinkedObjectType(Grid0, "DocNum", "202"); // muestro la orden de fabricacion
            Grid0.Columns.Item("DocNum").TitleObject.Caption = "Nª Orden Fabricacion";
            Grid0.Columns.Item("FechaOF").TitleObject.Caption = "Fecha de OF";
            Grid0.Columns.Item("Producto").LinkedObjectType(Grid0, "Producto", "4"); // muestro la ventana de productos
            Grid0.ReadOnlyColumns();
            Grid0.Columns.Item(0).Editable = true;
            Grid0.AutoResizeColumns();


        }

        private void PrintWOSelecteds()
        {
            string isSelected = "N";
            Printer printer = null;

            //  01: sino cumple las validaciones entonces aborto
            if (!Validate())
                return;


            //  02: obtengo los datos de la impresora donde desean imprimir
            printer = Utils.LoadPrinter(ComboBox0.GetSelectedValue());


            // 03: recorrre la grilla verificando cuales fueron los seleccionados
            if (OptionBtn0.Selected)
            {
                 //   isSelected = Grid0.DataTable.GetString("Marcar", row);

                    // si el registro esta selecccionado, entonces imprimo
                    //if (isSelected == "Y")
                    PrintWO(printer);
            }

            else if (OptionBtn1.Selected)
            {
                // te lleva al panel de impresión de SSCC
                //   for (int row = 0; row < Grid0.DataTable.Rows.Count; row++)
                // {

                PrintWO2(printer);

               // }

            }



        }

        private void PrintWO2(Printer printer)
        {
            // envia los datos a la API, para que se proceda a Imprimir
            // si imprimio de manera correcta debo Actuaizar la Orden de Producción
            if (SendToAPISSCC(lineaData_C(printer)))
            {
                for (int row1 = 0; row1 < Grid0.Rows.Count; row1++)
                {
                    if (Grid0.DataTable.GetString("Marcar", row1) == "Y")
                    {
                        UpdateWO(Convert.ToInt32(Grid0.DataTable.GetString("DocEntry", row1)));
                    }
                }
            }

        }

        public LineaData_C lineaData_C(Printer printer)
        {
            LineaData_C cabecera = new LineaData_C();
            cabecera.ipAddress = printer.IPAdress;
            cabecera.portNumber = printer.PortNumber;

            cabecera.lineaData = ObtenerDetalle(printer);
            return cabecera;
        }

        public List<LineaData_D>  ObtenerDetalle(Printer printer)
        {
            List<LineaData_D> LineaData_D = new List<LineaData_D>();

            for (int row = 0; row < Grid0.Rows.Count; row++)
            {
                if (Grid0.DataTable.GetString("Marcar", row)=="Y")
                {
                    LineaData_D objLineaData_D = new LineaData_D();
                    objLineaData_D.ssccName = Grid0.DataTable.GetString("NameSSCC", row).Substring(0, 19);
                    objLineaData_D.itemCode = Grid0.DataTable.GetString("Producto", row);
                    objLineaData_D.itemName = Grid0.DataTable.GetString("Descripcion", row);
                    int CantidaImpresion = Convert.ToInt32(EditText3.Value);
                    objLineaData_D.numero = Convert.ToInt32(Grid0.DataTable.GetString("Cantidad SSCC", row));
                    objLineaData_D.lote = Grid0.DataTable.GetString("Numero Mezcla", row);
                    objLineaData_D.fecha = Convert.ToDateTime(Grid0.DataTable.GetString("FechaOF", row)).ToString("MM/yyyy");
                    objLineaData_D.unidadMedida = Grid0.DataTable.GetString("UMD", row);
                    LineaData_D.Add(objLineaData_D);
                }
               
            }
            return LineaData_D;
        }



        private void PrintWO(Printer printer)
        {
            if (SendToAPISSCC(lineaData_C_Uni(printer)))
            {
                for (int row1 = 0; row1 < Grid0.Rows.Count; row1++)
                {
                    if (Grid0.DataTable.GetString("Marcar", row1) == "Y")
                    {
                        UpdateWO(Convert.ToInt32(Grid0.DataTable.GetString("DocEntry", row1)));

                    }
                }
            }

        }


        public LineaData_C lineaData_C_Uni(Printer printer)
        {
            LineaData_C cabecera = new LineaData_C();
            cabecera.ipAddress = printer.IPAdress;
            cabecera.portNumber = printer.PortNumber;
            cabecera.flag = "Zebra_QR";

            cabecera.lineaData = ObtenerDetalle_Uni(Grid0, printer);
            return cabecera;
        }

        public List<LineaData_D> ObtenerDetalle_Uni(Grid Grid0, Printer printer)
        {
            List<LineaData_D> LineaData_D = new List<LineaData_D>();

            for (int row = 0; row < Grid0.Rows.Count; row++)
            {
                if (Grid0.DataTable.GetString("Marcar", row) == "Y")
                {
                    LineaData_D objLineaData_D = new LineaData_D();
                    objLineaData_D.ssccName = "";
                    objLineaData_D.itemCode = Grid0.DataTable.GetString("Producto", row);
                    objLineaData_D.itemName = Grid0.DataTable.GetString("Descripcion", row);
                    int CantidaImpresion = Convert.ToInt32(EditText3.Value);
                    objLineaData_D.numero = Convert.ToInt32(Grid0.DataTable.GetString("CantidadPlanificada", row));
                    objLineaData_D.lote = Grid0.DataTable.GetString("NumeroMezcla", row);
                    objLineaData_D.fecha = Convert.ToDateTime(Grid0.DataTable.GetString("FechaOF", row)).ToString("MM/yyyy");
                    objLineaData_D.unidadMedida = Grid0.DataTable.GetString("UMD", row);
                    LineaData_D.Add(objLineaData_D);
                }

            }
            return LineaData_D;
        }
        private bool Validate ()
        {
            bool ret = true;

            // verifico que seleccionen una impresora
            if (ComboBox0.Value.Length == 0)
            {
                Sb1Messages.ShowError(AddonMessageInfo.Message007);
                ret = false;
            }
            return ret;
        }

        //private bool  SendToAPI (LineData lineData)
        //{
        //    bool ret = false;
        //    string endPointService = ConfigurationManager.AppSettings["Zebra.Api"].ToString();

        //    RestClient client = new RestClient(endPointService);
        //    RestRequest request = new RestRequest(Method.POST);
        //    string JsonObtenerCabezera = JsonConvert.SerializeObject(lineData);
        //    string dataReq = JsonObtenerCabezera;
        //    IRestResponse result = client.Execute(request.AddJsonBody(dataReq));

        //    if (result.StatusDescription == "OK")
        //    {
        //        Sb1Messages.ShowMessage(AddonMessageInfo.Message009);
        //        Sb1Messages.ShowMessage(string.Format(AddonMessageInfo.Message010,lineData.lote));
        //        ret = true;

        //    }
        //    else
        //    {
        //        Sb1Messages.ShowError(AddonMessageInfo.Message008);
        //        ret = false;
        //    }

        //    return ret;
        //}

        private bool SendToAPISSCC(LineaData_C lineData)
        {
            bool ret = false;
            string endPointService = ConfigurationManager.AppSettings["Zebra.Api"].ToString();

            RestClient client = new RestClient(endPointService);
            RestRequest request = new RestRequest(Method.POST);
            string JsonObtenerCabezera = JsonConvert.SerializeObject(lineData);
            string dataReq = JsonObtenerCabezera;
            IRestResponse result = client.Execute(request.AddJsonBody(dataReq));

            if (result.StatusDescription == "OK")
            {
                Sb1Messages.ShowMessage(AddonMessageInfo.Message009);
                //Sb1Messages.ShowMessage(string.Format(AddonMessageInfo.Message010, lineData.lote));
                ret = true;

            }
            else
            {
                Sb1Messages.ShowError(AddonMessageInfo.Message008);
                ret = false;
            }

            return ret;
        }
        private string UpdateWO (int? docEntry )
        {
            string ret = string.Empty;
            WorkOrder workOrder = new WorkOrder();

            workOrder.U_VIS_PrintedLabel = "Y";

            using (WorkOrderBLL workOrderBLL = new WorkOrderBLL())
            {
              ret =   workOrderBLL.UpdateStatusPrinted(workOrder, docEntry);
            }


            return ret;
        }

        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SegundoPlano();
        }

        private EditText EditText2;
        private LinkedButton LinkedButton0;
        private LinkedButton LinkedButton1;

        private void Grid0_LinkPressedAfter(object sboObject, SBOItemEventArg pVal)
        {
            if (pVal.ColUID == "DocNum")
            {
                SAPbouiCOM.EditTextColumn col = null;
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("DocNum")));
                col.LinkedObjectType = "202";// muestra la flecha amariilla asociada al objeto pedidos  
            }

            else if (pVal.ColUID == "NumeroMezcla")
            {
                SAPbouiCOM.EditTextColumn col = null;
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("NumeroMezcla")));
                col.LinkedObjectType = "202";// muestra la flecha amariilla asociada al objeto pedidos  
            }
        }



        private void Grid0_LinkPressedBefore(object sboObject, SBOItemEventArg pVal, out bool BubbleEvent)
        {

            BubbleEvent = true;
            SAPbouiCOM.EditTextColumn col = null;

            // verifico en que columna hicieron click  en el linkedbutton
            if (pVal.ColUID == "DocNum")

            {

                //int rowSelected = Grid0.Rows.SelectedRows.Item(0, SAPbouiCOM.BoOrderType.ot_RowOrder);
                int rowSelected = pVal.Row;
                int rowIndex = rowSelected;
                string Codigo = Grid0.DataTable.GetValue("DocEntry", Grid0.GetDataTableRowIndex(rowIndex)).ToString();

                EditText2.Value = Codigo;

                EditText2.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);

                LinkedButton1.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("DocNum")));
                col.LinkedObjectType = "";// 
            }

            else if (pVal.ColUID == "NumeroMezcla")
            {
                //int rowSelected = Grid0.Rows.SelectedRows.Item(0, SAPbouiCOM.BoOrderType.ot_RowOrder);
                int rowSelected = pVal.Row;
                int rowIndex = rowSelected;
                string Codigo = Grid0.DataTable.GetValue("DocEntryMezcla", Grid0.GetDataTableRowIndex(rowIndex)).ToString();

                EditText2.Value = Codigo;

                EditText2.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);

                LinkedButton1.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("NumeroMezcla")));
                col.LinkedObjectType = "";//
            }

        }

        private StaticText StaticText8;
        private EditText EditText3;

        private void Form_LoadAfter(SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private void Button0_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            NextPane();
        }

        private void OptionBtn0_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            ModSelect = "OF";
        }

        private void OptionBtn1_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            ModSelect = "SSCC";
        }

        private void Button1_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            PriorPane();
        }
    }
    }

