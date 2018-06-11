using LIMSCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIMSWebApp.ViewModels.LIMSViewModels
{
    public class RatesPaymentViewModel
    {
        public RatesPaymentViewModel()
        {

        }
        //public int ID { get; set; }
        public int Id { get; set; }

        [Display(Name = "Title Number")]
        public string ParcelNumber { get; set; }
        public double? Area { get; set; }
        public string AdministrationArea { get; set; }
        public string LandUse { get; set; }
        //public string Tenure { get; set; }
        //public string Resposibility { get; set; }
        //public string Lender { get; set; }
        //public double amount { get; set; }
        //public string ChargeLender { get; set; }
        //public string Apartment { get; set; }
        //public string RegistrationType { get; set; }
        //public string BeconNumb { get; set; }
        public DateTime DateSearched { get; set; }
        //public string SpatialUnitType { get; set; }
        //public string ValuationRemarks { get; set; }
        //public string Valuer { get; set; }
        //public string RegistrationSection { get; set; }
        //public DateTime RegistrationDate { get; set; }
        //public double MAmount { get; set; }
        //public string MorgageLender { get; set; }



        //public int RRRscount { get; set; }

        //public string Leahold { get; set; }
        //public DateTime LeasePeriod { get; set; }

        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string PIN { get; set; }
        //public string OwnershipType { get; set; }


        //payments 
        //public decimal? Amount { get; set; }
        //public string ModeOfPayment { get; set; }
        //public DateTime? PaymentDate { get; set; }
        //public int Rateid { get; set; }
        //public string ReceiptNo { get; set; }

        public IEnumerable<Payments> Payments { get; set; }
    }
}
