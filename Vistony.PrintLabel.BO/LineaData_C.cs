using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.PrintLabel.BO
{
    public class LineaData_C
    {
        public string ipAddress { get; set; }
        public int portNumber { get; set; }
        public string flag { get; set; } = "Zebra_SSCC";
        public List<LineaData_D> lineaData { get; set; }
    }
}
