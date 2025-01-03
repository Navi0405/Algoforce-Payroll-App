using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using AlgoforcePayrollSystem;
using AlgoforcePayrollSystem.Data;

namespace AlgoforcePayrollSystem.Views
{
    public partial class PayrollWindow : Window
    {
        private readonly CsvHandler _csvHandler = new CsvHandler(); // Use CsvHandler for managing CSV operations
        private List<Employee> _employees = new List<Employee>();

        public PayrollWindow()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            // Load employees from the CSV file
            _employees = _csvHandler.LoadEmployees();

            if (_employees.Count == 0)
            {
                MessageBox.Show("No employees found. Add new employees to start.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            EmployeeList.ItemsSource = _employees;
        }

        private void EmployeeList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedEmployee = EmployeeList.SelectedItem as Employee;
            if (selectedEmployee != null)
            {
                EmployeeName.Text = selectedEmployee.Name;
                HourlyRateInput.Text = selectedEmployee.HourlyRate.ToString();
                HoursWorkedInput.Text = selectedEmployee.HoursWorked.ToString();
                OvertimeHoursInput.Text = selectedEmployee.OvertimeHours.ToString();
                NightDifferentialInput.Text = selectedEmployee.NightDifferential.ToString();
                DeMinimisInput.Text = selectedEmployee.DeMinimis.ToString();
                LoanInput.Text = selectedEmployee.Loan.ToString();
                SSSLoanInput.Text = selectedEmployee.SSSLoan.ToString();
                PagIbigLoanInput.Text = selectedEmployee.PagIbigLoan.ToString();
            }
        }

        private void CalculatePayrollButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeList.SelectedItem is Employee selectedEmployee)
            {
                // Update employee details
                selectedEmployee.HourlyRate = double.Parse(HourlyRateInput.Text);
                selectedEmployee.HoursWorked = double.Parse(HoursWorkedInput.Text);
                selectedEmployee.OvertimeHours = double.Parse(OvertimeHoursInput.Text);
                selectedEmployee.NightDifferential = double.Parse(NightDifferentialInput.Text);
                selectedEmployee.DeMinimis = double.Parse(DeMinimisInput.Text);
                selectedEmployee.Loan = double.Parse(LoanInput.Text);
                selectedEmployee.SSSLoan = double.Parse(SSSLoanInput.Text);
                selectedEmployee.PagIbigLoan = double.Parse(PagIbigLoanInput.Text);

                // Calculate Net Pay
                double netPay = selectedEmployee.CalculateNetPay();
                NetPayOutput.Text = netPay.ToString("C");
            }
        }

        private void SavePayrollButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeList.SelectedItem is Employee selectedEmployee)
            {
                // Update the CSV with modified employee data
                _csvHandler.AddEmployee(selectedEmployee);
                MessageBox.Show("Payroll saved successfully to CSV file!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select an employee to save payroll.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create a new employee from input fields
                var newEmployee = new Employee
                {
                    EmployeeId = _employees.Count + 1, // Auto-generate an ID
                    Name = EmployeeName.Text,
                    HourlyRate = double.Parse(HourlyRateInput.Text),
                    HoursWorked = double.Parse(HoursWorkedInput.Text),
                    OvertimeHours = double.Parse(OvertimeHoursInput.Text),
                    NightDifferential = double.Parse(NightDifferentialInput.Text),
                    DeMinimis = double.Parse(DeMinimisInput.Text),
                    Loan = double.Parse(LoanInput.Text),
                    SSSLoan = double.Parse(SSSLoanInput.Text),
                    PagIbigLoan = double.Parse(PagIbigLoanInput.Text)
                };

                // Add the employee to the CSV and refresh the list
                _csvHandler.AddEmployee(newEmployee);
                _employees.Add(newEmployee);
                EmployeeList.ItemsSource = null;
                EmployeeList.ItemsSource = _employees;

                MessageBox.Show("New employee added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
