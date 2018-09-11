using iTextSharp.text;
using iTextSharp.text.pdf;
using LIMSInfrastructure.Data;
using LIMSInfrastructure.Services.Printing;
using LIMSWebApp.ViewModels.LIMSViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIMSWebApp.Helpers
{
    public class DocPrinter:Controller
    {
        private LIMSCoreDbContext _context;
        private IHostingEnvironment _hostingEnvironment;

        public DocPrinter(LIMSCoreDbContext ctx, IHostingEnvironment hostingEnvironment)
        {
            _context = ctx;
            _hostingEnvironment = hostingEnvironment;
        }
        public FileResult CreatePdf(string parcelnum)
        {
            var parcelviewmodel = new ParcelSearchViewModel(); // instance variable
            var parcel = _context.Parcel
                .Include(i => i.Administration)
                .Include(i => i.LandUse)
                .Include(i => i.RestrictionsNavigation)
                    .ThenInclude(sa => sa.Chrage)
                .Include(i => i.RestrictionsNavigation.Morgage)

                .Include(i => i.SpatialUnit)
                .Include(i => i.Tenure)
                .Include(i => i.Valuation)
                .Include(i => i.Owner)
                .Where(a => a.ParcelNum == parcelnum).SingleOrDefault();


            parcelviewmodel.ParcelNumber = parcel.ParcelNum;
            parcelviewmodel.Area = parcel.Area;
            parcelviewmodel.AdministrationArea = parcel.Administration.DistrictName;
            parcelviewmodel.landUse = parcel.LandUse.LandUseType;
            parcelviewmodel.Tenure = parcel.Tenure.TenureType;

            parcelviewmodel.Name = parcel.Owner.Name;
            parcelviewmodel.Phone = parcel.Owner.TelephoneAddress;
            parcelviewmodel.Adress = parcel.Owner.PostalAddress;
            parcelviewmodel.DateSearched = DateTime.Now;
            parcelviewmodel.PIN = parcel.Owner.PIN;
            parcelviewmodel.amount = parcel.RestrictionsNavigation.Chrage.Amount;
            parcelviewmodel.MAmount = parcel.RestrictionsNavigation.Morgage.Amount;
            parcelviewmodel.Lender = parcel.RestrictionsNavigation.Chrage.Lender;
            parcelviewmodel.MorgageLender = parcel.RestrictionsNavigation.Morgage.Lender;

            Random generator = new Random();
            string r = generator.Next(0, 1000000).ToString("D6");



            //TempData["ModelName"] = parcelviewmodel;

            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            DateTime DateTimedTime = DateTime.Now;

            string strPDFFileName = string.Format("LIMS Search Certificate" + DateTimedTime.ToString("yyyyMMdd") + "-" + ".pdf");
            Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

            // pull data returned by search parcel action

            //file will created in this path  
            string strAttachment = Path.Combine(_hostingEnvironment.WebRootPath, "~/Downloads/" + strPDFFileName);
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "images/logos/kenyalogo.png");
            var footer = Path.Combine(_hostingEnvironment.WebRootPath, "images/logos/oakarlogo.png");
            string datetime = string.Format("{0:MM/dd/yy H:mm:ss}", parcelviewmodel.DateSearched);
            PdfWriter.GetInstance(doc, workStream).CloseStream = false;

            PdfFooter m = new PdfFooter();

            doc.Open();

            var logo = Image.GetInstance(path);
            logo.Alignment = Element.ALIGN_CENTER;
            logo.ScaleAbsoluteHeight(70);
            logo.ScaleAbsoluteWidth(70);
            doc.Add(logo);

            var footerlogo = Image.GetInstance(footer);
            footerlogo.Alignment = Element.ALIGN_CENTER;
            footerlogo.ScaleAbsoluteHeight(20);
            footerlogo.ScaleAbsoluteWidth(70);

            footerlogo.SetAbsolutePosition(doc.PageSize.Width - 36f - 72f, doc.PageSize.Height - 800.6f);
            doc.Add(footerlogo);


            Paragraph headingone = new Paragraph("REPUBLIC OF KENYA", new Font(Font.HELVETICA, 12f, Font.BOLD))
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 5f
            };
            doc.Add(headingone);

            Paragraph headingtwo = new Paragraph("THE REGISTERED LAND ACT", new Font(Font.HELVETICA, 12f, Font.BOLD))
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 5f
            };
            doc.Add(headingtwo);

            Paragraph headingthree = new Paragraph("(Cap 300)", new Font(Font.HELVETICA, 9f, Font.BOLD))
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 5f
            };
            doc.Add(headingthree);

            Paragraph headingfour = new Paragraph("CERTIFICATE OF OFFICIAL SEARCH", new Font(Font.HELVETICA, 12f, Font.BOLD))
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            };
            doc.Add(headingfour);

            Paragraph headingPARTA = new Paragraph("PART A: PARCEL INFORMATION", new Font(Font.HELVETICA, 11f))
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            };
            doc.Add(headingPARTA);


            /// add elements 


            PdfPTable table1 = new PdfPTable(5);

            Paragraph Title = new Paragraph("Title Number:", new Font(Font.HELVETICA, 10f))
            {
                Alignment = Element.ALIGN_LEFT
            };



            Paragraph SearchNumber = new Paragraph("Search Number:", new Font(Font.HELVETICA, 10f))
            {
                Alignment = Element.ALIGN_LEFT
            };


            Paragraph DATEOFSEARCH = new Paragraph("Date Of Search:", new Font(Font.HELVETICA, 10f))
            {
                Alignment = Element.ALIGN_LEFT
            };



            // Add elements in the section
            table1.AddCell(Title);
            table1.AddCell(parcelviewmodel.ParcelNumber);// title number
            table1.AddCell("");
            table1.AddCell(SearchNumber);
            table1.AddCell(r);// search number

            PdfPCell PDST = new PdfPCell(new Phrase("Date Of Search:"))
            {
                Colspan = 1,
                HorizontalAlignment = 0
            };
            table1.AddCell(PDST);

            PdfPCell PDSV = new PdfPCell(new Phrase(datetime))
            {
                Colspan = 4,
                BorderColorLeft = new BaseColor(255, 255, 255),

                HorizontalAlignment = 0
            }; // date of search 
            table1.AddCell(PDSV);

            PdfPCell NOT = new PdfPCell(new Phrase("Nature Of Title: "))
            {
                Colspan = 2,
                HorizontalAlignment = 0
            };
            table1.AddCell(NOT);

            PdfPCell NOTvalue = new PdfPCell(new Phrase("Absolute"))
            {
                Colspan = 3,
                HorizontalAlignment = 0
            };
            table1.AddCell(NOTvalue);

            PdfPCell AAT = new PdfPCell(new Phrase("Approximate Area:"))
            {
                Colspan = 3,
                HorizontalAlignment = 0
            };
            table1.AddCell(AAT);

            PdfPCell AAV = new PdfPCell(new Phrase(Convert.ToDecimal(parcelviewmodel.Area).ToString()))
            {
                Colspan = 2,
                HorizontalAlignment = 0
            };
            table1.AddCell(AAV);

            PdfPCell Tenure = new PdfPCell(new Phrase("Tenure Type:"))
            {
                Colspan = 1,
                HorizontalAlignment = 0
            };
            table1.AddCell(Tenure);

            PdfPCell TenureType = new PdfPCell(new Phrase(parcelviewmodel.Tenure))
            {
                Colspan = 4,
                HorizontalAlignment = 0
            };
            table1.AddCell(TenureType);
            doc.Add(table1);

            PdfPTable table2 = new PdfPTable(5);
            Paragraph headingPARTB = new Paragraph("PART B: PROPRIETORSHIP SECTION", new Font(Font.HELVETICA, 11f))
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            };
            doc.Add(headingPARTB);

            PdfPCell Name = new PdfPCell(new Paragraph("NAME:", new Font(Font.HELVETICA, 10f)))
            {
                Colspan = 1,
                HorizontalAlignment = 0
            };
            table2.AddCell(Name);

            PdfPCell NameValue = new PdfPCell(new Phrase(parcelviewmodel.Name))
            {
                Colspan = 2,
                HorizontalAlignment = 0
            };
            table2.AddCell(NameValue);

            PdfPCell PIN = new PdfPCell(new Paragraph("PIN: ", new Font(Font.HELVETICA, 10f)))
            {
                Colspan = 1,
                HorizontalAlignment = 0
            };
            table2.AddCell(PIN);

            PdfPCell PINVALUE = new PdfPCell(new Phrase(parcelviewmodel.PIN))
            {
                Colspan = 2,
                BorderColorLeft = new BaseColor(255, 255, 255),
                HorizontalAlignment = 0
            };

            table2.AddCell(PINVALUE);


            PdfPCell PADRESS = new PdfPCell(new Paragraph("Postal Address:", new Font(Font.HELVETICA, 10f)))
            {
                Colspan = 1,
                HorizontalAlignment = 0
            };
            table2.AddCell(PADRESS);

            PdfPCell POA = new PdfPCell(new Phrase(parcelviewmodel.Adress))
            {
                Colspan = 4,
                HorizontalAlignment = 0
            };
            table2.AddCell(POA);

            PdfPCell PHONE = new PdfPCell(new Paragraph("Phone Number:", new Font(Font.HELVETICA, 10f)))
            {
                Colspan = 1,
                HorizontalAlignment = 0
            };
            table2.AddCell(PHONE);

            PdfPCell PhoneValue = new PdfPCell(new Phrase(parcelviewmodel.Phone))
            {
                Colspan = 4,
                HorizontalAlignment = 0
            };
            table2.AddCell(PhoneValue);


            doc.Add(table2);



            Paragraph headingPARTC = new Paragraph("PART C: ENCUMBRANCE (Charges,Lease e.t.c)", new Font(Font.HELVETICA, 11f))
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            };
            doc.Add(headingPARTC);

            PdfPTable table3 = new PdfPTable(2);
            PdfPCell Charges = new PdfPCell(new Paragraph("Charges", new Font(Font.HELVETICA, 10f)))
            {
                Colspan = 2,
                HorizontalAlignment = 1
            };
            table3.AddCell(Charges);

            PdfPCell chargetitle = new PdfPCell(new Phrase("Amount"))
            {
                Colspan = 1,
                HorizontalAlignment = 0
            };
            table3.AddCell(chargetitle);

            PdfPCell LenderTitle = new PdfPCell(new Phrase("Lender"))
            {
                Colspan = 1,
                HorizontalAlignment = 0
            };
            table3.AddCell(LenderTitle);

            PdfPCell AmountValue = new PdfPCell(new Phrase(Convert.ToDecimal(parcelviewmodel.amount).ToString("Ksh. ")))
            {
                Colspan = 1,
                HorizontalAlignment = 0
            };
            table3.AddCell(AmountValue);

            PdfPCell lendervalue = new PdfPCell(new Phrase(parcelviewmodel.Lender))
            {
                Colspan = 1,
                HorizontalAlignment = 0
            };
            table3.AddCell(lendervalue);
            doc.Add(table3);

            // morgage 

            PdfPTable table4 = new PdfPTable(2);
            PdfPCell Morgage = new PdfPCell(new Paragraph("Morgage", new Font(Font.HELVETICA, 10f)))
            {
                Colspan = 2,
                HorizontalAlignment = 1
            };
            table4.AddCell(Morgage);

            PdfPCell Mtitle = new PdfPCell(new Phrase("Amount"))
            {
                Colspan = 1,
                HorizontalAlignment = 0
            };
            table4.AddCell(Mtitle);

            PdfPCell MLenderTitle = new PdfPCell(new Phrase("Lender"))
            {
                Colspan = 1,
                HorizontalAlignment = 0
            };
            table4.AddCell(MLenderTitle);

            PdfPCell MAmountValue = new PdfPCell(new Phrase(Convert.ToDecimal(parcelviewmodel.MAmount).ToString("Ksh. ")))
            {
                Colspan = 1,
                HorizontalAlignment = 0
            };
            table4.AddCell(MAmountValue);

            PdfPCell Mlendervalue = new PdfPCell(new Phrase(parcelviewmodel.MorgageLender))
            {
                Colspan = 1,
                HorizontalAlignment = 0
            };
            table4.AddCell(Mlendervalue);
            doc.Add(table4);




            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;


            return File(workStream, "application/pdf", strPDFFileName);

        }
    }
}
