using System.Windows;
using AlgoforcePayrollSystem;
using AlgoforcePayrollSystem.Views; // Namespace for AddEmployeeWindow, PayrollWindow
using System.Collections.Generic;
using AlgoforcePayrollApp;
using AlgoforcePayrollSystem.Data;

namespace AlgoforcePayrollSystem
{
    public partial class MainWindow : Window
    {
        private List<Employee> _employees = new List<Employee>(); // List to store loaded employees

        public MainWindow()
        {
            InitializeComponent();
            LoadEmployeesFromCsv(); // Load employees on window startup
        }

        // Load employee data from CSV for the Dashboard and Employees tab
        private void LoadEmployeesFromCsv()
        {
            CsvHandler csvHandler = new CsvHandler();
            _employees = csvHandler.LoadEmployees(); // Load employees from CSV

            // Bind employee data to both Dashboard and Employees tab ListViews
            DashboardEmployeeListView.ItemsSource = _employees;
            EmployeesTabEmployeeListView.ItemsSource = _employees;
        }

        // Dashboard Button Click
        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 0; // Switch to the Dashboard tab
        }

        // Employees Button Click
        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 1; // Switch to the Employees tab
        }

        // Payroll Button Click
        private void PayrollButton_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 2; // Switch to the Payroll tab
        }

        // Add Employee Button Click
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.ShowDialog();

            // Assuming AddEmployeeWindow has a public property to get the new Employee object
            if (addEmployeeWindow.NewEmployee != null) // Assuming NewEmployee is the new Employee instance
            {
                // Add newEmployee to the list and CSV
                Employee newEmployee = addEmployeeWindow.NewEmployee;
                _employees.Add(newEmployee); // Add to the list
                DashboardEmployeeListView.Items.Refresh(); // Refresh Dashboard ListView
                EmployeesTabEmployeeListView.Items.Refresh(); // Refresh Employees ListView

                CsvHandler csvHandler = new CsvHandler();
                csvHandler.AddEmployee(newEmployee); // Save to CSV
            }
        }

        // Generate Payroll Button Click
        private void GeneratePayroll_Click(object sender, RoutedEventArgs e)
        {
            PayrollWindow payrollWindow = new PayrollWindow();
            payrollWindow.ShowDialog();
        }

        private void DashboardEmployeeListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Get the selected employee
            var selectedEmployee = DashboardEmployeeListView.SelectedItem as Employee;

            if (selectedEmployee != null)
            {
                // Fetch payroll history for the selected employee
                CsvHandler csvHandler = new CsvHandler();
                var payrollHistory = csvHandler.GetPayrollHistoryForEmployee(selectedEmployee.Name);

                // Open the PayrollHistoryWindow
                PayrollHistoryWindow payrollHistoryWindow = new PayrollHistoryWindow(selectedEmployee, payrollHistory);
                payrollHistoryWindow.ShowDialog();
            }
        }

        private void EmployeesTabEmployeeListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Get the selected employee
            var selectedEmployee = EmployeesTabEmployeeListView.SelectedItem as Employee;

            if (selectedEmployee != null)
            {
                // Open an employee detail window
                EmployeeDetailsWindow employeeDetailsWindow = new EmployeeDetailsWindow(selectedEmployee);
                employeeDetailsWindow.ShowDialog();
            }

        }
    }

}
