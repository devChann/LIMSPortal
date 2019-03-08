using iTextSharp.text;
using iTextSharp.text.pdf;

namespace LIMS.Infrastructure.Services.Printing
{
    
    
    public class PdfFooter: PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document document)
        {
               
            base.OnEndPage(writer, document);
            var tabFot = new PdfPTable(new float[] { 1F });
            PdfPCell cell;
            tabFot.TotalWidth = 300F;
            //var logo = iTextSharp.text.Image.GetInstance(path);
            //logo.Alignment = Element.ALIGN_CENTER;
            //logo.ScaleAbsoluteHeight(70);
            //logo.ScaleAbsoluteWidth(70);
            //doc.Add(logo);
            cell = new PdfPCell(new Phrase("Land Information Management System | Official Search Certificate"));
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 150, document.Bottom, writer.DirectContent);
        }
        





    }

}
