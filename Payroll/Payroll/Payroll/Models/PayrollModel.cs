namespace Payroll.Models
{
    public class PayrollModel
    {
        public double Income { get; set; }
        public double OnOfficialSalary { get; set; }
        public double Other { get; set; }
        public int Region { get; set; }
        public int NumberOfDependents { get; set; }
    }
}
