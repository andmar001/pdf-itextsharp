using pdf_generator.Models;
using pdf_generator.Util;

namespace PDF_generator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Propiedades propiedades = new Propiedades();
            // Instancias             
            Utilidades u = new Utilidades();
            funciones f = new funciones();
            
            // f.GenerarPDF(); 
            // f.GenerarPDF_basic();
            // f.GenerarPDFinMemory();
            // f.GenerarPDFsizePageIdeal();  // MArgenes similares al boleto
            // f.GenerarPDFTextos();
            f.GenerarPDFFuentes();

        }
    }
}
