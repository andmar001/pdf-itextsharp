using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//url https://www.dynamicpdf.com/examples/add-image-to-pdf-.net-core
namespace pdf_generator.Util
{
    public class Utilidades
    {
        public Utilidades( )
        {
            
        }
        public string GetGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        public int Conversion(int cantidadCM, string operacion)
        {
            float pulgada = 2.54f;          //in cm
            float puntos = 0.352777778f;    //in cm
            
            switch (operacion)
            {
                case "cm2pulgadas":
                    var res = (cantidadCM / pulgada);
                    return (int)res;
                case "cm2puntos":
                    return (int)(cantidadCM / puntos);
                default:
                    return 0;
            }
        }
    }
}