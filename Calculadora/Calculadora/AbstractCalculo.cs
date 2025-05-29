using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public abstract class AbstractCalculo
    {
        public abstract double valorVisor { set; get; }
        public abstract double valorAnterior { get; set; }
        public abstract double valorResultado { get; set; }
        public abstract string operacao { get; set; }

        public abstract double Calculo();
    }
}
