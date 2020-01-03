using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditInfoAPI.Models
{
    public class DetailMethodResultViewModel
    {
        //Individual information

        public string Surname { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalId { get; set; }

        //Contract information

        public string RoleOfCustomer { get; set; }
        public string PhaseOfContract { get; set; }
        public float OriginalAmountValue { get; set; }
        public string OriginalAmountCurrency { get; set; }
        public float InstallmentAmountValue { get; set; }
        public string InstallmentAmountCurrency { get; set; }
        public float OverdueAmountValue { get; set; }
        public string OverdueAmountCurrency { get; set; }
        public float CurrentAmountValue { get; set; }
        public string CurrentAmountCurrency { get; set; }
        public DateTime DateOfLastPayment { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public DateTime DateAccountOpened { get; set; }
        public DateTime RealEndDate { get; set; }

        //Summary information

        public float SumOriginalAmountValue { get; set; }
        public string SumOriginalAmountCurrency { get; set; }

        public float SumInstallmentAmountValue { get; set; }
        public string SumInstallmentAmountCurrency { get; set; }

        public float MaxOverdueAmountValue { get; set; }
        public string MaxOverdueAmountCurrency { get; set; }


    }
}