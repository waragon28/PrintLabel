using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.PrintLabel.BO
{
    public class LineaData
    {
        public string SSCC { get; set; }
        public string Name { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public int? numero { get; set; }
        public int? Cantidad { get; set; }
        public string lote { get; set; }
        public string fecha { get; set; }
        public string unidadMedida { get; set; }

        public string ipAddress { get; set; }

        public int portNumber { get; set; }
        public string Flag { get; set; } = "Zebra_SSCC";

    }

}
