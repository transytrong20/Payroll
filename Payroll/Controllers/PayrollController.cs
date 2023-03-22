using Microsoft.AspNetCore.Mvc;
using Payroll.Models;

namespace Payroll.Controllers
{
    public class PayrollController : Controller
    {
        public IActionResult Index(PayrollModel model)
        {
            return View();
        }

        [HttpPost]
        public ActionResult InputIncome(PayrollModel model)
        {
            double gross = model.Income;
            double reducepersonalcircumstances = 11000000;
            double dependencydeduction = model.NumberOfDependents * 4400000;


            double SocialInsurance = model.Income * 0.08; // bảo hiểm xã hội
            if (SocialInsurance < 2384001)
            {
                SocialInsurance = model.Income * 0.08;
            }
            else
            {
                SocialInsurance = 2384000;
            }

            double HealthInsurance = model.Income * 0.015; //bảo hiểm y tế
            if (HealthInsurance < 447001)
            {
                HealthInsurance = model.Income * 0.015;
            }
            else
            {
                HealthInsurance = 447000;
            }

            double UnemploymentInsurance = model.Income * 0.01; //bảo hiểm thất nghiệp
            if (UnemploymentInsurance < 884001)
            {
                UnemploymentInsurance = model.Income * 0.01;
            }
            else
            {
                UnemploymentInsurance = 884000;
            }

            double Insurance = SocialInsurance + HealthInsurance + UnemploymentInsurance; //bảo hiểm

            double IncomeBeforeTax = model.Income - Insurance; // thu nhập trước thuế

            double IncomeTaxes = IncomeBeforeTax - 11000000 - (model.NumberOfDependents * 4400000); //thu nhập chịu thuế

            double PersonalIncomeTax = IncomeTaxes; //Thuế thu nhập cá nhân
            if (IncomeTaxes < 5000001)
            {
                PersonalIncomeTax = IncomeTaxes * 0.05;
            }
            else if (IncomeTaxes < 10000001)
            {
                PersonalIncomeTax = IncomeTaxes * 0.10 - 250000;
            }
            else if (IncomeTaxes < 18000001)
            {
                PersonalIncomeTax = IncomeTaxes * 0.15 - 250000 - 500000;
            }
            else if (IncomeTaxes < 32000001)
            {
                PersonalIncomeTax = IncomeTaxes * 0.20 - 250000 - 500000 - 1200000;
            }
            else if (IncomeTaxes < 52000001)
            {
                PersonalIncomeTax = IncomeTaxes * 0.25 - 250000 - 500000 - 1200000 - 2800000;
            }
            else if (IncomeTaxes < 80000001)
            {
                PersonalIncomeTax = IncomeTaxes * 0.30 - 250000 - 500000 - 1200000 - 2800000 - 5000000;
            }
            else
            {
                PersonalIncomeTax = IncomeTaxes * 0.30 - 250000 - 500000 - 1200000 - 2800000 - 5000000 - 8400000;
            }
            double SalaryNet = IncomeBeforeTax - PersonalIncomeTax;
            


            //Net to Gross
            double ConvertedIncome = model.Income - 11000000 - (model.NumberOfDependents * 4400000); //thu nhập quy đổi

            double IncomeBeforeTaxs = ConvertedIncome; //thu nhập chịu thuế
            if (ConvertedIncome < 4750001)
            {
                IncomeBeforeTaxs = ConvertedIncome / 0.9;
            }
            else if (ConvertedIncome < 9250001)
            {
                IncomeBeforeTaxs = (ConvertedIncome - 250000) / 0.9;
            }
            else if (ConvertedIncome < 16050001)
            {
                IncomeBeforeTaxs = (ConvertedIncome - 750000) / 0.85;
            }
            else if (ConvertedIncome < 27250001)
            {
                IncomeBeforeTaxs = (ConvertedIncome - 1650000) / 0.8;
            }
            else if (ConvertedIncome < 42250001)
            {
                IncomeBeforeTaxs = (ConvertedIncome - 3250000) / 0.75;
            }
            else if (ConvertedIncome < 61850001)
            {
                IncomeBeforeTaxs = (ConvertedIncome - 5850001) / 0.7;
            }
            else
            {
                IncomeBeforeTaxs = (ConvertedIncome - 9850000) / 0.65;
            }

            double TaxCollectedBeforeTaxs = IncomeBeforeTaxs + 11000000 + model.OnOfficialSalary*4400000; //Thu nhập trước thuế


            double SalaryGross = TaxCollectedBeforeTaxs; //Net to gosss
            if (TaxCollectedBeforeTaxs < 29800000)
            {
                SalaryGross = TaxCollectedBeforeTaxs / (100 - 8 - 1.5 - 1) * 100;
            }
            else if (TaxCollectedBeforeTaxs < 88400000)
            {
                SalaryGross =( TaxCollectedBeforeTaxs + 2384000 +447000)/0.99;
            }
            else
            {
                SalaryGross = TaxCollectedBeforeTaxs + 2384000 + 447000 + 884000;
            }


            double SocialInsuranceGross = SalaryGross * 0.08; // bảo hiểm xã hội
            if (SocialInsuranceGross < 2384001)
            {
                SocialInsuranceGross = SalaryGross * 0.08;
            }
            else
            {
                SocialInsuranceGross = 2384000;
            }

            double HealthInsuranceGross = SalaryGross * 0.015; //bảo hiểm y tế
            if (HealthInsuranceGross < 447001)
            {
                HealthInsuranceGross = SalaryGross * 0.015;
            }
            else
            {
                HealthInsuranceGross = 447000;
            }

            double UnemploymentInsuranceGross = SalaryGross * 0.01; //bảo hiểm thất nghiệp
            if (UnemploymentInsuranceGross < 884001)
            {
                UnemploymentInsuranceGross = SalaryGross * 0.01;
            }
            else
            {
                UnemploymentInsuranceGross = 884000;
            }

            double personalincometaxs = IncomeBeforeTaxs;
            if (IncomeBeforeTaxs < 5000001)
            {
                personalincometaxs = IncomeBeforeTaxs * 0.05;
            }
            else if (IncomeBeforeTaxs < 10000001)
            {
                personalincometaxs = IncomeBeforeTaxs * 0.10 - 250000;
            }
            else if (IncomeBeforeTaxs < 18000001)
            {
                personalincometaxs = IncomeBeforeTaxs * 0.15 - 250000 - 500000;
            }
            else if (IncomeBeforeTaxs < 32000001)
            {
                personalincometaxs = IncomeBeforeTaxs * 0.20 - 250000 - 500000 - 1200000;
            }
            else if (IncomeBeforeTaxs < 52000001)
            {
                personalincometaxs = IncomeBeforeTaxs * 0.25 - 250000 - 500000 - 1200000 - 2800000;
            }
            else if (IncomeBeforeTaxs < 80000001)
            {
                personalincometaxs = IncomeBeforeTaxs * 0.30 - 250000 - 500000 - 1200000 - 2800000 - 5000000;
            }
            else
            {
                personalincometaxs = IncomeBeforeTaxs * 0.30 - 250000 - 500000 - 1200000 - 2800000 - 5000000 - 8400000;
            }




            // view gross to net
            ViewBag.SalaryNet = SalaryNet;
            ViewBag.SocialInsurance = SocialInsurance;
            ViewBag.HealthInsurance = HealthInsurance;
            ViewBag.UnemploymentInsurance = UnemploymentInsurance;
            ViewBag.IncomeBeforeTax = IncomeBeforeTax;
            ViewBag.reducepersonalcircumstances = reducepersonalcircumstances;
            ViewBag.dependencydeduction = dependencydeduction;
            ViewBag.IncomeTaxes = IncomeTaxes;
            ViewBag.PersonalIncomeTax = PersonalIncomeTax;
            ViewBag.gross = gross;



            //view net to gross
            ViewBag.SalaryGross = SalaryGross;
            ViewBag.SocialInsuranceGross = SocialInsuranceGross;
            ViewBag.HealthInsuranceGross = HealthInsuranceGross;
            ViewBag.UnemploymentInsuranceGross = UnemploymentInsuranceGross;
            ViewBag.TaxCollectedBeforeTaxs = TaxCollectedBeforeTaxs;
            ViewBag.IncomeBeforeTaxs = IncomeBeforeTaxs;
            ViewBag.personalincometaxs = personalincometaxs;
            



            return View("Index");
        }
    }
}
