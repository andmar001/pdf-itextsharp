using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using pdf_generator.Models;

namespace PDF_generator
{
    public class funciones
    {
        public funciones()
        {            
        }
        public void GenerarPDF()
        {
            Propiedades propiedades = new Propiedades();
            Document document = new Document( PageSize.LETTER, 20, 20, 20, 20 ); 

            // Create a writer that listens to the document
            // and directs a XML-stream to a file
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(propiedades.Nombre , FileMode.Create));

            // Open the document to enable you to write to the document
            document.Open();

            // Add a simple and wellknown phrase to the document in a flow layout manner
            document.Add(new Paragraph(propiedades.Lorem));
            document.AddTitle("test");
            // Close the document
            document.Close();

        }

        public void GenerarPDF_basic()
        {
            Propiedades propiedades = new Propiedades();

            Document document = new Document( PageSize.LETTER);
            FileStream file = new FileStream(propiedades.Nombre, FileMode.Create, FileAccess.Write, FileShare.None);

            PdfWriter writer = PdfWriter.GetInstance(document, file);

            document.AddAuthor("Antonio");
            document.AddCreator("Antonio");
            document.AddTitle("test");

            document.Open();
            document.Add(new Paragraph(propiedades.Lorem));

            // writer.Close();
            document.Close();
            file.Close();

        }
        
        public void GenerarPDFinMemory()
        {
            Propiedades propiedades = new Propiedades();

            Document document = new Document( PageSize.LETTER);
            MemoryStream ms = new MemoryStream();

            PdfWriter writer = PdfWriter.GetInstance(document, ms);

            document.AddAuthor("Antonio");
            document.AddTitle("test");

            document.Open();
            document.Add(new Paragraph(propiedades.Lorem));

            document.Close();

            // ms.Seek(0, SeekOrigin.Begin);  //ubicar el puntero al inicio del stream, mostrar en ram
        }

        public void GenerarPDFsizePageIdeal()
        {
            Propiedades propiedades = new Propiedades();
           
            Document document = new Document(PageSize.LETTER); 
            document.SetPageSize(PageSize.A4); //rotar la pagina
            // document.SetMargins(100, 100, 200, 200); //configurar los margenes, se miden en puntos
            document.SetMargins(85f, 85f,200f, 200f);
            
            // 21.59 cm = 8.5 in = 612 pt
            // 27.94 cm = 11 in = 792 pt
            // 792/4 = 198
            // 27.94/2 = 13.97

            FileStream file = new FileStream(propiedades.Nombre, FileMode.Create, FileAccess.Write, FileShare.None);

            PdfWriter writer = PdfWriter.GetInstance(document, file);

            document.AddAuthor("Antonio");
            document.AddCreator("Antonio");
            document.AddTitle("test");

            document.Open();
            document.Add(new Paragraph(propiedades.Lorem));

            // writer.Close();
            document.Close();
            file.Close();
        }

        public void GenerarPDFTextos()
        {
            Propiedades propiedades = new Propiedades();    

            Document document = new Document(PageSize.LETTER);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(90f, 90f,90f, 90f);

            FileStream file = new FileStream(propiedades.Nombre, FileMode.Create, FileAccess.Write, FileShare.None);

            PdfWriter writer = PdfWriter.GetInstance(document, file);

            document.Open();

            document.Add(new Phrase("Reporte de Venta"));
            document.Add(new Paragraph(propiedades.Lorem));
            document.Add(new Paragraph("Este es un \nsaldo de linea"));    
            document.Add(new Paragraph("Esta es una \t\t tabulación"));
            document.Add(new Paragraph("Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500"){Alignment = Element.ALIGN_JUSTIFIED});

            //salto de linea - dos formas de hacerlo
            document.Add(new Paragraph(" "));
            document.Add(Chunk.NEWLINE);
            //Generacion de nuevo parrafo
            var parrafo_nuevo = new Paragraph("Lorem dos de prueba Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500");
            //convert to upper case
            parrafo_nuevo.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK);    
            parrafo_nuevo.Alignment = Element.ALIGN_RIGHT;
            document.Add(parrafo_nuevo); // always add to document, because it is a block element

            document.Close();
            file.Close();             
        }

        public void GenerarPDFFuentes()
        {
            Propiedades propiedades = new Propiedades();    

            Document document = new Document(PageSize.LETTER);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(90f, 90f,90f, 90f);

            FileStream file = new FileStream(propiedades.Nombre, FileMode.Create, FileAccess.Write, FileShare.None);

            PdfWriter writer = PdfWriter.GetInstance(document, file);

            document.Open();

            //Fuentes,, estas fuentes se reciben como segunda parametros en el objeto que se 
            BaseFont bf = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fuente_titulo = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD, BaseColor.GREEN);
            iTextSharp.text.Font base_parrafo = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD, new BaseColor(255,0,75)); //
            


            document.Add(new Phrase("Reporte de Venta", fuente_titulo));
            document.Add(new Paragraph(propiedades.Lorem));
            document.Add(new Paragraph("Este es un \nsalto de linea"));    
            document.Add(new Paragraph("Esta es una \t\t tabulación"));
            document.Add(new Paragraph("Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500"){Alignment = Element.ALIGN_JUSTIFIED});

            //salto de linea - dos formas de hacerlo
            document.Add(new Paragraph(" "));
            document.Add(Chunk.NEWLINE);
            //Generacion de nuevo parrafo
            var parrafo_nuevo = new Paragraph("Lorem dos de prueba Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500", base_parrafo);

            parrafo_nuevo.Alignment = Element.ALIGN_RIGHT;
            document.Add(parrafo_nuevo); // always add to document, because it is a block element

            document.Close();
            file.Close();             
        }

        public void GenerarPDFImagenes()
        {
            Propiedades propiedades = new Propiedades();    

            Document document = new Document(PageSize.LETTER);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(90f, 90f,90f, 90f);

            FileStream file = new FileStream(propiedades.Nombre, FileMode.Create, FileAccess.Write, FileShare.None);

            PdfWriter writer = PdfWriter.GetInstance(document, file);

            document.Open();

            //Fuentes,, estas fuentes se reciben como segunda parametros en el objeto que se 
            BaseFont bf = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fuente_titulo = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD, BaseColor.GREEN);
            iTextSharp.text.Font base_parrafo = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD, new BaseColor(255,0,75)); //


            document.Add(new Phrase("Reporte de Venta", fuente_titulo));
            document.Add(new Paragraph(propiedades.Lorem));
            document.Add(new Paragraph("Este es un \nsaldo de linea"));    
            document.Add(new Paragraph("Esta es una \t\t tabulación"));
            document.Add(new Paragraph("Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500"){Alignment = Element.ALIGN_JUSTIFIED});

            //salto de linea - dos formas de hacerlo
            document.Add(new Paragraph(" "));
            document.Add(Chunk.NEWLINE);
            string path = "C:\\Users\\DGTITAANDRADLAP\\Desktop\\logo.png";



            document.Close();
            file.Close();  
        }

    }
}