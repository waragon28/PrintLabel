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
            public string ItemName { get; set; }
            public int? Cantidad { get; set; }
            public string lote { get; set; }
            public string fecha { get; set; }
            public string codArticulo { get; set; }


            public string ipAddress { get; set; }
            public int portNumber { get; set; }
    }

}
