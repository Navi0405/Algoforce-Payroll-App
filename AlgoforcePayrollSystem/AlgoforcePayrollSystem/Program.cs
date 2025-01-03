using System;
using System.Collections.Generic;
using AlgoforcePayrollSystem.Data; // Import the namespace for CsvHandler

namespace AlgoforcePayrollSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Payroll System!");

            // Instantiate CsvHandler to manage CSV operations
            CsvHandler csvHandler = new CsvHandler();

            // Load existing employees from CSV
            List<Employee> employees = csvHandler.LoadEmployees();

            Console.WriteLine("\nExisting Employees in the System:");
            if (employees.Count > 0)
            {
                foreach (var emp in employees)
                {
                    Console.WriteLine($"{emp.Name} - Hourly Rate: {emp.HourlyRate}, Hours Worked: {emp.HoursWorked}, Overtime Hours: {emp.OvertimeHours}");
                }
            }
            else
            {
                Console.WriteLine("No employees found.");
            }

            // Add new employees based on user input
            Console.Write("\nHow many new employees do you want to add? ");
            int numEmployees = int.Parse(Console.ReadLine());

            for (int i = 0; i < numEmployees; i++)
            {
                Console.WriteLine($"\nEnter details for Employee {i + 1}:");

                Console.Write("Name: ");
                string name = Console.ReadLine();

                double hourlyRate = GetValidatedDouble("Hourly Rate: ");
                double hoursWorked = GetValidatedDouble("Hours Worked: ");
                double overtimeHours = GetValidatedDouble("Overtime Hours (if any): ");

                double loan = GetOptionalLoan("Loan Amount (if any): ");
                double sssLoan = GetOptionalLoan("SSS Loan Amount (if any): ");
                double pagIbigLoan = GetOptionalLoan("Pag-Ibig Loan Amount (if any): ");

                Employee employee = new Employee
                {
                    EmployeeId = employees.Count + 1, // Assign a unique ID
                    Name = name,
                    HourlyRate = hourlyRate,
                    HoursWorked = hoursWorked,
                    OvertimeHours = overtimeHours,
                    Loan = loan,
                    SSSLoan = sssLoan,
                    PagIbigLoan = pagIbigLoan,
                    DeMinimis = 200 // You can set a default or input-based value
                };

                employees.Add(employee);
                csvHandler.AddEmployee(employee); // Save to CSV
            }

            // Calculate and display pay for each employee
            Console.WriteLine("\nPayroll Summary:");
            double totalPayroll = 0;

            foreach (var employee in employees)
            {
                double netPay = employee.CalculateNetPay();
                Console.WriteLine($"{employee.Name}: Net Pay: ${netPay}");
                totalPayroll += netPay;
            }

            Console.WriteLine($"Total Payroll: ${totalPayroll}");
        }

        // Method for getting valid input
        static double GetValidatedDouble(string prompt)
        {
            double value;
            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out value) || value < 0)
            {
                Console.Write("Please enter a valid positive number: ");
            }
            return value;
        }

        // Method to get optional loan input
        static double GetOptionalLoan(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return double.TryParse(input, out double loan) ? loan : 0; // Returns 0 if input is not a valid number
        }
    }
}
