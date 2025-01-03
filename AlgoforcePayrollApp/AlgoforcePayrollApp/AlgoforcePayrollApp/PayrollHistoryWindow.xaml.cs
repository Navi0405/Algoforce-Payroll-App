using System.Collections.Generic;
using System.Windows;


namespace AlgoforcePayrollSystem
{
    public partial class PayrollHistoryWindow : Window
    {
        public PayrollHistoryWindow(Employee employee, List<PayrollRecord> payrollRecords)
        {
            InitializeComponent();

            // Set the employee name
            EmployeeNameText.Text = $"Payroll History for {employee.Name}";

            // Bind Payroll history to the ListView
            PayrollHistoryListView.ItemsSource = payrollRecords;
        }
    }

    // Define a class for Payroll Records if not already defined
    public class PayrollRecord
    {
        public string PayDate { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetPay { get; set; }
    }
}
