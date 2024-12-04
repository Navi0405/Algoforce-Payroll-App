using System;
using System.Collections.Generic;
using System.IO;

namespace AlgoforcePayrollSystem.Data
{
    public class CsvHandler
    {
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "algoforcePayrollData.csv");

        public CsvHandler()
        {
            // Ensure the directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? AppDomain.CurrentDomain.BaseDirectory);

            // Ensure the file has a header row
            if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("EmployeeId,Name,HourlyRate,HoursWorked,OvertimeHours,Loan,SSSLoan,PagIbigLoan,DeMinimis");
                }
            }
        }


        /// <summary>
        /// Add a single employee to the CSV file.
        /// </summary>
        public void AddEmployee(Employee employee)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{employee.EmployeeId},{employee.Name},{employee.HourlyRate},{employee.HoursWorked},{employee.OvertimeHours},{employee.Loan},{employee.SSSLoan},{employee.PagIbigLoan},{employee.DeMinimis}");
            }
        }

        /// <summary>
        /// Save a list of employees, overwriting the existing CSV file.
        /// </summary>
        public void SaveEmployees(List<Employee> employees)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                // Write the header row
                writer.WriteLine("EmployeeId,Name,HourlyRate,HoursWorked,OvertimeHours,Loan,SSSLoan,PagIbigLoan,DeMinimis");

                // Write each employee's data
                foreach (var employee in employees)
                {
                    writer.WriteLine($"{employee.EmployeeId},{employee.Name},{employee.HourlyRate},{employee.HoursWorked},{employee.OvertimeHours},{employee.Loan},{employee.SSSLoan},{employee.PagIbigLoan},{employee.DeMinimis}");
                }
            }
        }

        /// <summary>
        /// Load all employees from the CSV file.
        /// </summary>
        public List<Employee> LoadEmployees()
        {
            var employees = new List<Employee>();

            if (!File.Exists(filePath))
                return employees;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line; // Use nullable string (string?) to handle potential null value
                bool isFirstLine = true;

                while ((line = reader.ReadLine()) != null) // Ensure null is handled correctly
                {
                    // Skip the header row
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }

                    try
                    {
                        var data = line.Split(',');

                        var employee = new Employee
                        {
                            EmployeeId = int.Parse(data[0]),
                            Name = data[1],
                            HourlyRate = double.Parse(data[2]),
                            HoursWorked = double.Parse(data[3]),
                            OvertimeHours = double.Parse(data[4]),
                            Loan = double.Parse(data[5]),
                            SSSLoan = double.Parse(data[6]),
                            PagIbigLoan = double.Parse(data[7]),
                            DeMinimis = double.Parse(data[8])
                        };

                        employees.Add(employee);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing line: {line}. Exception: {ex.Message}");
                        // Optionally log or skip malformed lines
                    }
                }
            }

            return employees;
        }

    }
}
