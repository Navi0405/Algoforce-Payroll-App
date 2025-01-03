using System;

namespace AlgoforcePayrollSystem
{
    public class Employee
    {
        // Properties
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }
        public double OvertimeHours { get; set; } // Optional
        public double NightDifferential { get; set; } // Computed based on the logic you'll implement
        public double DeMinimis { get; set; }
        public double Loan { get; set; } // Optional
        public double SSSLoan { get; set; } // Optional
        public double PagIbigLoan { get; set; } // Optional

        // Fixed values for deductions
        private const double SSSPremium = 450;
        private const double SSSProvidentFund = 225;
        private const double PagIbig = 100;
        private const double Philhealth = 437.50;

        // Empty constructor
        public Employee() { }

        // Constructor
        public Employee(string name, double hourlyRate, double hoursWorked, double overtimeHours = 0, double loan = 0, double sssLoan = 0, double pagIbigLoan = 0)
        {
            Name = name;
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
            OvertimeHours = overtimeHours;
            Loan = loan;
            SSSLoan = sssLoan;
            PagIbigLoan = pagIbigLoan;
            DeMinimis = 0; // Initialize to 0, can be set later
        }

        // Method to calculate Gross Income
        public double CalculateGrossIncome()
        {
            double basicSalary = HourlyRate * HoursWorked;
            double overtimePay = OvertimeHours * HourlyRate * 1.5; // Assuming 1.5x rate for overtime
            double nightDifferentialPay = NightDifferential; // This would be computed separately
            double totalIncome = basicSalary + overtimePay + nightDifferentialPay + DeMinimis;
            return totalIncome;
        }

        // Method to calculate Total Deductions
        public double CalculateTotalDeductions()
        {
            double totalDeductions = 0;
            totalDeductions += SSSPremium;
            totalDeductions += SSSProvidentFund;
            totalDeductions += PagIbig;
            totalDeductions += Philhealth;

            if (Loan > 0)
            {
                totalDeductions += Loan; // Add loan deduction if exists
            }

            if (SSSLoan > 0)
            {
                totalDeductions += SSSLoan; // Add SSS loan deduction if exists
            }

            if (PagIbigLoan > 0)
            {
                totalDeductions += PagIbigLoan; // Add Pag-ibig loan deduction if exists
            }

            return totalDeductions;
        }

        // Method to calculate Net Pay
        public double CalculateNetPay()
        {
            double grossIncome = CalculateGrossIncome();
            double totalDeductions = CalculateTotalDeductions();
            return grossIncome - totalDeductions; // Calculate Net Pay
        }

        // Additional methods to calculate Night Differentials can be added here...
    }
}
