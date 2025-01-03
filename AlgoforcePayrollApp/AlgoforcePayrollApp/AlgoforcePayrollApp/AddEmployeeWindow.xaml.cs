using System;
using System.Windows;
using AlgoforcePayrollSystem;

namespace AlgoforcePayrollApp
{
    public partial class AddEmployeeWindow : Window
    {
        public Employee NewEmployee { get; private set; } = new Employee();

        public AddEmployeeWindow()
        {
            InitializeComponent();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            // Validate and assign user input
            if (double.TryParse(HourlyRateTextBox.Text, out double hourlyRate) &&
                double.TryParse(HoursWorkedTextBox.Text, out double hoursWorked) &&
                double.TryParse(OvertimeHoursTextBox.Text, out double overtimeHours) &&
                double.TryParse(LoanTextBox.Text, out double loan) &&
                double.TryParse(SSSLoanTextBox.Text, out double sssLoan) &&
                double.TryParse(PagIbigLoanTextBox.Text, out double pagIbigLoan) &&
                double.TryParse(DeMinimisTextBox.Text, out double deMinimis))
            {
                // Create a new employee instance with input data
                NewEmployee = new Employee
                {
                    Name = NameTextBox.Text,
                    HourlyRate = hourlyRate,
                    HoursWorked = hoursWorked,
                    OvertimeHours = overtimeHours,
                    Loan = loan,
                    SSSLoan = sssLoan,
                    PagIbigLoan = pagIbigLoan,
                    DeMinimis = deMinimis,
                    NightDifferential = 0 // Leave it as 0 for now; it will be calculated separately
                };

                // Close the window with success status
                DialogResult = true;
            }
            else
            {
                // Show an error message if input is invalid
                MessageBox.Show("Please enter valid numbers for all fields.", "Input Error");
            }
        }

        private void NameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Optional: Add validation for the Name field (e.g., no empty names)
        }
    }
}
