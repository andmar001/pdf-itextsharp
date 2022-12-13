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

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("logo.png");
            logo.ScaleToFit(400f, 400f);
            logo.Alignment = Element.ALIGN_CENTER;
            logo.ScalePercent(50f);
            document.Add(logo);

            // write text on image
            var cb = writer.DirectContentUnder;
            var bf2 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.BeginText();
            cb.SetFontAndSize(bf2, 12);
            cb.SetRGBColorFill(0, 0, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "This is a watermark", 100, 100, 0);
            cb.EndText();

            document.Close();
            file.Close();  
        }

        public void GenerarImagenesMedidasEspeciales()
        {
             Propiedades propiedades = new Propiedades();    

            Document document = new Document(PageSize.LETTER);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(90f, 90f,90f, 90f);

            FileStream file = new FileStream(propiedades.Nombre, FileMode.Create, FileAccess.Write, FileShare.None);

            PdfWriter writer = PdfWriter.GetInstance(document, file);

            document.Open();

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("boleto.png");
            logo.ScaleToFit(396.85f,581.1024f);  //medidas en especificas. punto a cm
            logo.Alignment = Element.ALIGN_CENTER;
            logo.ScalePercent(50f);

            //write over the image
            var cb = writer.DirectContentUnder;
            var bf2 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.BeginText();
            cb.SetFontAndSize(bf2, 12);
            
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "This is a watermark", 400,100, 0);
            cb.EndText();

            document.Add(new Phrase(logo.ScaledWidth + " " + logo.ScaledHeight));
            document.Add(new Phrase(logo.ScaledWidth + " " + logo.ScaledHeight));
            document.Add(new Phrase(logo.ScaledWidth + " " + logo.ScaledHeight));
            document.Add(new Phrase(logo.ScaledWidth + " " + logo.ScaledHeight));

            document.Add(logo);
            
            document.Close();
            file.Close();  
        }

        public void GenerarPDFTablas()
        {
            Propiedades propiedades = new Propiedades();    

            Document document = new Document(PageSize.LETTER);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(90f, 90f,90f, 90f);

            FileStream file = new FileStream(propiedades.Nombre, FileMode.Create, FileAccess.Write, FileShare.None);

            PdfWriter writer = PdfWriter.GetInstance(document, file);

            document.Open();

            PdfPTable table = new PdfPTable(3);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.SpacingBefore = 10f;
            table.SpacingAfter = 10f;

            PdfPCell cell = new PdfPCell(new Phrase("Tabla de prueba"));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            table.AddCell("Celda 1");
            table.AddCell("Celda 2");
            table.AddCell("Celda 3");
            table.AddCell("Celda 4");
            table.AddCell("Celda 5");
            table.AddCell("Celda 6");

            document.Add(table);

            document.Close();
            file.Close();  
        }
        public void GenerarImagenenTabla()
        {
            Propiedades propiedades = new Propiedades();    

            Document document = new Document(PageSize.LETTER);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(90f, 90f,90f, 90f);

            FileStream file = new FileStream(propiedades.Nombre, FileMode.Create, FileAccess.Write, FileShare.None);

            PdfWriter writer = PdfWriter.GetInstance(document, file);

            document.Open();

            PdfPTable table = new PdfPTable(3);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.SpacingBefore = 10f;
            table.SpacingAfter = 10f;

            PdfPCell cell = new PdfPCell(new Phrase("Tabla de prueba"));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            table.AddCell("Celda 1");
            table.AddCell("Celda 2");
            table.AddCell("Celda 3");
            table.AddCell("Celda 4");
            table.AddCell("Celda 5");
            table.AddCell("Celda 6");

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("boleto.png");
            logo.ScaleToFit(400f, 400f);
            logo.Alignment = Element.ALIGN_CENTER;
            logo.ScalePercent(50f);

            PdfPCell cell2 = new PdfPCell(logo);
            cell2.Colspan = 3;
            cell2.HorizontalAlignment = 1;
            table.AddCell(cell2);

            document.Add(table);

            document.Close();
            file.Close();  
        } 
        public void ImageOverTable()
        {
            Propiedades prop = new Propiedades();

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("boleto.png");
            logo.ScaleToFit(396.85f, 581.1024f);
            using (var stream = new FileStream( prop.Nombre+".pdf", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var document = new Document(PageSize.A4, 0, 0, 0, 0);
                var writer = PdfWriter.GetInstance(document, stream);
                document.Open();
                var cb = writer.DirectContentUnder;
                var bf2 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, true);
                cb.BeginText();
                cb.SetFontAndSize(bf2, 12);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "This is a watermark", 400, 400, 0);
                cb.EndText();
                document.Add(logo);
                document.Close();
            }
        }

        public void OverImage()
        {
            Propiedades prop = new Propiedades();
            string texto = "This is a test";

            try
            {
                //create a pdf document
                Document documentPDF = new Document(PageSize.LETTER, 50f, 0f, 50f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(documentPDF, new FileStream(prop.Nombre + ".pdf", FileMode.Create));
                documentPDF.Open();

                //create a image and configure it
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance("boleto.png");
                image.BorderWidth = 0;
                image.Alignment = Element.ALIGN_BASELINE;
                image.ScalePercent(25);

                //add image to document
                documentPDF.Add(image);

                //add text to document
                documentPDF.Add(new Paragraph(prop.Lorem));

                //close document
                documentPDF.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void mostrarTabla()
        {
            Propiedades propiedades = new Propiedades();

            Document document = new Document(PageSize.LETTER);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(90f, 90f, 90f, 90f);

            FileStream file = new FileStream(propiedades.Nombre, FileMode.Create, FileAccess.Write, FileShare.None);

            PdfWriter writer = PdfWriter.GetInstance(document, file);

            document.Open();

            //parrafo
            Paragraph parrafo = new Paragraph("Hola mundo");
            parrafo.AsParallel();
            document.Add(parrafo);


            PdfPTable t;
            PdfPCell c;

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("boleto.png");

            t = new PdfPTable(1);
            t.WidthPercentage = 100;

            float[] widths = new float[1];
            widths[0] = 10;
            t.SetWidths(widths);

            c = new PdfPCell(logo);
            c.Border = 0;
            c.VerticalAlignment = Element.ALIGN_TOP;
            c.HorizontalAlignment = Element.ALIGN_LEFT;
            t.AddCell(c);

            document.Add(t);
            //add text in the middle of the page
            var cb = writer.DirectContentUnder;
            var bf2 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            // over the existing content
            cb.BeginText();
            cb.SetColorFill(BaseColor.GREEN);
            cb.SetFontAndSize(bf2, 12);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "This is a watermark", 100, 100, 0);
            cb.EndText();


            document.Close();
           
        }
    }
    
    public void GenerarTextoDentroImagen()
    {
        Propiedades propiedades = new Propiedades();

        Document document = new Document(PageSize.LETTER);
        document.SetPageSize(PageSize.A4);
        document.SetMargins(200f, 200f, 200f, 200f);

        FileStream file = new FileStream(propiedades.Nombre, FileMode.Create, FileAccess.Write, FileShare.None);

        PdfWriter writer = PdfWriter.GetInstance(document, file);

        document.Open();

        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("boleto.png");
        logo.ScaleToFit(396.85f, 581.1024f);
        logo.Alignment = iTextSharp.text.Image.UNDERLYING;
        logo.SetAbsolutePosition(100, 130);
        document.Add(logo);

        Phrase frase = new Phrase("Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, BaseColor.BLACK));
        ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_LEFT, frase, 100, 100, 0);
        document.Add(frase); 

        document.Close();
    }
}

// Hola, si usas netcore 3 en adelante debes usar IWebHostEnvironment para netcore 2 usa IHostingEnvironment, aunque igualmente para ninguno de los dos debería marcarte error si has importado el espacio de nombres using Microsoft.AspNetCore.Hosting;
// https://stackoverflow.com/questions/8657857/itextsharp-text-overlapping-image
