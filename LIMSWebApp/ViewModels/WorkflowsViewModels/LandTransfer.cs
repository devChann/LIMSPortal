using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIMSCore.ViewModels.WorkflowsViewModels
{
    public class LandTransfer
    {
        public int Id { get; set; }

        [Display(Name ="First Name"),Required,MaxLength(5)]
        public string FirstName { get; set; }
        [Display(Name = "Surname")]
        public string SecondName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Telephone")]
        public string PhoneNumber { get; set; }
        public string ApplicationLetter { get; set; }
        public string TransferAgreement { get; set; }
        public string LandTitle { get; set; }
        public string RatesCertificate { get; set; }
       
    }
}
