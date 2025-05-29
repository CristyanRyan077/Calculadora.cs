using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class ObjetoCalculo : AbstractCalculo
    {
        public override double valorVisor { get; set; }
        public override double valorAnterior { get; set; }
        public override double valorResultado { get; set; }
        public override string operacao { get; set; }

        public override double Calculo()
        {
            switch (operacao)
            {
                case "+":
                    valorResultado = valorAnterior + valorVisor;
                    break;
                case "-":
                    valorResultado = valorAnterior - valorVisor;
                    break;
                case "x":
                    valorResultado = valorAnterior * valorVisor;
                    break;
                case "/":
                    valorResultado = valorAnterior / valorVisor;
                    break;
                case "√":
                    /* formula raiz quadrada
                      double valorRaiz = valorVisor;
                    for (int i = 0; i < 10; i++)
                    {
                        valorRaiz = (valorRaiz / 2) + valorVisor / (2 * valorRaiz);
                    }
                    valorResultado = valorRaiz; */
                    valorResultado = Math.Sqrt(valorVisor);
                    break;

                default:
                    break;
            }
            return valorResultado;
        }
    }
}
